namespace Pliance.SDK.Contract
{
    public class ClassifyPersonHitCommand
    {
        public string PersonReferenceId { get; set; }
        public string MatchId { get; set; }        
        public string AliasId { get; set; }        
        public ClassificationType Classification { get; set; }        
    }
}


