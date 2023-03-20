using DataBaseProyecto;
using Microsoft.EntityFrameworkCore;
using RegistroNotas.Services.EstudiantesR;
using RegistroNotas.Services.MateriaR;
using RegistroNotas.Services.NotaR;

var builder = WebApplication.CreateBuilder(args);
// Add services to the container.
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
var connectionString = builder.Configuration.GetConnectionString("EafitConnection");
builder.Services.AddDbContext<EafitContext>(options => options.UseMySQL(connectionString));
builder.Services.AddScoped<IEstudianteService, EstudianteService>();
builder.Services.AddScoped<IMateriaService, MateriaService>();
builder.Services.AddScoped<INotaService, NotaService>();

var app = builder.Build();

//using (var scope = app.Services.CreateScope())
//{
//  var dataContext = scope.ServiceProvider.GetRequiredService<EafitContext>();
//  dataContext.Database.Migrate();
//}

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
  {
    app.UseSwagger();
    app.UseSwaggerUI();
  }

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();