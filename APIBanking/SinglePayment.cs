using System;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;
using System.Text;

namespace APIBanking.JSON.RBL.SinglePayment
{
    [DataContract]
    public class SinglePaymentRequest
    {
        [DataMember(Name = "Single_Payment_Corp_Req")]
        public Request request;
    }

    [DataContract]
    public class Request
    {
        [DataMember(Name = "Header", Order = 0)]
        public RequestHeader header;
        [DataMember(Name = "Body", Order = 1)]
        public RequestBody body;
        [DataMember(Name = "Signature", Order = 2)]
        internal Signature signature;

    }

    [DataContract]
    public class SinglePaymentResponse
    {
        [DataMember(Name = "Single_Payment_Corp_Resp")]
        public Response response;
    }

    [DataContract]
    public class Response
    {
        [DataMember(Name = "Header")]
        public ResponseHeader header;
        [DataMember(Name = "Body")]
        public ResponseBody body;
        [DataMember(Name = "Signature")]
        internal Signature signature;

    }

    [DataContract]
    internal class Signature
    {
        [DataMember(Name = "Signature")]
        public String sign = "signature";
    }

    [DataContract]
    public class RequestHeader
    {
        [DataMember(Name = "TranID", Order = 0)]
        public String transactionID;
        [DataMember(Name = "Corp_ID", Order = 1)]
        public String corporateID;
        [DataMember(Name = "Maker_ID", Order = 2)]
        public String makerID = "";
        [DataMember(Name = "Checker_ID", Order = 3)]
        public String checkerID = "";
        [DataMember(Name = "Approver_ID", Order = 4)]
        public String approverID = "";
    }
    [DataContract]
    public class RequestBody
    {
        [DataMember(Name = "Amount", Order = 0)]
        public String amount;

        [DataMember(Name = "Debit_Acct_No", Order = 1)]
        public String debitAccountNo;

        [DataMember(Name = "Debit_Acct_Name", Order = 2)]
        public String debitAccountName;

        [DataMember(Name = "Debit_IFSC", Order = 3)]
        public String debitAccountIFSC;

        [DataMember(Name = "Debit_Mobile", Order = 4)]
        public String debitAccountMobile;

        [DataMember(Name = "Debit_TrnParticulars", Order = 5)]
        public String debitTransactionParticulars;

        [DataMember(Name = "Debit_PartTrnRmks", Order = 6)]
        public String debitPartTransactionRemarks;

        [DataMember(Name = "Ben_IFSC", Order = 7)]
        public String beneficiaryAccountIFSC;

        [DataMember(Name = "Ben_Acct_No", Order = 8)]
        public String beneficiaryAccountNo;

        [DataMember(Name = "Ben_Name", Order = 9)]
        public String beneficiaryName;

        [DataMember(Name = "Ben_Address", Order = 10)]
        public String beneficiaryAddress;

        [DataMember(Name = "Ben_BankName", Order = 11)]
        public String beneficiaryBankName = "";

        [DataMember(Name = "Ben_BankCd", Order = 12)]
        public String beneficiaryBankCode = "";

        [DataMember(Name = "Ben_BranchCd", Order = 13)]
        public String beneficiaryBranchCode = "";

        [DataMember(Name = "Ben_Email", Order = 14)]
        public String beneficiaryEmail = "";

        [DataMember(Name = "Ben_Mobile", Order = 15)]
        public String beneficiaryMobileNo = "";

        [DataMember(Name = "Ben_TrnParticulars", Order = 16)]
        public String beneficiaryTransactionParticulars;

        [DataMember(Name = "Ben_PartTrnRmks", Order = 17)]
        public String beneficiaryPartTransactionRemarks;

        [DataMember(Name = "Issue_BranchCd", Order = 18)]
        public String issueBranchCode = "";

        [DataMember(Name = "Mode_of_Pay", Order = 19)]
        public String modeOfPayment;

        [DataMember(Name = "Remarks", Order = 20)]
        public String remarks = "";

        [DataMember(Name = "RptCode", Order = 21)]
        public String reportCode = "";
    }

    [DataContract]
    public class ResponseHeader
    {
        [DataMember(Name = "TranID")]
        public String transactionID;
        [DataMember(Name = "Corp_ID")]
        public String corporateID;
        [DataMember(Name = "Maker_ID")]
        public String makerID;
        [DataMember(Name = "Checker_ID")]
        public String checkerID;
        [DataMember(Name = "Approver_ID")]
        public String approverID;
        [DataMember(Name = "Status")]
        public String status;
        [DataMember(Name = "Error_Cde")]
        public String errorCode;
        [DataMember(Name = "Error_Desc")]
        public String errorDescription;
    }

    [DataContract]
    public class ResponseBody
    {

    }


    public class SinglePayment
    {
        private static HttpContent getRequestContent(SinglePaymentRequest req)
        {
            req.request.signature = new Signature();

            DataContractJsonSerializer serializer = new DataContractJsonSerializer(typeof(SinglePaymentRequest));

            using (MemoryStream ms = new MemoryStream())
            {
                serializer.WriteObject(ms, req);

                String requestJSON = Encoding.UTF8.GetString(ms.ToArray());

                Console.WriteLine(requestJSON);

                return new StringContent(
                    requestJSON,
                    Encoding.UTF8,
                    "application/json");
            }
        }
        private static WebRequestHandler getHTTPClientHandler(String serviceName, Environment env)
        {
            WebRequestHandler handler = new WebRequestHandler();
            
            if ( env.needsClientCertificate() )
            {
                handler.ClientCertificates.Add(env.getClientCertificate());
            }

            if ( env.needsHTTPBasicAuth() )
            {
                NetworkCredential basicAuthCredentials = new NetworkCredential(env.getUser(), env.getPassword());
                CredentialCache credentialsCache = new CredentialCache();
                credentialsCache.Add(env.getEndpointAddress(serviceName).Uri, "Basic", basicAuthCredentials);

                handler.Credentials = credentialsCache;
            }

            if ( env.getProxyAddress() != null )
            {
                handler.UseProxy = true;
                handler.Proxy = new WebProxy(env.getProxyAddress());
            }
             
            return handler;
        }
        public static SinglePaymentResponse doSomething(Environment env, SinglePaymentRequest req)
        {

            using (HttpClient client = new HttpClient(getHTTPClientHandler("singlePayment", env)))
            {
                String queryParams = "?client_id=" + env.getClientId() + "&client_secret=" + env.getClientSecret();

                client.BaseAddress = new Uri(
                    env.getEndpointAddress("singlePayment").Uri.ToString() + queryParams);
                
                HttpResponseMessage response = client.PostAsync("", getRequestContent(req)).Result;
                response.EnsureSuccessStatusCode();

                String responseJSON =  response.Content.ReadAsStringAsync().Result;
                using (MemoryStream responseStream = new MemoryStream(Encoding.UTF8.GetBytes(responseJSON)))
                {
                    DataContractJsonSerializer serializer = new DataContractJsonSerializer(typeof(SinglePaymentResponse));
                    return (SinglePaymentResponse) serializer.ReadObject(responseStream);
                }
            }
        }
    }
}
