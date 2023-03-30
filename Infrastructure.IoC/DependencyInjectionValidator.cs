using Application.Validation.Books;
using Application.ViewModels.Book;
using FluentValidation;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure.IoC;

public static class DependencyInjectionValidator
{
    public static void Register(this IServiceCollection services)
    {
        services.AddValidatorsFromAssemblyContaining<BookValidation<BookViewModel>>();
    }
}
