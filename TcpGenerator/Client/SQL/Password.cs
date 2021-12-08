namespace Client
{
    public class Password
    {
        public int PostId { get; set; }
        public string PasswordNumber { get; set; }

        public int LoginId { get; set; }
        public virtual Logins Logins { get; set; }
    }
}
