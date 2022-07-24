using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RadencyBooks.Application.Dtos;
using RadencyBooks.Application.Exceptions;
using RadencyBooks.Application.Interfaces;
using RadencyBooks.Application.Models;
using RadencyBooks.Application.Services;
using RadencyBooks.Infrastructure;

namespace RadencyBooks.WEB.Controllers;

[ApiController]
[Route("api")]
public class BookController : ControllerBase
{
    private readonly IBookService _bookService;
    private readonly IMapper _mapper;
    private readonly DataContext _context;
    private readonly AppSettings _appSettings;

    public BookController(
        IBookService bookService, 
        IMapper mapper, 
        DataContext context, 
        AppSettings appSettings)
    {
        _bookService = bookService;
        _mapper = mapper;
        _context = context;
        _appSettings = appSettings;
    }

    [HttpGet("/books")]
    public async Task<IActionResult> GetBooks([FromQuery]string? order = default)
    {
        var books = await _bookService.GetAllBooksAsync(order);
        var res = _mapper.Map<List<BookDto>>(books);
        return Ok(res);
    } 
    [HttpGet("/recommended")]
    public async Task<IActionResult> GetTenRecommendedBooks([FromQuery]string? genre = default)
    {
        var books = await _bookService.GetTenRecommendedBooksAsync(genre);
        var res = _mapper.Map<List<BookDto>>(books);
        return Ok(res);
    }  
    [HttpGet("/books/{id}")]
    public async Task<IActionResult> GetBookDetail(int id)
    {
        var book = await _bookService.GetBookDetailAsync(id);
        var res = _mapper.Map<BookListReviewDto>(book);
        return Ok(res);
    }  
    [HttpDelete("/books/{secret}")]
    public async Task<IActionResult> DeleteBook(string secret, int id)
    {
        if (secret != _appSettings.SecretKey)
            throw new ProvidedSecretKeyIsNotValidException(secret);
        await _bookService.DeleteBookAsync(id);
        return Ok();
    } 
    [HttpGet("Test")]
    public async Task<IActionResult> Test()
    {
        var a = _context.Set<Book>().EntityType.FindPrimaryKey();
        return Ok(a);
    } 
    [HttpPost("/books/save")]
    public async Task<IActionResult> SaveBook(BookCreateDto bookDto)
    {
        var book = _mapper.Map<Book>(bookDto);
        var res = await _bookService.AddAsync(book);
        return Ok(new {res.Id});
    }
}