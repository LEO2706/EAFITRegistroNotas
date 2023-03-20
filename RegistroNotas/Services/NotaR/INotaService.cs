using DataBaseProyecto.Models;

namespace RegistroNotas.Services.NotaR
{
  public interface INotaService
  {
    public IEnumerable<Nota> GetMostrarNota();
    public Task Save(Nota nota);
    public List<Nota> TodasLasNotas(int Id_Estudiante, int Id_Materia);
    public string CalcularNota(int Id_Estudiante, int Id_Materia);
  }
}
