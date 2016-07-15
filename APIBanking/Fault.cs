using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.ServiceModel.Security;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Windows.Forms;

namespace APIBanking
{
    public class Fault : ApplicationException
    {
        public readonly String Code;
        public readonly String SubCode;
        public readonly String MessageInserts;

        public Fault(MessageSecurityException e) : base(e.Message, e)
        {
            WebException we = (WebException)e.GetBaseException();
            WebResponse response = we.Response;

            if (response.ContentType == "application/xml")
            {
                XmlDocument document = new XmlDocument();
                using (StreamReader streamReader = new System.IO.StreamReader(response.GetResponseStream(), ASCIIEncoding.ASCII))
                {
                    using (XmlReader xmlReader = XmlReader.Create(streamReader))
                    {
                        document.Load(xmlReader);
                        XmlNodeList moreInfo = document.GetElementsByTagName("moreInformation");
                        if (moreInfo.Count > 0)
                        {
                            MessageInserts = moreInfo[0].InnerText;
                        }
                        if ( MessageInserts == "Invalid client id or secret.")
                        {
                            SubCode = "100";
                        }
                        else if (MessageInserts == "Client id not registered.")
                        {
                            SubCode = "101";
                        }
                        else if ( MessageInserts == "Not Registered to Plan")
                        {
                            SubCode = "102";
                        }
                        else if (MessageInserts == "Authentication Failure, Unable to Validate Credentials")
                        {
                            SubCode = "103";
                        }
                        else if (MessageInserts == "Rate Limit - Rate Limit Exceeded")
                        {
                            SubCode = "104";
                        }
                        else if (MessageInserts.StartsWith("Internal Server Error"))
                        {
                            SubCode = "105";
                        }
                        else if (MessageInserts == "Authentication Failure, Unable to Validate Credentials")
                        {
                            SubCode = "106";
                        }
                        String xml = document.ToString();
                    }
                }
            }
            else if (response.ContentType.StartsWith("text/html"))
            {
                SubCode = "201";
            }
            else
            {
                using (StreamReader reader = new System.IO.StreamReader(we.Response.GetResponseStream(), ASCIIEncoding.ASCII))
                {
                    MessageInserts = reader.ReadToEnd();
                }
            }

        }

        public Fault(FaultException e) : base(e.Reason.ToString(), e)
        {
            if ( e.Code.SubCode != null ) {
                Code = e.Code.SubCode.Name;
            } else {
                Code = "502";
            }

            if (e.Code.SubCode.SubCode != null) {
                SubCode = e.Code.SubCode.SubCode.Name;
            }

            MessageFault msgFault = e.CreateMessageFault();
            if (msgFault.HasDetail)
            {
                MessageInserts = msgFault.GetReaderAtDetailContents().ReadOuterXml();
                XmlReader reader = msgFault.GetReaderAtDetailContents();
                if (reader.ReadToFollowing("messageInserts"))
                {
                    MessageInserts = reader.ReadOuterXml();
                }
            }
        }

        public Fault(Exception e) : base(e.Message, e)
        {
            // no reply
            if (e is TimeoutException)
            {
                Code = "504";
            }
            // transport failure
            else if (e is CommunicationException)
            {
                Code = "503";
            }
            // generic failure
            else
            {
                Code = "500";
            }
        }


        public override String ToString()
        {
            String prettyPrint;

            prettyPrint = "Fault: Code " + this.Code +
                          " SubCode: " + this.SubCode +
                          " ReasonText: " + this.Message + 
                          " messageInserts: " + this.MessageInserts;

            return prettyPrint;
        }
    }

}
