// Controllers/ItemsController.cs
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;



[Route("api/[controller]")]
[ApiController]
public class ItemsController : ControllerBase
{
    private readonly DataContext _context;

    public ItemsController(DataContext context)
    {
        _context = context;
    }

    // GET: api/items
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Item>>> GetItems()
    {
        return await _context.Items.ToListAsync();
    }

    // POST: api/items
    [HttpPost]
    public async Task<ActionResult<Item>> PostItem(Item item)
    {
        _context.Items.Add(item);
        await _context.SaveChangesAsync();

        return CreatedAtAction(nameof(GetItems), new { id = item.Id }, item);
    }
}

