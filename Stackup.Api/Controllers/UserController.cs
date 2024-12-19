// using Microsoft.AspNetCore.Mvc;
// using Microsoft.Extensions.Configuration;
// using System.Data;

// [Route("Api/[controller]")]
// [ApiController]

// public class UserController : ControllerBase
// {
//     private readonly DbManager _dbManager;

//     Response response = new Response();

//     public UserController(IConfiguration configuration)
//     {
//         _dbManager = new DbManager(configuration);
//     }

//     // GET: api/User
//     [HttpGet]

//     public IActionResult GetUsers()
//     {
//         try
//         {
//             response.status = 200;
//             response.message = "Success";
//             response.data = _dbManager.GetAllUsers();
//         }
//         catch (Exception ex)
//         {
//             response.status = 500;
//             response.message = ex.Message;
//         }
//         return Ok(response);
//     }

//     // Post User
//     [HttpPost]
//     public IActionResult CreateUser([FromBody] User user) 
//     {

//         try
//         {
        
//             response.status = 200;
//             response.message = "Success";
//             _dbManager.CreateUser(user);
//         }
//         catch (Exception ex)
//         {
//             response.status = 500;
//             response.message = ex.Message;
            
//         }

//         return Ok(response);
//     }

//     // Put User
//     [HttpPut("{id}")]
//     public IActionResult UpdateUser(int id, [FromBody] User user)
//     {

//         try
//         {
        
//             response.status = 200;
//             response.message = "Success";
//             _dbManager.UpdateUser(id, user);
//         }
//         catch (Exception ex)
//         {
//             response.status = 500;
//             response.message = ex.Message;
            
//         }

//         return Ok(response);
//     }

//     // Delete User
//     [HttpDelete("{id}")]
//     public IActionResult DeleteUser(int id)
//     {

//         try
//         {
//             response.status = 200;
//             response.message = "Success";
//             _dbManager.DeleteUser(id);
//         }
//         catch (Exception ex)
//         {
//             response.status = 500;
//             response.message = ex.Message;
            
//         }

//         return Ok(response);
//     }
// }