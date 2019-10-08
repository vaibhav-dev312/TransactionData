using Newtonsoft.Json;
using System;

namespace TransactionAPI.Models
{
    public class TransactionListModel
    {
        public DateTime TransactionDateFrom { get; set; }
        public DateTime TransactionDateTo { get; set; }
        public string TransactionStatus { get; set; }
        public string TransactionCurrency { get; set; }
    }
}