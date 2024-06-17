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
    private readonly ICreateBookOperation _createBookOperation;
    private readonly IGetBookOperation _getBookOperation;
    private readonly IUpdateBookOperation _updateBookOperation;

    public BookController(ICreateBookOperation createBookOperation, IGetBookOperation getBookOperation, IUpdateBookOperation updateBookOperation)
    {
        _createBookOperation = createBookOperation;
        _getBookOperation = getBookOperation;
        _updateBookOperation = updateBookOperation;
    }

    [MapToApiVersion("1")]
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(BookResponse))]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> CreateBook([FromBody] BookRequest request, CancellationToken cancellationToken)
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
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<BookResponse>))]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> GetBooks(CancellationToken cancellationToken)
    {
        var result = await _getBookOperation.ProcessAsync(new GetBookRequest(), cancellationToken);
        return Ok(result);
    }

    [MapToApiVersion("1")]
    [HttpPut]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(UpdateBookResponse))]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> UpdateBook([FromBody] UpdateBookRequest request, CancellationToken cancellationToken)
    {
        if (!ModelState.IsValid)
        {
            return CustomResponse(ModelState);
        }

        var result = await _updateBookOperation.ProcessAsync(request, cancellationToken);
        return CustomResponse(result);
    }



    //[HttpDelete("[action]")]
    //[ProducesResponseType(StatusCodes.Status200OK, Type = typeof(BookRequest))]
    //[ProducesResponseType(StatusCodes.Status400BadRequest)]
    //public async Task<IActionResult> DeleteBook(Guid id, CancellationToken cancellationToken)
    //{
    //    var result = await _bookService.DeleteBook(id, cancellationToken);
    //    return Ok(result);
    //}
}
