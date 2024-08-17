using MagicVilla_Web.Models;
using MagicVilla_Web.Repository;

namespace MagicVilla_Web.Services.IServices
{
    public interface IBaseService
    {
        APIResponse responseModel { get; set; }
        Task<T> SendAsync<T>(ApiRequest apiRequest);
    }
}
