namespace Api.Schema.Request
{
    public class UserLoginRequest
    {
        public string Password { get; set; }

        public string UserName { get; set; }

        public string Email { get; set; }
    
        public string Role { get; set; }

        public int Status { get; set; } = 1;
    }
}
