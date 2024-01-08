namespace Bonyan.Bnb.Identity.Options;

public class BnbIdentityJwtOptions
{
    public string Issuer { get; set; }
    public string Audience { get; set; }
    public string SecretKey { get; set; }

    public long ExpireMinutes { get; set; }
}