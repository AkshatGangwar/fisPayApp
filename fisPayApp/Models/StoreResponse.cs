namespace fisPayApp.Models
{
    public class StoreResponse
    {
        public StoreResponseData dataObject { get; set; }
    }
    public class StoreResponseData
    {
        public List<StoreList> data { get; set; }
    }
}
