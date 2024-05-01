using AutoMapper;
using VetTextShifo.Application.DTOs.Details.Location;
using VetTextShifo.Application.DTOs.Products.Comments;
using VetTextShifo.Application.DTOs.Products.ForRequest;
using VetTextShifo.Application.DTOs.Products.ForView;
using VetTextShifo.Application.DTOs.Users.Customer.ForRequest;
using VetTextShifo.Application.DTOs.Users.Customer.ForView;
using VetTextShifo.Application.DTOs.Users.Orders.ForRequest;
using VetTextShifo.Application.DTOs.Users.Orders.ForView;
using VetTextShifo.Domain.Entities;
using VetTextShifo.Domain.Entities.ProductDetails;
using VetTextShifo.Domain.Entities.ProductDetails.NewsModel;
using VetTextShifo.Domain.Entities.ProductDetails.Products;
using VetTextShifo.Domain.Entities.Users;

namespace VetTextShifo.Application.Mappers;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        //News Eng
        CreateMap<NewsModelEng, NewForCreate>().ReverseMap();
        CreateMap<NewsModelEng, NewForUpdate>().ReverseMap();
        CreateMap<NewsModelEng, NewForView>().ReverseMap();

        //News Rus
        CreateMap<NewsModelRus, NewForCreate>().ReverseMap();
        CreateMap<NewsModelRus, NewForUpdate>().ReverseMap();
        CreateMap<NewsModelRus, NewForView>().ReverseMap();

        //News Uzb
        CreateMap<NewsModelUzb, NewForCreate>().ReverseMap();
        CreateMap<NewsModelUzb, NewForUpdate>().ReverseMap();
        CreateMap<NewsModelUzb, NewForView>().ReverseMap();

        //Product Eng
        CreateMap<ProductEng, ProductForCreate>().ReverseMap();
        CreateMap<ProductEng, ProductForUpdate>().ReverseMap();
        CreateMap<ProductEng, ProductByIdView>().ReverseMap();
        CreateMap<ProductEng, ProductForMainView>().ReverseMap();

        //Product Rus
        CreateMap<ProductRus, ProductForCreate>().ReverseMap();
        CreateMap<ProductRus, ProductForUpdate>().ReverseMap();
        CreateMap<ProductRus, ProductByIdView>().ReverseMap();
        CreateMap<ProductRus, ProductForMainView>().ReverseMap();

        //Product Uzb
        CreateMap<ProductUzb, ProductForCreate>().ReverseMap();
        CreateMap<ProductUzb, ProductForUpdate>().ReverseMap();
        CreateMap<ProductUzb, ProductByIdView>().ReverseMap();
        CreateMap<ProductUzb, ProductForMainView>().ReverseMap();

        //Customer Respons
        CreateMap<Customer, CustomerLikedProductView>().ReverseMap();
        CreateMap<Customer, OrderForCollectionView>().ReverseMap();

        //Location 
        CreateMap<Location, LocationForCreation>().ReverseMap();
        CreateMap<Location, LocationForUpdating>().ReverseMap();
        CreateMap<Location, LocationForView>().ReverseMap();

        //Admin
        CreateMap<Admin, AdminRequest>().ReverseMap();
        CreateMap<Admin, AdminChangePassword>().ReverseMap();
        CreateMap<Admin, AdminRespons>().ReverseMap();
        CreateMap<AdminRequest, AdminRespons>().ReverseMap();

        //Comments
        CreateMap<Comment, CommentForCreate>().ReverseMap();

        //Order
        CreateMap<Order, OrderForRequest>().ReverseMap();
        CreateMap<Order, OrderForView>().ReverseMap();

        //Customer
        CreateMap<Customer, CustomerForCreateRequest>().ReverseMap();
        CreateMap<Customer, CustomerForUpdateRequest>().ReverseMap();
        CreateMap<Customer, CustomerForView>().ReverseMap();







    }
}
