using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SecureApi.Models;
[ApiController]
[Route("api/data")]
public class DataController : ControllerBase
{
    [HttpGet]
    public IActionResult Get()
    {
        
        return Ok("Secure endpoint using Azure AD authentication!");
    }
    //by serverlogic branch
     [Authorize]
    [HttpPost]
    public IActionResult Post([FromBody] DataRequest request)
    {
        if (string.IsNullOrWhiteSpace(request?.Message))
        {
            return BadRequest("Message is required (by serverlogic branch).");
        }

        var response = new
        {
            ReceivedMessage = request.Message,
            Status = "Saved successfully",
            Timestamp = DateTime.UtcNow
        };

        return Ok(response);
    }
}
