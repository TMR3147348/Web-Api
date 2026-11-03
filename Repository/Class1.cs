using System.Runtime.InteropServices;
using System.Text.Json;
using Entity;
namespace Repository
{
    public class UserRepository
    {
       
            
            public IEnumerable<string> GetUsers()
            {
                return new string[] { "value1", "value2" };
            }

            
            public User GetUserById(int id)
            {
                string filePath = "D:\\שנה ב\\WebAPI\\MyWebApi\\DB.txt";
                using (StreamReader reader = System.IO.File.OpenText(filePath))
                {
                    string? currentUserInFile;
                    while ((currentUserInFile = reader.ReadLine()) != null)
                    {
                        User user =
                        JsonSerializer.Deserialize<User>(currentUserInFile);
                        if (user.id == id)
                            return user;
                    }
                }
            return null;
            }
            
           
            public User PostLogin( Login login)
            {
                string filePath = "D:\\שנה ב\\WebAPI\\MyWebApi\\DB.txt";
                using (StreamReader reader = System.IO.File.OpenText(filePath))
                {
                    string? currentUserInFile;
                    while ((currentUserInFile = reader.ReadLine()) != null)
                    {
                        var user =
                        JsonSerializer.Deserialize<User>(currentUserInFile);
                        if (user.email == login.email && user.password == login.password)
                            //CreatedAtAction(nameof(Get), new { id = user.id },user);
                            return user;
                    }
                }

                return null;
            }

            
            public User AddUser(User user)
            {
                string filePath = "D:\\שנה ב\\WebAPI\\MyWebApi\\DB.txt";
                int numberOfUsers = System.IO.File.ReadLines(filePath).Count();
                user.id = numberOfUsers + 1;
                var  userJson = JsonSerializer.Serialize(user);
                System.IO.File.AppendAllText(filePath, userJson +
                Environment.NewLine);
                return user;
            }

            public void UpdateUser(int id,User user)
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

                if (textToReplace != string.Empty)
                {
                    string text = System.IO.File.ReadAllText(filePath);
                    text = text.Replace(textToReplace,
                    JsonSerializer.Serialize(user));
                    System.IO.File.WriteAllText(filePath, text);
                }
            }

            public void DeleteUser(int id)
            {
            }
        }
    }


