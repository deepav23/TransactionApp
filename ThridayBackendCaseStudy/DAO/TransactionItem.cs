using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThridayBackendCaseStudy.DAO
{
    public class TransactionItem
    {
       public int Id {get; set;}
        public Guid AccountUuid { get; set; }
        public string AccountId { get; set; }
        public string TransEnrichmentState { get; set; }
        public string TransactionId { get; set; }
        public TransactionType TransactionType { get; set; }
        public DateTime Date { get; set; }
        public string TransactionTitle { get; set; }
        public TransactionStatus Status { get; set; }
        public string BkStatus { get; set; }
        public string Description { get; set; }
        public string ReferenceClean { get; set; }
        public CashflowDirection Cashflow { get; set; }
        public decimal Amount { get; set; }
        public decimal BalanceAmount { get; set; }
        public DateTime PostedDate { get; set; }
        public string LogoUrl { get; set; }
        public string ReceiptName { get; set; }
        public string ReceiptUrl { get; set; }
        public string ReceiptID { get; set; }
        public string attachedFileName { get; set; }
        public decimal Gst { get; set; }
        public string MerchantPresence { get; set; }
        public string Category { get; set; }
        public string ShortCategory { get; set; }
        public int CategoryId { get; set; }
        public string MerchantName { get; set; }
        public string MerchantNameAlias { get; set; }
        public string AddressShort { get; set; }
        public string AddressLong { get; set; }
        public string Suburb { get; set; }
        public string Longitude { get; set; }
        public string Latitude { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string WebSite { get; set; }
        public string Acn { get; set; }
        public string Abn { get; set; }
        public string OriginalCofACode { get; set; }
        public string CurrentCofACode { get; set; }
        public string ChartOfAccount { get; set; }
        public string SalesTaxSource { get; set; }
        public string Notes { get; set; }
        public decimal BusinessUsePercentage { get; set; }
        public List<object> Tags { get; set; }
        public List<object> Attachment { get; set; }

    }
}
