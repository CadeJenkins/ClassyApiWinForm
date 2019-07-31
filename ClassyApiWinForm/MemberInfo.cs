using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassyApiWinForm
{
    class MemberInfo
    {
        public List<MemberInfoDetails> data { get; set; }
        
        public class MemberInfoDetails
        {
            public string first_name { get; set; }
            public string last_name { get; set; }
            //public string email_address { get; set; }

            //string nickname { get; set; }
        }
    }
}
