﻿namespace TransactionAPI.Common
{
    public static class Constants
    {
        #region Route Prefix
        public const string TransactionController = "api/transaction";
        #endregion

        #region Controller Methods
        public const string GetTransactionList = "transactionList";
        public const string UploadTransaction = "uploadTransaction";
        #endregion

        #region Data table columns
        public const string TransactionIdentificator = "TransactionIdentificator";
        public const string Amount = "Amount";
        public const string CurrencyCode = "CurrencyCode";
        public const string TransactionDate = "TransactionDate";
        public const string Status = "Status";
        #endregion

        public const string InvalidFileMsg = "Invalid file";
    }
}