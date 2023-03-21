using Application.ViewModels;
using AutoMapper;
using Domain.Entities;

namespace Application.Mapping;

public class ViewModelToDomainMappingProfile : Profile
{
    public ViewModelToDomainMappingProfile()
    {
        CreateMap<BookViewModel, Book>();
    }
}
