using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Windows.Forms;
using System.Net;
using System.IO;
using System.Collections.Specialized;
using System.Net.Http;
using System.Net.Http.Headers;

namespace ClassyApiWinForm
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        #region UI events

        private void cmdDeserialise_Click(object sender, EventArgs e)
        {
            //debugOutput(txtInput.Text);
            deserialiseJSON(txtInput.Text);
            CreateRequest();

        }

        private void cmdClear_Click(object sender, EventArgs e)
        {
            txtDebugOutput.Text = string.Empty;
        }

        #endregion

        #region json functions

        private void deserialiseJSON(string strJSON)
        {
            try
            {
                var jPerson = JsonConvert.DeserializeObject<Campaign>(strJSON);

                //var jPerson = JsonConvert.DeserializeObject<dynamic>(strJSON);

                //debugOutput("Here's our JSON object: " + jPerson.ToString());
                foreach (var num in jPerson.data)
                {
                    debugOutput("ID: " + num.id.ToString());
                    debugOutput("Name: " + num.name.ToString());
                    debugOutput("Status: " + num.status.ToString());
                    debugOutput(" ");
                }
                //debugOutput("Here's the ID of this campaign: " + jPerson.id.ToString());
                //debugOutput("Here's the name of this campaign: " + jPerson.name.ToString());
                //debugOutput("Here's the ID of this campaign: " + jPerson.id);
                //debugOutput("Here's the name of this campaign: " + jPerson.name);

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


        #region Post Request

        public string CreateRequest()
        {
            try
            {
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create("https://api.classy.org/oauth2/auth");
                request.Method = "POST";
                request.Host = "api.classy.org";
                request.ContentType = "application/x-www-form-urlencoded";
                string postData = "grant_type=client_credentials&client_id=LVcPCqPrcz1sJbYn&client_secret=zdvmtIzhrGXWbqNu";
                byte[] bytes = Encoding.UTF8.GetBytes(postData);
                request.ContentLength = bytes.Length;
                request.Timeout = 10000;

                //ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
                //ServicePointManager.SecurityProtocol = (SecurityProtocolType)3072;
                Stream requestStream = request.GetRequestStream();
                requestStream.Write(bytes, 0, bytes.Length);

                WebResponse response = request.GetResponse();
                Stream stream = response.GetResponseStream();
                StreamReader reader = new StreamReader(stream);

                var result = reader.ReadToEnd();
                stream.Dispose();
                reader.Dispose();

                return result;
            }
            catch (Exception ex)
            {
                debugOutput("Error : " + ex.Message);
                return "wrong";
            }
        }

        #endregion
         

        #region MakeRequest

        public string MakeRequest(string requestUrl)
        {

            return requestUrl;
        }


        #endregion
    }

}


//    Function MakeRequest(requestUrl As String) As String
//        Try
//            Dim request As HttpWebRequest = WebRequest.Create(requestUrl)
//            Using response As HttpWebResponse = request.GetResponse()
//                If(response.StatusCode<> HttpStatusCode.OK) Then
//                  Throw New Exception(String.Format(
//                        "Server error (HTTP {0}: {1}).",
//                      response.StatusCode,
//                      response.StatusDescription))
//                End If
//                Using responseStream As Stream = response.GetResponseStream()
//                    Dim reader As StreamReader = New StreamReader(responseStream, Encoding.GetEncoding("utf-8"))
//                    Dim jsonText As String = reader.ReadToEnd()
//                    Return jsonText
//                End Using
//            End Using
//        Catch e As Exception
//            SHIPPINGATTENTION.Value = SHIPPINGATTENTION.Value & "Error On Make Request"
//            Return ""
//        End Try
//    End Function



/***************************************************************************************************************/
//HttpWebRequest request = (HttpWebRequest)WebRequest.Create("https://api.classy.org/oauth2/auth");
//request.Method = "POST";
//request.Host = "api.classy.org";
//request.ContentType = "application/x-www-form-urlencoded";
//string postData = "grant_type=client_credentials&client_id=LVcPCqPrcz1sJbYn&client_secret=zdvmtIzhrGXWbqNu";
//byte[] bytes = Encoding.UTF8.GetBytes(postData);
//request.ContentLength = bytes.Length;

//Stream requestStream = request.GetRequestStream();
//requestStream.Write(bytes, 0, bytes.Length);

//WebResponse response = request.GetResponse();
//Stream stream = response.GetResponseStream();
//StreamReader reader = new StreamReader(stream);

//var result = reader.ReadToEnd();
//stream.Dispose();
//reader.Dispose();

//return result;
/*****************************************************************************************************************/



                //IEnumerable<KeyValuePair<string, string>> contents = new List<KeyValuePair<string, string>>()
            //{

            //};
            //HttpContent conts = new FormUrlEncodedContent(contents);
            //using (HttpClient client = new HttpClient())
            //{
            //    using (HttpResponseMessage response = await client.PostAsync(url, conts))
            //    {
            //        using (HttpContent content = response.Content)
            //        {
            //            string myContent = await content.ReadAsStringAsync();
            //            HttpContentHeaders headers = content.Headers;
            //            string x = myContent;
                        
            //        }
            //    }
            //}
