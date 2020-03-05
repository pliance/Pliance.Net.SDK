using System.Collections.Generic;

namespace Pliance.SDK.Contract
{
    public class FeedQueryResult : Response<FeedQueryResultData>
    {
    }

    public class FeedQueryResultData
    {
        public List<FeedQueryItem> Items { get; set; } = new List<FeedQueryItem>();
    }

    public class FeedQueryItem
    {
        public string Checkpoint { get; set; }
        public string Type { get; set; }
        public object Body { get; set; }
        // public IMetaObject Metadata { get; set; }
    }
}