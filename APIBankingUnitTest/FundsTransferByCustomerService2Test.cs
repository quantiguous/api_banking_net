using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using APIBanking;
using APIBanking.com.quantiguous;

namespace APIBankingTests
{
    [TestClass]
    public class FundsTransferByCustomerService2Test
    {
        [TestMethod]
        public void transfer_successWithCert()
        {
            APIBanking.com.quantiguous.api.FundsTransferByCustomerService2.transfer request = new APIBanking.com.quantiguous.api.FundsTransferByCustomerService2.transfer();

            request.uniqueRequestNo = FundsTransferByCustomerService2.generateGUID();
            request.customerID = "505";
            request.appID = "12345";
            request.debitAccountNo = "000180100000244";
            request.beneficiary = new APIBanking.com.quantiguous.api.FundsTransferByCustomerService2.beneficiaryType();

            APIBanking.com.quantiguous.api.FundsTransferByCustomerService2.beneficiaryDetailType beneficiaryDetail = new APIBanking.com.quantiguous.api.FundsTransferByCustomerService2.beneficiaryDetailType();
            beneficiaryDetail.beneficiaryName = new APIBanking.com.quantiguous.api.FundsTransferByCustomerService2.nameType();
            beneficiaryDetail.beneficiaryName.Item = "RAJIV SHUKLA";
            beneficiaryDetail.beneficiaryAddress = new APIBanking.com.quantiguous.api.FundsTransferByCustomerService2.AddressType();
            beneficiaryDetail.beneficiaryAddress.address1 = "NEW";
            beneficiaryDetail.beneficiaryContact = new APIBanking.com.quantiguous.api.FundsTransferByCustomerService2.contactType();
            beneficiaryDetail.beneficiaryAccountNo = "109876543210";
            beneficiaryDetail.beneficiaryIFSC = "HDFC0000239";

            request.beneficiary.Item = beneficiaryDetail;

            request.transferType = APIBanking.com.quantiguous.api.FundsTransferByCustomerService2.transferTypeType.NEFT;
            request.transferCurrencyCode = APIBanking.com.quantiguous.api.FundsTransferByCustomerService2.currencyCodeType.INR;
            request.transferAmount = 20;
            request.remitterToBeneficiaryInfo = "FUND TRANSFER";

            String userName = System.Environment.GetEnvironmentVariable("API_YBL_USER");
            String userPassword = System.Environment.GetEnvironmentVariable("API_YBL_PASSWORD");
            String clientId = System.Environment.GetEnvironmentVariable("API_YBL_CLIENT_ID");
            String clientSecret = System.Environment.GetEnvironmentVariable("API_YBL_CLIENT_SECRET");
            String clientCert = System.Environment.GetEnvironmentVariable("API_YBL_CLIENT_CERT");
            String clientCertPassword = System.Environment.GetEnvironmentVariable("API_YBL_CLIENT_CERT_PASSWORD");

            APIBanking.Environment env = new APIBanking.Environments.YBL.UAT(userName, userPassword,
                clientId, clientSecret, clientCert,clientCertPassword);


            try
            {
                APIBanking.com.quantiguous.api.FundsTransferByCustomerService2.transferResponse response = FundsTransferByCustomerService2.transfer(env, request);
                Assert.IsNotNull(response);
            }
            catch (Fault e)
            {
                Console.WriteLine(e.ToString());
            }
        }

