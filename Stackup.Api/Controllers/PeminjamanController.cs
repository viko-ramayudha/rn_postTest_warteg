// using Microsoft.AspNetCore.Mvc;
// using Microsoft.Extensions.Configuration;
// using System.Data;

// [Route("api/[controller]")]
// [ApiController]

// public class PeminjamanController : ControllerBase
// {
//     private readonly DbManager _dbManager;
//     Response response = new Response();

//     public PeminjamanController(IConfiguration configuration)
//     {
//         _dbManager = new DbManager(configuration);
//     }

//     [HttpGet]
//     public IActionResult  GetPeminjamans()
//     {
//         try
//         {
//             response.status = 200;
//             response.message = "Success";
//             response.data = _dbManager.GetAllPeminjamans();
//         }
//         catch (Exception ex)
//         {
//             response.status = 500;
//             response.message = ex.Message;
//         }
//         return Ok(response);
//     }
//     [HttpGet("GetPeminjamanById")]
//     public IActionResult  GetIndeksPeminjamanById(int id)
//     {
//         try
//         {
//             response.status = 200;
//             response.message = "Success";
//             response.data = _dbManager.GetIndeksPeminjamanById(id);
//         }
//         catch (Exception ex)
//         {
//             response.status = 500;
//             response.message = ex.Message;
//         }
//         return Ok(response);
//     }

//     [HttpPost("InsertPeminjaman")]
//     public IActionResult CreatePeminjaman([FromBody] Peminjaman peminjaman)
//     {
//         try
//         {
//             response.status = 200;
//             response.message = "Success";
//             _dbManager.CreatePeminjaman(peminjaman);
//         }
//         catch (Exception ex)
//         {
//             response.status = 500;
//             response.message = ex.Message;
//         }
//         return Ok(response);
//     }

//     [HttpPut("UpdatePeminjaman")]
//     public IActionResult UpdatePeminjaman(int id, [FromBody] Peminjaman peminjaman)
//     {
//         try
//         {
//             response.status = 200;
//             response.message = "Success";
//             _dbManager.UpdatePeminjaman(id, peminjaman);
//         }
//         catch (Exception ex)
//         {
//             response.status = 500;
//             response.message = ex.Message;
//         }
//         return Ok(response);
//     }

//     [HttpDelete("DeletePeminjaman")]
//     public IActionResult DeletePeminjaman(int id)
//     {
//         try
//         {
//             response.status = 200;
//             response.message = "Success";
//             _dbManager.DeletePeminjaman(id);
//         }
//         catch (Exception ex)
//         {
//             response.status = 500;
//             response.message = ex.Message;
//         }
//         return Ok(response);
//     }


// }
