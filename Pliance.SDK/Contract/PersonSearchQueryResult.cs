using System.Collections.Generic;

namespace Pliance.SDK.Contract
{
    public class PersonSearchQueryResult : Response<PersonSearchResponseData>
    {
    }

    public class PersonSearchResponseData
    {
        public List<PersonSearchResult> Result { get; set; }
    }
}
