using System.Collections.Generic;

namespace Pliance.SDK.Contract.Entities
{
    public class ListPersonViewModel
    {
        public string ListId { get; set; }
        public string NationalIdentificationNumber { get; set; }
        public List<ListNameViewModel> Names { get; set; } = new List<ListNameViewModel>();
        public List<ListBirthdate> Birthdates { get; set; } = new List<ListBirthdate>();
        public List<ListAddress> Addresses { get; set; } = new List<ListAddress>();
        public List<string> Countries { get; set; } = new List<string>();
        public bool IsPep { get; set; }
        public bool IsRca { get; set; }
        public bool IsSanction { get; set; }
        public List<string> Nationalities { get; set; }
        public List<string> Images { get; set; }
        public List<ListRole> Roles { get; set; }
        public List<ListRelationViewModel> Relations { get; set; } = new List<ListRelationViewModel>();
        public Gender Gender { get; set; }
        public List<string> Lists { get; set; } = new List<string>{ "N/A" };
    }
}