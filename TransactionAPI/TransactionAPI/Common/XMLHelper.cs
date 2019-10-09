using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;
using System.Xml;
using TransactionAPI.Model;

namespace TransactionAPI.Common
{
    public static class XMLHelper
    {
        public static XmlDocument ReadXMLData(byte[] transactionFile)
        {
            XmlDocument xmlData = new XmlDocument();
            Stream stream = new MemoryStream(transactionFile);
            xmlData.Load(stream);
            return xmlData;
        }

        public static DataTable CreateDataTable(DataTable table, XmlDocument xmlData)
        {
            TransactionFileModel model = new TransactionFileModel();

            //Get the parent node
            XmlNode nodeResult = xmlData.SelectSingleNode(Constants.PreantTransactionNode);
            if (nodeResult != null)
            {
                // Get the individual transaction node
                XmlNodeList nodeList = xmlData.SelectNodes(Constants.ChildTransactionNode);
                foreach (XmlNode node in nodeList)
                {
                    if (node.HasChildNodes)
                    {
                        //Read the transaction file data
                        model.TransactionIdentificator = node.Attributes[0].Value;
                        foreach (XmlNode transactionNode in node.ChildNodes)
                        {
                            switch (transactionNode.Name)
                            {
                                case Constants.TransactionDate:
                                    model.TransactionDate = DateTime.Parse(transactionNode.InnerText);
                                    break;
                                case Constants.PaymentDetails:
                                    //Read amount and currency code
                                    if (node.HasChildNodes && transactionNode.ChildNodes[0].Name.Equals(Constants.Amount) && transactionNode.ChildNodes[1].Name.Equals(Constants.CurrencyCode))
                                    {
                                        model.Amount = Convert.ToDecimal(transactionNode.ChildNodes[0].InnerText);
                                        model.CurrencyCode = transactionNode.ChildNodes[1].InnerText;
                                    }
                                    break;
                                case Constants.Status:
                                    model.Status = transactionNode.InnerText;
                                    break;
                            }
                        }

                    }
                    table.Rows.Add(model.TransactionIdentificator, model.Amount, model.CurrencyCode, model.TransactionDate, model.Status);
                }
            }
            return table;
        }
    }
}