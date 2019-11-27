using System.Collections.Generic;

namespace Pliance.SDK.Contract.Entities
{
    public class ListPersonBase
    {
        public virtual string ListId { get; set; }
        public virtual bool IsPep { get; set; }
        public virtual bool IsRca { get; set; }
        public virtual bool IsSanction { get; set; }
        public virtual List<ListName> Names { get; set; } = new List<ListName>();
        public virtual List<ListBirthdate> Birthdates { get; set; } = new List<ListBirthdate>();
        public virtual Gender Gender { get; set; }
        public string SwedishPersonnummer { get; set; }        
    }
}