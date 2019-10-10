using Newtonsoft.Json;
using System;
using System.Runtime.Serialization;

namespace TransactionData.Models
{
    public class TransactionListRequestModel
    {
        [JsonProperty(PropertyName = "transactionCurrency")]
        public string TransactionCurrency { get; set; }

        [JsonProperty(PropertyName = "transactionDateFrom")]
        public DateTime? TransactionDateFrom { get; set; } = null;

        [JsonProperty(PropertyName = "transactionDateTo")]
        public DateTime? TransactionDateTo { get; set; } = null;

        [JsonProperty(PropertyName = "transactionStatus")]
        public string TransactionStatus { get; set; }

        public string TransactionBy { get; set; }

        [IgnoreDataMember]
        [JsonIgnore]
        public TransactionEnum TransactionListBy { get; set; }

        [IgnoreDataMember]
        [JsonIgnore]
        public TransactionListResponse TransactionList { get; set; }

    }

    public enum TransactionEnum
    {
        Currency,
        TransactionDate,
        Status
    }
}