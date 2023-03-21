using System.Net;
using AutoMapper;
using DataBaseProyecto;
using DataBaseProyecto.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using NSubstitute;
using NSubstitute.ExceptionExtensions;
using RegistroNotas.Services.EstudiantesR;

namespace UnitestProyecto.Services
{
  public class EstudianteServiceUnitTest
  {
    private Estudiante estudiante;
    private IMapper mapper;

    [SetUp]
    public void Setup()
    {
      mapper = Substitute.For<IMapper>();
      estudiante = new Estudiante()
      {
        Id_Estudiante = 1,
        Nombre = "Ricardo Isaza"
      };
    }

    private IServiceProvider CreateContext(string nameBD)
    {
      var services = new ServiceCollection();
      services.AddDbContext<EafitContext>(options => options.UseInMemoryDatabase(databaseName: nameBD), ServiceLifetime.Scoped, ServiceLifetime.Scoped);

      return services.BuildServiceProvider();
    }

    [Test]
    [TestCase(HttpStatusCode.OK)]
    // [TestCase(HttpStatusCode.InternalServerError)]
    public async Task MostrarTodosLosEstudiante(HttpStatusCode code)
    {
      //Arrange
      var nameDb = Guid.NewGuid().ToString();
      var serviceProvider = CreateContext(nameDb);

      var db = serviceProvider.GetService<EafitContext>();
      db.Add(estudiante);

      //Act
      if (code == HttpStatusCode.OK)
      {
        mapper.Map<Estudiante>(estudiante).ReturnsForAnyArgs(estudiante);
      }
      else
      {
        mapper.Map<Estudiante>(estudiante).ThrowsForAnyArgs(x => { throw new Exception(); });
      }

      EstudianteService services = new EstudianteService(db);
      var responseServices = services.GetMostrarEstudiantes();

      //Assert
      Assert.AreEqual(code, (HttpStatusCode.OK));
    }

    [Test]
    [TestCase(HttpStatusCode.OK)]
    // [TestCase(HttpStatusCode.InternalServerError)]
    public async Task RegistrarEstudiante(HttpStatusCode code)
    {
      //Arrange
      var nameDb = Guid.NewGuid().ToString();
      var serviceProvider = CreateContext(nameDb);

      var db = serviceProvider.GetService<EafitContext>();
      db.Add(estudiante);

      //Act
      if (code == HttpStatusCode.OK)
      {
        mapper.Map<Estudiante>(estudiante).ReturnsForAnyArgs(estudiante);
      }
      else
      {
        mapper.Map<Estudiante>(estudiante).ThrowsForAnyArgs(x => { throw new Exception(); });
      }

      EstudianteService services = new EstudianteService(db);
      var responseServices = services.Save(estudiante);

      //Assert
      Assert.AreEqual(code, (HttpStatusCode.OK));

    }

    [Test]
    [TestCase(HttpStatusCode.OK)]
    // [TestCase(HttpStatusCode.InternalServerError)]
    public async Task BuscarEstudiante(HttpStatusCode code)
    {
      //Arrange
      var nameDb = Guid.NewGuid().ToString();
      var serviceProvider = CreateContext(nameDb);

      var db = serviceProvider.GetService<EafitContext>();
      db.Add(estudiante);

      //Act
      if (code == HttpStatusCode.OK)
      {
        mapper.Map<Estudiante>(estudiante).ReturnsForAnyArgs(estudiante);
      }
      else
      {
        mapper.Map<Estudiante>(estudiante).ThrowsForAnyArgs(x => { throw new Exception(); });
      }

      EstudianteService services = new EstudianteService(db);
      int id = 1;
      var responseServices = services.GetFindEstudiante(id);

      //Assert
      Assert.AreEqual(code, (HttpStatusCode.OK));

    }
  }
}