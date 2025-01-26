using System;
using AutoMapper;
using MicroserviceProject.Catalog.Dtos.ProductDetailDtos;
using MicroserviceProject.Catalog.Entities;
using MicroserviceProject.Catalog.Settings;
using MongoDB.Driver;

namespace MicroserviceProject.Catalog.Services.ProductDetailService;

public class ProductDetailService : IProductDetailService
{
    private readonly IMongoCollection<ProductDetail> _productDetailCollection;
    private readonly IMapper _mapper;
    public ProductDetailService(IMapper mapper,IDatabaseSettings databaseSettings)
    {
        var client = new MongoClient(databaseSettings.ConnectionString);
        var database = client.GetDatabase(databaseSettings.DatabaseName);
        _productDetailCollection = database.GetCollection<ProductDetail>(databaseSettings.ProductDetailCollectionName);
        _mapper = mapper;
    }

    public async Task CreateAsync(CreateProductDetailDto createProductDetailDto)
    {
        var productDetail = _mapper.Map<ProductDetail>(createProductDetailDto);
        await _productDetailCollection.InsertOneAsync(productDetail);
    }

    public async Task DeleteAsync(string id)
    {
        await _productDetailCollection.DeleteOneAsync(x => x.Id == id);
    }

    public async Task<List<ResultProductDetailDto>> GetAllAsync()
    {
        var productDetails = await _productDetailCollection.Find(x => true).ToListAsync();
        return _mapper.Map<List<ResultProductDetailDto>>(productDetails);
    }

    public async Task<GetByIdProductDetailDto> GetByIdAsync(string id)
    {
        var productDetail = await _productDetailCollection.Find(x => x.Id == id).FirstOrDefaultAsync();
        return _mapper.Map<GetByIdProductDetailDto>(productDetail);
    }

    public async Task UpdateAsync(UpdateProductDetailDto updateProductDetailDto)
    {
        var productDetail = _mapper.Map<ProductDetail>(updateProductDetailDto);
        await _productDetailCollection.FindOneAndReplaceAsync(x => x.Id == productDetail.Id, productDetail);
    }
}
