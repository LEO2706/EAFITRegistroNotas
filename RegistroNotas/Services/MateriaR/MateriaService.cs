using DataBaseProyecto.Models;
using DataBaseProyecto;

namespace RegistroNotas.Services.MateriaR
{
  public class MateriaService : IMateriaService
  {
    readonly EafitContext _context;
    public MateriaService(EafitContext dbcontext)
    {
      _context = dbcontext;
    }
    public IEnumerable<Materia> GetMostrarMaterias()
    {
      return _context.Materias;
    }
    public async Task Save(Materia materia)
    {
      _context.Add(materia);
      await _context.SaveChangesAsync();
    }

    public Materia GetFindMateria(int Id_Materia)
    {
      var materiaActual = _context.Materias.Find(Id_Materia);

      return materiaActual;
    }
  }
}