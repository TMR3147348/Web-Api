namespace MyWebApi
{
    //In C#, public properties are written in PascalCase (Id, FirstName, LastName, Password, Email).
    //If you rename them, DB.txt still has the old names, so read it with
    //new JsonSerializerOptions { PropertyNameCaseInsensitive = true }
    public class User
    {
       
    
        
            public int id { get; set; }
            public string firstname { get; set; }
            public string lastname { get; set; }
            public string password { get; set; }
            public string email { get; set; }
        
    }

}

