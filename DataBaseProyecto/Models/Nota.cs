using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataBaseProyecto.Models
{
  public class Nota
  {
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id_Nota { get; set; }
    public double Value { get; set; }
    public double Porcentaje { get; set; }
    public string? Actividad { get; set; }

    public int Id_Materia { get; set; }
    [ForeignKey("Id_Materia")]
    public virtual ICollection<Materia>? Materia { get; set; }

    public int Id_Estudiante{ get; set; }
    [ForeignKey("Id_Estudiante")]
    public virtual ICollection<Estudiante>? Estudiante { get; set; }

  }
}