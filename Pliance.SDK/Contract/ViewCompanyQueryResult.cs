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
        public LastChanged LastChanged { get; set; }
    }
}
