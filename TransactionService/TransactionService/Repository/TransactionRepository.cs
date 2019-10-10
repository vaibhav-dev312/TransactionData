using System;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using TransactionService.Common;
using TransactionService.Context;
using TransactionService.Model;

namespace TransactionService.Repository
{
    public class TransactionRepository : ITransactionRepository
    {
        private TXN_DatabaseEntities dbContext;

        public TransactionRepository(TXN_DatabaseEntities _dbContext) 
        {
            this.dbContext = _dbContext;
        }

        public TransactionListResponse GetTransactionList(DateTime? transactionDateFrom, DateTime? transactionDateTo, string transactionStatus = null, string transactionCurrency = null, string selectTransactionBy = null)
        {
           
            if (transactionDateFrom != null && transactionDateTo != null && selectTransactionBy == Constants.TransactionByDate)
            {
                var transactionByDateResponse = dbContext.Stp_GetTransactionsByDate(transactionDateFrom, transactionDateTo).ToList();

                return new TransactionListResponse
                {
                    TransactionList = transactionByDateResponse.Select(item => new TransactionList
                    {
                        Id = item.ID,
                        Payment = string.Concat(item.Amount, ' ', item.CurrencyCode),
                        Status = item.Status
                    }).ToList()
                };
            }
            else if (transactionCurrency != null && selectTransactionBy == Constants.TransactionByCurrency)
            {
                var transactionByCurrencyResponse = dbContext.Stp_GetTransactionsByCurrency(transactionCurrency).ToList();

                return new TransactionListResponse
                {
                    TransactionList = transactionByCurrencyResponse.Select(item => new TransactionList
                    {
                        Id = item.ID,
                        Payment = string.Concat(item.Amount, ' ', item.CurrencyCode),
                        Status = item.Status
                    }).ToList()
                };
            }
            else if(transactionStatus != null && selectTransactionBy == Constants.TransactionByStatus)
            {
                var transactionByStatusResponse = dbContext.Stp_GetTransactionsByStatus(transactionStatus).ToList();

                return new TransactionListResponse
                {
                    TransactionList = transactionByStatusResponse.Select(item => new TransactionList
                    {
                        Id = item.ID,
                        Payment = string.Concat(item.Amount, ' ', item.CurrencyCode),
                        Status = item.Status
                    }).ToList()
                };
            }
            else
            {
                return new TransactionListResponse();
            }

            
        }

        public bool UploadTransactions(DataTable transactionTable)
        {
            try
            {
                string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings[Constants.ConnectionKey].ConnectionString;
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    SqlCommand cmd = conn.CreateCommand();
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.CommandText = Constants.UploadTransactionProc; 
                    SqlParameter param = cmd.Parameters.AddWithValue("@TransactionTableType", transactionTable);
                    conn.Open();
                    cmd.ExecuteNonQuery();
                    conn.Close();
                }
            }
            catch
            {
                return false;
            }
            return true;
        }

    }
}
