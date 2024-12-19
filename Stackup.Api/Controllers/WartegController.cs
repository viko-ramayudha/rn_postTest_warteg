using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System.Data;

[Route("Api/[controller]")]
[ApiController]

public class WartegController : ControllerBase
{
    private readonly DbManager _dbManager;

    Response response = new Response();

    public WartegController(IConfiguration configuration)
    {
        _dbManager = new DbManager(configuration);
    }

    // GET: api/Warteg
    [HttpGet]

    public IActionResult GetWartegs()
    {
        try
        {
            response.status = 200;
            response.message = "Success";
            response.data = _dbManager.GetAllWartegs();
        }
        catch (Exception ex)
        {
            response.status = 500;
            response.message = ex.Message;
        }
        return Ok(response);
    }

    [HttpGet("GetWartegById")]
    public IActionResult GetWartegById(int id)
    {
        try
        {
            var warteg = _dbManager.GetWartegById(id);
            if (warteg == null)
            {
                response.status = 404;
                response.message = "Warteg not found";
                response.data = null;
            }
            else
            {
                response.status = 200;
                response.message = "Success";
                response.data = warteg;
            }
        }
        catch (Exception ex)
        {
            response.status = 500;
            response.message = ex.Message;
        }
        return Ok(response);
        }

    // Post Warteg
    [HttpPost]
    public IActionResult CreateWarteg([FromBody] Warteg warteg) 
    {

        try
        {
        
            response.status = 200;
            response.message = "Success";
            _dbManager.CreateWarteg(warteg);
        }
        catch (Exception ex)
        {
            response.status = 500;
            response.message = ex.Message;
            
        }

        return Ok(response);
    }

    // Put Warteg
    [HttpPut("{id}")]
    public IActionResult UpdateWarteg(int id, [FromBody] Warteg warteg)
    {

        try
        {
        
            response.status = 200;
            response.message = "Success";
            _dbManager.UpdateWarteg(id, warteg);
        }
        catch (Exception ex)
        {
            response.status = 500;
            response.message = ex.Message;
            
        }

        return Ok(response);
    }

    // Delete Warteg
    [HttpDelete("{id}")]
    public IActionResult DeleteWarteg(int id)
    {

        try
        {
            response.status = 200;
            response.message = "Success";
            _dbManager.DeleteWarteg(id);
        }
        catch (Exception ex)
        {
            response.status = 500;
            response.message = ex.Message;
            
        }

        return Ok(response);
    }
}