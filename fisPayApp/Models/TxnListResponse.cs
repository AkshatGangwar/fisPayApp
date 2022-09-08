
namespace fisPayApp.Models
{
    public class TxnListResponse
    {
        public TxnListResponseData dataObject { get; set; }
    }
    public class TxnListResponseData
    {
        public List<TxnList> data { get; set; }
    }
}
