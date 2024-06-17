using Application.Contracts.Request.Books;
using Application.Interfaces.Books;
using Asp.Versioning;
using Core.Contracts.Request.Books;
using Core.Contracts.Response.Books;
using Microsoft.AspNetCore.Mvc;

namespace WebApp.Controllers.V1;

[ApiVersion("1")]
[ApiVersion("2")]
[Route("api/v{version:apiVersion}/book")]
public class BookController : ApiController<BookController>
{
    [MapToApiVersion("1")]
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(CreateBookResponse))]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> CreateBook(ICreateBookOperation _createBookOperation, [FromBody] CreateBookRequest request, CancellationToken cancellationToken)
    {
        if (!ModelState.IsValid)
        {
            return CustomResponse(ModelState);
        }

        var result = await _createBookOperation.ProcessAsync(request, cancellationToken);
        return CustomResponse(result);
    }

    [MapToApiVersion("1")]
    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<CreateBookResponse>))]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> GetBooks(IGetBookOperation _getBookOperation, CancellationToken cancellationToken)
    {
        var result = await _getBookOperation.ProcessAsync(new GetBookRequest(), cancellationToken);
        return CustomResponse(result);
    }

    [MapToApiVersion("1")]
    [HttpPut]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(UpdateBookResponse))]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> UpdateBook(IUpdateBookOperation _updateBookOperation, UpdateBookRequest request, CancellationToken cancellationToken)
    {
        if (!ModelState.IsValid)
        {
            return CustomResponse(ModelState);
        }

        var result = await _updateBookOperation.ProcessAsync(request, cancellationToken);
        return CustomResponse(result);
    }

    [MapToApiVersion("1")]
    [HttpDelete]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(CreateBookRequest))]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> DeleteBook(IDeleteBookOperation _deleteBookOperation, Guid id, CancellationToken cancellationToken)
    {
        var request = new UpdateBookRequest();
        request.Book.Id = id;

        var result = await _deleteBookOperation.ProcessAsync(request, cancellationToken);
        return CustomResponse(result);
    }
}
