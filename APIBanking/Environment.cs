using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;
using System.Security.Cryptography.X509Certificates;

namespace APIBanking
{
    public interface Environment
    {
        Boolean needsHTTPBasicAuth();
        String getUser();
        String getPassword();
        String getClientId();
        String getClientSecret();
        EndpointAddress getEndpointAddress(String serviceName);
        Hashtable getHeaders();
        System.Net.SecurityProtocolType getSecurityProtocol();
        Uri getProxyAddress();
        X509Certificate2 getClientCertificate();
        Boolean needsClientCertificate();

    }
    namespace Environments.YBL
    {
        public class UAT : Environment
        {
            private String user;
            private String password;
            private String client_id;
            private String client_secret;
            private Uri proxyAddress;
            private String pkcs12FilePath;
            private String pkcs12Password;

            public UAT(String user, String password, String client_id, String client_secret, String pkcs12FilePath = null, String pkcs12Password = null, Uri proxyAddress = null)
            {
                this.user = user;
                this.password = password;
                this.client_id = client_id;
                this.client_secret = client_secret;
                this.proxyAddress = proxyAddress;
                this.pkcs12FilePath = pkcs12FilePath;
                this.pkcs12Password = pkcs12Password;
            }
            public UAT(String user, String password, String client_id, String client_secret, Uri proxyAddress = null)
                : this(user, password, client_id, client_secret, null, null, proxyAddress)
            {
            }

            public Uri getProxyAddress()
            {
                return this.proxyAddress;
            }
            public Boolean needsHTTPBasicAuth()
            {
                return true;
            }
            public String getUser()
            {
                return this.user;
            }
            public String getPassword()
            {
                return this.password;
            }
            public String getClientId()
            {
                return this.client_id;
            }
            public String getClientSecret()
            {
                return this.client_secret;
            }
            public Boolean needsClientCertificate()
            {
                return ( this.pkcs12FilePath != null ) ? true : false;
            }
            public EndpointAddress getEndpointAddress(String serviceName)
            {
                String baseURL = "https://uatsky.yesbank.in";
                if (needsClientCertificate())
                {
                    baseURL += ":444";
                }

                if ( serviceName == "fundsTransferByCustomerService2" )
                {
                    return new EndpointAddress(baseURL + "/app/uat/ssl/fundsTransferByCustomerSevice2");
                }
                else
                {
                    return new EndpointAddress(baseURL + "/app/uat/ssl/" + serviceName);
                }
            }

            public Hashtable getHeaders()
            {
                Hashtable headers = new Hashtable();
                headers.Add("X-IBM-Client-Id", client_id);
                headers.Add("X-IBM-Client-Secret", client_secret);
                if (needsClientCertificate())
                {
                    headers.Add("Authorization", "Basic " + Convert.ToBase64String(Encoding.ASCII.GetBytes(user + ":" + password)));
                }
                return headers;
            }
            public System.Net.SecurityProtocolType getSecurityProtocol()
            {
                return System.Net.SecurityProtocolType.Tls;
            }
            public X509Certificate2 getClientCertificate()
            {
                return new X509Certificate2(this.pkcs12FilePath, this.pkcs12Password);
            }
        }
    }

    namespace Environments.RBL
    {
        public class UAT : Environment
        {
            private String user;
            private String password;
            private String client_id;
            private String client_secret;
            private Uri proxyAddress;
            private String pkcs12FilePath;
            private String pkcs12Password;

            public UAT(String user, String password, String client_id, String client_secret, String pkcs12FilePath = null, String pkcs12Password = null, Uri proxyAddress = null)
            {
                this.user = user;
                this.password = password;
                this.client_id = client_id;
                this.client_secret = client_secret;
                this.proxyAddress = proxyAddress;
                this.pkcs12FilePath = pkcs12FilePath;
                this.pkcs12Password = pkcs12Password;
            }
            public UAT(String user, String password, String client_id, String client_secret, Uri proxyAddress = null)
                : this(user, password, client_id, client_secret, null, null, proxyAddress)
            {
            }
            public Uri getProxyAddress()
            {
                return this.proxyAddress;
            }
            public Boolean needsHTTPBasicAuth()
            {
                return true;
            }
            public String getUser()
            {
                return this.user;
            }
            public String getPassword()
            {
                return this.password;
            }
            public String getClientId()
            {
                return this.client_id;
            }
            public String getClientSecret()
            {
                return this.client_secret;
            }
            public Boolean needsClientCertificate()
            {
                return (this.pkcs12FilePath != null) ? true : false;
            }
            public EndpointAddress getEndpointAddress(String serviceName)
            {
                String baseURL = "https://apideveloper.rblbank.com";

                if (serviceName == "singlePayment")
                {
                    return new EndpointAddress(baseURL + "/test/sb/rbl/v1/payments/corp/payment");
                }

                return null;
            }

            public Hashtable getHeaders()
            {
                return new Hashtable();
            }
            public System.Net.SecurityProtocolType getSecurityProtocol()
            {
                return System.Net.SecurityProtocolType.Tls;
            }
            public X509Certificate2 getClientCertificate()
            {
                return new X509Certificate2(this.pkcs12FilePath, this.pkcs12Password);
            }
        }
    }
    namespace Environments.QG
    {
        public class DEMO : Environment
        {
            private String user;
            private String password;
            private Uri proxyAddress;

            public DEMO(String user, String password, Uri proxyAddress = null)
            {
                this.user = user;
                this.password = password;
                this.proxyAddress = proxyAddress;
            }

            public Uri getProxyAddress()
            {
                return this.proxyAddress;
            }

            public Boolean needsHTTPBasicAuth()
            {
                return true;
            }
            public String getUser()
            {
                return this.user;
            }
            public String getPassword()
            {
                return this.password;
            }
            public String getClientId()
            {
                return null;
            }
            public String getClientSecret()
            {
                return null;
            }

            public EndpointAddress getEndpointAddress(String serviceName)
            {
                return new EndpointAddress("https://api.quantiguous.com/" + serviceName);
            }
            public Hashtable getHeaders()
            {
                return new Hashtable();
            }

            public System.Net.SecurityProtocolType getSecurityProtocol()
            {
                return System.Net.SecurityProtocolType.Tls;
            }
            public X509Certificate2 getClientCertificate()
            {
                return null;
            }
            public Boolean needsClientCertificate()
            {
                return false;
            }
        }
    }
}
