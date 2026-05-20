using GastosPersonales.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
#region CONFIGURACION DE LA CONEXION A LA BASE DE DATOS
// Configuramos el contex, para usarlo en la aplicacion
builder.Services.AddDbContext<ApplicationDbContext>(opciones => opciones.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
#endregion

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi

#region CONFIGURACION DE SWAGGER
builder.Services.AddSwaggerGen(opciones =>
{
    opciones.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo
    {
        Version = "v1",
        Title = "Gestion de gastos API",
        Description = "Esta es una api de ejemplo para aprender a usar ASP.NET Core, para gestionar gastos personales",
        Contact = new Microsoft.OpenApi.Models.OpenApiContact // Datos del contacto
        {
            Email = "dabojimenez16@hotmail.com",
            Name = "Stalyn Jimenez",
            Url = new Uri("https://stalynjimenez.com")
        },
        License = new Microsoft.OpenApi.Models.OpenApiLicense // Licencia de la api
        {
            Name = "MIT",
            Url = new Uri("https://opensource.org/license/mit")
        },
    });

    //opciones.SwaggerDoc("v2", new Microsoft.OpenApi.Models.OpenApiInfo
    //{
    //    Version = "v2", // Version de la api
    //    Title = "Biblioteca API",
    //    Description = "Esta es una api de ejemplo para aprender a usar ASP.NET Core, para atrabajr con autores y libros",
    //    Contact = new Microsoft.OpenApi.Models.OpenApiContact // Datos del contacto
    //    {
    //        Email = "david@correo.com",
    //        Name = "Ing. David Gavilan",
    //        Url = new Uri("https://davidgavilancore.net")
    //    },
    //    License = new Microsoft.OpenApi.Models.OpenApiLicense // Licencia de la api
    //    {
    //        Name = "MIT",
    //        Url = new Uri("https://opensource.org/license/mit")
    //    },
    //});

    // Configuracion para JWT
    opciones.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        Name = "Authorization",
        Description = "Ingrese el token JWT en el siguiente formato: Bearer {token}",
        BearerFormat = "JWT",
        Type = SecuritySchemeType.ApiKey,
        In = ParameterLocation.Header, // Lugar dodne se va aenviar el token (cabecera)
    });

    //opciones.AddSecurityRequirement(new OpenApiSecurityRequirement
    //{
    //    {
    //        new OpenApiSecurityScheme
    //        {
    //            Reference = new OpenApiReference
    //            {
    //                Type = ReferenceType.SecurityScheme,
    //                Id = "Bearer"
    //            }
    //        },
    //        new string[] {}
    //    }
    //});
    //opciones.OperationFilter<FiltroAutorizacion>(); // Agregamos el filtro de autorizacion para que se muestre el candado en las rutas que tienen el atributo Authorize
});
#endregion

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(opciones =>
    {
        opciones.SwaggerEndpoint("/swagger/v1/swagger.json", "Gestion de gastos API V1"); // Ruta del swagger de la version 1
        //opciones.SwaggerEndpoint("/swagger/v2/swagger.json", "Gestion de gastos API V2"); // Ruta del swagger de la version 2
    });
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
