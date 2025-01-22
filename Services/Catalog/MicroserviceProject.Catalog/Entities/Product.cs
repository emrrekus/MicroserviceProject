using System;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace MicroserviceProject.Catalog.Entities;

public class Product
{
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string Id { get; set; }

    [BsonElement("Name")]
    public string Name { get; set; }

    public decimal Price { get; set; }

    public string Image { get; set; }

    public DateTimeOffset CreatedDate { get; set; }

    public string Description { get; set; }

    public string CategoryId { get; set; }

    [BsonIgnore]
    public Category Category { get; set; }

}
