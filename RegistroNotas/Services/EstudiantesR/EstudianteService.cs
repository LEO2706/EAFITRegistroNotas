using DataBaseProyecto;
using DataBaseProyecto.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace RegistroNotas.Services.EstudiantesR
{
  public class EstudianteService : IEstudianteService
  {
    readonly EafitContext _context;
    public EstudianteService(EafitContext dbcontext)
    {
      _context = dbcontext;
    }
    public IEnumerable<Estudiante> GetMostrarEstudiantes()
    {
      return _context.Estudiantes;
    }

    public async Task Save(Estudiante estudiante)
    {
      _context.Add(estudiante);
      await _context.SaveChangesAsync();
    }
    public Estudiante GetFindEstudiante(int Id_Estudiante)
    {
      var estudianteActual = _context.Estudiantes.Find(Id_Estudiante);

      return estudianteActual;
    }
  }
}