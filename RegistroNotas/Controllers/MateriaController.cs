using DataBaseProyecto.Models;
using Microsoft.AspNetCore.Mvc;
using RegistroNotas.Services.EstudiantesR;
using RegistroNotas.Services.MateriaR;

namespace RegistroNotas.Controllers
{
  [ApiController]
  [Route("[controller]")]
  public class MateriaController : ControllerBase
  {
    readonly IMateriaService materiaService;

    public MateriaController(IMateriaService materiaService)
    {
      this.materiaService = materiaService;
    }

    [HttpGet]
    [Route("Listar")]
    public IActionResult GetListaMaterias()
    {
      return Ok(materiaService.GetMostrarMaterias());
    }

    [HttpGet]
    [Route("Buscar/{Id_Materia}")]
    public IActionResult GetBuscarMateria(int Id_Materia)
    {
      return Ok(materiaService.GetFindMateria(Id_Materia));
    }

    [HttpPost]
    [Route("Registrar")]
    public IActionResult PostRegistrarMaterias([FromBody] Materia materia)
    {
      materiaService.Save(materia);
      return Ok();
    }
  }
}