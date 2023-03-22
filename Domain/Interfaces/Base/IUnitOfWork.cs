using FluentValidation.Results;

namespace Domain.Interfaces.Base;

public interface IUnitOfWork
{
    Task<ValidationResult> Commit();
}
