namespace Entity
{
    public class Login
    {
        public string email { get; set; }
        public string password { get; set; }
    }
    public class User
    {
        //In C#, properties are written in PascalCase: Id. DB.txt stores the current names: if you rename them, set PropertyNameCaseInsensitive = true in the JsonSerializerOptions, so the existing file still loads
        public int id { get; set; }
        public string firstname { get; set; }
        public string lastname { get; set; }
        public string password { get; set; }
        public string email { get; set; }
    }
}
