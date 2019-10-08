
using System.Data;
using TransactionService.Model;

namespace TransactionService.Repository
{
    public interface ITransactionRepository
    {
        TransactionListResponse GetTransactionList(string transactionCurrency);
        bool UploadTransactions(DataTable transactionTable);
    }
  
}
