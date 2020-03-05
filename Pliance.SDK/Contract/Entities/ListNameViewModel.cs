using System.Collections.Generic;

namespace Pliance.SDK.Contract.Entities
{
    public class ListNameViewModel
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public List<TextMatch> SelectedFirstName { get; set; }
        public List<TextMatch> SelectedLastName { get; set; }
        public string Type { get; set; }
    }
}