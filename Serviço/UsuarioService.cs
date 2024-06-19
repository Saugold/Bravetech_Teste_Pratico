using static TesteBraveTech.Models.Entidades;
using static TesteBraveTech.Models.UsuarioInterface;

namespace TesteBraveTech.Serviço
{
	public class UsuarioService
	{
		private readonly IUsuarioRepository _usuario;
		public UsuarioService(IUsuarioRepository usuarioRepository)
		{
            _usuario = usuarioRepository;
		}
		public IEnumerable<Usuario> GetAllUsuarios()
		{
			return _usuario.GetAllUsuarios();
		}
		public Usuario GetUsuarioById(int id)
		{
			return _usuario.GetUsuarioById(id);
		}

		public void PostUsuario(Usuario usuario)
		{
            if (UsuarioExiste(usuario.Id))
            {
                throw new ArgumentException($"Usuário com ID {usuario.Id} já existe.");
            }
            _usuario.PostUsuario(usuario);
		}

		public void UpdateUsuario(Usuario usuario)
		{
            _usuario.UpdateUsuario(usuario);
            if (!UsuarioExiste(usuario.Id))
            {
                throw new ArgumentException($"Usuário com ID {usuario.Id} não encontrado.");
            }
        }

		public void DeleteUsuario(int id)
		{
            _usuario.DeleteUsuario(id);
		}
        private bool UsuarioExiste(int id)
        {
            var existeUsuario = _usuario.GetUsuarioById(id);
            return existeUsuario != null;
        }
    }
}
