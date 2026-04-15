using StreetStatusAPI.Dtos.Locations;
using StreetStatusAPI.Entities;

namespace StreetStatusAPI.Mappers
{
    public static class LocationMapper
    {
        public static Location CreateDtoToEntity(LocationCreateDto dto)
        {
            return new Location
            {
                Id = Guid.NewGuid().ToString(),
                City = dto.City,
                Street = dto.Street,
                ZipCode = dto.ZipCode,
                CreatedDate = DateTime.UtcNow
            };
        }

        public static LocationDto EntityToDto(Location entity)
        {
            return new LocationDto
            {
                Id = entity.Id,
                City = entity.City,
                Street = entity.Street,
                ZipCode = entity.ZipCode
            };
        }

        public static Location EditDtoToEntity(Location entity, LocationEditDto dto)
        {
            entity.City = dto.City;
            entity.Street = dto.Street;
            entity.ZipCode = dto.ZipCode;

            return entity;
        }

        public static List<LocationDto> ListEntityToListDto(List<Location> entities)
        {
            return entities.Select(EntityToDto).ToList();
        }
    }
}
