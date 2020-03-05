namespace Pliance.SDK.Contract
{
    public class FeedQuery
    {
        public string From { get; set; } = Position.Start.AsHexString();
    }
}