using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APIBanking
{
    public class FaultCode
    {   
        /* common error codes */
        public const String EC1 = "E5025";

        /* error codes specific to fundsTransferByCustomerService2 */
        public const String FT1 = "E8000";
        public const String FT2 = "E1003";
        public const String FT3 = "E1001";
        public const String FT4 = "E1002";
        public const String FT5 = "E405";
        public const String FT6 = "E403";
        public const String FT7 = "E2000";
        public const String FT8 = "E1028";
        public const String FT9 = "E1029";
        public const String FT10 = "E2005";
        public const String FT11 = "E501";
    }
}
