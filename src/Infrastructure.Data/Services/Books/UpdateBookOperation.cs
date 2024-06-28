using Application.Core;
using Application.Core.Services;
using Application.Interfaces.Books;
using Core.Contracts.Request.Books;
using Core.Contracts.Response.Books;
using Domain.Entities;
using Domain.Interfaces.Base;
using FluentValidation.Results;
using Microsoft.Extensions.Logging;

namespace Application.Services.Books
{
    public class UpdateBookOperation : CoreOperationAsync<UpdateBookRequest, UpdateBookResponse>, IUpdateBookOperation
    {
        private Book _book;

        public UpdateBookOperation(IUnitOfWork unitOfWork, ILogger<CoreOperationAsync<UpdateBookRequest, UpdateBookResponse>> logger) : base(unitOfWork, logger)
        { }

        protected override async Task<UpdateBookResponse> ProcessOperationAsync(UpdateBookRequest request, CancellationToken cancellationToken)
        {
            _book.Author = request.Book.Author;
            _book.Title = request.Book.Title;

            var result = await _unitOfWork.BookRepository.UpdateAsync(_book, cancellationToken);
            return (UpdateBookResponse)result;
        }

        protected override async Task<ValidationResult> ValidateAsync(UpdateBookRequest request, CancellationToken cancellationToken)
        {
            var response = new CoreOperationResponse();
            _book = await _unitOfWork.BookRepository.GetAsync(request.Book.Id, cancellationToken);

            if (_book is null)
            {
                response.AddError("Book not found to updated.");
            }

            return response;
        }
    }
}
