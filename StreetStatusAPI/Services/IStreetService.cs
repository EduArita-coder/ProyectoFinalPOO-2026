using StreetStatusAPI.Dtos.Common;
using StreetStatusAPI.Dtos.Streets;

namespace StreetStatusAPI.Services
{
    public interface IStreetService
    {
        Task<ResponseDto<List<StreetDto>>> GetAllAsync();
        Task<ResponseDto<StreetDto>> GetByIdAsync(int id);
        Task<ResponseDto<StreetActionResponseDto>> CreateAsync(StreetCreateDto dto);
    }
}

