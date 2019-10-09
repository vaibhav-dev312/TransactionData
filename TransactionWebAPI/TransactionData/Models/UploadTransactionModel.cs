
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using System.Web;

namespace TransactionData.Models
{
    public class UploadTransactionModel
    {
        [IgnoreDataMember]
        [JsonIgnore]
        public HttpPostedFileBase UploadTransactionFile { get; set; }

        [Required]
        public byte[] TransactionFile { get; set; }

        public string FileName { get; set; }
    }
}