using AutoMapper;

namespace Rentaly.Implementation.Mappings;
public class PasswordConverter : IValueConverter<string, string>
{
    public string Convert(string sourceMember, ResolutionContext context)
    {
        return BCrypt.Net.BCrypt.HashPassword(sourceMember);
    }
}
