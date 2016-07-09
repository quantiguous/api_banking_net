using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APIBanking
{
    class Fault : SystemException
    {
        private String code;
        private String subCode;
        private String reasonText;

        public Fault(String code, String subCode, String reasonText)
        {
            this.code = code;
            this.subCode = subCode;
            this.reasonText = reasonText;
        }

        public void setCode(String code)
        {
            this.code = code;
        }
        public void setSubCode(String subCode)
        {
            this.subCode = subCode;
        }
        public void setReasonText(String reasonText)
        {
            this.reasonText = reasonText;
        }
    }
}
