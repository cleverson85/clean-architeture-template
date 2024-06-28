using Application.Books.Commands.Create;
using Application.Books.Commands.Delete;
using Application.Books.Commands.Update;
using Application.Books.Queries.GetAll;
using Application.Books.Queries.GetById;
using Asp.Versioning;
using Microsoft.AspNetCore.Mvc;

namespace WebApp.Controllers.V1;

[ApiVersion("1")]
[ApiVersion("2")]
[Route("api/v{version:apiVersion}/book")]
public class BookController : ApiController<BookController>
{
    [MapToApiVersion("1")]
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Guid))]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> CreateBook([FromBody] CreateBookRequest request, CancellationToken cancellationToken)
    {
        var result = await Sender.Send(request, cancellationToken);
        return CustomResponse(result as CreateBookResponse);
    }

    [MapToApiVersion("1")]
    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<BookResponseList>))]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> GetBooks(CancellationToken cancellationToken)
    {
        var result = await Sender.Send(new GetAllBooksQuery(), cancellationToken);
        return CustomResponse(result as BookResponseList);
    }

    [MapToApiVersion("1")]
    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(BookResponse))]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> GetBook(Guid id, CancellationToken cancellationToken)
    {
        var result = await Sender.Send(new GetBookByIdQuery(id), cancellationToken);
        return CustomResponse(result as BookResponse);
    }

    [MapToApiVersion("1")]
    [HttpPut]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Guid))]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> UpdateBook(UpdateBookRequest request, CancellationToken cancellationToken)
    {
        var result = await Sender.Send(request, cancellationToken);
        return CustomResponse(result as UpdateBookResponse);
    }

    [MapToApiVersion("1")]
    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Guid))]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> DeleteBook(Guid id, CancellationToken cancellationToken)
    {
        var result = await Sender.Send(new DeleteBookRequest(id), cancellationToken);
        return CustomResponse(result as DeleteBookResponse);
    }
}
