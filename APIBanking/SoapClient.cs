using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel.Channels;
using System.ServiceModel;

namespace APIBanking
{
    public class SoapClient
    {
        public static String generateGUID()
        {
            return System.Guid.NewGuid().ToString("N"); 
        }
        protected static CustomBinding getBinding(Environment env)
        {
            // https only
            HttpsTransportBindingElement httpsBindingElement = new HttpsTransportBindingElement();

            // basic auth when required
            if (env.needsHTTPBasicAuth())
            {
                httpsBindingElement.AuthenticationScheme = System.Net.AuthenticationSchemes.Basic;
            }

            // client certificates when required 
            if (env.needsClientCertificate())
            {
                httpsBindingElement.RequireClientCertificate = true;
            }

            // proxy when required
            if (env.getProxyAddress() != null)
            {
                httpsBindingElement.ProxyAddress = env.getProxyAddress();
                httpsBindingElement.BypassProxyOnLocal = false;
                httpsBindingElement.UseDefaultWebProxy = false;
            }


            // soap 1.2
            CustomTextMessageBindingElement textBindingElement = new CustomTextMessageBindingElement("iso-8859-1", "application/soap+xml", MessageVersion.Soap12);

            // we create the binding
            ICollection<BindingElement> bindingElements = new List<BindingElement>();
            bindingElements.Add(textBindingElement);
            bindingElements.Add(httpsBindingElement);
            CustomBinding binding = new CustomBinding(bindingElements);

            return binding;

        }
    }
}
