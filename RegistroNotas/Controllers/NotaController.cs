using DataBaseProyecto.Models;
using Microsoft.AspNetCore.Mvc;
using RegistroNotas.Services.MateriaR;
using RegistroNotas.Services.NotaR;

namespace RegistroNotas.Controllers
{
  [ApiController]
  [Route("[controller]")]
  public class NotaController : ControllerBase
  {
    readonly INotaService notaService;

    public NotaController(INotaService notaService)
    {
      this.notaService = notaService;
    }

    [HttpGet]
    [Route("Listar")]
    public IActionResult GetListarNotas()
    {
      return Ok(notaService.GetMostrarNota());
    }

    [HttpPost]
    [Route("Registrar")]
    public IActionResult PostRegistrarNotas([FromBody] Nota nota)
    {
      notaService.Save(nota);
      return Ok();
    }

    [HttpGet]
    [Route("TodasLasNotas/{Id_Materia}/{Id_Estudiante}")]
    public IActionResult GetBuscarNotas(int Id_Materia, int Id_Estudiante)
    {
      return Ok(notaService.TodasLasNotas(Id_Estudiante,Id_Materia));
    }

    [HttpGet]
    [Route("CalcularNota/{Id_Materia}/{Id_Estudiante}")]
    public IActionResult GetCalcularNota(int Id_Materia, int Id_Estudiante)
    {
      return Ok(notaService.CalcularNota(Id_Estudiante, Id_Materia));
    }
  }
}
