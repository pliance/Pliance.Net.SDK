namespace Pliance.SDK.Contract
{
    public class ClassifyHitCommand
    {
        public string PersonReferenceId { get; set; }
        public string MatchId { get; set; }        
        public string AliasId { get; set; }        
        public ClassificationType Classification { get; set; }        
    }
}
