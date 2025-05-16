using earrings_api;
using earrings_api.Handlers;
using earrings_api.Middleware;
using earrings_api.Shared;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
Auth auth = new();

var ambiente = builder.Configuration["Environment"] ?? "";
var connectionString = builder.Configuration["ConnectionDB:Finiquitos:" + ambiente];

builder.Services.AddDbContext<AppDBContext>(opciones =>
{
    opciones.UseSqlServer(connectionString, sqlServer => sqlServer.UseNetTopologySuite());
    opciones.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
}
);
ServiceRegistrations.RegisterServices(builder.Services);

// Add services to the container.
builder.Services
    .AddControllers()
    .AddJsonOptions(opciones => opciones.JsonSerializerOptions.PropertyNamingPolicy = new JsonNamingPolicyHandler()); // Cambia a minúsculas propiedades

// Aplica a los controladores el filtro Authorize (según las reglas establecidas)
builder.Services.AddControllers(options => options.Conventions.Add(new AddAuthorizeFiltersControllerConvention()));

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddRouting(options => options.LowercaseUrls = true); // Cambia a minúsculas URL

builder.Services.AddCors(option => option.AddPolicy("AllowAnyOrigin", builder => {
    builder.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod().SetIsOriginAllowed((host) => true);
}));

// Valida el token proporcionado en el header
auth.ValidateJWT(builder.Services);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseRouting();

app.UseCors("AllowAnyOrigin");

//app.MapControllers();

app.UseAuthentication();

app.UseAuthorization();

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllers();
});

app.Run();
