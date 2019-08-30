using System.Collections.Generic;
using System.Linq;

namespace Pliance.SDK.Contract
{
    public class ViewPersonResponseData
    {
        public string PersonReferenceId { get; set; }
        public PersonIdentity Identity { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Birthdate { get; set; }
        public List<Address> Addresses { get; set; }
        public List<List<Hit>> Hits { get; set; }
        public Gender Gender { get; set; }
        public bool Archived { get; set; }
    }
}
