
using System;
using System.Data;
using TransactionService.Model;

namespace TransactionService.Repository
{
    public interface ITransactionRepository
    {
        TransactionListResponse GetTransactionList(DateTime? transactionDateFrom, DateTime? transactionDateTo,string transactionStatus = null, string transactionCurrency = null, string selectTransactionBy = null);
        bool UploadTransactions(DataTable transactionTable);
    }
  
}
