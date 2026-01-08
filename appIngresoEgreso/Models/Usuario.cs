namespace appIngresoEgreso.Models
{
    public class Usuario
    {
        private string _email;
        private string _password;
        public string Email { get => _email; set => _email = value; }
        public string Password { get => _password; set => _password = value; }
        public Usuario(string email,string password)
        {
            _email = email;
            _password = password;
        }
    }
}
