using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using APIBanking.JSON.RBL.SinglePayment;
using APIBanking.Environments.RBL;

namespace APIBankingTests
{
    [TestClass]
    public class SinglePaymentTest
    {
        [TestMethod]
        public void transfer()
        {

            SinglePaymentRequest singlePaymentReq = new SinglePaymentRequest();
            singlePaymentReq.request = new Request();
            singlePaymentReq.request.header = new RequestHeader();
            singlePaymentReq.request.body = new RequestBody();
            
            singlePaymentReq.request.header.transactionID = "6301042";
            singlePaymentReq.request.header.corporateID = "DSPBR";

            singlePaymentReq.request.body.amount = "100";

            singlePaymentReq.request.body.debitAccountNo = "1000110010007511";
            singlePaymentReq.request.body.debitAccountName = "ABC";
            singlePaymentReq.request.body.debitAccountIFSC = "RBLB1122123";
            singlePaymentReq.request.body.debitAccountMobile = "7023923603";
            singlePaymentReq.request.body.debitTransactionParticulars = "AB";
            singlePaymentReq.request.body.debitPartTransactionRemarks = "BC";

            singlePaymentReq.request.body.beneficiaryAccountIFSC = "CBIN0R10001";
            singlePaymentReq.request.body.beneficiaryAccountNo = "1006211030035980";
            singlePaymentReq.request.body.beneficiaryName = "BEN";
            singlePaymentReq.request.body.beneficiaryAddress = "ADD";
            singlePaymentReq.request.body.beneficiaryTransactionParticulars = "AB";
            singlePaymentReq.request.body.beneficiaryPartTransactionRemarks = "BC";

            singlePaymentReq.request.body.modeOfPayment = "NEFT";

            String userName = System.Environment.GetEnvironmentVariable("API_RBL_USER");
            String userPassword = System.Environment.GetEnvironmentVariable("API_RBL_PASSWORD");
            String clientId = System.Environment.GetEnvironmentVariable("API_RBL_CLIENT_ID");
            String clientSecret = System.Environment.GetEnvironmentVariable("API_RBL_CLIENT_SECRET");
            String clientCert = System.Environment.GetEnvironmentVariable("API_RBL_CLIENT_CERT");
            String clientCertPassword = System.Environment.GetEnvironmentVariable("API_RBL_CLIENT_CERT_PASSWORD");

            UAT env = new APIBanking.Environments.RBL.UAT(userName, userPassword,
               clientId, clientSecret, clientCert, clientCertPassword);

            SinglePaymentResponse x = SinglePayment.doSomething(env, singlePaymentReq);
            Console.WriteLine(x.response.header.status);
            Console.WriteLine(x.response.header.errorCode);
            Console.WriteLine(x.response.header.errorDescription);
        }
    }
}
