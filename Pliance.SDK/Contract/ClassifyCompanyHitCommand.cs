namespace Pliance.SDK.Contract
{
    public class ClassifyCompanyHitCommand
    {
        public string CompanyReferenceId { get; set; }
        public string MatchId { get; set; }        
        public string AliasId { get; set; }        
        public ClassificationType Classification { get; set; }        
    }
}