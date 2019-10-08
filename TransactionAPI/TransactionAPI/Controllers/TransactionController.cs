using System;
using System.Web.Http;
using TransactionAPI.Models;
using TransactionService.Repository;
using TransactionAPI.Common;
using System.Data;

namespace TransactionAPI.Controllers
{
    [RoutePrefix(Constants.TransactionController)]
    public class TransactionController : ApiController
    {
        private readonly ITransactionRepository TransactionRepository;

        public TransactionController(ITransactionRepository _TransactionRepository) 
        {
            this.TransactionRepository = _TransactionRepository;
        }

        public TransactionController() : base()
        {
            this.TransactionRepository = new TransactionRepository();
        }

        /// <summary>
        /// Get the transation list
        /// </summary>
        /// <param name="request"></param>
        [HttpPost]
        [Route(Constants.GetTransactionList)]
        public IHttpActionResult GetTransactionsList([FromBody] TransactionListModel transactionListModel)
        {
            try
            {
                return Ok(this.TransactionRepository.GetTransactionList(transactionListModel.TransactionCurrency));
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
                // Read CSV data 
                string csvData =CSVHelper.ReadCSVFile(request.TransactionFile);
                // Create data tabel from CSV file data
                if(string.IsNullOrEmpty(csvData))
                    return BadRequest(Constants.InvalidFileMsg);

                DataTable table = CSVHelper.CreateDataTable(csvData);
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
