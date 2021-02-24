using System;
using System.Configuration;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace ClientBonusSystem
{
    public class CardApiClient
    {
        public HttpResponseMessage Get(string url)
        {
            try
            {
                var noSslHandler = new HttpClientHandler()
                {
                    ServerCertificateCustomValidationCallback = HttpClientHandler.DangerousAcceptAnyServerCertificateValidator
                };

                using (var client = new HttpClient(noSslHandler))
                {
                    var apiHostUrl = ConfigurationManager.AppSettings["ApiHostUrl"];

                    client.BaseAddress = new Uri(apiHostUrl);
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                    return client.GetAsync(url).Result;
                }                   
            }
            catch (Exception ex)
            {
                return new HttpResponseMessage
                {
                    StatusCode = System.Net.HttpStatusCode.InternalServerError,
                    ReasonPhrase = ex.Message
                };
            }
        }

        public HttpResponseMessage Post(string url, string postParams)
        {
            try
            {
                var noSslHandler = new HttpClientHandler()
                {
                    ServerCertificateCustomValidationCallback = HttpClientHandler.DangerousAcceptAnyServerCertificateValidator
                };

                using (var client = new HttpClient(noSslHandler))
                {                  
                    var apiHostUrl = ConfigurationManager.AppSettings["ApiHostUrl"];

                    client.BaseAddress = new Uri(apiHostUrl);
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));


                    var response = client.PostAsync(url, new StringContent(postParams, Encoding.UTF8, "application/json"));
                    response.Wait();


                    return response.Result;

                }
            }
            catch (Exception ex)
            {
                return new HttpResponseMessage
                {
                    StatusCode = System.Net.HttpStatusCode.InternalServerError,
                    ReasonPhrase = ex.Message
                };
            }
        }
    }
}