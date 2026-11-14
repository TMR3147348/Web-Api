using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.Data;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;
using Zxcvbn;
using Entity;
using Services;
// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MyWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class UserController : ControllerBase
    {
        IUserService userservice;
        public UserController (IUserService UserService) 
        {
            this.userservice = UserService;
        }
        // GET: api/<UserController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return userservice.Get();
        }

        //GET api/<UserController>/5
        [HttpGet("{id}")]
        public ActionResult<User> Get(int id)
        {
            User user= userservice.Get(id);
            if (user == null)
                return NotFound($"לא נמצא המשתנה{id}");
            else
                return Ok(user);

            
        }
        [HttpPost("Check")]
        public int PostCheck([FromBody] string password)
        {
            return userservice.PostCheck(password);

        }


        [HttpPost("login")]
        public ActionResult<User> PostLogin([FromBody] Login login)
        {
            var user= userservice.PostLogin(login);

            if (user == null)
                return NoContent();
            return Ok(user);
        }

        // POST api/<UserController>
        [HttpPost]

        public ActionResult<User> Post([FromBody] User user)
        {
            //string filePath = "D:\\שנה ב\\WebAPI\\MyWebApi\\DB.txt";
            //int numberOfUsers = System.IO.File.ReadLines(filePath).Count();
            //user.id = numberOfUsers + 1;
            //string userJson = JsonSerializer.Serialize(user);
            //System.IO.File.AppendAllText(filePath, userJson +
            //Environment.NewLine);
            //return CreatedAtAction(nameof(Get), new { id = user.id },
            //user);
            user = userservice.Post(user);
            return CreatedAtAction(nameof(Get), new { id = user.id },
            user); 
        }

        // PUT api/<UserController>/5
        [HttpPut("{id}")]
        //The assignment asks PUT to return Ok(): change void to IActionResult and return Ok() at the end
        public void Put(int id, [FromBody] User user)
        {
//            string filePath = "D:\\שנה ב\\WebAPI\\MyWebApi\\DB.txt";
//            string textToReplace = string.Empty;
//            using (StreamReader reader =
//            System.IO.File.OpenText(filePath))
//            {
//                string currentUserInFile;
//                while ((currentUserInFile = reader.ReadLine()) != null)
//                {
//                    User user1 =
//                    JsonSerializer.Deserialize<User>(currentUserInFile);
//                    if (user1.id == user.id)
//                        textToReplace = currentUserInFile;
//                }
//            }
            
//            if (textToReplace != string.Empty)
//{
//                string text = System.IO.File.ReadAllText(filePath);
//                text = text.Replace(textToReplace,
//                JsonSerializer.Serialize(user));
//                System.IO.File.WriteAllText(filePath, text);
//            }
            userservice.Put(id, user);
        }

        // DELETE api/<UserController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
