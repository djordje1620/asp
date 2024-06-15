using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Rentaly.API.Core;
using Rentaly.API.Extensions;
using Rentaly.Application;
using Rentaly.DataAccess;
using Rentaly.Implementation;
using Rentaly.Implementation.Mappings;
using System.Reflection;
using System.Text;


var builder = WebApplication.CreateBuilder(args);

var configuration = builder.Configuration;
var connString = configuration["Database"];

var jwtSettings = new JwtSettings();
configuration.GetSection("JwtSettings").Bind(jwtSettings);

builder.Services.AddSingleton(jwtSettings);
builder.Services.AddSingleton(configuration);

builder.Services.AddDbContext<RentalyDbContext>(options => options.UseSqlServer(connString));
builder.Services.AddTransient<JwtTokenCreator>();

builder.Services.AddHttpContextAccessor();
builder.Services.AddCommands();
builder.Services.AddValidators();
builder.Services.AddQueries();
builder.Services.AddLoggers();

builder.Services.AddTransient<ITokenStorage, InMemoryTokenStorage>();
builder.Services.AddTransient<IApplicationActorProvider>(x =>
{
    var accessor = x.GetService<IHttpContextAccessor>();

    var request = accessor.HttpContext.Request;

    var authHeader = request.Headers.Authorization.ToString();

    var context = x.GetService<RentalyDbContext>();

    return new JwtApplicationActorProvider(authHeader);
});
builder.Services.AddTransient<IApplicationActor>(x =>
{
    var accessor = x.GetService<IHttpContextAccessor>();
    if (accessor.HttpContext == null)
    {
        return new UnauthorizedActor();
    }

    return x.GetService<IApplicationActorProvider>().GetActor();
});


builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new OpenApiInfo
    {
        Version = "v1",
        Title = "Rentaly API",
        Description = "An ASP.NET Core Web API for managing rent a car system",
    });

    var xmlFilename = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    options.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, xmlFilename));
});

builder.Services.AddTransient<UseCaseHandler>();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddAutoMapper(conf =>
{
    conf.AddProfile<CarProfile>();
    conf.AddProfile<ModelProfile>();
    conf.AddProfile<BrandProfile>();
    conf.AddProfile<BookingProfile>();
    conf.AddProfile<AuditLogProfile>();
    conf.AddProfile<ReviewProfile>();
    conf.AddProfile<UserProfile>();
});

builder.Services.AddAuthentication(options =>
{
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultSignInScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(cfg =>
{
    cfg.RequireHttpsMetadata = false;
    cfg.SaveToken = true;
    cfg.TokenValidationParameters = new TokenValidationParameters
    {
        ValidIssuer = jwtSettings.Issuer,
        ValidateIssuer = true,
        ValidAudience = "Any",
        ValidateAudience = true,
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtSettings.SecretKey)),
        ValidateIssuerSigningKey = true,
        ValidateLifetime = true,
        ClockSkew = TimeSpan.Zero
    };
    cfg.Events = new JwtBearerEvents
    {
        OnTokenValidated = context =>
        {

            Guid tokenId = context.HttpContext.Request.GetTokenId().Value;

            var storage = builder.Services.BuildServiceProvider().GetService<ITokenStorage>();

            if (!storage.Exists(tokenId))
            {
                context.Fail("Invalid token");
            }

            return Task.CompletedTask;
        }
    };
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
    app.UseSwagger();
    app.UseSwaggerUI();
    app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Rentaly.API v1"));
}


app.UseMiddleware<GlobalExceptionHandler>();
app.UseAuthorization();

app.UseStaticFiles();

app.MapControllers();

app.Run();
