using System.Collections.Generic;
using Pliance.SDK.Contract.Entities;

namespace Pliance.SDK.Contract
{
    public class ViewCompanyQueryResult : Response<ViewCompanyResponseData>
    {
    }
    
    public class ViewCompanyResponseData
    {
        public string CompanyReferenceId { get; set; }
        public CompanyIdentity Identity { get; set; }
        public string Name { get; set; }
        public List<ViewPersonResponseData> Beneficiaries { get; set; }
        public bool Archived { get; set; }
        public bool HighRiskCountry { get; set; }
        public List<List<CompanyHit>> Hits { get; set; }
        public LastChanged LastChanged { get; set; }
        public bool IsSanction { get; set; }
    }

    public class CompanyHit
    {
        public string MatchId { get; set; }
        public string AliasId { get; set; }
        public bool IsSanction { get; set; }
        public ClassificationType Classification { get; set; }
        public string Name { get; set; }
        public List<TextMatch> MatchedName { get; set; }
    }
}
