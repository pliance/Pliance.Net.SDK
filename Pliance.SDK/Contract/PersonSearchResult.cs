using System.Collections.Generic;

namespace Pliance.SDK.Contract
{
    public class PersonSearchResult
    {
        public string PersonReferenceId { get; set; }
        public List<TextMatch> FirstName { get; set; }
        public List<TextMatch> LastName { get; set; }
        public bool IsPep { get; set; }
        public bool IsRca { get; set; }
        public bool IsSanction { get; set; }
        public PersonIdentity Identity { get; set; }
    }
}
