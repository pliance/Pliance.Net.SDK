using System.Collections.Generic;
using Pliance.SDK.Contract.Entities;

namespace Pliance.SDK.Contract
{
    public class ViewPersonQueryResult : Response<ViewPersonResponseData>
    {
    }

    public class ViewPersonResponseData
    {
        public string PersonReferenceId { get; set; }
        public PersonIdentity Identity { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Birthdate { get; set; }
        public List<Address> Addresses { get; set; }
        public List<List<PersonHit>> Hits { get; set; }
        public Gender Gender { get; set; }
        public bool Archived { get; set; }
        public List<EngagementModel> Engagements { get; set; }
        public bool IsPep { get; set; }
        public bool IsRca { get; set; }
        public bool IsSanction { get; set; }
        public Birthdate Birth { get; set; }
        public bool HighRiskCountry { get; set; }
        public LastChanged LastChanged { get; set; }
    }
}
