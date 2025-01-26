using System;
using MicroserviceProject.Catalog.Dtos.ProductImagesDtos;

namespace MicroserviceProject.Catalog.Services.ProductImagesServices;

public interface IProductImages
{
    Task<List<ResultProductImagesDto>> GetAllAsync();
    Task<GetByIdProductImagesDto> GetByIdAsync(string id);
    Task CreateAsync(CreateProductImagesDto createProductImagesDto);
    Task UpdateAsync(UpdateProductImagesDto updateProductImagesDto);
    Task DeleteAsync(string id);
}
