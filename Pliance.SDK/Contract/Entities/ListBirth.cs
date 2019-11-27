namespace Pliance.SDK.Contract.Entities
{
    public class ListBirthdate
    {
        public bool Circa { get; set; }
        public int? Year { get; set; }
        public int? Month { get; set; }
        public int? Day { get; set; }
        public int FromYear { get; set; }
        public int ToYear { get; set; }
    }
}