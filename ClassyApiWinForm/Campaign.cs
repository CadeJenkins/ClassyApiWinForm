﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassyApiWinForm
{
    class Campaign
    {
        public List<CampaignData> data { get; set; }

        public class CampaignData
        {
            public string name { get; set; }
            public string id { get; set; }
            public string status { get; set; }
        }
    }
}