        [TestMethod]
        public void transfer_successWithoutCert()
        {
            APIBanking.com.quantiguous.api.FundsTransferByCustomerService2.transfer request = new APIBanking.com.quantiguous.api.FundsTransferByCustomerService2.transfer();

            request.uniqueRequestNo = FundsTransferByCustomerService2.generateGUID();
            request.customerID = "505";
            request.appID = "12345";
            request.debitAccountNo = "000180100000244";
            request.beneficiary = new APIBanking.com.quantiguous.api.FundsTransferByCustomerService2.beneficiaryType();

            APIBanking.com.quantiguous.api.FundsTransferByCustomerService2.beneficiaryDetailType beneficiaryDetail = new APIBanking.com.quantiguous.api.FundsTransferByCustomerService2.beneficiaryDetailType();
            beneficiaryDetail.beneficiaryName = new APIBanking.com.quantiguous.api.FundsTransferByCustomerService2.nameType();
            beneficiaryDetail.beneficiaryName.Item = "RAJIV SHUKLA";
            beneficiaryDetail.beneficiaryAddress = new APIBanking.com.quantiguous.api.FundsTransferByCustomerService2.AddressType();
            beneficiaryDetail.beneficiaryAddress.address1 = "NEW";
            beneficiaryDetail.beneficiaryContact = new APIBanking.com.quantiguous.api.FundsTransferByCustomerService2.contactType();
            beneficiaryDetail.beneficiaryAccountNo = "109876543210";
            beneficiaryDetail.beneficiaryIFSC = "HDFC0000239";

            request.beneficiary.Item = beneficiaryDetail;

            request.transferType = APIBanking.com.quantiguous.api.FundsTransferByCustomerService2.transferTypeType.NEFT;
            request.transferCurrencyCode = APIBanking.com.quantiguous.api.FundsTransferByCustomerService2.currencyCodeType.INR;
            request.transferAmount = 20;
            request.remitterToBeneficiaryInfo = "FUND TRANSFER";

            String userName = System.Environment.GetEnvironmentVariable("API_YBL_USER");
            String userPassword = System.Environment.GetEnvironmentVariable("API_YBL_PASSWORD");
            String clientId = System.Environment.GetEnvironmentVariable("API_YBL_CLIENT_ID");
            String clientSecret = System.Environment.GetEnvironmentVariable("API_YBL_CLIENT_SECRET");
            String clientCert = System.Environment.GetEnvironmentVariable("API_YBL_CLIENT_CERT");
            String clientCertPassword = System.Environment.GetEnvironmentVariable("API_YBL_CLIENT_CERT_PASSWORD");

            APIBanking.Environment env = new APIBanking.Environments.YBL.UAT(userName, userPassword,
                clientId, clientSecret, null);// clientCert, clientCertPassword);

            try
            {
                APIBanking.com.quantiguous.api.FundsTransferByCustomerService2.transferResponse response = FundsTransferByCustomerService2.transfer(env, request);
                Assert.IsNotNull(response);
            }
            catch (Fault e)
            {
                Console.WriteLine(e.ToString());
            }
        }

        [TestMethod]
        public void transfer_invalidAppID()
        {
            APIBanking.com.quantiguous.api.FundsTransferByCustomerService2.transfer request = new APIBanking.com.quantiguous.api.FundsTransferByCustomerService2.transfer();

            request.uniqueRequestNo = FundsTransferByCustomerService2.generateGUID();
            request.customerID = "505";
            request.appID = "11111";
            request.debitAccountNo = "000180100000244";
            request.beneficiary = new APIBanking.com.quantiguous.api.FundsTransferByCustomerService2.beneficiaryType();

            APIBanking.com.quantiguous.api.FundsTransferByCustomerService2.beneficiaryDetailType beneficiaryDetail = new APIBanking.com.quantiguous.api.FundsTransferByCustomerService2.beneficiaryDetailType();
            beneficiaryDetail.beneficiaryName = new APIBanking.com.quantiguous.api.FundsTransferByCustomerService2.nameType();
            beneficiaryDetail.beneficiaryName.Item = "RAJIV SHUKLA";
            beneficiaryDetail.beneficiaryAddress = new APIBanking.com.quantiguous.api.FundsTransferByCustomerService2.AddressType();
            beneficiaryDetail.beneficiaryAddress.address1 = "NEW";
            beneficiaryDetail.beneficiaryContact = new APIBanking.com.quantiguous.api.FundsTransferByCustomerService2.contactType();
            beneficiaryDetail.beneficiaryAccountNo = "109876543210";
            beneficiaryDetail.beneficiaryIFSC = "HDFC0000239";

            request.beneficiary.Item = beneficiaryDetail;

            request.transferType = APIBanking.com.quantiguous.api.FundsTransferByCustomerService2.transferTypeType.NEFT;
            request.transferCurrencyCode = APIBanking.com.quantiguous.api.FundsTransferByCustomerService2.currencyCodeType.INR;
            request.transferAmount = 20;
            request.remitterToBeneficiaryInfo = "FUND TRANSFER";

            String userName = System.Environment.GetEnvironmentVariable("API_YBL_USER");
            String userPassword = System.Environment.GetEnvironmentVariable("API_YBL_PASSWORD");
            String clientId = System.Environment.GetEnvironmentVariable("API_YBL_CLIENT_ID");
            String clientSecret = System.Environment.GetEnvironmentVariable("API_YBL_CLIENT_SECRET");
            String clientCert = System.Environment.GetEnvironmentVariable("API_YBL_CLIENT_CERT");
            String clientCertPassword = System.Environment.GetEnvironmentVariable("API_YBL_CLIENT_CERT_PASSWORD");

            APIBanking.Environment env = new APIBanking.Environments.YBL.UAT(userName, userPassword,
                clientId, clientSecret, clientCert,clientCertPassword);

            try
            {
                APIBanking.com.quantiguous.api.FundsTransferByCustomerService2.transferResponse response = FundsTransferByCustomerService2.transfer(env, request);
                Assert.IsNotNull(response);
            }
            catch (Fault e)
            {
                Assert.AreEqual("E403", e.Code);
                Console.WriteLine(e.ToString());
            }
        }

