using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;
using Rentaly.DataAccess;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Rentaly.API.Core;

public class JwtTokenCreator
{
    private readonly RentalyDbContext _context;
    private readonly JwtSettings _settings;
    private readonly ITokenStorage _storage;

    public JwtTokenCreator(RentalyDbContext context, JwtSettings settings, ITokenStorage storage)
    {
        _context = context;
        _settings = settings;
        _storage = storage;
    }

    public string Create(string email, string password)
    {
        var user = _context.Users.Include(x => x.Role)
                                 .ThenInclude(x => x.RoleUseCases)
                                 .Select(x => new {
                                     x.FirstName, 
                                     x.UserName, 
                                     x.LastName, 
                                     x.Email, 
                                     x.Password,
                                     x.Id,
                                     RoleName = x.Role.Name,
                                     UseCasesIds = x.Role.RoleUseCases.Select(x => x.UseCaseId)})
                                 .FirstOrDefault(x => x.Email == email);


        if (user == null)
        {
            throw new UnauthorizedAccessException();
        }

        var valid = BCrypt.Net.BCrypt.Verify(password, user.Password);

        if (!valid)
        {
            throw new UnauthorizedAccessException();
        }

        Guid tokenGuid = Guid.NewGuid();

        string tokenId = tokenGuid.ToString();

        var useCaseIds = _context.RoleUseCases.Include(x => x.Role).Where(x => x.Role.Users.Any(u => u.Id == user.Id)).Select(x => x.UseCaseId);

        var claims = new List<Claim> 
            {
                new Claim(JwtRegisteredClaimNames.Jti, tokenId, ClaimValueTypes.String),
                new Claim(JwtRegisteredClaimNames.Iss, _settings.Issuer, ClaimValueTypes.String),
                new Claim(JwtRegisteredClaimNames.Iat, DateTimeOffset.UtcNow.ToUnixTimeSeconds().ToString(), ClaimValueTypes.Integer64, _settings.Issuer),
                new Claim("UserId", user.Id.ToString(), ClaimValueTypes.String, _settings.Issuer),
                new Claim("UseCases", JsonConvert.SerializeObject(user.UseCasesIds)),
                new Claim("Email", user.Email),
                new Claim("Role", user.RoleName),
                new Claim("Username", user.UserName),
                new Claim("FirstName", user.FirstName),
                new Claim("LastName", user.LastName),
            };

        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_settings.SecretKey));

        var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

        var now = DateTime.UtcNow;

        var token = new JwtSecurityToken(
            issuer: _settings.Issuer,
            audience: "Any",
            claims: claims,
            notBefore: now,
            expires: now.AddMinutes(_settings.Seconds),
            signingCredentials: credentials);

        _storage.Add(tokenGuid);

        return new JwtSecurityTokenHandler().WriteToken(token);
    }
}
