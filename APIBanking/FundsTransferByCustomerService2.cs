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
    public class FundsTransferByCustomerService2 : SoapClient
    {
        public static readonly String VERSION = "1";
        public static readonly String SERVICE_NAME = "fundsTransferByCustomerService2";

        private static com.quantiguous.api.FundsTransferByCustomerService2.fundsTransferByCustomerService2Client createClient(Environment env)
        {
            com.quantiguous.api.FundsTransferByCustomerService2.fundsTransferByCustomerService2Client client;

            client = new com.quantiguous.api.FundsTransferByCustomerService2.fundsTransferByCustomerService2Client(
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

        public static com.quantiguous.api.FundsTransferByCustomerService2.transferResponse transfer(Environment env, APIBanking.com.quantiguous.api.FundsTransferByCustomerService2.transfer request)
        {
            String message;// faultCode, faultSubCode, reason;
            request.version = VERSION;
            com.quantiguous.api.FundsTransferByCustomerService2.fundsTransferByCustomerService2Client client = createClient(env);

            try
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

                    com.quantiguous.api.FundsTransferByCustomerService2.transferResponse response = client.transfer(request);

                    return response;
                }
            }
            catch (TimeoutException e)
            {
                message = e.Message;
            }
            catch (FaultException e)
            {
                Fault fault = new Fault(null, null, null);
                fault.setCode(e.Code.Name);
                fault.setSubCode(e.Code.SubCode.Name);
                fault.setReasonText(e.Reason.ToString());
                /*faultCode = e.Code.Name;
                faultSubCode = e.Code.SubCode.Name;
                reason = e.Reason.ToString();*/
                /*message = e.Message;
                MessageFault msgFault = e.CreateMessageFault();
                if (msgFault.HasDetail)
                {
                    message = msgFault.GetReaderAtDetailContents().ReadOuterXml();
                    XmlReader reader = msgFault.GetReaderAtDetailContents();
                    if (reader.ReadToFollowing("messageInserts"))
                    {
                        message = reader.ReadOuterXml();
                    }
                }*/
                throw fault;
            }
            
            catch (CommunicationException e)
            {
                message = e.Message;
                Fault fault = new Fault(null, null, null);
                fault.setReasonText(message);
                throw fault;
            }

            catch (Exception e)
            {
                String msg = e.ToString();
                Fault fault = new Fault(null, null, null);
                fault.setReasonText(msg);
                throw fault;
            }
            return null;
            
        }

        public static com.quantiguous.api.FundsTransferByCustomerService2.getBalanceResponse getBalance(Environment env, APIBanking.com.quantiguous.api.FundsTransferByCustomerService2.getBalance request)
        {
            String message;// faultCode, faultSubCode, reason;
            request.version = VERSION;
            com.quantiguous.api.FundsTransferByCustomerService2.fundsTransferByCustomerService2Client client = createClient(env);

            try
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

                    com.quantiguous.api.FundsTransferByCustomerService2.getBalanceResponse response = client.getBalance(request);

                    return response;
                }
            }
            catch (TimeoutException e)
            {
                message = e.Message;
            }
            catch (FaultException e)
            {
                Fault fault = new Fault(null, null, null);
                fault.setCode(e.Code.Name);
                fault.setSubCode(e.Code.SubCode.Name);
                fault.setReasonText(e.Reason.ToString());
                throw fault;
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

        }

        public static com.quantiguous.api.FundsTransferByCustomerService2.getStatusResponse getStatus(Environment env, APIBanking.com.quantiguous.api.FundsTransferByCustomerService2.getStatus request)
        {
            String message;// faultCode, faultSubCode, reason;
            request.version = VERSION;
            com.quantiguous.api.FundsTransferByCustomerService2.fundsTransferByCustomerService2Client client = createClient(env);

            try
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

                    com.quantiguous.api.FundsTransferByCustomerService2.getStatusResponse response = client.getStatus(request);

                    return response;
                }
            }
            catch (TimeoutException e)
            {
                message = e.Message;
            }
            catch (FaultException e)
            {
                Fault fault = new Fault(null, null, null);
                fault.setCode(e.Code.Name);
                fault.setSubCode(e.Code.SubCode.Name);
                fault.setReasonText(e.Reason.ToString());
                throw fault;
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

        }
    }
}
