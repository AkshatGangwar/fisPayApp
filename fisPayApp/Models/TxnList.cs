namespace fisPayApp.Models
{
    public class TxnList
    {
        public DateTime txnDate { get; set; }
        public string txnID { get; set; }
        public string description { get; set; }
        public string amount { get; set; }
        public string txnMode { get; set; }
        public string comment { get; set; }
        public string date
        {
            get => $"{txnDate.Date.ToString("dd/MM/yyyy")}";
        }
        public string desc
        {
            get => $"{getdesc()}";
        }
        string getdesc()
        {
            if (txnMode == "C")
                return "Credit";
            else
                return "Debit";
        }
    }
}
