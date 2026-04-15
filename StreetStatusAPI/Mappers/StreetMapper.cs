using StreetStatusAPI.Dtos.Streets;
using StreetStatusAPI.Entities;

namespace StreetStatusAPI.Mappers
{
    public static class StreetMapper
    {
        public static StreetEntity CreateDtoToEntity(StreetCreateDto dto)
        {
            return new StreetEntity
            {
                Id = Guid.NewGuid().ToString(),
                StreetName = dto.StreetName,
                Description = dto.Description,
                LocationId = dto.LocationId,
                Status = StreetStatus.SinReparar,
                CreatedDate = DateTime.UtcNow
            };
        }

        public static StreetDto EntityToDto(StreetEntity entity)
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

        public static StreetEntity EditDtoToEntity(StreetEntity entity,StreetEditDto dto)
        {
            entity.StreetName = dto.StreetName;
            entity.Description = dto.Description;
            entity.Status = Enum.Parse<StreetStatus>(dto.Status);
            entity.LastRepairDate = dto.LastRepairDate;
            entity.LocationId = dto.LocationId;

            return entity;
        }
        public static List<StreetDto> ListEntityToListDto(List<StreetEntity> entities)
        {
            return entities.Select(s => EntityToDto(s)).ToList();
        }
    }
}
