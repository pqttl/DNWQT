using DNQT.ViewModels.Common;

namespace DNQT.ViewModels.Admin.Order
{
    public class GetOrderPaging_VMQuery : PagingRequestBase
    {
        public string Keyword { get; set; }
    }
}
