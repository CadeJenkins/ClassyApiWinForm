using System;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Windows.Forms;
using System.Net;
using System.IO;
using System.Net.Http;
using System.Web;
using System.Globalization;


namespace ClassyApiWinForm
{
    public partial class Form1 : Form
    {
        string[] campaignID = new string[999];
        string[] campaignName = new string[999];
        string[] isActive = new string[999];
        string[] endDate = new string[999];
        string[] activeCampaigns = new string[999];
        string[] activeMemberIds = new string[999];
        public string[,] MemberInfo = new string[3,999];   //2d array
        public int timeout = 200000;


        string fundraiseUrlBeg ="https://api.classy.org/2.0/campaigns/";
        string fundraiseTeamUrlEnd = "/fundraising-teams?per_page=100";
        string fundraisePageUrlEnd = "/fundraising-pages?per_page=100";

        string MembersUrl = "https://api.classy.org/2.0/organizations/11145/supporters?filter=member_id=";

        string nextCampaignPage = "";
        int lastPage = 0;
        int currentPage = 0;

        int counter = 0;

        DateTime currentTime = DateTime.Now;
       

        public Form1()
        {
            InitializeComponent();
        }

        #region UI events

        private async void cmdDeserialise_Click(object sender, EventArgs e)
        {
            string token = GetToken("https://api.classy.org/oauth2/auth");
            debugOutput(token);

            debugOutput("");

            string rawJSON = await MakeRequest("https://api.classy.org/2.0/organizations/11145/campaigns?per_page=100", token);
            txtInput.Text = txtInput.Text + rawJSON;
            debugOutput("");

            deserialiseJSON(txtInput.Text);

            while (currentPage < lastPage)
            {
                rawJSON = await MakeRequest(nextCampaignPage, token);
                txtInput.Text = txtInput.Text + rawJSON;
                debugOutput("");
                deserialiseJSON(rawJSON);
            }

            GetActiveCampaigns();

            //BuildFundraisingTeamsUrl(token);

            //BuildFundraisingPagesUrl(token);

            //BuildMemberInfoUrl(token, id);
        }

        private void cmdClear_Click(object sender, EventArgs e)
        {
            txtDebugOutput.Text = string.Empty;
            txtActiveResults.Text = string.Empty;
           //Was seeing the format of time (not needed here) => txtFundraisingPages.Text = currentTime.ToString();
        }

        private void cmdClearJson_Click(object sender, EventArgs e)
        {
            txtInput.Text = "";
        }


        #endregion

        #region json functions

        public void deserialiseJSON(string strJSON)
        {

            try
            {
                var jPerson = JsonConvert.DeserializeObject<Campaign>(strJSON);

                lastPage = jPerson.last_page;
                currentPage = jPerson.current_page;

                try
                {
                    nextCampaignPage = jPerson.next_page_url.ToString();
                }
                catch
                {
                    if (jPerson.next_page_url == null)
                    {
                        nextCampaignPage = "No more Pages.";
                    }
                }

                foreach (var num in jPerson.data)
                {
                    debugOutput("ID: " + num.id.ToString());
                    debugOutput("Name: " + num.name.ToString());
                   // debugOutput("Status: " + num.status.ToString());
                    debugOutput(" ");

                    campaignID[counter] = num.id.ToString();
                    campaignName[counter] = num.name.ToString();
                    isActive[counter] = num.status.ToString();

                    try
                    {
                        endDate[counter] = num.ended_at.ToString();
                    }
                    catch
                    {
                        endDate[counter] = "0";
                    }

                    counter++;
                }
            }
            catch (Exception ex)
            {
                debugOutput("We had a problem: " + ex.Message.ToString());
            }
        }

        #endregion

        #region Debug Output

        private void debugOutput(string strDebugText)
        {
            try
            {
                System.Diagnostics.Debug.Write(strDebugText + Environment.NewLine);
                txtDebugOutput.Text = txtDebugOutput.Text + strDebugText + Environment.NewLine;
                txtDebugOutput.SelectionStart = txtDebugOutput.TextLength;
                txtDebugOutput.ScrollToCaret();
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.Write(ex.Message.ToString() + Environment.NewLine);
            }
        }

        #endregion

