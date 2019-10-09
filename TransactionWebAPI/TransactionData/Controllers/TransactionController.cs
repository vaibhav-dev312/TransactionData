
using Newtonsoft.Json;
using System.IO;
using System.Threading.Tasks;
using System.Web.Mvc;
using TransactionData.Common;
using TransactionData.Models;

namespace TransactionData.Controllers
{
    public class TransactionController : Controller
    {
        public string ErrorMessage { get; set; }
        public TransactionListResponse transactionList { get; set; }

        [HttpGet]
        public ActionResult UploadTransactionData()
        {
            return View();
        }

        [HttpPost]
        [Route(Constants.UploadTransaction)]
        public async Task<ActionResult> UploadTransactionData(UploadTransactionModel request)
        {
            if (request.UploadTransactionFile != null)
            {
                if (request.UploadTransactionFile.FileName.ToLower().Contains(Constants.CSV_File_Type) || request.UploadTransactionFile.FileName.ToLower().Contains(Constants.XML_File_Type))
                {
                    request.FileName = request.UploadTransactionFile.FileName;
                    using (var binaryReader = new BinaryReader(request.UploadTransactionFile.InputStream))
                    {
                        ViewBag.Result = string.Empty;
                        request.TransactionFile = binaryReader.ReadBytes(request.UploadTransactionFile.ContentLength);
                        var response = await HTTPClientFactory.APIPostAsyncJson(Constants.UploadTransactionAPI, request);
                        if (response == "true")
                            ViewBag.Result = Constants.UploadFileSuccessMsg;
                        else
                            ViewBag.Result = Constants.UploadErrorMsg;
                    }
                }
                else
                    ViewBag.Result = Constants.UnknownFileErrorMsg;
            }
            else
                ViewBag.Result = Constants.SelectFileMsg;
            return View(request);
        }

        [HttpGet]
        public ActionResult GetTransactionList()
        {
            return View();
        }

        [HttpPost]
        [Route(Constants.TransactionList)]
        public async Task<ActionResult> GetTransactionList(TransactionListRequestModel request)
        {
            if (request != null)
            {
                var response = await HTTPClientFactory.APIPostAsyncJson(Constants.TransactionListAPI, request);
                request.TransactionList = JsonConvert.DeserializeObject<TransactionListResponse>(response);
            }
            return View(request);
        }


    }
}