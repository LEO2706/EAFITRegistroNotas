using DataBaseProyecto.Models;

namespace RegistroNotas.Services.MateriaR
{
  public interface IMateriaService
  {
    public IEnumerable<Materia> GetMostrarMaterias();
    public Task Save(Materia materia);
    public Materia GetFindMateria(int Id_Materia);
  }
}
