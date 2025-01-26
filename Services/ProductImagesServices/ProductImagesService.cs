using System;
using AutoMapper;
using MicroserviceProject.Catalog.Dtos.ProductImagesDtos;
using MicroserviceProject.Catalog.Entities;
using MicroserviceProject.Catalog.Settings;
using MongoDB.Driver;

namespace MicroserviceProject.Catalog.Services.ProductImagesServices;

public class ProductImagesService : IProductImages  
{
    private readonly IMongoCollection<ProductImages> _productImagesCollection;
    private readonly IMapper _mapper;
    public ProductImagesService(IMapper mapper,IDatabaseSettings databaseSettings)
    {
        var client = new MongoClient(databaseSettings.ConnectionString);
        var database = client.GetDatabase(databaseSettings.DatabaseName);
        _productImagesCollection = database.GetCollection<ProductImages>(databaseSettings.ProductImagesCollectionName);
        _mapper = mapper;
    }

    public async Task CreateAsync(CreateProductImagesDto createProductImagesDto)
    {
        var productImages = _mapper.Map<ProductImages>(createProductImagesDto);
        await _productImagesCollection.InsertOneAsync(productImages);
    }

    public async Task DeleteAsync(string id)
    {
        await _productImagesCollection.DeleteOneAsync(x => x.Id == id);
    }

    public async Task<List<ResultProductImagesDto>> GetAllAsync()
    {
        var productImages = await _productImagesCollection.Find(x => true).ToListAsync();
        return _mapper.Map<List<ResultProductImagesDto>>(productImages);
    }

    public async Task<GetByIdProductImagesDto> GetByIdAsync(string id)
    {
        var productImages = await _productImagesCollection.Find(x => x.Id == id).FirstOrDefaultAsync();
        return _mapper.Map<GetByIdProductImagesDto>(productImages);
    }

    public async Task UpdateAsync(UpdateProductImagesDto updateProductImagesDto)
    {
        var productImages = _mapper.Map<ProductImages>(updateProductImagesDto);
        await _productImagesCollection.FindOneAndReplaceAsync(x => x.Id == productImages.Id, productImages);
    }
}

