namespace Pliance.SDK.Contract
{
    public class CompanySearchQuery
    {
        public Page Page { get; set; }
        public Filter Filter { get; set; }
        public string Query { get; set; }
    }    
}
