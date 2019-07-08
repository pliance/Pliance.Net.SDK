using System.Collections.Generic;
using Pliance.SDK.Contract.Graphs;

namespace Pliance.SDK.Contract
{
    public class ViewCompanyResponseData
    {
        public string CompanyReferenceId { get; set; }
        public CompanyIdentity Identity { get; set; }
        public string Name { get; set; }
        public Graph Graph { get; set; }
        public List<Beneficiary> Beneficiaries { get; set; }
    }
}
