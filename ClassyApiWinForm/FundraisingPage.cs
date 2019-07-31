using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassyApiWinForm
{
    class FundraisingPage
    {
        public List<FundraisingPageData> data { get; set; }

        public string next_page_url { get; set; }
        public int last_page { get; set; }
        public int current_page { get; set; }

        public class FundraisingPageData
        {
           // public string name { get; set; }
            public string id { get; set; }
            public string title { get; set; }
            public string member_id { get; set; }
        }
    }
}
