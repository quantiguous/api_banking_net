using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace APIBanking
{
    public class FundsTransferByCustomerService : SoapClient
    {
        public static readonly String VERSION = "1";
        public static readonly String SERVICE_NAME = "fundsTransferByCustomerService";

        private static com.quantiguous.api.FundsTransferByCustomerService.fundsTransferByCustomerServiceClient createClient(Environment env)
        {
            com.quantiguous.api.FundsTransferByCustomerService.fundsTransferByCustomerServiceClient client;

            client = new com.quantiguous.api.FundsTransferByCustomerService.fundsTransferByCustomerServiceClient(
                getBinding(env), env.getEndpointAddress(SERVICE_NAME));


            if (env.needsClientCertificate())
            {
                client.ClientCredentials.ClientCertificate.Certificate = env.getClientCertificate();
            }

            if (env.needsHTTPBasicAuth())
            {
                client.ClientCredentials.UserName.UserName = env.getUser();
                client.ClientCredentials.UserName.Password = env.getPassword();
            }

            return client;
        }

        public static String transfer(Environment env, APIBanking.com.quantiguous.api.FundsTransferByCustomerService.transfer request)
        {
            String message, faultCode, faultSubCode, reason;
            request.version = VERSION;
            com.quantiguous.api.FundsTransferByCustomerService.fundsTransferByCustomerServiceClient client = createClient(env);

     //       try
            {
                using (new System.ServiceModel.OperationContextScope((System.ServiceModel.IClientChannel)client.InnerChannel))
                {
                    System.Net.ServicePointManager.SecurityProtocol = env.getSecurityProtocol();

                    System.ServiceModel.Web.WebOperationContext.Current.OutgoingRequest.UserAgent = "APIBanking.NET";


                    IDictionaryEnumerator headers = env.getHeaders().GetEnumerator();
                    while (headers.MoveNext())
                    {

                        System.ServiceModel.Web.WebOperationContext.Current.OutgoingRequest.Headers.Add(headers.Key.ToString(), headers.Value.ToString());
                    }

                    com.quantiguous.api.FundsTransferByCustomerService.transferResponse response = client.transfer(request);

                    return response.transactionStatus.bankReferenceNo;
                }
            }
  /*          catch (TimeoutException e)
            {
                message = e.Message;
            }
            catch (FaultException e)
            {
                faultCode = e.Code.Name;
                faultSubCode = e.Code.SubCode.Name;
                reason = e.Reason.ToString();
                message = e.Message;
                MessageFault msgFault = e.CreateMessageFault();
                if (msgFault.HasDetail)
                {
                    message = msgFault.GetReaderAtDetailContents().ReadOuterXml();
                    XmlReader reader = msgFault.GetReaderAtDetailContents();
                    if (reader.ReadToFollowing("messageInserts"))
                    {
                        message = reader.ReadOuterXml();
                    }
                }
            }
            
            catch (CommunicationException e)
            {
                message = e.Message;
            }

            catch (Exception e)
            {
                String msg = e.ToString();
            }
            return null;
            */
        }
    }
}
