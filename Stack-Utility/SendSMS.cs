using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Net;
using System.Configuration;
using System.Web;
using System.Security.Cryptography.X509Certificates;
using System.Net.Security;

namespace Syntizen.Utilities.SMS
{
    public class SMSSender
    {
        public static string SendSMS(String username, String password, String messageType, String msg_token, String from, String to, String message, String text)
        {
            try
            {
                  
                //Create URI  

                // string uri = "https://" + ConfigurationManager.AppSettings["SMSServerUrl"] + "/smpp/sendsms?username=<username>&password=<password>&messageType=<messageType>&msg_token=<msg_token>&from=<from>&to=<mobile>&message=<msg>&text=<text>";
             
                string uri = "http://" + ConfigurationManager.AppSettings["SMSServerUrl"] + "/smpp/sendsms?username=<username>&password=<password>&from=<from>&to=<mobile>&text=<text>";
              //  string uri = "https://" + ConfigurationManager.AppSettings["SMSServerUrl"] + "/?username=<username>&password=<password>&messageType=<messageType>&msg_token=<msg_token>&from=<from>&to=<mobile>&message=<msg>&text=<text>";
               // ServicePointManager.ServerCertificateValidationCallback = delegate(object s, X509Certificate certificate, X509Chain chain, SslPolicyErrors sslPolicyErrors) { return true; };
                
                //Set User Parameters                
                uri = uri.Replace("<username>", username);
                uri = uri.Replace("<password>", password);
                uri = uri.Replace("<from>", from);
                uri = uri.Replace("<mobile>", to);
                uri = uri.Replace("<msg>", message);
                uri = uri.Replace("<text>", text);
                uri = uri.Replace("<messageType>", messageType);
                uri = uri.Replace("<msg_token>", msg_token);
                   
             
                // Create a request for the URL. 
                WebRequest request = WebRequest.Create(uri);

                // If required by the server, set the credentials.
                request.Credentials = CredentialCache.DefaultCredentials;
                // Get the response.
                WebResponse response = request.GetResponse();
                // Display the status.
                //Console.WriteLine(((HttpWebResponse)response).StatusDescription);
                // Get the stream containing content returned by the server.
                Stream dataStream = response.GetResponseStream();
                // Open the stream using a StreamReader for easy access.
                StreamReader reader = new StreamReader(dataStream);
                // Read the content.
                string responseFromServer = reader.ReadToEnd();
                // Display the content.
                //MessageBox.Show(StripHTML(responseFromServer));
                // Clean up the streams and the response.
                reader.Close();
                response.Close();

                return responseFromServer;
                           
            }
            catch (Exception ex)
            {
                //throw ex;
                return "FAILED : 501 SERVER ERROR + | " + ex.Message;
            }
        }        
    }
}
