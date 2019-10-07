using Newtonsoft.Json;
using System;

namespace TransactionData.Models
{
    public class TransactionByDateModel
    {
        [JsonProperty(PropertyName = "transactionDateFrom")]
        public DateTime  TransactionDateFrom { get; set; }

        [JsonProperty(PropertyName = "transactionDateTo")]
        public DateTime TransactionDateTo { get; set; }
    }
}