using Newtonsoft.Json;
using System;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Web;

namespace Mvc {
    public class HttpClientHelper {
        internal static string Request(Uri url, HttpMethod method, string body = null) {
            string retVal = string.Empty;
            var response = default(HttpResponseMessage);

            HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            var error = default(Exception);
            try {
                if (method == HttpMethod.Get) {
                    response = client.GetAsync(url).Result;
                } else if (method == HttpMethod.Post) {
                    StringContent stringContent = new StringContent(body, Encoding.UTF8, "application/json");
                    response = client.PostAsync(url, stringContent).Result;
                }else if(method == HttpMethod.Put) {
                    StringContent stringContent = new StringContent(body, Encoding.UTF8, "application/json");
                    response = client.PutAsync(url, stringContent).Result;
                }
                if (response.StatusCode == HttpStatusCode.OK || response.StatusCode == HttpStatusCode.NoContent || response.StatusCode == HttpStatusCode.Created) {
                    AppTrace.Verbose($"Request succeded with statuscode: {response.StatusCode}");
                    retVal = response.Content.ReadAsStringAsync().Result;
                } else {

                    AppTrace.Verbose($"Request succeded with statuscode: {response.StatusCode}");
                    string message = response.Content.ReadAsStringAsync().Result;
                    dynamic errorResponse = JsonConvert.DeserializeObject<dynamic>(message, new JsonSerializerSettings {
                        NullValueHandling = NullValueHandling.Ignore
                    });
                    if (errorResponse.error != null) {
                        string errorMessage = $"Request failed with statuscode: {response.StatusCode}, with message {errorResponse.error.message}";
                        AppTrace.Error(errorMessage);
                        throw new HttpException(500, errorMessage);
                    } else {
                        AppTrace.Error($"Request failed with statuscode: {response.StatusCode}");
                        throw new HttpException(500, $"Invoice request failed {response.StatusCode}. With message {response.RequestMessage}");
                    }
                }
            } catch (HttpException ex) {
                error = ex;
            } finally {
                if (error != null) {
                    AppTrace.Error(error.Message);
                }
                client.Dispose();
            }
            AppTrace.Verbose("Processed request");
            return retVal;
        }
    }
}