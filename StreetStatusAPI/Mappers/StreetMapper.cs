using StreetStatusAPI.Dtos.Streets;
using StreetStatusAPI.Entities;

namespace StreetStatusAPI.Mappers
{
    public static class StreetMapper
    {
        public static Street CreateDtoToEntity(StreetCreateDto dto)
        {
            return new Street
            {
                StreetName = dto.StreetName,
                Description = dto.Description,
                LocationId = dto.LocationId,
                Status = StreetStatus.SinReparar,
                CreatedDate = DateTime.UtcNow
            };
        }

        public static StreetDto EntityToDto(Street entity)
        {
            return new StreetDto
            {
                Id = entity.Id.ToString(),
                StreetName = entity.StreetName,
                Description = entity.Description,
                Status = entity.Status.ToString(),
                LastRepairDate = entity.LastRepairDate,
                LocationId = entity.LocationId
            };
        }

        public static List<StreetDto> ListEntityToListDto(List<Street> entities)
        {
            return entities.Select(s => EntityToDto(s)).ToList();
        }
    }
}
