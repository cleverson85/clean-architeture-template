using Application.Interfaces;
using Application.ViewModels.Book;
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
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(BookCreateViewModel))]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> CreateBook([FromBody] BookCreateViewModel bookViewModel, CancellationToken cancellationToken)
    {
        return !ModelState.IsValid ? CustomResponse(ModelState) : CustomResponse(await _bookService.AddBook(bookViewModel, cancellationToken));
    }

    [HttpGet("[action]")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<BookCreateViewModel>))]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> GetBooks(CancellationToken cancellationToken)
    {
        var result = await _bookService.GetBooks(cancellationToken);
        return Ok(result);
    }
}
