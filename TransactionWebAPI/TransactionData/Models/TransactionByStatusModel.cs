using Newtonsoft.Json;

namespace TransactionData.Models
{
    public class TransactionByStatusModel
    {
        [JsonProperty(PropertyName = "transactionStatus")]
        public string TransactionStatus { get; set; }
    }
}