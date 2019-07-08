using System.Collections.Generic;

namespace Pliance.SDK.Contract
{
    public class Beneficiary
    {
        public string NationIdentityNumber { get; }
        public string FirstName { get; }
        public string LastName { get; }
        public bool IsPep { get; }
        public List<Engagement> Engagements { get; }
    }
}