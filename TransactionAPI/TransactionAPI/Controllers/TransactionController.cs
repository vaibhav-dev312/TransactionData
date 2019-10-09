using System;
using System.Web.Http;
using TransactionAPI.Models;
using TransactionService.Repository;
using TransactionAPI.Common;
using System.Data;
using System.Xml;
using log4net;

namespace TransactionAPI.Controllers
{
    [RoutePrefix(Constants.TransactionController)]
    public class TransactionController : ApiController
    {
        private readonly ITransactionRepository TransactionRepository;
        ILog logger;

        public TransactionController(ITransactionRepository _TransactionRepository)
        {
            logger =  LogManager.GetLogger(typeof(TransactionController));
            this.TransactionRepository = _TransactionRepository;
        }


        /// <summary>
        /// Get the transation list
        /// </summary>
        /// <param name="request"></param>
        [HttpPost]
        [Route(Constants.GetTransactionList)]
        public IHttpActionResult GetTransactionsList([FromBody] TransactionListRequestModel transactionListModel)
        {
            try
            {
                var response = this.TransactionRepository.GetTransactionList(transactionListModel.TransactionDateFrom, transactionListModel.TransactionDateTo, transactionListModel.TransactionStatus, transactionListModel.TransactionCurrency);
                return Ok(response);
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }

        }

        /// <summary>
        /// Upload transaction data from CSV 
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost]
        [Route(Constants.UploadTransaction)]
        public IHttpActionResult UploadTransationData([FromBody] UploadTransactionModel request)
        {
            try
            {
                logger.Error(request);
                DataTable table = new DataTable();
                table.Columns.Add(Constants.TransactionIdentificator, typeof(string));
                table.Columns.Add(Constants.Amount, typeof(decimal));
                table.Columns.Add(Constants.CurrencyCode, typeof(string));
                table.Columns.Add(Constants.TransactionDate, typeof(DateTime));
                table.Columns.Add(Constants.Status, typeof(string));

                if (!string.IsNullOrEmpty(request.FileName) && request.FileName.Contains(".csv"))
                {
                    //Read CSV data
                    string csvData = CSVHelper.ReadCSVFile(request.TransactionFile);
                    //Create data tabel from CSV file data
                    if (string.IsNullOrEmpty(csvData))
                        return BadRequest(Constants.InvalidFileMsg);

                    table = CSVHelper.CreateDataTable(csvData);
                }
                else
                {
                    XmlDocument xmlData = XMLHelper.ReadXMLData(request.TransactionFile);
                    if (xmlData == null)
                        return BadRequest(Constants.InvalidFileMsg);

                    table = XMLHelper.CreateDataTable(table,xmlData);
                }

                if (table != null)
                    return Ok(this.TransactionRepository.UploadTransactions(table));
                else
                    return BadRequest(Constants.InvalidFileMsg);
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }

        }
    }
}
