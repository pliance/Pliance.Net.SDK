using System.Collections.Generic;

namespace Pliance.SDK.Contract
{
    public class PersonHit
    {
        public string MatchId { get; set; }
        public List<TextMatch> MatchedFirstName { get; set; }
        public List<TextMatch> MatchedLastName { get; set; }
        public Birthdate Birthdate { get; set; }
        public bool IsPep { get; set; }
        public bool IsRca { get; set; }
        public bool IsSanction { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public ClassificationType Classification { get; set; }
        public string AliasId { get; set; }
    }
}
