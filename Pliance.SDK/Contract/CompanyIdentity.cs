namespace Pliance.SDK.Contract
{
    public class CompanyIdentity
    {
        public string Identity { get; }
        public string Country { get; }

        public CompanyIdentity(string identity, string country)
        {
            Identity = identity;
            Country = country;
        }
    }
}