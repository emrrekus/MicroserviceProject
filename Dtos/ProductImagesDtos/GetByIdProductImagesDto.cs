using System;

namespace MicroserviceProject.Catalog.Dtos.ProductImagesDtos;

public class GetByIdProductImagesDto
{
    public string Id { get; set; }
    public string Image1 { get; set; }
    public string Image2 { get; set; }
    public string Image3 { get; set; }
    public string Image4 { get; set; }
    public string ProductId { get; set; }
} 