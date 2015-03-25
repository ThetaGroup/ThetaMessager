using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThetaMessager.Utils
{
    class SendInfo
    {
        public string phoneNo;
        public string message;

        public SendInfo(string phoneNo, string message)
        {
            this.phoneNo = phoneNo;
            this.message = message;
        }
    }
}
