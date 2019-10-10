using Newtonsoft.Json;
using System;

namespace TransactionAPI.Models
{
    public class TransactionListRequestModel
    {
        public DateTime? TransactionDateFrom { get; set; } = null;
        public DateTime? TransactionDateTo { get; set; } = null;
        public string TransactionStatus { get; set; }
        public string TransactionCurrency { get; set; }
        public string TransactionBy { get; set; }
    }
}