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
        public string TransactionDateFrom { get; set; }

        [JsonProperty(PropertyName = "transactionDateTo")]
        public string TransactionDateTo { get; set; }

        [JsonProperty(PropertyName = "transactionStatus")]
        public string TransactionStatus { get; set; }

        [IgnoreDataMember]
        [JsonIgnore]
        public TransactionEnum TransactionListBy { get; set; }

        [IgnoreDataMember]
        [JsonIgnore]
        public TransactionListResponse TransactionList { get; set; }

    }

    public enum TransactionEnum
    {
        ByCurrency,
        ByTransactionDate,
        ByStatus
    }
}