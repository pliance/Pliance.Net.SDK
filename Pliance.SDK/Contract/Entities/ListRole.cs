namespace Pliance.SDK.Contract.Entities
{
    public class ListRole
    {
        public string Description { get; set; }
        public bool IsActive { get; set; }
        public string SinceYear { get; set; }
        public string SinceMonth { get; set; }
        public string SinceDay { get; set; }
        public string ToYear { get; set; }
        public string ToMonth { get; set; }
        public string ToDay { get; set; }
    }
}