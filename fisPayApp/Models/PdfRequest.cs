using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace fisPayApp.Models
{
     public class PdfRequest
    {
        public string Name { get; set; }
        public string Mobile { get; set; }
        public string Email { get; set; }
        public string From { get; set; }
        public string To { get; set; }
        public List<TranData> Tran { get; set; }
    }
    public class TranData
    {
        public string Date { get; set; }
        public string Remarks { get; set; }
        public string Amount { get; set; }
        public string Balance { get; set; }
    }
}
