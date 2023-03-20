using DataBaseProyecto.Models;
using DataBaseProyecto;
using System.Globalization;

namespace RegistroNotas.Services.NotaR
{
  public class NotaService : INotaService
  {
    readonly EafitContext _context;
    public NotaService(EafitContext dbcontext)
    {
      _context = dbcontext;
    }
    public IEnumerable<Nota> GetMostrarNota()
    {
      return _context.Notas;
    }
    public async Task Save(Nota nota)
    {
      _context.Add(nota);
      await _context.SaveChangesAsync();
    }

    public List<Nota> TodasLasNotas(int Id_Estudiante, int Id_Materia)
    {
      _context.Estudiantes.Find(Id_Estudiante);
      _context.Materias.Find(Id_Materia);
      var NotaActual = _context.Notas.Where(x => x.Id_Materia == Id_Materia && x.Id_Estudiante == Id_Estudiante).ToList();
      return NotaActual;
    }

    public string CalcularNota(int Id_Estudiante, int Id_Materia)
    {
      double valorNota = 0;
      double Porcetanje = 0;
      var estudianteActual = _context.Estudiantes.Find(Id_Estudiante);
      var materiaActual = _context.Materias.Find(Id_Materia);
      var NotaActual = _context.Notas.Where(x => x.Id_Materia == Id_Materia && x.Id_Estudiante == Id_Estudiante).ToList();

      foreach (var nota in NotaActual)
      {
        valorNota += (nota.Value * nota.Porcentaje) / 100;
        Porcetanje += nota.Porcentaje;
      }

      if (valorNota > 5)
      {
        return $"Hay un error de datos, el valor de la nota ({valorNota}), es superio a 5.00";
      }

      if (Porcetanje > 100)
      {
        return $"Hay un error de datos, el porcentaje acumulado de todas las notas ({Porcetanje}), es superio a 100.00";
      }

      return $"Estudiante --> {estudianteActual.Nombre}. La nota  de la materia {materiaActual.Nombre} es: {valorNota} --> Total Evaluado {Porcetanje}%";
    }
  }
}
