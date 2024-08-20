using MagicVilla_Utility;
using MagicVilla_Web.Models;
using MagicVilla_Web.Models.DTO;
using MagicVilla_Web.Services.IServices;

namespace MagicVilla_Web.Services
{
    public class VillaService : BaseService, IVillaService
    {
        private readonly IHttpClientFactory _clientFactory;
        private string villaUrl;
        public VillaService(IHttpClientFactory clientFactory,IConfiguration configuration):base(clientFactory)
        {
            _clientFactory = clientFactory;
            villaUrl = configuration.GetValue<string>("ServiceUrls:VillAPI");
                
        }
        public Task<T> CreateAsync<T>(VillaCreateDTO dto)
        {
            return SendAsync<T>(new ApiRequest()
            {
                ApiType = SD.ApiType.POST,
                Data = dto,
                Url = villaUrl + "/api/VillApi"
            });

        }

        public Task<T> DeleteAsync<T>(int id)
        {
            return SendAsync<T>(new ApiRequest()
            {
                ApiType = SD.ApiType.DELETE,
                
                Url = villaUrl + "/api/VillApi/"+id
            });
        }

        public Task<T> GetAllAsync<T>()
        {
            return SendAsync<T>(new ApiRequest()
            {
                ApiType = SD.ApiType.GET,
                Url = villaUrl + "/api/VillApi"
            });
        }

        public Task<T> GetAsync<T>(int id)
        {
            return SendAsync<T>(new ApiRequest()
            {
                ApiType = SD.ApiType.GET,
                Url = villaUrl + "/api/VillApi/"+id
            });
        }

        public Task<T> UpdateAsync<T>(VillaUpdateDTO dto)
        {
            return SendAsync<T>(new ApiRequest()
            {
                ApiType = SD.ApiType.PUT,
                Data = dto,
                Url = villaUrl + "/api/VillApi/" + dto.Id
            });
        }
    }
}
