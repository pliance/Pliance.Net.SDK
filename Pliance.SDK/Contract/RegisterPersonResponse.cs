using System;
using System.Collections.Generic;
using System.Linq;

namespace Pliance.SDK.Contract
{
    public class RegisterPersonResponse : Response<ViewPersonResponseData>
    {
        [Obsolete]
        public List<List<PersonHit>> Hits { get; set; }
    }
}
