using MagicVilla_Web.Models.DTO;

namespace MagicVilla_Web.Services.IServices
{
    public interface IVillaNumberService
    {
        Task<T> GetAllAsync<T>();
        Task<T> GetAsync<T>(int id);
        Task<T> CreateAsync<T>(VillaCreateNumberDTO dto);
        Task<T> UpdateAsync<T>(VillaUpdateNumberDTO dto);
        Task<T> DeleteAsync<T>(int id);
    }
}
