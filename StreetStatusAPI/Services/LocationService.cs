using StreetStatusAPI.Constants;
using StreetStatusAPI.Database;
using StreetStatusAPI.Dtos.Common;
using StreetStatusAPI.Dtos.Locations;
using StreetStatusAPI.Entities;
using StreetStatusAPI.Mappers;
using Microsoft.EntityFrameworkCore;

namespace StreetStatusAPI.Services
{
    public class LocationService : ILocationService
    {
        private readonly StreetDbContext _context;

        public LocationService(StreetDbContext context)
        {
            _context = context;
        }

        public async Task<ResponseDto<List<LocationDto>>> GetAllAsync()
        {
            var locations = await _context.Locations.ToListAsync();

            return new ResponseDto<List<LocationDto>>
            {
                StatusCode = HttpStatusCode.OK,
                Status = true,
                Message = HttpMessageResponse.REGISTERS_FOUND,
                Data = LocationMapper.ListEntityToListDto(locations)
            };
        }

        public async Task<ResponseDto<LocationDto>> GetByIdAsync(string id)
        {
            var location = await _context.Locations.FirstOrDefaultAsync(l => l.Id == id);

            if (location is null)
            {
                return new ResponseDto<LocationDto>
                {
                    StatusCode = HttpStatusCode.NOT_FOUND,
                    Status = false,
                    Message = HttpMessageResponse.REGISTER_NOT_FOUND
                };
            }

            return new ResponseDto<LocationDto>
            {
                StatusCode = HttpStatusCode.OK,
                Status = true,
                Message = HttpMessageResponse.REGISTER_FOUND,
                Data = LocationMapper.EntityToDto(location)
            };
        }

        public async Task<ResponseDto<LocationActionResponseDto>> CreateAsync(LocationCreateDto dto)
        {
            var duplicatedLocation = await _context.Locations.AnyAsync(l =>
                l.City == dto.City &&
                l.Street == dto.Street &&
                l.ZipCode == dto.ZipCode);

            if (duplicatedLocation)
            {
                return new ResponseDto<LocationActionResponseDto>
                {
                    StatusCode = HttpStatusCode.CONFLICT,
                    Status = false,
                    Message = "La ubicacion ya existe."
                };
            }

            Location location = LocationMapper.CreateDtoToEntity(dto);

            _context.Locations.Add(location);
            await _context.SaveChangesAsync();

            return new ResponseDto<LocationActionResponseDto>
            {
                StatusCode = HttpStatusCode.CREATED,
                Status = true,
                Message = HttpMessageResponse.REGISTER_CREATED,
                Data = new LocationActionResponseDto
                {
                    Id = location.Id
                }
            };
        }

        public async Task<ResponseDto<LocationActionResponseDto>> EditAsync(string id, LocationEditDto dto)
        {
            var locationEntity = await _context.Locations.FirstOrDefaultAsync(l => l.Id == id);

            if (locationEntity is null)
            {
                return new ResponseDto<LocationActionResponseDto>
                {
                    StatusCode = HttpStatusCode.NOT_FOUND,
                    Status = false,
                    Message = HttpMessageResponse.REGISTER_NOT_FOUND
                };
            }

            var duplicatedLocation = await _context.Locations.AnyAsync(l =>
                l.Id != id &&
                l.City == dto.City &&
                l.Street == dto.Street &&
                l.ZipCode == dto.ZipCode);

            if (duplicatedLocation)
            {
                return new ResponseDto<LocationActionResponseDto>
                {
                    StatusCode = HttpStatusCode.CONFLICT,
                    Status = false,
                    Message = "La ubicacion ya existe."
                };
            }

            var locationEntityUpdated = LocationMapper.EditDtoToEntity(locationEntity, dto);
            _context.Locations.Update(locationEntityUpdated);
            await _context.SaveChangesAsync();

            return new ResponseDto<LocationActionResponseDto>
            {
                StatusCode = HttpStatusCode.OK,
                Status = true,
                Message = HttpMessageResponse.REGISTER_UPDATED,
                Data = new LocationActionResponseDto
                {
                    Id = id
                }
            };
        }

        public async Task<ResponseDto<LocationActionResponseDto>> DeleteAsync(string id)
        {
            var locationEntity = await _context.Locations
                .Include(l => l.Streets)
                .FirstOrDefaultAsync(l => l.Id == id);

            if (locationEntity is null)
            {
                return new ResponseDto<LocationActionResponseDto>
                {
                    StatusCode = HttpStatusCode.NOT_FOUND,
                    Status = false,
                    Message = HttpMessageResponse.REGISTER_NOT_FOUND
                };
            }

            if (locationEntity.Streets.Any())
            {
                return new ResponseDto<LocationActionResponseDto>
                {
                    StatusCode = HttpStatusCode.CONFLICT,
                    Status = false,
                    Message = "No se puede eliminar la ubicacion porque tiene calles asociadas."
                };
            }

            _context.Locations.Remove(locationEntity);
            await _context.SaveChangesAsync();

            return new ResponseDto<LocationActionResponseDto>
            {
                StatusCode = HttpStatusCode.OK,
                Status = true,
                Message = HttpMessageResponse.REGISTER_DELETED,
                Data = new LocationActionResponseDto
                {
                    Id = id
                }
            };
        }
    }
}
