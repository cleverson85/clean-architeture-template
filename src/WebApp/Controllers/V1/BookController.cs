using Application.Contracts.Request.Books;
using Application.Interfaces.Books;
using Asp.Versioning;
using Core.Contracts.Request.Books;
using Core.Contracts.Response.Books;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Distributed;

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
        return CustomResponse(result.Book);
    }

    [MapToApiVersion("1")]
    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<GetBookResponse>))]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> GetBooks(IGetBookOperation _getBookOperation, CancellationToken cancellationToken)
    {
        var result = await _getBookOperation.ProcessAsync(new GetBookRequest(), cancellationToken);
        return CustomResponse(result.Books);
    }

    [MapToApiVersion("1")]
    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(GetBookResponse))]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> GetBook(IGetBookOperation _getBookOperation, IDistributedCache cache, Guid id, CancellationToken cancellationToken)
    {
        var request = new GetBookRequest()
        {
            Id = id,
        };

        var result = await _getBookOperation.ProcessAsync(request, cancellationToken);
        return CustomResponse(result.Book);
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
        return CustomResponse(result.Book);
    }

    [MapToApiVersion("1")]
    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(UpdateBookResponse))]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> DeleteBook(IDeleteBookOperation _deleteBookOperation, Guid id, CancellationToken cancellationToken)
    {
        var request = new UpdateBookRequest()
        {
            Id = id,
        };

        var result = await _deleteBookOperation.ProcessAsync(request, cancellationToken);
        return CustomResponse(result.Book);
    }
}
