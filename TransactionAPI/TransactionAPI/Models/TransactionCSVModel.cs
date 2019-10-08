using System;

namespace TransactionService.Model
{
    public class TransactionCSVModel
    {
        
        public string TransactionIdentificator { get; set; }
        public decimal Amount { get; set; }
        public string CurrencyCode  { get; set; }
        public string TransactionDate { get; set; }
        public string Status { get; set; }
    }
}
