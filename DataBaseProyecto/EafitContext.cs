using DataBaseProyecto.Models;
using Microsoft.EntityFrameworkCore;

namespace DataBaseProyecto
{
  public class EafitContext : DbContext
  {
    public EafitContext(DbContextOptions<EafitContext> options) : base(options) 
    {
      
    }
    public DbSet<Estudiante> Estudiantes { get; set; }
    public DbSet<Materia> Materias { get; set; }
    public DbSet<Nota> Notas { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
      modelBuilder.Entity<Estudiante>().ToTable("Estudiante");
      modelBuilder.Entity<Materia>().ToTable("Materia");
      modelBuilder.Entity<Nota>().ToTable("Nota");
    }
  }
}