using Microsoft.AspNetCore.Mvc;
using Notebook.Shared.Models;

namespace Notebook.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RecordController : Controller
    {
        readonly List<Record> records = new List<Record>()
        {
            new Record { ID = 1, Name = "John Doe", Phone = "123-456-7890" },
            new Record { ID = 2, Name = "Jane Doe", Phone = "123-456-7890" },
            new Record { ID = 3, Name = "Jim Doe", Phone = "123-456-7890" },
            new Record { ID = 4, Name = "Jill Doe", Phone = "123-456-7890"}
        };

        [HttpGet]
        [Route("list")]
        public IActionResult List()
        {
            try
            {
                return Ok(records);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        [Route("record")]
        public IActionResult GetRecordByName(string name, string phone)
        {
            try
            {
                Record? record = records.FirstOrDefault(r => r.Name.Contains(name, StringComparison.InvariantCultureIgnoreCase));

                if (record == null)
                {
                    return NotFound(); // 404
                }

                return Ok(record); // 200
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message); // 400
            }
        }

        [HttpPost]
        [Route("add")]
        public IActionResult AddRecord(string name, string phone)
        {
            try
            {
                records.Add(new Record() { Name = name, Phone = phone});
                return Ok("Successfully added");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
