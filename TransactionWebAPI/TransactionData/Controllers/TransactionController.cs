using System;
using System.Threading.Tasks;
using System.Web.Http;
using TransactionData.Models;
using TransactionData.Common;

namespace TransactionData.Controllers
{
    [RoutePrefix(Constants.TransactionController)]
    public class TransactionController : ApiController
    {

        /// <summary>
        /// Get the transation list by currency
        /// </summary>
        /// <param name="request"></param>
        [HttpPost]
        [Route(Constants.TransactionByCurrency)]
        public async Task<IHttpActionResult> TransactionListByCurrency([FromBody] TransactionByCurrencyModel request)
        {
            try
            {
                //To Do :  Get the transation list by currency
                return Ok();
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }

        }

        /// <summary>
        /// Get the transation list by status
        /// </summary>
        /// <param name="request"></param>
        [HttpPost]
        [Route(Constants.TransactionByStatus)]
        public async Task<IHttpActionResult> TransactionListByStatus([FromBody] TransactionByStatusModel request)
        {
            //To Do :  Get the transation list by status
            return Ok();
        }

        /// <summary>
        /// Get the transation list by date range
        /// </summary>
        /// <param name="request"></param>
        [HttpPost]
        [Route(Constants.TransactionByDate)]
        public async Task<IHttpActionResult> TransactionListByDate([FromBody] TransactionByDateModel request)
        {
            //To Do :  Get the transation list by date range
            return Ok();
        }
    }
}
