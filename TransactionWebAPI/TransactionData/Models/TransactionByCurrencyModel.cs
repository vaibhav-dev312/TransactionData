using Newtonsoft.Json;

namespace TransactionData.Models
{
    public class TransactionByCurrencyModel
    {
        [JsonProperty(PropertyName = "transactionCurrency")]
        public string TransactionCurrency { get; set; }
    }
}