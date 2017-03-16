using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using System.Net.Http;
using FXProducer.Models;
using System.Net.Http.Headers;
using Newtonsoft.Json;
using System.Text;
using System.Dynamic;

namespace FXProducer.Controllers
{
    public class TrafficController : Controller
    {
        private enum EventSource { LandingPage, FacebookTab, Microsite, Web };
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<JsonResult> SendData(Traffic webTraffic)
        {
            try
            {
                using (var httpClient = new HttpClient())
                {
                    //post data structure
                    dynamic jsonData = new ExpandoObject();
                    jsonData.message = JsonConvert.SerializeObject(webTraffic);
                    jsonData.topic = ConfigVars.Instance.KafkaTopic;

                    httpClient.DefaultRequestHeaders.Accept.Clear();
                    httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                    HttpRequestMessage request = new HttpRequestMessage
                    {
                        Content = new StringContent(JsonConvert.SerializeObject(jsonData), Encoding.UTF8, "application/json"),
                        Method = HttpMethod.Post,
                        RequestUri = new Uri(string.Format("{0}", ConfigVars.Instance.EnpointUrl))
                    };
                    var response = await httpClient.SendAsync(request);
                    return Json(response);
                }
            }
            catch (Exception exception)
            {
                return Json(null);
            }
        }

        public IActionResult Error()
        {
            return View();
        }
    }
}
