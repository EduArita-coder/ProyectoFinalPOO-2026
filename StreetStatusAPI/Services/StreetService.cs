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

        public async Task<ResponseDto<StreetDto>> GetByIdAsync(int id)
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
            var street = StreetMapper.CreateDtoToEntity(dto);

            _context.Streets.Add(street);
            await _context.SaveChangesAsync();

            return new ResponseDto<StreetActionResponseDto>
            {
                StatusCode = HttpStatusCode.CREATED,
                Status = true,
                Message = HttpMessageResponse.REGISTER_CREATED,
                Data = new StreetActionResponseDto { Id = street.Id }
            };
        }
    }
}