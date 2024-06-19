using static TesteBraveTech.Models.Entidades;

namespace TesteBraveTech.Models
{
	public class UsuarioInterface
	{
		public interface IUsuarioRepository
		{
			IEnumerable<Usuario> GetAllUsuarios();
			Usuario GetUsuarioById(int id);
			void PostUsuario(Usuario usuario);
			void UpdateUsuario(Usuario usuario);
			void DeleteUsuario(int id);
		}
	}
}
