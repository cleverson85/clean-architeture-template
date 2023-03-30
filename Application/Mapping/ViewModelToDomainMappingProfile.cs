using Application.ViewModels.Book;
using AutoMapper;
using Domain.Entities;

namespace Application.Mapping;

public class ViewModelToDomainMappingProfile : Profile
{
    public ViewModelToDomainMappingProfile()
    {
        CreateMap<BookCreateViewModel, Book>();
        CreateMap<BookUpdateViewModel, Book>();
    }
}
