using System;
using MongoDB.Bson.Serialization.Attributes;

namespace MicroserviceProject.Catalog.Entities;

public class ProductImages
{
    public string Id { get; set; }
    public string Image1 { get; set; }
    public string Image2 { get; set; }
    public string Image3 { get; set; }
    public string Image4 { get; set; }

    public string ProductId { get; set; }

    [BsonIgnore]
    public Product Product { get; set; }

}
