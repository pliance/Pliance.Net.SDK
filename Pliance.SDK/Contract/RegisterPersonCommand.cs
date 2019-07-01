using System.Collections.Generic;

namespace Pliance.SDK.Contract
{
    public class RegisterPersonCommand
    {
        public string PersonReferenceId { get; set; }
        public PersonIdentity Identity { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Gender { get; set; }
        public Birthdate Birthdate { get; set; }
        public List<Address> Addresses { get; set; }
        public RegisterPersonOptions Options { get; set; }
    }
}
