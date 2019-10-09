
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
        public const string TransactionList = "transactionList";
        public const string UploadTransaction = "uploadTransaction";
        #endregion

        #region API Routes
        public const string TransactionByStatusAPI = "transaction/transactionByStatus";
        public const string TransactionByDateAPI = "transaction/transactionByDate";
        public const string TransactionByCurrencyAPI = "transaction/transactionByCurrecny";
        public const string UploadTransactionAPI = "transaction/uploadTransaction";
        public const string TransactionListAPI = "transaction/transactionList";
        #endregion

        #region Config.
        public const string API_URL = "APIUrl";
        public const string MediaType_JSON = "application/json";
        #endregion

        public const string CSV_File_Type = ".csv";
        public const string XML_File_Type = ".xml";
        public const string SelectFileMsg = "Pleaes select file";
        public const string UploadErrorMsg = "An error occured during file upload.";
        public const string UnknownFileErrorMsg = "Unknown format";
        public const string UploadFileSuccessMsg = "File uploaded successfully.";
    }
}