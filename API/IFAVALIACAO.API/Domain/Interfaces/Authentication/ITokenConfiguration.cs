namespace IFAVALIACAO.API.Domain.Interfaces.Authentication
{
    public interface ITokenConfiguration
    {
        string Audience { get; }
        string Issuer { get; }
        int Days { get; }
    }
}