        [TestMethod]
        public void transfer_invalidUserID()
        {
            APIBanking.com.quantiguous.api.FundsTransferByCustomerService2.transfer request = new APIBanking.com.quantiguous.api.FundsTransferByCustomerService2.transfer();

            request.uniqueRequestNo = FundsTransferByCustomerService2.generateGUID();
            request.customerID = "505";
            request.appID = "12345";
            request.debitAccountNo = "000180100000244";
            request.beneficiary = new APIBanking.com.quantiguous.api.FundsTransferByCustomerService2.beneficiaryType();

            APIBanking.com.quantiguous.api.FundsTransferByCustomerService2.beneficiaryDetailType beneficiaryDetail = new APIBanking.com.quantiguous.api.FundsTransferByCustomerService2.beneficiaryDetailType();
            beneficiaryDetail.beneficiaryName = new APIBanking.com.quantiguous.api.FundsTransferByCustomerService2.nameType();
            beneficiaryDetail.beneficiaryName.Item = "RAJIV SHUKLA";
            beneficiaryDetail.beneficiaryAddress = new APIBanking.com.quantiguous.api.FundsTransferByCustomerService2.AddressType();
            beneficiaryDetail.beneficiaryAddress.address1 = "NEW";
            beneficiaryDetail.beneficiaryContact = new APIBanking.com.quantiguous.api.FundsTransferByCustomerService2.contactType();
            beneficiaryDetail.beneficiaryAccountNo = "109876543210";
            beneficiaryDetail.beneficiaryIFSC = "HDFC0000239";

            request.beneficiary.Item = beneficiaryDetail;

            request.transferType = APIBanking.com.quantiguous.api.FundsTransferByCustomerService2.transferTypeType.NEFT;
            request.transferCurrencyCode = APIBanking.com.quantiguous.api.FundsTransferByCustomerService2.currencyCodeType.INR;
            request.transferAmount = 20;
            request.remitterToBeneficiaryInfo = "FUND TRANSFER";

            String userName = "test123";
            String userPassword = System.Environment.GetEnvironmentVariable("API_YBL_PASSWORD");
            String clientId = System.Environment.GetEnvironmentVariable("API_YBL_CLIENT_ID");
            String clientSecret = System.Environment.GetEnvironmentVariable("API_YBL_CLIENT_SECRET");
            String clientCert = System.Environment.GetEnvironmentVariable("API_YBL_CLIENT_CERT");
            String clientCertPassword = System.Environment.GetEnvironmentVariable("API_YBL_CLIENT_CERT_PASSWORD");

            APIBanking.Environment env = new APIBanking.Environments.YBL.UAT(userName, userPassword,
                clientId, clientSecret, clientCert,clientCertPassword);

            try
            {
                APIBanking.com.quantiguous.api.FundsTransferByCustomerService2.transferResponse response = FundsTransferByCustomerService2.transfer(env, request);
                Assert.IsNotNull(response);
            }
            catch (Fault e)
            {
                Assert.AreEqual("201", e.SubCode);
                Console.WriteLine(e.ToString());
            }
        }

