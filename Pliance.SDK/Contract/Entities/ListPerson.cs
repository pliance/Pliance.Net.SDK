using System.Collections.Generic;

namespace Pliance.SDK.Contract.Entities
{
    public class ListPerson : ListPersonBase
    {
        public List<ListAddress> Addresses { get; set; } = new List<ListAddress>();
        public List<string> Countries { get; set; } = new List<string>();
        public List<string> Nationalities { get; set; }
        public List<string> Images { get; set; }
        public List<ListRole> Roles { get; set; } = new List<ListRole>();
        public List<ListRelation> Relations { get; set; } = new List<ListRelation>();
        public List<string> SanctionLists { get; set; }

        public ListPersonBase Reduce()
        {
            return new ListPersonBase
            {
                ListId = ListId,
                IsPep = IsPep,
                IsRca = IsRca,
                IsSanction = IsSanction,
                Names = Names,
                Birthdates = Birthdates,
				Gender = Gender,
                SwedishPersonnummer = SwedishPersonnummer,
            };
        }
    }
}