namespace ChartServer;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

[Route("api/[controller]")]
[ApiController]
public class DataController : ControllerBase
{
    private readonly DataContext _context;

    public DataController(DataContext context)
    {
        _context = context;
    }

    // Fetch all chart data
    [HttpGet]
    public async Task<ActionResult<IEnumerable<ChartData>>> GetData()
    {
        var data = await _context.ChartData.ToListAsync();
        if (data == null || data.Count == 0)
        {
            return NotFound("No data found.");
        }
        return Ok(data);
    }

    // Add new chart data
    [HttpPost]
    public async Task<ActionResult<ChartData>> AddData(ChartData newData)
    {
        _context.ChartData.Add(newData);
        await _context.SaveChangesAsync();
        return CreatedAtAction(nameof(GetData), new { id = newData.Id }, newData);
    }
}