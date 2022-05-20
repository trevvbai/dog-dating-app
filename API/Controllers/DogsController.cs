using API.Data;
using API.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class DogsController : ControllerBase
{
    private readonly DataContext _context;

    public DogsController(DataContext context)
    {
        _context = context;
    }


    [HttpGet]
    public async Task<ActionResult<IEnumerable<Dog>>> GetDogs()
    {
        try
        {
            return await _context.Users.ToListAsync();
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }
    
    [HttpGet("{id:int}")]
    public async Task<ActionResult<Dog>> GetDog(int id)
    {
        try
        {
            return await _context.Users.FindAsync(id).ConfigureAwait(false) ?? throw new InvalidOperationException();

        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }
}