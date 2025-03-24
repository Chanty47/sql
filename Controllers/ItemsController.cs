// Controllers/ItemsController.cs
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;



[Route("[controller]")]
[ApiController]
public class ItemsController : ControllerBase
{
    private readonly DataContext _context;

    public ItemsController(DataContext context)
    {
        _context = context;
    }

/*************  ✨ Codeium Command ⭐  *************/
/// <summary>
/// Retrieves all items from the database.
/// </summary>
/// <returns>An asynchronous task that resolves to an ActionResult containing a list of items.</returns>

/******  30595494-cd1e-4adf-9873-0db716201880  *******/
    [HttpGet("Get")]
    public async Task<ActionResult<IEnumerable<Item>>> GetItems()
    {
        return await _context.Items.ToListAsync();
    }

    [HttpPost("post")]
    public async Task<ActionResult<Item>> PostItem(Item item)
    {
        _context.Items.Add(item);
        await _context.SaveChangesAsync();

        return CreatedAtAction(nameof(GetItems), new { id = item.Id }, item);
    }
}

