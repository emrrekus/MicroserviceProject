using System;
using AutoMapper;
using MicroserviceProject.Catalog.Dtos.ProductDtos;
using MicroserviceProject.Catalog.Entities;
using MicroserviceProject.Catalog.Settings;
using MongoDB.Driver;

namespace MicroserviceProject.Catalog.Services.ProductServices;

public class ProductService : IProdcutService
{
    private readonly IMongoCollection<Product> _productCollection;
    private readonly IMapper _mapper;
    public ProductService(IMapper mapper,IDatabaseSettings databaseSettings)
    {
        var client = new MongoClient(databaseSettings.ConnectionString);
        var database = client.GetDatabase(databaseSettings.DatabaseName);
        _productCollection = database.GetCollection<Product>(databaseSettings.ProductCollectionName);
        _mapper = mapper;
    }

    public async Task CreateAsync(CreateProductDto createProductDto)
    {
        var product = _mapper.Map<Product>(createProductDto);
        await _productCollection.InsertOneAsync(product);
    }

    public async Task DeleteAsync(string id)
    {
        await _productCollection.DeleteOneAsync(x => x.Id == id);
    }

    public async Task<List<ResultProductDto>> GetAllAsync()
    {
        var products = await _productCollection.Find(x => true).ToListAsync();
        return _mapper.Map<List<ResultProductDto>>(products);
    }

    public async Task<GetByIdProductDto> GetByIdAsync(string id)
    {
        var product = await _productCollection.Find(x => x.Id == id).FirstOrDefaultAsync();
        return _mapper.Map<GetByIdProductDto>(product);
    }

    public async Task UpdateAsync(UpdateProductDto updateProductDto)
    {
        var product = _mapper.Map<Product>(updateProductDto);
      await _productCollection.FindOneAndReplaceAsync(x => x.Id == product.Id, product);
    }
}
