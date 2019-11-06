namespace IFAVALIACAO.API.Domain.Authentication
{
    public interface ITokenConfiguration
    {
        string Audience { get; }
        string Issuer { get; }
        int Days { get; }
    }
}