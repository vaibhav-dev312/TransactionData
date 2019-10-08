using System;
using System.Data;
using System.Data.SqlClient;
using TransactionService.Common;
using TransactionService.Context;
using TransactionService.Model;

namespace TransactionService.Repository
{
    public class TransactionRepository : ITransactionRepository
    {
        private TXN_DatabaseEntities dbContext;

        public TransactionRepository()
        {
        }
        public TransactionRepository(TXN_DatabaseEntities _dbContext) 
        {
            this.dbContext = _dbContext;
        }

        public TransactionListResponse GetTransactionList(string transactionCurrency)
        {
            throw new NotImplementedException();
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
