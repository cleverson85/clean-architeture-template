using Application.ViewModels.Book;
using AutoMapper;
using Domain.Entities;

namespace Application.Mapping;

public class DomainToViewModelMappingProfile : Profile
{
    public DomainToViewModelMappingProfile() 
    {
        CreateMap<Book, BookCreateViewModel>();
        CreateMap<Book, BookUpdateViewModel>();
    }
}
