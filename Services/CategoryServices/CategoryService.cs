using System;
using AutoMapper;
using MicroserviceProject.Catalog.Dtos.CategoryDtos;
using MicroserviceProject.Catalog.Entities;
using MicroserviceProject.Catalog.Settings;
using MongoDB.Driver;

namespace MicroserviceProject.Catalog.Services.CategoryServices;

public class CategoryService : ICategoryService
{

    private readonly IMongoCollection<Category> _categoryCollection;
    private readonly IMapper _mapper;
    public CategoryService(IMapper mapper,IDatabaseSettings databaseSettings)
    {
        var client = new MongoClient(databaseSettings.ConnectionString);
        var database = client.GetDatabase(databaseSettings.DatabaseName);
        _categoryCollection = database.GetCollection<Category>(databaseSettings.CategoryCollectionName);
        _mapper = mapper;
    }
    public async Task CreateAsync(CreateCategoryDto createCategoryDto)
    {
        var category = _mapper.Map<Category>(createCategoryDto);
        await _categoryCollection.InsertOneAsync(category);
    }

    public async Task DeleteAsync(string id)
    {
        await _categoryCollection.DeleteOneAsync(x => x.Id == id);
    }

    public async Task<List<ResultCategoryDto>> GetAllAsync()
    {
        var categories = await _categoryCollection.Find(x => true).ToListAsync();
        return _mapper.Map<List<ResultCategoryDto>>(categories);
    }

    public async Task<GetByIdCategoryDto> GetByIdAsync(string id)
    {
        var category = await _categoryCollection.Find(x=> x.Id == id).FirstOrDefaultAsync();
        return _mapper.Map<GetByIdCategoryDto>(category);
    }

    public async Task UpdateAsync(UpdateCategoryDto updateCategoryDto)
    {
        var category = _mapper.Map<Category>(updateCategoryDto);
       await _categoryCollection.FindOneAndReplaceAsync(x => x.Id == category.Id, category);
    }
}
