//fix: Removed "using Microsoft.AspNetCore.Identity;" and "using Microsoft.AspNetCore.Identity.Data;" - they were added by mistake and are not used
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;
using Zxcvbn;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MyWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        // GET: api/<UserController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<UserController>/5
        //Why is GET by id commented out? It should read the file and return the user with this id (or NotFound / NoContent)
        //[HttpGet("{id}")]
        //public string Get(int id)
        //{
        //    string filePath = "E:\\שנה ב\\WebAPI\\MyWebApi\\DB.txt";
        //    using (StreamReader reader = System.IO.File.OpenText(filePath))
        //    {
        //        string? currentUserInFile;
        //        while ((currentUserInFile = reader.ReadLine()) != null)
        //        {
        //            User user =
        //            JsonSerializer.Deserialize<User>(currentUserInFile);
        //            if (user.id == id)
        //                RETURN USER TO CLIENT
        //        }
        //    }
        //    RETURN NO USER FOUND
        //}
        [HttpPost("Check")]
        public int PostCheck([FromBody] string password)
        {
            if (password == null)
                return 0;
            //cont result=zxcvbn(password)
            //const score=result.score
            var result = Core.EvaluatePassword(password);
            int score = result.Score;
            return score;
        }


        [HttpPost("login")]
        public ActionResult<User> PostLogin([FromBody] Login login)
        {
            //This full path works only on your computer, and DB.txt is not in the repository (.gitignore leaves it out),
            //so nobody else can run the project. Keep DB.txt in the project folder, commit it, and use the relative path "DB.txt"
            string filePath = "D:\\שנה ב\\WebAPI\\MyWebApi\\DB.txt";
            using (StreamReader reader = System.IO.File.OpenText(filePath))
            {
                string? currentUserInFile;
                while ((currentUserInFile = reader.ReadLine()) != null)
                {
                    User user =
                    JsonSerializer.Deserialize<User>(currentUserInFile);
                    if (user.email == login.email && user.password == login.password)
                        //CreatedAtAction(nameof(Get), new { id = user.id },user);
                        //This returns what the client sent (email and password). Should it return the user that was found?
                        return Ok(login);
                }
            }

            return NoContent();
        }

        // POST api/<UserController>
        [HttpPost]

        public ActionResult<User> Post([FromBody] User user)
        {
            //Same here: use the relative path "DB.txt"
            string filePath = "D:\\שנה ב\\WebAPI\\MyWebApi\\DB.txt";
            int numberOfUsers = System.IO.File.ReadLines(filePath).Count();
            user.id = numberOfUsers + 1;
            string userJson = JsonSerializer.Serialize(user);
            System.IO.File.AppendAllText(filePath, userJson +
            Environment.NewLine);
            return CreatedAtAction(nameof(Get), new { id = user.id },
            user);
        }

        // PUT api/<UserController>/5
        [HttpPut("{id}")]
        //The assignment asks PUT to return Ok(): change void to IActionResult and return Ok() at the end
        public void Put(int id, [FromBody] User user)
        {
            //Same here: use the relative path "DB.txt"
            string filePath = "D:\\שנה ב\\WebAPI\\MyWebApi\\DB.txt";
            string textToReplace = string.Empty;
            using (StreamReader reader =
            System.IO.File.OpenText(filePath))
            {
                string currentUserInFile;
                while ((currentUserInFile = reader.ReadLine()) != null)
                {
                    User user1 =
                    JsonSerializer.Deserialize<User>(currentUserInFile);
                    //fix: Look for the id from the route (api/User/5), not the id in the body
                    if (user1.id == id)
                    {
                        textToReplace = currentUserInFile;
                        //fix: Found- break
                        break;
                    }
                }
            }
            if(textToReplace != string.Empty)
{
                //fix: Keep the id, otherwise the updated user is saved with the id from the body
                user.id = id;
                string text = System.IO.File.ReadAllText(filePath);
                text = text.Replace(textToReplace,
                JsonSerializer.Serialize(user));
                System.IO.File.WriteAllText(filePath, text);
            }
        }

        // DELETE api/<UserController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