        #region Final Output
        private void finalOutput(string strDebugText)
        {
            try
            {
                System.Diagnostics.Debug.Write(strDebugText + Environment.NewLine);
                txtActiveResults.Text = txtActiveResults.Text + strDebugText + Environment.NewLine;
                txtActiveResults.SelectionStart = txtActiveResults.TextLength;
                txtActiveResults.ScrollToCaret();
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.Write(ex.Message.ToString() + Environment.NewLine);
            }
        }

        #endregion

        #region FT Output

        private void ftOutput(string strDebugText)
        {
            try
            {
                System.Diagnostics.Debug.Write(strDebugText + Environment.NewLine);
                txtFundraisingTeams.Text = txtFundraisingTeams.Text + strDebugText + Environment.NewLine;
                txtFundraisingTeams.SelectionStart = txtFundraisingTeams.TextLength;
                txtFundraisingTeams.ScrollToCaret();
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.Write(ex.Message.ToString() + Environment.NewLine);
            }
        }

        #endregion

        #region FP Output

        private void fpOutput(string strDebugText)
        {
            try
            {
                System.Diagnostics.Debug.Write(strDebugText + Environment.NewLine);
                txtFundraisingPages.Text = txtFundraisingPages.Text + strDebugText + Environment.NewLine;
                txtFundraisingPages.SelectionStart = txtFundraisingPages.TextLength;
                txtFundraisingPages.ScrollToCaret();
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.Write(ex.Message.ToString() + Environment.NewLine);
            }
        }

        #endregion

        #region MemberOutput

        private void MemberOutput(string strDebugText)
        {
            try 
            {
                System.Diagnostics.Debug.Write(strDebugText + Environment.NewLine);
                txtMembers.Text = txtMembers.Text + strDebugText + Environment.NewLine;
                txtMembers.SelectionStart = txtMembers.TextLength;
                txtMembers.ScrollToCaret();
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.Write(ex.Message.ToString() + Environment.NewLine);
            }
        }

        #endregion

        #region GetToken
        public string GetToken(string url)
        {
            string request = string.Format("grant_type=client_credentials&client_id={0}&client_secret={1}&audience={2}"
                                , HttpUtility.UrlEncode(APIRequestConstants.ClientId),
                                  HttpUtility.UrlEncode(APIRequestConstants.ClientSecret), "aws-dev-api");
            HttpWebRequest webRequest = (HttpWebRequest)WebRequest.Create(url);
            webRequest.ContentType = "application/x-www-form-urlencoded";
            webRequest.Method = "POST";
            webRequest.Host = "api.classy.org";
            byte[] bytes = Encoding.ASCII.GetBytes(request);
            webRequest.ContentLength = bytes.Length;
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls
                                     | SecurityProtocolType.Tls11
                                     | SecurityProtocolType.Tls12;

            try
            {
                Stream outputStream = webRequest.GetRequestStream();
                outputStream.Write(bytes, 0, bytes.Length);
                outputStream.Close();
            }
            catch (Exception ex)
            {
                debugOutput("Error: " + ex.Message);
            }

            try
            {
                WebResponse webResponse = webRequest.GetResponse();

                using (var reader = new StreamReader(webResponse.GetResponseStream()))
                {
                    string result = reader.ReadToEnd();
                    //var res = JsonConvert.DeserializeObject<TokenResponse>(result);
                    var res = JsonConvert.DeserializeObject<dynamic>(result);
                    if (!string.IsNullOrEmpty(result))
                    {
                        return res.access_token.ToString();
                    }
                    else return "NOPE";
                }
            }
            catch (Exception ex)
            {
                debugOutput("Error: " + ex.Message);
                return "NOPE!!!";
            }
        }

        #endregion


        #region MakeRequest

        public async Task<string> MakeRequest(string requestUrl, string token)
        {
            string response = "";
            try
            {
                using (HttpClient client = new HttpClient())
                {
                    client.DefaultRequestHeaders.Add("Authorization", "Bearer " + token);
                    response = await client.GetStringAsync(requestUrl.ToString());
                }
            }
            catch (HttpRequestException e)
            {
                Console.WriteLine(e.InnerException.Message);
            }
            return response;
        }

        #endregion


        #region GetActiveCampaigns