        [TestMethod]
        public void transfer_invalidClientSecret()
        {
            APIBanking.com.quantiguous.api.FundsTransferByCustomerService2.transfer request = new APIBanking.com.quantiguous.api.FundsTransferByCustomerService2.transfer();

            request.uniqueRequestNo = FundsTransferByCustomerService2.generateGUID();
            request.customerID = "505";
            request.appID = "12345";
            request.debitAccountNo = "000180100000244";
            request.beneficiary = new APIBanking.com.quantiguous.api.FundsTransferByCustomerService2.beneficiaryType();

            APIBanking.com.quantiguous.api.FundsTransferByCustomerService2.beneficiaryDetailType beneficiaryDetail = new APIBanking.com.quantiguous.api.FundsTransferByCustomerService2.beneficiaryDetailType();
            beneficiaryDetail.beneficiaryName = new APIBanking.com.quantiguous.api.FundsTransferByCustomerService2.nameType();
            beneficiaryDetail.beneficiaryName.Item = "RAJIV SHUKLA";
            beneficiaryDetail.beneficiaryAddress = new APIBanking.com.quantiguous.api.FundsTransferByCustomerService2.AddressType();
            beneficiaryDetail.beneficiaryAddress.address1 = "NEW";
            beneficiaryDetail.beneficiaryContact = new APIBanking.com.quantiguous.api.FundsTransferByCustomerService2.contactType();
            beneficiaryDetail.beneficiaryAccountNo = "109876543210";
            beneficiaryDetail.beneficiaryIFSC = "HDFC0000239";

            request.beneficiary.Item = beneficiaryDetail;

            request.transferType = APIBanking.com.quantiguous.api.FundsTransferByCustomerService2.transferTypeType.NEFT;
            request.transferCurrencyCode = APIBanking.com.quantiguous.api.FundsTransferByCustomerService2.currencyCodeType.INR;
            request.transferAmount = 20;
            request.remitterToBeneficiaryInfo = "FUND TRANSFER";

            String userName = System.Environment.GetEnvironmentVariable("API_YBL_USER");
            String userPassword = System.Environment.GetEnvironmentVariable("API_YBL_PASSWORD");
            String clientId = System.Environment.GetEnvironmentVariable("API_YBL_CLIENT_ID");
            String clientSecret = "12345678901234567890";
            String clientCert = System.Environment.GetEnvironmentVariable("API_YBL_CLIENT_CERT");
            String clientCertPassword = System.Environment.GetEnvironmentVariable("API_YBL_CLIENT_CERT_PASSWORD");

            APIBanking.Environment env = new APIBanking.Environments.YBL.UAT(userName, userPassword,
                clientId, clientSecret, clientCert,clientCertPassword);

            try
            {
                APIBanking.com.quantiguous.api.FundsTransferByCustomerService2.transferResponse response = FundsTransferByCustomerService2.transfer(env, request);
                Assert.IsNotNull(response);
            }
            catch (Fault e)
            {
                Assert.AreEqual("100", e.SubCode);
                Console.WriteLine(e.ToString());
            }
        }

