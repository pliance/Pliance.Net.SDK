using System.Collections.Generic;
using System.Linq;

namespace Pliance.SDK.Contract
{
    public class RegisterPersonResponse : Response
    {
        public IEnumerable<IGrouping<string, Hit>> Hits { get; set; }
    }
}
