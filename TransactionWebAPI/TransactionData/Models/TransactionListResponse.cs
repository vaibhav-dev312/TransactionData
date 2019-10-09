using System.Collections.Generic;

namespace TransactionData.Models
{
    public class TransactionListResponse
    {
        public List<Transactions> TransactionList { get; set; }
    }
    public class Transactions
    {
            public string Id { get; set; }
            public string Payment { get; set; }
            public string Status { get; set; }

    }
}