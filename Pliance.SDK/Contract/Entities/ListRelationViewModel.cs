namespace Pliance.SDK.Contract.Entities
{
    public class ListRelationViewModel
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string RelationPersonId { get; set; }
        public bool IsPep { get; set; }
        public bool IsRca { get; set; }
        public bool IsSanction { get; set; }
        public string RelationType { get; set; }
    }
}