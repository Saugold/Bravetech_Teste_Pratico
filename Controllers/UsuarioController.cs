using Microsoft.AspNetCore.Mvc;
using TesteBraveTech.Serviço;
using TesteBraveTech.Models;
using static TesteBraveTech.Models.Entidades;

namespace TesteBraveTech.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsuarioController : ControllerBase
    {
        private readonly UsuarioService _usuario;

        public UsuarioController(UsuarioService usuarioService)
        {
            _usuario = usuarioService;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var usuarios = _usuario.GetAllUsuarios();
            return Ok(usuarios);
        }

        [HttpGet("{id}")]
        public IActionResult Details(int id)
        {
            var usuario = _usuario.GetUsuarioById(id);
            if (usuario == null)
            {
                return NotFound();
            }
            return Ok(usuario);
        }

        [HttpPost]
        public IActionResult Create([FromBody] Usuario usuario)
        {
            if (ModelState.IsValid)
            {
                _usuario.PostUsuario(usuario);
                return CreatedAtAction(nameof(Details), new { id = usuario.Id }, usuario);
            }
            return BadRequest(ModelState);
        }

        [HttpPut("{id}")]
        public IActionResult Edit(int id, [FromBody] Usuario usuario)
        {
            if (id != usuario.Id)
            {
                return BadRequest();
            }

            if (ModelState.IsValid)
            {
                _usuario.UpdateUsuario(usuario);
                return NoContent();
            }
            return BadRequest(ModelState);
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteConfirmed(int id)
        {
            var usuario = _usuario.GetUsuarioById(id);
            if (usuario == null)
            {
                return NotFound();
            }
            _usuario.DeleteUsuario(id);
            return NoContent();
        }
    }
}
