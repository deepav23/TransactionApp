using System.Collections.Generic;

namespace ThridayBackendCaseStudy.DAO
{
    public class ResponseObject
    {
        public string Status { get; set; }
        public bool Successful { get; set; }
        public string ErrorMessage { get; set; }
        public string NavigateTo { get; set; }
        public Data Data { get; set; }
    }

    public class Data
    {
        public List<TransactionItem> Transactions { get; set; }
    }
}
