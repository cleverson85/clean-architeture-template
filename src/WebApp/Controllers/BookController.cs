using Application.Interfaces;
using Core.Contracts;
using Microsoft.AspNetCore.Mvc;

namespace WebApp.Controllers;

[ApiController]
public class BookController : ApiController
{
    private readonly IBookOperation _bookService;

    public BookController(IBookOperation bookService)
    {
        _bookService = bookService;
    }

    [HttpPost("[action]")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(BookRequest))]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> CreateBook([FromBody] BookRequest request, CancellationToken cancellationToken)
    {
        if (!ModelState.IsValid)
        {
            return CustomResponse(ModelState);
        }

        return CustomResponse(await _bookService.ProcessAsync(request, cancellationToken));
    }

    //[HttpPut("[action]")]
    //[ProducesResponseType(StatusCodes.Status200OK, Type = typeof(BookRequest))]
    //[ProducesResponseType(StatusCodes.Status400BadRequest)]
    //public async Task<IActionResult> UpdateBook([FromBody] BookRequest bookDto, CancellationToken cancellationToken)
    //{
    //    return !ModelState.IsValid ? CustomResponse(ModelState) : CustomResponse(await _bookService.UpdateBook(bookDto, cancellationToken));
    //}


    //[HttpGet("[action]")]
    //[ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<Book>))]
    //[ProducesResponseType(StatusCodes.Status400BadRequest)]
    //public async Task<IActionResult> GetBooks(CancellationToken cancellationToken)
    //{
    //    var result = await _bookService.GetBooks(cancellationToken);
    //    return Ok(result);
    //}

    //[HttpDelete("[action]")]
    //[ProducesResponseType(StatusCodes.Status200OK, Type = typeof(BookRequest))]
    //[ProducesResponseType(StatusCodes.Status400BadRequest)]
    //public async Task<IActionResult> DeleteBook(Guid id, CancellationToken cancellationToken)
    //{
    //    var result = await _bookService.DeleteBook(id, cancellationToken);
    //    return Ok(result);
    //}
}
