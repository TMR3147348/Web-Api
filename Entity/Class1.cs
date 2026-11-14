namespace Entity
{
    //Public properties are PascalCase (Email, Password). Keep the names of the stored User properties: add PropertyNameCaseInsensitive = true to the JSON options instead
    public class Login
    {
        public string email { get; set; }
        public string password { get; set; }
    }
    public class User
    {
        public int id { get; set; }
        public string firstname { get; set; }
        public string lastname { get; set; }
        public string password { get; set; }
        public string email { get; set; }
    }
}
