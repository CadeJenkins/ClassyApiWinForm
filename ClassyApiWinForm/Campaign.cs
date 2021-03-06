﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace ClassyApiWinForm
{
    class Campaign
    { 
        public List<CampaignData> data { get; set; }

        public string next_page_url { get; set; }
        public int last_page { get; set; }
        public int current_page { get; set; }


        public class CampaignData
        {
            public string name { get; set; }
            public string id { get; set; }
            public string status { get; set; }
            public string ended_at { get; set; }
        }
    }
}
