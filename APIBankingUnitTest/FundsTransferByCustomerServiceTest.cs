using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using APIBanking;
using APIBanking.com.quantiguous;

namespace APIBankingTests
{
    [TestClass]
    public class FundsTransferByCustomerServiceTest
    {
        [TestMethod]
        public void transfer()
        {
            APIBanking.com.quantiguous.api.FundsTransferByCustomerService.transfer request = new APIBanking.com.quantiguous.api.FundsTransferByCustomerService.transfer();

            request.uniqueRequestNo = FundsTransferByCustomerService.generateGUID();
            request.customerID = "505";
          //  request.appID = "12345";
            request.debitAccountNo = "000180100000244";
            request.beneficiary = new APIBanking.com.quantiguous.api.FundsTransferByCustomerService.beneficiaryType();

            APIBanking.com.quantiguous.api.FundsTransferByCustomerService.beneficiaryDetailType beneficiaryDetail = new APIBanking.com.quantiguous.api.FundsTransferByCustomerService.beneficiaryDetailType();
            beneficiaryDetail.beneficiaryName = new APIBanking.com.quantiguous.api.FundsTransferByCustomerService.nameType();
            beneficiaryDetail.beneficiaryName.Item = "RAJIV SHUKLA";
            beneficiaryDetail.beneficiaryAddress = new APIBanking.com.quantiguous.api.FundsTransferByCustomerService.AddressType();
            beneficiaryDetail.beneficiaryAddress.address1 = "NEW";
            beneficiaryDetail.beneficiaryContact = new APIBanking.com.quantiguous.api.FundsTransferByCustomerService.contactType();
            beneficiaryDetail.beneficiaryAccountNo = "109876543210";
            beneficiaryDetail.beneficiaryIFSC = "HDFC0000239";

            request.beneficiary.Item = beneficiaryDetail;

            request.transferType = APIBanking.com.quantiguous.api.FundsTransferByCustomerService.transferTypeType.NEFT;
            request.transferCurrencyCode = APIBanking.com.quantiguous.api.FundsTransferByCustomerService.currencyCodeType.INR;
            request.transferAmount = 20;
            request.remitterToBeneficiaryInfo = "FUND TRANSFER";

            String userName = System.Environment.GetEnvironmentVariable("API_YBL_USER");
            String userPassword = System.Environment.GetEnvironmentVariable("API_YBL_PASSWORD");
            String clientId = System.Environment.GetEnvironmentVariable("API_YBL_CLIENT_ID");
            String clientSecret = System.Environment.GetEnvironmentVariable("API_YBL_CLIENT_SECRET");
            String clientCert = System.Environment.GetEnvironmentVariable("API_YBL_CLIENT_CERT");
            String clientCertPassword = System.Environment.GetEnvironmentVariable("API_YBL_CLIENT_CERT_PASSWORD");

            APIBanking.Environment env = new APIBanking.Environments.YBL.UAT(userName, userPassword,
                clientId,clientSecret,clientCert,clientCertPassword);

            
            String result = FundsTransferByCustomerService.transfer(env, request);

            Assert.IsNotNull(result);
        }
    }
}
