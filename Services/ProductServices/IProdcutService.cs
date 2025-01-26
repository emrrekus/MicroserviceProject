using System;
using MicroserviceProject.Catalog.Dtos.ProductDtos;

namespace MicroserviceProject.Catalog.Services.ProductServices;

public interface IProdcutService
{
    Task<List<ResultProductDto>> GetAllAsync();
    Task<GetByIdProductDto> GetByIdAsync(string id);
    Task CreateAsync(CreateProductDto createProductDto);
    Task UpdateAsync(UpdateProductDto updateProductDto);
    Task DeleteAsync(string id);
}
