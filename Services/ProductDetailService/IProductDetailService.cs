using System;
using MicroserviceProject.Catalog.Dtos.ProductDetailDtos;

namespace MicroserviceProject.Catalog.Services.ProductDetailService;

public interface IProductDetailService
{
    Task<List<ResultProductDetailDto>> GetAllAsync();
    Task<GetByIdProductDetailDto> GetByIdAsync(string id);
    Task CreateAsync(CreateProductDetailDto createProductDetailDto);
    Task UpdateAsync(UpdateProductDetailDto updateProductDetailDto);
    Task DeleteAsync(string id);
}
