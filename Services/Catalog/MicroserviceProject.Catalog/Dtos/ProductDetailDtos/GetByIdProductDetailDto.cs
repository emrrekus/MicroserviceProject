using System;

namespace MicroserviceProject.Catalog.Dtos.ProductDetailDtos;

public class GetByIdProductDetailDto
{
    public string Id { get; set; }
    public string Description { get; set; }
    public string Information { get; set; }
} 