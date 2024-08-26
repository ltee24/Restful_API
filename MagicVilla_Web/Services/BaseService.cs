using MagicVilla_Utility;
using MagicVilla_Web.Models;
using MagicVilla_Web.Repository;
using MagicVilla_Web.Services.IServices;
using Newtonsoft.Json;
using System.Text;

namespace MagicVilla_Web.Services
{
    public class BaseService : IBaseService
    {
        public APIResponse responseModel { get;  set; }
        public IHttpClientFactory httpClient { get; set; }
        public BaseService(IHttpClientFactory httpClientFactory)
        {
            this.responseModel = new();
            this.httpClient = httpClientFactory;
                
        }

        public async Task<T> SendAsync<T>(ApiRequest apiRequest)
        {
            try
            {
                var client = httpClient.CreateClient("MagicApi");
                HttpRequestMessage message = new HttpRequestMessage();
                message.Headers.Add("Accept", "application/json");
                message.RequestUri = new Uri(apiRequest.Url);
                if (apiRequest.Data != null)
                {
                    message.Content = new StringContent(JsonConvert.SerializeObject(apiRequest.Data), Encoding.UTF8, "application/json");
                }
                switch (apiRequest.ApiType)
                {
                    case SD.ApiType.POST:
                        message.Method = HttpMethod.Post;
                        break;
                    case SD.ApiType.DELETE:
                        message.Method = HttpMethod.Delete;
                        break;
                    case SD.ApiType.PUT:
                        message.Method = HttpMethod.Put;
                        break;
                    default:
                        message.Method = HttpMethod.Get;
                        break;
                }
                HttpResponseMessage apiResponse = null;
                apiResponse = await client.SendAsync(message);
                var apiContent = await apiResponse.Content.ReadAsStringAsync();
               
                try
                {
                    APIResponse APIResponse = JsonConvert.DeserializeObject<APIResponse>(apiContent);
                    if(apiResponse.StatusCode==System.Net.HttpStatusCode.BadRequest || apiResponse.StatusCode==System.Net.HttpStatusCode.NotFound)
                    {
                        APIResponse.StatusCode = System.Net.HttpStatusCode.BadRequest;
                        APIResponse.IsSuccess = false;
                        var res = JsonConvert.SerializeObject(APIResponse);
                        var returnObj = JsonConvert.DeserializeObject<T>(res);
                        return returnObj;
                    }
                }
                catch(Exception e)
                {
                    var ExceptionResponse = JsonConvert.DeserializeObject<T>(apiContent);
                    return ExceptionResponse;

                }
                var ApiResponse = JsonConvert.DeserializeObject<T>(apiContent);
                return ApiResponse;


            }
            catch (Exception e)
            {
                var dto = new APIResponse
                {
                    ErrorMessages = new List<string> { Convert.ToString(e.Message) },
                    IsSuccess = false
                };
                var res = JsonConvert.SerializeObject(dto);
                var ApiResponse = JsonConvert.DeserializeObject<T>(res);
                return ApiResponse;
            }
        }
                

        
    }
}
