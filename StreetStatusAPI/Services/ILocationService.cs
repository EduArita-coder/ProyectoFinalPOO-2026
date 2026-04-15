using StreetStatusAPI.Dtos.Common;
using StreetStatusAPI.Dtos.Locations;

namespace StreetStatusAPI.Services
{
    public interface ILocationService
    {
        Task<ResponseDto<List<LocationDto>>> GetAllAsync();
        Task<ResponseDto<LocationDto>> GetByIdAsync(string id);
        Task<ResponseDto<LocationActionResponseDto>> CreateAsync(LocationCreateDto dto);
        Task<ResponseDto<LocationActionResponseDto>> EditAsync(string id, LocationEditDto dto);
        Task<ResponseDto<LocationActionResponseDto>> DeleteAsync(string id);
    }
}
