using System.Collections.Generic;
using Pliance.SDK.Contract;

namespace Pliance.SDK.Contract
{
    public class RegisterCompanyResponse : Response<ViewCompanyResponseData>
    {
    }

    public class RegisterCompanyData
    {
        public string CompanyReferenceId { get; set; }
        public CompanyIdentity Identity { get; set; }
        public string Name { get; set; }
        public List<ViewPersonResponseData> Beneficiaries { get; set; }
        public bool Archived { get; set; }
    }
}