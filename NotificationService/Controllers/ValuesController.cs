using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace NotificationService.Controllers
{
    public class ValuesController : ApiController
    {
        // GET api/values
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/values/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/values
        public void Post([FromBody]string value)
        {
        }

        // PUT api/values/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        public void Delete(int id)
        {
        }
        public async Task<bool> SendMessageAsync()
        {
            string serverKey = "AAAA67j-JD0:APA91bEqRx134JkYtImqij5cs-rApLYbCdn6Jecd34_S6-dMM3zKEV6XzfO3u93De1U0pUBuAU8wm2lPtHMzTKiAMqvDPTQEUhNd7zBKYi9bGpMnreMtMZlcee_rF9kInGbWQJu4aXgF";
            string senderId = "1012420977725";
            try
            {
                var jsonMessage = JsonConvert.SerializeObject(new
                {
                    data = new { message = "This is a message"},                    
                });
                var firebaseURL = "https://fcm.googleapis.com/fcm/send";
                var request = new HttpRequestMessage(HttpMethod.Post, firebaseURL);
                request.Headers.TryAddWithoutValidation("Authorization", $"key={serverKey}");
                request.Headers.TryAddWithoutValidation("Sender", $"id={senderId}");
                request.Content = new StringContent(jsonMessage, System.Text.Encoding.UTF8, "application/json");

                HttpResponseMessage result;
                using (var client = new HttpClient())
                {
                    result = await client.SendAsync(request);
                }

                return result.IsSuccessStatusCode;
            }
            catch (Exception ex)
            {
                //  Response.Write(ex.Message);
                return false;
            }
        }
    }
}
