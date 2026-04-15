using StreetStatusAPI.Dtos.Common;
using StreetStatusAPI.Dtos.Streets;

namespace StreetStatusAPI.Services
{
    public interface IStreetService
    {
        Task<ResponseDto<List<StreetDto>>> GetAllAsync();
        Task<ResponseDto<StreetDto>> GetByIdAsync(string id);
        Task<ResponseDto<StreetActionResponseDto>> CreateAsync(StreetCreateDto dto);
        Task<ResponseDto<StreetActionResponseDto>> EditAsync(string id,StreetEditDto dto);
        Task<ResponseDto<StreetActionResponseDto>> DeleteAsync(string id);
    }
}

