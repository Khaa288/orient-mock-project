namespace MockProject.Infrastructure.Services.Token
{
    public class TokenConfiguration
    {
        public string Issuer { get; }
        public string Audience { get; }
        public string Key { get; }

        public TokenConfiguration(string issuer, string audience, string key)
        {
            Issuer = issuer;
            Audience = audience;
            Key = key;
        }
    }
}
