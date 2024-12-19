// using Microsoft.AspNetCore.Mvc;
// using Microsoft.Extensions.Configuration;
// using System.Data;

// [Route("api/[controller]")]
// [ApiController]

// public class DendaController : ControllerBase
// {
//     private readonly DbManager _dbManager;
//     Response response = new Response();

//     public DendaController(IConfiguration configuration)
//     {
//         _dbManager = new DbManager(configuration);
//     }

//     [HttpGet]
//     public IActionResult  GetDendas()
//     {
//         try
//         {
//             response.status = 200;
//             response.message = "Success";
//             response.data = _dbManager.GetAllDendas();
//         }
//         catch (Exception ex)
//         {
//             response.status = 500;
//             response.message = ex.Message;
//         }
//         return Ok(response);
//     }

//     [HttpPost]
//     public IActionResult CreateDenda([FromBody] Denda denda)
//     {
//         try
//         {
//             response.status = 200;
//             response.message = "Success";
//             _dbManager.CreateDenda(denda);
//         }
//         catch (Exception ex)
//         {
//             response.status = 500;
//             response.message = ex.Message;
//         } 
//         return Ok(response);
//     }

//     [HttpPut("{id}")]
//     public IActionResult UpdateDenda(int id, [FromBody] Denda denda)
//     {
//         try
//         {
//             response.status = 200;
//             response.message = "Success";
//             _dbManager.UpdateDenda(id, denda);
//         }
//         catch (Exception ex)
//         {
//             response.status = 500;
//             response.message = ex.Message;
//         }
//         return Ok(response);
//     }

//     [HttpDelete("{id}")]
//     public IActionResult DeleteDenda(int id)
//     {
//         try
//         {
//             response.status = 200;
//             response.message = "Success";
//             _dbManager.DeleteDenda(id);
//         }
//         catch (Exception ex)
//         {
//             response.status = 500;
//             response.message = ex.Message;
//         }
//         return Ok(response);
//     }


// }
