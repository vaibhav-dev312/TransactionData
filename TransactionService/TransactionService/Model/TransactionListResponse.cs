
using System.Collections.Generic;

namespace TransactionService.Model
{
    public class TransactionListResponse
    {
        public List<TransactionList> TransactionList { get; set; }
    }

    public class TransactionList
    {
        public string Id { get; set; }
        public string Payment { get; set; }
        public string Status { get; set; }

    }
}
