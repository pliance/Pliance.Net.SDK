namespace Pliance.SDK.Contract.Graphs
{
    public class Node
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public string Reference { get; set; }
        public bool IsPep { get; set; }
    }
}