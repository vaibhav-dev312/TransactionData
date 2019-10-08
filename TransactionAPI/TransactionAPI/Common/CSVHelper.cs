using System;
using System.Data;
using System.IO;

namespace TransactionAPI.Common
{
    public static class CSVHelper
    { 
        /// <summary>
        /// Read CSV file
        /// </summary>
        /// <param name="transactionFile"></param>
        /// <returns></returns>
       public static string ReadCSVFile(byte[] transactionFile)
       {
            Stream stream = new MemoryStream(transactionFile);
            string csvData = string.Empty;
            using (var sr = new StreamReader(stream))
            {
                csvData = sr.ReadToEnd();
            }
            return csvData;
       }

        /// <summary>
        /// Create data tabel from CSV file data
        /// </summary>
        /// <param name="csvData"></param>
        /// <returns></returns>
        public static DataTable CreateDataTable(string csvData)
        {
            DataTable table = new DataTable();
            table.Columns.Add(Constants.TransactionIdentificator, typeof(string));
            table.Columns.Add(Constants.Amount, typeof(decimal));
            table.Columns.Add(Constants.CurrencyCode, typeof(string));
            table.Columns.Add(Constants.TransactionDate, typeof(DateTime));
            table.Columns.Add(Constants.Status, typeof(string));

            var csvRows = csvData.Split(new string[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);
            for (int index = 1; index < csvRows.Length; index++)
            {
                //Add CSV data to data table
                var column = csvRows[index].Split(new char[] { ',' });
                if (!string.IsNullOrEmpty(column[0]) && !string.IsNullOrEmpty(column[1]) && !string.IsNullOrEmpty(column[2]) && !string.IsNullOrEmpty(column[3]) && !string.IsNullOrEmpty(column[4]))
                {
                    DateTime transactionDateTime = DateTime.Parse(column[3]);
                    table.Rows.Add(column[0], Convert.ToDecimal(column[1]), column[2], transactionDateTime, column[4]);
                }
                else
                {
                    return null;
                }
            }
            return table;
        }
    }
}