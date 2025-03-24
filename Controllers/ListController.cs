using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace DockerVolumeListApi.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ListController : ControllerBase
    {
        // In-memory list to hold items temporarily
        private static List<string> _items = new List<string>();

        // The file path for persisting data (in Docker volume)
        private readonly string _filePath = "C:\\Users\\vchanti\\Downloads\\chanty.txt";

        // Constructor - Load the items from the file when the API starts
        public ListController()
        {
            LoadItemsFromFile();
        }

        // GET method to retrieve all items in the list
        [HttpGet("Get")]
        public IActionResult GetItems()
        {
            return Ok(_items);
        }

        // POST method to add a new item to the list
        [HttpPost("post")]
        public IActionResult AddItem([FromBody] string item)
        {
            _items.Add(item);
            SaveItemsToFile(); // Persist the list to file
            return Ok($"Item '{item}' added.");
        }

        // Helper method to load items from the file
        private void LoadItemsFromFile()
        {
            if (System.IO.File.Exists(_filePath))
            {
                var lines = System.IO.File.ReadAllLines(_filePath);
                _items = lines.ToList(); // Populate in-memory list from file
            }
        }

        // Helper method to save items to the file
        private void SaveItemsToFile()
        {
            System.IO.File.WriteAllLines(_filePath, _items); // Write the list to file
        }
    }
}
