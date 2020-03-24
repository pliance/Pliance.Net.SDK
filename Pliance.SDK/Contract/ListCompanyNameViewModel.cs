using System.Collections.Generic;

namespace Pliance.SDK.Contract
{
    public class ListCompanyNameViewModel
    {
        public string Type { get; set; }
        public string Name { get; set; }
        public List<TextMatch> SelectedName { get; set; }
    }
}