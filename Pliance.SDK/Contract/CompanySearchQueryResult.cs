using System.Collections.Generic;

namespace Pliance.SDK.Contract
{
    public class CompanySearchQueryResult : Response<CompanySearchResponseData>
    {
    }    
    
    public class CompanySearchResponseData
    {
        public List<CompanySearchResult> Result { get; set; }
    }    
}
