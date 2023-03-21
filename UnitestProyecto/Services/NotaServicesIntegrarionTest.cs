using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using DataBaseProyecto.Models;
using DataBaseProyecto;
using Microsoft.Extensions.DependencyInjection;
using NSubstitute;
using RegistroNotas.Services.NotaR;
using Microsoft.EntityFrameworkCore;

namespace UnitestProyecto.Services
{
  public class NotaServicesIntegrarionTest
  {
    private Nota nota;
    private IMapper mapper;

    [SetUp]
    public void Setup()
    {
      mapper = Substitute.For<IMapper>();
      nota = new Nota()
      {
        Id_Nota = 1,
        Value = 4,
        Porcentaje = 50,
        Actividad = "Test",
        Id_Materia = 1,
        Id_Estudiante = 1
      };
    }

    private IServiceProvider CreateContext(string nameBD)
    {
      var services = new ServiceCollection();
      services.AddDbContext<EafitContext>(options => options.UseInMemoryDatabase(databaseName: nameBD), ServiceLifetime.Scoped, ServiceLifetime.Scoped);

      return services.BuildServiceProvider();
    }

    //[Test]
    ////[TestCase(HttpStatusCode.OK)]
    //// [TestCase(HttpStatusCode.InternalServerError)]
    //public async Task HttpGetNotasCalculo()
    //{
    //  //Arrange
    //  var nameDb = Guid.NewGuid().ToString();
    //  var serviceProvider = CreateContext(nameDb);

    //  var db = serviceProvider.GetService<EafitContext>();
    //  db.Add(nota
    //    );

    //  //Act
    //  mapper.Map<Nota>(nota).ReturnsForAnyArgs(nota);


    //  NotaService services = new NotaService(db);
    //  int idMateria = 1;
    //  int idEstudiante = 1;
    //  var responseServices = services.CalcularNota(idEstudiante, idMateria);

    //  //Assert
    //  Assert.True(responseServices.Contains("Ok"));
    //}
  }
}