        public void GetActiveCampaigns()
        {
            int activeCounter = 0;
            for(int i = 0; i < endDate.Length; i++)
            {
                if ((isActive[i] == "active" || isActive[i] == "Active") &&
                     (endDate[i] == "0" || Convert.ToDateTime(endDate[i]).AddDays(30) > currentTime))
                {
                    finalOutput(campaignID[i]);
                    finalOutput(campaignName[i]);
                    finalOutput(isActive[i]);
                    finalOutput("");

                    activeCampaigns[activeCounter] = campaignID[i];

                    activeCounter++;
                }
            }
            txtActiveResults.Text = txtActiveResults.Text + Environment.NewLine + "Active Campaigns: " + activeCounter;

        }
        #endregion


        #region BuildFundraisingTeamsUrl
        void BuildFundraisingTeamsUrl(string token)
        {

            string fundraiseTeamFullUrl = "";

            for (int i = 0; i < activeCampaigns.Length; i++)
            {
                try
                {
                    fundraiseTeamFullUrl = fundraiseUrlBeg + activeCampaigns[i].ToString() + fundraiseTeamUrlEnd;
                    //fundraisingTeamsJsonResponse = await MakeRequest(fundraiseTeamFullUrl, token);
                    //deserialiseFtJson(fundraisingTeamsJsonResponse, ref counter);
                    GetFtPages(fundraiseTeamFullUrl, token);
                }
                catch
                {
                    i = activeCampaigns.Length;
                }
            }
        }

        #endregion

        async
        #region GetFTPages

        void GetFtPages(string FtPageUrl, string token)
        {
            string fundraisingTeamsJsonResponse = "";
            string nextFtPage = "";
            int ftLastPage = 0;
            int ftCurrentPage = 0;
            int ftCounter = 0;
            string rawJSON = "";

            fundraisingTeamsJsonResponse = await MakeRequest(FtPageUrl, token);
            deserialiseFtJson(fundraisingTeamsJsonResponse, ref ftCounter, ref ftLastPage, ref ftCurrentPage, ref nextFtPage);

            while (ftCurrentPage < ftLastPage)
            {
                rawJSON = await MakeRequest(nextFtPage, token);
                deserialiseFtJson(rawJSON, ref ftCounter, ref ftLastPage, ref ftCurrentPage, ref nextFtPage);
            }
        }

        #endregion


        #region deserialiseFtJson

        public void deserialiseFtJson(string strJSON, ref int ftCounter, ref int ftLastPage, ref int ftCurrentPage, ref string nextFtPage)
        {

            try
            {
                var jFTeams = JsonConvert.DeserializeObject<FundraisingTeam>(strJSON);

                ftLastPage = jFTeams.last_page;
                ftCurrentPage = jFTeams.current_page;

                try
                {
                    nextFtPage = jFTeams.next_page_url.ToString();
                }
                catch
                {
                    if (jFTeams.next_page_url == null)
                    {
                        nextFtPage = "No more Pages.";
                    }
                }

                foreach (var num in jFTeams.data)
                {
                    //ftOutput("ID: " + num.id.ToString());
                    //ftOutput("Name: " + num.name.ToString());
                    //ftOutput(" ");

                    ftCounter++;
                    //campaignID[counter] = num.id.ToString();
                    //campaignName[counter] = num.name.ToString();
                }
                //ftOutput("");
                ftOutput("Number of FtPages: " + ftCounter);
                counter = 0;
            }
            catch (Exception ex)
            {
                debugOutput("We had a problem: " + ex.Message.ToString());
            }
        }

        #endregion

        #region BuildFundraisingPagesUrl

        void BuildFundraisingPagesUrl(string token)
        {
            //string fundraisingPagesJsonResponse = "";
            string fundraisePageFullUrl = "";

            for (int i = 0; i < activeCampaigns.Length; i++)
            {
                try
                {
                    fundraisePageFullUrl = fundraiseUrlBeg + activeCampaigns[i].ToString() + fundraisePageUrlEnd;
                    //fundraisingPagesJsonResponse = "";
                    //fundraisingPagesJsonResponse = await MakeRequest(fundraisePageFullUrl, token);
                    GetFpPages(fundraisePageFullUrl, token);
                }
                catch
                {
                    i = activeCampaigns.Length;
                }
            }
        }

        #endregion

        async
        #region GetFpPages

