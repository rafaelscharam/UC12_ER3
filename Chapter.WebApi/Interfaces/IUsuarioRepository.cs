using Chapter.WebApi.Models;

namespace Chapter.WebApi.Interfaces
{
    public interface IUsuarioRepository
    {
        Usuario Login(string Email, string Senha);
    }
}
