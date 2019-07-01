using System;

namespace Pliance.SDK.Contract
{
    public class PersonIdentity
    {
        public string Identity { get; }
        public string Country { get; }

        public PersonIdentity(string identity, string country)
        {
            Identity = identity;
            Country = country;
        }
    }
}