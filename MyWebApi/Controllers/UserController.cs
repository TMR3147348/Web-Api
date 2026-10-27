using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.Data;
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
                        return Ok(login);
                }
            }

            return NoContent();
        }

        // POST api/<UserController>
        [HttpPost]

        public ActionResult<User> Post([FromBody] User user)
        {
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
        public void Put(int id, [FromBody] User user)
        {
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
                    if (user1.id == user.id)
                        textToReplace = currentUserInFile;
                }
            }
            if(textToReplace != string.Empty)
{
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