        [TestMethod]
        public void transfer_invalidCertPath()
        {
            APIBanking.com.quantiguous.api.FundsTransferByCustomerService2.transfer request = new APIBanking.com.quantiguous.api.FundsTransferByCustomerService2.transfer();

            request.uniqueRequestNo = FundsTransferByCustomerService2.generateGUID();
            request.customerID = "505";
            request.appID = "12345";
            request.debitAccountNo = "000180100000244";
            request.beneficiary = new APIBanking.com.quantiguous.api.FundsTransferByCustomerService2.beneficiaryType();

            APIBanking.com.quantiguous.api.FundsTransferByCustomerService2.beneficiaryDetailType beneficiaryDetail = new APIBanking.com.quantiguous.api.FundsTransferByCustomerService2.beneficiaryDetailType();
            beneficiaryDetail.beneficiaryName = new APIBanking.com.quantiguous.api.FundsTransferByCustomerService2.nameType();
            beneficiaryDetail.beneficiaryName.Item = "RAJIV SHUKLA";
            beneficiaryDetail.beneficiaryAddress = new APIBanking.com.quantiguous.api.FundsTransferByCustomerService2.AddressType();
            beneficiaryDetail.beneficiaryAddress.address1 = "NEW";
            beneficiaryDetail.beneficiaryContact = new APIBanking.com.quantiguous.api.FundsTransferByCustomerService2.contactType();
            beneficiaryDetail.beneficiaryAccountNo = "109876543210";
            beneficiaryDetail.beneficiaryIFSC = "HDFC0000239";

            request.beneficiary.Item = beneficiaryDetail;

            request.transferType = APIBanking.com.quantiguous.api.FundsTransferByCustomerService2.transferTypeType.NEFT;
            request.transferCurrencyCode = APIBanking.com.quantiguous.api.FundsTransferByCustomerService2.currencyCodeType.INR;
            request.transferAmount = 20;
            request.remitterToBeneficiaryInfo = "FUND TRANSFER";

            String userName = System.Environment.GetEnvironmentVariable("API_YBL_USER");
            String userPassword = System.Environment.GetEnvironmentVariable("API_YBL_PASSWORD");
            String clientId = System.Environment.GetEnvironmentVariable("API_YBL_CLIENT_ID");
            String clientSecret = System.Environment.GetEnvironmentVariable("API_YBL_CLIENT_SECRET");
            String clientCert = @"C:\Users\akhileshkataria\abcd";
            String clientCertPassword = System.Environment.GetEnvironmentVariable("API_YBL_CLIENT_CERT_PASSWORD");

            APIBanking.Environment env = new APIBanking.Environments.YBL.UAT(userName, userPassword,
                clientId, clientSecret, clientCert,clientCertPassword);

            try
            {
                APIBanking.com.quantiguous.api.FundsTransferByCustomerService2.transferResponse response = FundsTransferByCustomerService2.transfer(env, request);
                Assert.IsNotNull(response);
            }
            catch (Fault e)
            {
                Console.WriteLine(e.ToString());
            }
        }

