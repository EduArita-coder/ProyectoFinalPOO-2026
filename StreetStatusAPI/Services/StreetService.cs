using Microsoft.EntityFrameworkCore;
using StreetStatusAPI.Constants;
using StreetStatusAPI.Database;
using StreetStatusAPI.Dtos.Common;
using StreetStatusAPI.Dtos.Streets;
using StreetStatusAPI.Entities;
using StreetStatusAPI.Mappers;

namespace StreetStatusAPI.Services
{
    public class StreetService : IStreetService
    {
        private readonly StreetDbContext _context;

        public StreetService(StreetDbContext context)
        {
            _context = context;
        }

        public async Task<ResponseDto<List<StreetDto>>> GetAllAsync()
        {
            var streets = await _context.Streets
                .Include(s => s.Location)
                .ToListAsync();

            return new ResponseDto<List<StreetDto>>
            {
                StatusCode = HttpStatusCode.OK,
                Status = true,
                Message = HttpMessageResponse.REGISTERS_FOUND,
                Data = StreetMapper.ListEntityToListDto(streets)
            };
        }

        public async Task<ResponseDto<StreetDto>> GetByIdAsync(string id)
        {
            var street = await _context.Streets
                .Include(s => s.Location)
                .FirstOrDefaultAsync(s => s.Id == id);

            if (street is null)
            {
                return new ResponseDto<StreetDto>
                {
                    StatusCode = HttpStatusCode.NOT_FOUND,
                    Status = false,
                    Message = HttpMessageResponse.REGISTER_NOT_FOUND
                };
            }

            return new ResponseDto<StreetDto>
            {
                StatusCode = HttpStatusCode.OK,
                Status = true,
                Message = HttpMessageResponse.REGISTER_FOUND,
                Data = StreetMapper.EntityToDto(street)
            };
        }

        public async Task<ResponseDto<StreetActionResponseDto>> CreateAsync(StreetCreateDto dto)
        {
            var location = await _context.Locations
                .FirstOrDefaultAsync(l => l.Id == dto.LocationId);

            if (location is null)
            {
                return new ResponseDto<StreetActionResponseDto>
                {
                    StatusCode = HttpStatusCode.BAD_REQUEST,
                    Status = false,
                    Message = "La ubicacion enviada no existe."
                };
            }
            
            // Si no se proporciona un nombre de calle, usar el nombre de la ubicación
            if (string.IsNullOrWhiteSpace(dto.StreetName))
            {
                dto.StreetName = location.Street;
            }
            
            StreetEntity street = StreetMapper.CreateDtoToEntity(dto);

            _context.Streets.Add(street);
            await _context.SaveChangesAsync();

            return new ResponseDto<StreetActionResponseDto>
            {
                StatusCode = HttpStatusCode.CREATED,
                Status = true,
                Message = HttpMessageResponse.REGISTER_CREATED,
                Data = new StreetActionResponseDto 
                { 
                       Id = street.Id 
                }
            };
        }
        public async Task<ResponseDto<StreetActionResponseDto>> EditAsync(string id,StreetEditDto dto)
        {

            var streetEntity = await _context.Streets.FirstOrDefaultAsync(s =>s.Id == id);
            if(streetEntity is null)
            {
                return new ResponseDto<StreetActionResponseDto>
                {
                  StatusCode = HttpStatusCode.NOT_FOUND,
                  Status = false,
                  Message = HttpMessageResponse.REGISTER_NOT_FOUND,  
                };
            }
            var locationExists = await _context.Locations.AnyAsync(l => l.Id == dto.LocationId);
            if (!locationExists)
            {
                return new ResponseDto<StreetActionResponseDto>
                {
                    StatusCode = HttpStatusCode.BAD_REQUEST,
                    Status = false,
                    Message = "La ubicacion enviada no existe."
                };
            }

            var duplicatedStreet = await _context.Streets.AnyAsync(s =>
                s.Id != id &&
                s.StreetName == dto.StreetName &&
                s.LocationId == dto.LocationId);

            if (duplicatedStreet)
            {
                return new ResponseDto<StreetActionResponseDto>
                {
                    StatusCode = HttpStatusCode.CONFLICT,
                    Status = false,
                    Message = "Ya existe una calle con ese nombre en esa ubicacion."
                };
            }
            var streetEntityUpdated = StreetMapper.EditDtoToEntity(streetEntity,dto);
            _context.Streets.Update(streetEntityUpdated);
            await _context.SaveChangesAsync();

            return new ResponseDto<StreetActionResponseDto>
            {
                StatusCode = HttpStatusCode.OK,
                Status = true ,
                Message = HttpMessageResponse.REGISTER_UPDATED,
                Data = new StreetActionResponseDto
                {
                    Id = id
                }
            };

        }
        public async Task<ResponseDto<StreetActionResponseDto>> DeleteAsync(string id)
        {
            var streetEntity = await _context.Streets.FirstOrDefaultAsync(s =>s.Id == id);
            if(streetEntity is null)
            {
                return new ResponseDto<StreetActionResponseDto>
                {
                  StatusCode = HttpStatusCode.NOT_FOUND,
                  Status = false,
                  Message = HttpMessageResponse.REGISTER_NOT_FOUND,  
                };
            }
            _context.Streets.Remove(streetEntity);
            await _context.SaveChangesAsync();

            return new ResponseDto<StreetActionResponseDto>
            {
                StatusCode = HttpStatusCode.OK,
                Status = true,
                Message = HttpMessageResponse.REGISTER_DELETED,
                Data = new StreetActionResponseDto
                {
                    Id = id
                }
            };
        }
    }
}
