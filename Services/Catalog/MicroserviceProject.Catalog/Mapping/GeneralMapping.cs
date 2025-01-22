using System;
using AutoMapper;
using MicroserviceProject.Catalog.Dtos.CategoryDtos;
using MicroserviceProject.Catalog.Dtos.ProductDetailDtos;
using MicroserviceProject.Catalog.Dtos.ProductDtos;
using MicroserviceProject.Catalog.Dtos.ProductImagesDtos;
using MicroserviceProject.Catalog.Entities;

namespace MicroserviceProject.Catalog.Mapping;

public class GeneralMapping : Profile
{
    public GeneralMapping()
    {
        CreateMap<Category, ResultCategoryDto>().ReverseMap();
        CreateMap<CreateCategoryDto, Category>().ReverseMap();
        CreateMap<UpdateCategoryDto, Category>().ReverseMap();
        CreateMap<GetByIdCategoryDto, Category>().ReverseMap();

        CreateMap<Product, ResultProductDto>().ReverseMap();
        CreateMap<CreateProductDto, Product>().ReverseMap();
        CreateMap<UpdateProductDto, Product>().ReverseMap();
        CreateMap<GetByIdProductDto, Product>().ReverseMap();

        CreateMap<ProductDetail, ResultProductDetailDto>().ReverseMap();
        CreateMap<CreateProductDetailDto, ProductDetail>().ReverseMap();
        CreateMap<UpdateProductDetailDto, ProductDetail>().ReverseMap();
        CreateMap<GetByIdProductDetailDto, ProductDetail>().ReverseMap();

        CreateMap<ProductImages, ResultProductImagesDto>().ReverseMap();
        CreateMap<CreateProductImagesDto, ProductImages>().ReverseMap();
        CreateMap<UpdateProductImagesDto, ProductImages>().ReverseMap();
        CreateMap<GetByIdProductImagesDto, ProductImages>().ReverseMap();
    }
}
