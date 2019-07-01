namespace Pliance.SDK.Contract
{
    public class TextMatch
    {
        public string Text { get; }
        public bool IsMatch { get; }

        public TextMatch(string text, bool isMatch)
        {
            Text = text;
            IsMatch = isMatch;
        }
    }
}