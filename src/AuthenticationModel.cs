namespace NSoneBilling
{
    public class AuthenticationModel
    {
        public GrantType GrantType { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string ApplicationId { get; set; }
        public string ClientId { get; set; }
    }
}