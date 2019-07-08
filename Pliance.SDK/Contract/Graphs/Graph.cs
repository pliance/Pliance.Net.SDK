using System.Collections.Generic;

namespace Pliance.SDK.Contract.Graphs
{
    public class Graph
    {
        public List<Node> Nodes { get; set; } = new List<Node>();
        public List<Link> Links { get; set; } = new List<Link>();
    }
}