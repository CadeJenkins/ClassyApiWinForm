using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassyApiWinForm
{
    class FundraisingTeam
    {
        public List<FundraisingTeamData> data { get; set; }

        public string next_page_url { get; set; }
        public int last_page { get; set; }
        public int current_page { get; set; }

        public class FundraisingTeamData
        {
            public string name { get; set; }
            public string id { get; set; }
        }

    }
}
