using Application.Interfaces;
using Domain.Dto;
using Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace WebApp.Controllers;

[ApiController]
public class BookController : ApiController
{
    private readonly IBookService _bookService;

    public BookController(IBookService bookService)
    {
        _bookService = bookService;
    }

    [HttpPost("[action]")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(BookDto))]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> CreateBook([FromBody] BookDto bookDto, CancellationToken cancellationToken)
    {
        return !ModelState.IsValid ? CustomResponse(ModelState) : CustomResponse(await _bookService.AddBook(bookDto, cancellationToken));
    }

    [HttpPut("[action]")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(BookDto))]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> UpdateBook([FromBody] BookDto bookDto, CancellationToken cancellationToken)
    {
        return !ModelState.IsValid ? CustomResponse(ModelState) : CustomResponse(await _bookService.UpdateBook(bookDto, cancellationToken));
    }


    [HttpGet("[action]")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<Book>))]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> GetBooks(CancellationToken cancellationToken)
    {
        var result = await _bookService.GetBooks(cancellationToken);
        return Ok(result);
    }

    [HttpDelete("[action]")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(BookDto))]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> DeleteBook(Guid id, CancellationToken cancellationToken)
    {
        var result = await _bookService.DeleteBook(id, cancellationToken);
        return Ok(result);
    }
}
