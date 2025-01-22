using System;

namespace MicroserviceProject.Catalog.Dtos.ProductDtos;

public class CreateProductDto
{
    public string Name { get; set; }
    public decimal Price { get; set; }
    public string Image { get; set; }
    public string Description { get; set; }
    public string CategoryId { get; set; }
} 