        void GetFpPages(string FpPageUrl, string token)
        {
            string fundraisingPagesJsonResponse = "";
            string nextFpPage = "";
            int fpLastPage = 0;
            int fpCurrentPage = 0;
            int fpCounter = 0;
            string rawJSON = "";

            fundraisingPagesJsonResponse = await MakeRequest(FpPageUrl, token);
            deserialiseFpJson(fundraisingPagesJsonResponse, ref fpCounter, ref fpLastPage, ref fpCurrentPage, ref nextFpPage, token);

            while (fpCurrentPage < fpLastPage)
            {
                rawJSON = await MakeRequest(nextFpPage, token);
                deserialiseFpJson(rawJSON, ref fpCounter, ref fpLastPage, ref fpCurrentPage, ref nextFpPage, token);
            }
        }

        #endregion


        #region deserialiseFpJson

        public void deserialiseFpJson(string strJSON, ref int fpCounter, ref int fpLastPage, ref int fpCurrentPage, ref string nextFpPage, string token)
        {

            try
            {
                var jFPages = JsonConvert.DeserializeObject<FundraisingPage>(strJSON);

                fpLastPage = jFPages.last_page;
                fpCurrentPage = jFPages.current_page;

                try
                {
                    nextFpPage = jFPages.next_page_url.ToString();
                }
                catch
                {
                    if (jFPages.next_page_url == null)
                    {
                        nextFpPage = "No more Pages.";
                    }
                }

                //This is where I would insert the data into a table.
                foreach (var num in jFPages.data)
                {
                    // fpOutput("ID: " + num.id.ToString());
                    //fpOutput("Name: " + num.name.ToString());
                    // fpOutput("Title: " + num.title.ToString());
                    //fpOutput(" ");
                    activeMemberIds[fpCounter] = num.member_id.ToString();

                    BuildMemberInfoUrl(token, num.member_id.ToString(), fpCounter);

                    fpCounter++;
                    //campaignID[counter] = num.id.ToString();
                    //campaignName[counter] = num.name.ToString();
                }
                fpOutput("");
                fpOutput("Number of FpPages: " + fpCounter);
            }
            catch (Exception ex)
            {
                debugOutput("We had a problem: " + ex.Message.ToString());
            }
        }

        #endregion

        #region BuildMemberInfoUrl

        void BuildMemberInfoUrl(string token, string id, int fpCounter)
        {
            string fullMemberUrl = "";
                try
                {
                    fullMemberUrl = MembersUrl + activeMemberIds[fpCounter].ToString();
                    GetMemberInfo(fullMemberUrl, token);
                }
                catch(Exception ex)
                {
                    ex.Message.ToString();
                }                  
        }

        #endregion


       #region GetMemberInfo
       async
       void GetMemberInfo(string fullMemberUrl, string token)
        {
            string membersResponse = "";
            int memberCounter = 0;

            membersResponse = await MakeRequest(fullMemberUrl, token);
            deserialiseMemberInfo(membersResponse, ref memberCounter);
        }

        #endregion

        #region deserialiseMemberInfo

        void deserialiseMemberInfo(string rawJSON, ref int memberCounter)
        {
            try
            {
                //var jMembers = JsonConvert.DeserializeObject<MemberInfo>(rawJSON);
                var jMembers = JsonConvert.DeserializeObject<MemberInfo>(rawJSON);
                //This is where I would insert the member data into a table.
                //foreach (var num in jMembers.data)
                //{
                var num = jMembers.data[0];
                    MemberInfo[0, memberCounter] = num.first_name;
                    MemberInfo[1, memberCounter] = num.last_name;
                    //MemberInfo[2, memberCounter] = num.email_address;

                    MemberOutput(num.first_name);
                    MemberOutput(num.last_name);
                    //MemberOutput(num.email_address);

                    memberCounter++;
               // }

            }
            catch (Exception ex)
            {
                debugOutput("We had a problem: " + ex.Message.ToString());
            }
        }

        #endregion
    }
}




//Was the original GetCampaigns

//for (int i = 0; i < isActive.Length; i++)
//{
//    if (isActive[i] == "active" || isActive[i] == "Active")
//    {
//        finalOutput(campaignID[i]);
//        finalOutput(campaignName[i]);
//        finalOutput(isActive[i]);
//        finalOutput("");

//if (campaignID[i] == "118127")
//{
//    finalOutput("Number of Active Campaigns: " + i);
//}
//    }
//}