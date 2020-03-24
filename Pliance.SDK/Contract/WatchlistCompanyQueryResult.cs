using System.Collections.Generic;

namespace Pliance.SDK.Contract
{
    public class WatchlistCompanyQueryResult : Response<ListCompanyViewModel>
    {
    }

    public class ListCompanyViewModel
    {
        public string CompanyReferenceId { get; set; }
        public bool IsSanction { get; set; }
        public List<ListCompanyNameViewModel> Names { get; set; }
        public List<string> SanctionLists { get; set; }
    }
}