namespace Pliance.SDK.Contract
{
    public class WebhookQueryResult : Response<WebhookQueryResultData>
    {
    }
    
    public class WebhookQueryResultData
    {
        public string Url { get; set; }
        public string Secret { get; set; }
        public bool Enabled { get; set; }   
    }
}