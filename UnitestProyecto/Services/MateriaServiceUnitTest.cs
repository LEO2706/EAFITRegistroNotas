using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using DataBaseProyecto;
using DataBaseProyecto.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using NSubstitute;
using NSubstitute.ExceptionExtensions;
using RegistroNotas.Services.MateriaR;

namespace UnitestProyecto.Services
{
  public class MateriaServiceUnitTest
  {
    private Materia materia;
    private IMapper mapper;

    [SetUp]
    public void Setup()
    {
      mapper = Substitute.For<IMapper>();
      materia = new Materia()
      {
        Id_Materia = 1,
        Nombre = "Programacion"
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
    public async Task MostrarTodosLasMaterias(HttpStatusCode code)
    {
      //Arrange
      var nameDb = Guid.NewGuid().ToString();
      var serviceProvider = CreateContext(nameDb);

      var db = serviceProvider.GetService<EafitContext>();
      db.Add(materia);

      //Act
      if (code == HttpStatusCode.OK)
      {
        mapper.Map<Materia>(materia).ReturnsForAnyArgs(materia);
      }
      else
      {
        mapper.Map<Materia>(materia).ThrowsForAnyArgs(x => { throw new Exception(); });
      }

      MateriaService services = new MateriaService(db);
      var responseServices = services.GetMostrarMaterias();

      //Assert
      Assert.AreEqual(code, (HttpStatusCode.OK));
    }

    [Test]
    [TestCase(HttpStatusCode.OK)]
    // [TestCase(HttpStatusCode.InternalServerError)]
    public async Task BuscarMateria(HttpStatusCode code)
    {
      //Arrange
      var nameDb = Guid.NewGuid().ToString();
      var serviceProvider = CreateContext(nameDb);

      var db = serviceProvider.GetService<EafitContext>();
      db.Add(materia);

      //Act
      if (code == HttpStatusCode.OK)
      {
        mapper.Map<Materia>(materia).ReturnsForAnyArgs(materia);
      }
      else
      {
        mapper.Map<Materia>(materia).ThrowsForAnyArgs(x => { throw new Exception(); });
      }

      MateriaService services = new MateriaService(db);
      int id = 1;
      var responseServices = services.GetFindMateria(id);

      //Assert
      Assert.AreEqual(code, (HttpStatusCode.OK));
    }

    [Test]
    [TestCase(HttpStatusCode.OK)]
    // [TestCase(HttpStatusCode.InternalServerError)]
    public async Task GuardarMateria(HttpStatusCode code)
    {
      //Arrange
      var nameDb = Guid.NewGuid().ToString();
      var serviceProvider = CreateContext(nameDb);

      var db = serviceProvider.GetService<EafitContext>();
      db.Add(materia);

      //Act
      if (code == HttpStatusCode.OK)
      {
        mapper.Map<Materia>(materia).ReturnsForAnyArgs(materia);
      }
      else
      {
        mapper.Map<Materia>(materia).ThrowsForAnyArgs(x => { throw new Exception(); });
      }

      MateriaService services = new MateriaService(db);
      var responseServices = services.Save(materia);

      //Assert
      Assert.AreEqual(code, (HttpStatusCode.OK));
    }
  }
}