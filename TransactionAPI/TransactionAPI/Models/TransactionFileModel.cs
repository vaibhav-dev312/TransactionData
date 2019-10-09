using System;

namespace TransactionAPI.Model
{
    public class TransactionFileModel
    {
        
        public string TransactionIdentificator { get; set; }
        public decimal Amount { get; set; }
        public string CurrencyCode  { get; set; }
        public DateTime TransactionDate { get; set; }
        public string Status { get; set; }
    }
}
