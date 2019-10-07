
namespace TransactionData.Common
{
    public static class Constants
    {
        #region Route Prefix
        public const string TransactionController = "api/transaction";
        #endregion 

        #region Methods
        public const string TransactionByStatus = "transactionByStatus";
        public const string TransactionByDate = "transactionByDate";
        public const string TransactionByCurrency = "transactionByCurrecny";
        #endregion

        #region API Routes
        public const string TransactionByStatusAPI = "transaction/transactionByStatus";
        public const string TransactionByDateAPI = "transaction/transactionByDate";
        public const string TransactionByCurrencyAPI = "transaction/transactionByCurrecny";
        #endregion

        #region Config.
        public const string API_URL = "APIUrl";
        public const string MediaType_JSON = "application/json";
        #endregion

    }
}