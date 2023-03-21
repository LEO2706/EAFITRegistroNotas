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
using Microsoft.EntityFrameworkCore;
using NSubstitute.ExceptionExtensions;
using RegistroNotas.Services.EstudiantesR;
using System.Net;

namespace UnitestProyecto.Services
{
  public class EstudiantesServiceIntegrationTest
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
        Nombre = "German Ezequiel Cano"
      };
    }

    private IServiceProvider CreateContext(string nameBD)
    {
      var services = new ServiceCollection();
      services.AddDbContext<EafitContext>(options => options.UseInMemoryDatabase(databaseName: nameBD), ServiceLifetime.Scoped, ServiceLifetime.Scoped);

      return services.BuildServiceProvider();
    }

    [Test]
    //[TestCase(HttpStatusCode.OK)]
    // [TestCase(HttpStatusCode.InternalServerError)]
    public async Task HttpGetEstudiantes()
    {
      //Arrange
      var nameDb = Guid.NewGuid().ToString();
      var serviceProvider = CreateContext(nameDb);

      var db = serviceProvider.GetService<EafitContext>();
      db.Add(estudiante);

      //Act
      mapper.Map<Estudiante>(estudiante).ReturnsForAnyArgs(estudiante);


      EstudianteService services = new EstudianteService(db);
      var responseServices = services.GetMostrarEstudiantes();

      //Assert
      Assert.True(responseServices.All(x => !x.Id_Estudiante.Equals("")));
    }
  }
}