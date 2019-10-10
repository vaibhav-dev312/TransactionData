
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
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
                if (request.UploadTransactionFile.ContentLength > 1000000)
                {
                    ViewBag.Result = Constants.FileSizeExccedErrorMsg;
                    return View(request);
                }
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
            var requestModel = new TransactionListRequestModel();
            requestModel.TransactionList = new TransactionListResponse();
            requestModel.TransactionList.TransactionList = new List<Transactions>();
            return View(requestModel);
        }

        [HttpPost]
        [Route(Constants.TransactionList)]
        public async Task<ActionResult> GetTransactionList(TransactionListRequestModel request)
        {
            if (request != null)
            {
                request.TransactionBy = Enum.GetName(typeof(TransactionEnum), request.TransactionListBy); ;
                var response = await HTTPClientFactory.APIPostAsyncJson(Constants.TransactionListAPI, request);
                request.TransactionList = JsonConvert.DeserializeObject<TransactionListResponse>(response);
            }
            return View(request);
        }


    }
}