        [TestMethod]
        public void transfer_schemaValidation()
        {
            APIBanking.com.quantiguous.api.FundsTransferByCustomerService2.transfer request = new APIBanking.com.quantiguous.api.FundsTransferByCustomerService2.transfer();

            request.uniqueRequestNo = FundsTransferByCustomerService2.generateGUID();
            //request.customerID = "505";
            request.appID = "12345";
            request.debitAccountNo = "000180100000244";
            request.beneficiary = new APIBanking.com.quantiguous.api.FundsTransferByCustomerService2.beneficiaryType();

            APIBanking.com.quantiguous.api.FundsTransferByCustomerService2.beneficiaryDetailType beneficiaryDetail = new APIBanking.com.quantiguous.api.FundsTransferByCustomerService2.beneficiaryDetailType();
            beneficiaryDetail.beneficiaryName = new APIBanking.com.quantiguous.api.FundsTransferByCustomerService2.nameType();
            beneficiaryDetail.beneficiaryName.Item = "RAJIV SHUKLA";
            beneficiaryDetail.beneficiaryAddress = new APIBanking.com.quantiguous.api.FundsTransferByCustomerService2.AddressType();
            beneficiaryDetail.beneficiaryAddress.address1 = "NEW";
            beneficiaryDetail.beneficiaryContact = new APIBanking.com.quantiguous.api.FundsTransferByCustomerService2.contactType();
            beneficiaryDetail.beneficiaryAccountNo = "109876543210";
            beneficiaryDetail.beneficiaryIFSC = "HDFC0000239";

            request.beneficiary.Item = beneficiaryDetail;

            request.transferType = APIBanking.com.quantiguous.api.FundsTransferByCustomerService2.transferTypeType.NEFT;
            request.transferCurrencyCode = APIBanking.com.quantiguous.api.FundsTransferByCustomerService2.currencyCodeType.INR;
            request.transferAmount = 20;
            request.remitterToBeneficiaryInfo = "FUND TRANSFER";

            String userName = System.Environment.GetEnvironmentVariable("API_YBL_USER");
            String userPassword = System.Environment.GetEnvironmentVariable("API_YBL_PASSWORD");
            String clientId = System.Environment.GetEnvironmentVariable("API_YBL_CLIENT_ID");
            String clientSecret = System.Environment.GetEnvironmentVariable("API_YBL_CLIENT_SECRET");
            String clientCert = System.Environment.GetEnvironmentVariable("API_YBL_CLIENT_CERT");
            String clientCertPassword = System.Environment.GetEnvironmentVariable("API_YBL_CLIENT_CERT_PASSWORD");

            APIBanking.Environment env = new APIBanking.Environments.YBL.UAT(userName, userPassword,
                clientId, clientSecret, clientCert, clientCertPassword);

            try
            {
                APIBanking.com.quantiguous.api.FundsTransferByCustomerService2.transferResponse response = FundsTransferByCustomerService2.transfer(env, request);
                Assert.IsNotNull(response);
            }
            catch (Fault e)
            {
                Assert.AreEqual("E5025", e.SubCode);
                Console.WriteLine(e.ToString());
            }
        }
        [TestMethod]
        public void getBalance()
        {
            APIBanking.com.quantiguous.api.FundsTransferByCustomerService2.getBalance request = new APIBanking.com.quantiguous.api.FundsTransferByCustomerService2.getBalance();

            request.customerID = "505";
            request.appID = "12345";
            request.AccountNumber = "000180100000244";

            String userName = System.Environment.GetEnvironmentVariable("API_YBL_USER");
            String userPassword = System.Environment.GetEnvironmentVariable("API_YBL_PASSWORD");
            String clientId = System.Environment.GetEnvironmentVariable("API_YBL_CLIENT_ID");
            String clientSecret = System.Environment.GetEnvironmentVariable("API_YBL_CLIENT_SECRET");
            String clientCert = System.Environment.GetEnvironmentVariable("API_YBL_CLIENT_CERT");
            String clientCertPassword = System.Environment.GetEnvironmentVariable("API_YBL_CLIENT_CERT_PASSWORD");

            APIBanking.Environment env = new APIBanking.Environments.YBL.UAT(userName, userPassword,
                clientId, clientSecret, clientCert,clientCertPassword);

            try
            {
                APIBanking.com.quantiguous.api.FundsTransferByCustomerService2.getBalanceResponse response = FundsTransferByCustomerService2.getBalance(env, request);
                Assert.IsNotNull(response);
            }
            catch (Fault e)
            {
                Assert.AreEqual(Fault.FaultCodes.FT6.ToString(), e.Code);
                Console.WriteLine(e.ToString());
            }
        }

        [TestMethod]
        public void getStatus()
        {
            APIBanking.com.quantiguous.api.FundsTransferByCustomerService2.getStatus request = new APIBanking.com.quantiguous.api.FundsTransferByCustomerService2.getStatus();

            request.customerID = "505";
            request.appID = "12345";
            request.requestReferenceNo = "d55c9008d2a0489fabc00965d5ce2296";

            String userName = System.Environment.GetEnvironmentVariable("API_YBL_USER");
            String userPassword = System.Environment.GetEnvironmentVariable("API_YBL_PASSWORD");
            String clientId = System.Environment.GetEnvironmentVariable("API_YBL_CLIENT_ID");
            String clientSecret = System.Environment.GetEnvironmentVariable("API_YBL_CLIENT_SECRET");
            String clientCert = System.Environment.GetEnvironmentVariable("API_YBL_CLIENT_CERT");
            String clientCertPassword = System.Environment.GetEnvironmentVariable("API_YBL_CLIENT_CERT_PASSWORD");

            APIBanking.Environment env = new APIBanking.Environments.YBL.UAT(userName, userPassword,
                clientId, clientSecret, clientCert,clientCertPassword);

            try
            {
                APIBanking.com.quantiguous.api.FundsTransferByCustomerService2.getStatusResponse response = FundsTransferByCustomerService2.getStatus(env, request);
                Assert.IsNotNull(response);
            }
            catch (Fault e)
            {
                Console.WriteLine(e.ToString());
            }
        }
    }
}
