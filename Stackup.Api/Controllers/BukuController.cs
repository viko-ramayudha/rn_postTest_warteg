// using Microsoft.AspNetCore.Mvc;
// using Microsoft.Extensions.Configuration;
// using System.Data;

// [Route("Api/[controller]")]
// [ApiController]

// public class BukuController : ControllerBase
// {
//     private readonly DbManager _dbManager;

//     Response response = new Response();

//     public BukuController(IConfiguration configuration)
//     {
//         _dbManager = new DbManager(configuration);
//     }

//     // GET: api/Buku
//     [HttpGet]

//     public IActionResult GetBukus()
//     {
//         try
//         {
//             response.status = 200;
//             response.message = "Success";
//             response.data = _dbManager.GetAllBukus();
//         }
//         catch (Exception ex)
//         {
//             response.status = 500;
//             response.message = ex.Message;
//         }
//         return Ok(response);
//     }

//     [HttpGet("GetBukuById")]
//     public IActionResult GetBukuById(int id)
//     {
//         try
//         {
//             var buku = _dbManager.GetBukuById(id);
//             if (buku == null)
//             {
//                 response.status = 404;
//                 response.message = "Buku not found";
//                 response.data = null;
//             }
//             else
//             {
//                 response.status = 200;
//                 response.message = "Success";
//                 response.data = buku;
//             }
//         }
//         catch (Exception ex)
//         {
//             response.status = 500;
//             response.message = ex.Message;
//         }
//         return Ok(response);
//         }

//     // Post Buku
//     [HttpPost]
//     public IActionResult CreateBuku([FromBody] Buku buku) 
//     {

//         try
//         {
        
//             response.status = 200;
//             response.message = "Success";
//             _dbManager.CreateBuku(buku);
//         }
//         catch (Exception ex)
//         {
//             response.status = 500;
//             response.message = ex.Message;
            
//         }

//         return Ok(response);
//     }

//     // Put Buku
//     [HttpPut("{id}")]
//     public IActionResult UpdateBuku(int id, [FromBody] Buku buku)
//     {

//         try
//         {
        
//             response.status = 200;
//             response.message = "Success";
//             _dbManager.UpdateBuku(id, buku);
//         }
//         catch (Exception ex)
//         {
//             response.status = 500;
//             response.message = ex.Message;
            
//         }

//         return Ok(response);
//     }

//     // Delete Buku
//     [HttpDelete("{id}")]
//     public IActionResult DeleteBuku(int id)
//     {

//         try
//         {
//             response.status = 200;
//             response.message = "Success";
//             _dbManager.DeleteBuku(id);
//         }
//         catch (Exception ex)
//         {
//             response.status = 500;
//             response.message = ex.Message;
            
//         }

//         return Ok(response);
//     }
// }