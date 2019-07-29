using Newtonsoft.Json;
using NotificationService.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;

namespace NotificationService.Controllers
{
    public class NotificationController : ApiController
    {
       

        public string DisconnectCall()
        {
            return "bhg";
        }
        
        //public void SendMessage()
        //{
        //    string serverKey = "AAAA67j-JD0:APA91bEqRx134JkYtImqij5cs-rApLYbCdn6Jecd34_S6-dMM3zKEV6XzfO3u93De1U0pUBuAU8wm2lPtHMzTKiAMqvDPTQEUhNd7zBKYi9bGpMnreMtMZlcee_rF9kInGbWQJu4aXgF";
        //    string senderId = "1012420977725";
        //    try
        //    {
        //        var result = "-1";
        //        var webAddr = "https://fcm.googleapis.com/fcm/send";

        //        var httpWebRequest = (HttpWebRequest)WebRequest.Create(webAddr);
        //        httpWebRequest.ContentType = "application/json";
        //        httpWebRequest.Headers.Add("Authorization:key=" + serverKey);
        //        httpWebRequest.Method = "POST";

        //        using (var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
        //        {
        //            string json = "{\"to\": \"Your device token\",\"data\": {\"message\": \"This is a Firebase Cloud Messaging Topic Message!\",}}";
        //            streamWriter.Write(json);
        //            streamWriter.Flush();
        //        }

        //        var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();
        //        using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
        //        {
        //            result = streamReader.ReadToEnd();
        //        }

        //        // return result;
        //    }
        //    catch (Exception ex)
        //    {
        //        //  Response.Write(ex.Message);
        //    }
        //}
        //public static async void SendPushNotification(string[] deviceTokens, string title, string body, object data)
        //{
        //    var messageInformation = new Message()
        //    {
        //        notification = new Notification()
        //        {
        //            title = title,
        //            text = body
        //        },
        //        data = data,
        //        registration_ids = deviceTokens
        //    };
        //    //Object to JSON STRUCTURE => using Newtonsoft.Json;
        //    string jsonMessage = JsonConvert.SerializeObject(messageInformation);
        //    string senderId = "1012420977725";
        //    string serverKey = "AAAA67j-JD0:APA91bEqRx134JkYtImqij5cs-rApLYbCdn6Jecd34_S6-dMM3zKEV6XzfO3u93De1U0pUBuAU8wm2lPtHMzTKiAMqvDPTQEUhNd7zBKYi9bGpMnreMtMZlcee_rF9kInGbWQJu4aXgF";
        //    // Create request to Firebase API
        //    var request = new HttpRequestMessage(HttpMethod.Post, "https://callnotification-96c2c.firebaseio.com");
        //    request.Headers.TryAddWithoutValidation("Authorization", serverKey);
        //    request.Headers.TryAddWithoutValidation("Sender", senderId);

        //    request.Content = new StringContent(jsonMessage, Encoding.UTF8, "application / json");
        //    HttpResponseMessage result;
        //    using (var client = new HttpClient())
        //    {
        //        result = await client.SendAsync(request);
        //    }          
        //}
        [HttpGet]
        public async Task<string> Getsend()
        {
            string token = "dgMv2_tsjAM:APA91bG3jgzmtJ6VjAM2XpP-WAesFdZWotW2fGCxO432MKc5NhxHh4EWUqaXXVophxuDYWv5l8mPlK7z3kRuq2_IL3ScgW9PjsPHG_v8JjjzP4lPjiqDCAbAOR0gemFRjG8FFDWB-X8v";
            string serverKey = "AAAA67j-JD0:APA91bEqRx134JkYtImqij5cs-rApLYbCdn6Jecd34_S6-dMM3zKEV6XzfO3u93De1U0pUBuAU8wm2lPtHMzTKiAMqvDPTQEUhNd7zBKYi9bGpMnreMtMZlcee_rF9kInGbWQJu4aXgF";
            string senderId = "1012420977725";
            var firebaseURL = "https://fcm.googleapis.com/fcm/send";
            try
            {
                var jsonMessage = JsonConvert.SerializeObject(new
                {
                    registration_ids = new[] { token },
                    data = new { body = "Data Body", title = "Data Title"},
                    priority = "high",
                    webpush = new { Urgency = "high"},
                    time_to_live = 0
                });
                var request = new HttpRequestMessage(HttpMethod.Post, firebaseURL);
                request.Headers.TryAddWithoutValidation("Authorization", $"key={serverKey}");
                request.Headers.TryAddWithoutValidation("Sender", $"id={senderId}");
                request.Content = new StringContent(jsonMessage, System.Text.Encoding.UTF8, "application/json");

                HttpResponseMessage result;
                using (var client = new HttpClient())
                {
                    result = await client.SendAsync(request);
                }

                return result.StatusCode.ToString();
            }
            catch (Exception ex)
            {
                //  Response.Write(ex.Message);
                return null;
            }
        }
    }
}