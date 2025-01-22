using System;

namespace MicroserviceProject.Catalog.Dtos.ProductDtos;

public class ResultProductDto
{
    public string Id { get; set; }
    public string Name { get; set; }
    public decimal Price { get; set; }
    public string Image { get; set; }
    public DateTimeOffset CreatedDate { get; set; }
    public string Description { get; set; }
    public string CategoryId { get; set; }
} 