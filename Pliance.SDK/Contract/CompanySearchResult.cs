using System.Collections.Generic;

namespace Pliance.SDK.Contract
{
    public class CompanySearchResult
    {
        public string CompanyReferenceId { get; set; }
        public List<TextMatch> Name { get; set; }
        public bool IsPep { get; set; }
        public bool IsRca { get; set; }
        public bool IsSanction { get; set; }
        public CompanyIdentity Identity { get; set; }
        public bool Archived { get; set; }
    }    
}
