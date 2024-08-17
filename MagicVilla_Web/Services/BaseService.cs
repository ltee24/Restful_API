using MagicVilla_Web.Models;
using MagicVilla_Web.Repository;
using MagicVilla_Web.Services.IServices;

namespace MagicVilla_Web.Services
{
    public class BaseService : IBaseService
    {
        public APIResponse responseModel { get;  set; }
        public BaseService()
        {
            this.responseModel = new();
                
        }

        public Task<T> SendAsync<T>(ApiRequest apiRequest)
        {
            throw new NotImplementedException();
        }
    }
}
