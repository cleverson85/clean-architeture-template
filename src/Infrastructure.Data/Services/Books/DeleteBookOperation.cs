using Application.Core;
using Application.Core.Services;
using Application.Interfaces.Base;
using Application.Interfaces.Books;
using Core.Contracts.Request.Books;
using Core.Contracts.Response.Books;
using Domain.Entities;
using FluentValidation.Results;
using Microsoft.Extensions.Logging;

namespace Application.Services.Books
{
    public class DeleteBookOperation : CoreOperationAsync<UpdateBookRequest, UpdateBookResponse>, IDeleteBookOperation
    {
        private Book _book;

        public DeleteBookOperation(IUnitOfWork unitOfWork, ILogger<CoreOperationAsync<UpdateBookRequest, UpdateBookResponse>> logger) : base(unitOfWork, logger)
        { }

        protected override async Task<UpdateBookResponse> ProcessOperationAsync(UpdateBookRequest request, CancellationToken cancellationToken)
        {
            var result = await _unitOfWork.BookRepository.DeleteAsync(_book, cancellationToken);
            return (UpdateBookResponse)result;
        }

        protected override async Task<ValidationResult> ValidateAsync(UpdateBookRequest request, CancellationToken cancellationToken)
        {
            var response = new CoreOperationResponse();
            _book = await _unitOfWork.BookRepository.GetAsync(request.Id, cancellationToken);

            if (_book is null)
            {
                response.AddError("Book not found.");
            }

            return response;
        }
    }
}
