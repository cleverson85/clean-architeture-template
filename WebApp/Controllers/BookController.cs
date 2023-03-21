using Application.Interfaces;
using Application.ViewModels;
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

    [HttpPost("save-book")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(BookViewModel))]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> CreateBook([FromBody] BookViewModel book, CancellationToken cancellationToken)
    {
        if (!ModelState.IsValid)
        {
            return CustomResponse(ModelState);
        }

        await _bookService.AddBook(book, cancellationToken);
        return CustomResponse(book);
    }

    [HttpGet("list-books")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<BookViewModel>))]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> GetBooks(CancellationToken cancellationToken)
    {
        var result = await _bookService.GetBooks(cancellationToken);
        return Ok(result);
    }
}
