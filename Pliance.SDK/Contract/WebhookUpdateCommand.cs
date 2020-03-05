namespace Pliance.SDK.Contract
{
    public class WebhookUpdateCommand
    {
        public bool Enabled { get; set; }
        public string Url { get; set; }
        public string Secret { get; set; }
    }
}