using Domain.Entities;
using Domain.Validation.Books;
using FluentValidation;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure.IoC;

public static class DependencyInjectionValidator
{
    public static void Register(this IServiceCollection services)
    {
        services.AddValidatorsFromAssemblyContaining<BookValidation<Book>>();
    }
}
