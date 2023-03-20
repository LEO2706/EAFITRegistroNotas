using DataBaseProyecto.Models;
using Microsoft.AspNetCore.Mvc;
using RegistroNotas.Services.EstudiantesR;

namespace RegistroNotas.Controllers
{
  [ApiController]
  [Route("[controller]")]
  public class EstudianteController : ControllerBase
  {
    readonly IEstudianteService estudianteService;

    public EstudianteController(IEstudianteService estudianteService)
    {
      this.estudianteService = estudianteService;
    }

    [HttpGet]
    [Route("Listar")]
    public IActionResult GetListaEstudiantes()
    {
      return Ok(estudianteService.GetMostrarEstudiantes());
    }

    [HttpGet]
    [Route("Buscar/{Id_Estudiante}")]
    public IActionResult GetBuscarEstudiantes(int Id_Estudiante)
    {
      return Ok(estudianteService.GetFindEstudiante(Id_Estudiante));
    }

    [HttpPost]
    [Route("Registrar")]
    public IActionResult PostRegistrarEstudiante([FromBody]Estudiante estudiante)
    {
      estudianteService.Save(estudiante);
      return Ok();
    }
  }
}