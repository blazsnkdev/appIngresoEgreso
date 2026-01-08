using appIngresoEgreso.Dao;
using appIngresoEgreso.Models.ViewModels;

namespace appIngresoEgreso.Services.Impl
{
    public class AuthService : IAuthService
    {
        private readonly IUsuarioDao _usuarioDAO;
        public AuthService(IUsuarioDao usuarioDao)
        {
            _usuarioDAO = usuarioDao;
        }
        public bool Login(LoginViewModel viewModel)
        {
            var resultSuccess = _usuarioDAO.GetUsuarioByEmailAndPassword(viewModel.EmailInput,viewModel.PasswordInput);
            return resultSuccess;
        }
    }
}
