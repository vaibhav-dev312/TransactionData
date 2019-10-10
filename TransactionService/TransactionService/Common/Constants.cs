namespace TransactionService.Common
{
    public static class Constants
    {
        public const string ConnectionKey = "TXN_Entities";
        public const string TransactionByCurrency = "Currency";
        public const string TransactionByDate = "TransactionDate";
        public const string TransactionByStatus = "Status";

        #region Stored Procedure
        public const string UploadTransactionProc = "Stp_UploadTranactions";
        #endregion
    }
}
