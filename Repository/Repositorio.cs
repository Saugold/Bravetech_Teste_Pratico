

using TesteBraveTech.Models;
using static TesteBraveTech.Models.Entidades;
using static TesteBraveTech.Models.UsuarioInterface;

namespace TesteBraveTech.Repository
{
	public class Repositorio : IUsuarioRepository
	{
		private readonly List<Usuario> _usuarios = new List<Usuario>();
		public void DeleteUsuario(int id)
		{
			var user = GetUsuarioById(id);
			if (user != null)
			{
				_usuarios.Remove(user);
			}
		}

		public IEnumerable<Usuario> GetAllUsuarios()
		{
			return _usuarios;
		}

		public Usuario GetUsuarioById(int id)
		{
			return _usuarios.FirstOrDefault(u => u.Id == id);
		}

		public void PostUsuario(Usuario usuario)
		{
			_usuarios.Add(usuario);
		}

		public void UpdateUsuario(Usuario usuario)
		{
			var existe = GetUsuarioById(usuario.Id);
			if (existe != null)
			{
				existe.Name = usuario.Name;
				existe.Email = usuario.Email;
				existe.Email = usuario.Telefone;
			}
		}
	}
}
