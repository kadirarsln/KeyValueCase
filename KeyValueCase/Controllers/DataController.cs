using KeyValueCase.Services;
using Microsoft.AspNetCore.Mvc;

namespace KeyValueStore.Controllers;

[ApiController]
[Route("data")]
public class DataController(IDataService dataService) : ControllerBase
{
    [HttpGet("{key}")]
    public async Task<IActionResult> Get(string key)
    {
        var result = await dataService.GetDataAsync(key);
        if (result == null) return NotFound();
        return Ok(result.Data);
    }

    [HttpPost("{key}")]
    public async Task<IActionResult> Post(string key, [FromBody] string jsonData)
    {
        await dataService.SaveDataAsync(key, jsonData);
        return Ok();
    }

    [HttpDelete("{key}")]
    public async Task<IActionResult> Delete(string key)
    {
        await dataService.DeleteDataAsync(key);
        return NoContent();
    }
}