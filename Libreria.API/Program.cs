using Libreria.Acceso.Datos.Repositorio.EF;
using Libreria.LogicaAplicacion.ImplementacionesCU.Atletas;
using Libreria.LogicaAplicacion.ImplementacionesCU.AtletasParticipantes;
using Libreria.LogicaAplicacion.ImplementacionesCU.Disciplina;
using Libreria.LogicaAplicacion.ImplementacionesCU.Evento;
using Libreria.LogicaAplicacion.ImplementacionesCU.Usuario.Administrador;
using Libreria.LogicaAplicacion.ImplementacionesCU.Usuario;
using Libreria.LogicaAplicacion.InterfacesCU.AtletasInterface;
using Libreria.LogicaAplicacion.InterfacesCU.AtletasParticipantesInterface;
using Libreria.LogicaAplicacion.InterfacesCU.DisciplinaInterface;
using Libreria.LogicaAplicacion.InterfacesCU.EventoInterface;
using Libreria.LogicaAplicacion.InterfacesCU.UsuarioInterface.Administrador;
using Libreria.LogicaAplicacion.InterfacesCU.UsuarioInterface;
using Libreria.LogicaNegocio.InterfacesRepositorios;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Microsoft.OpenApi.Models;
using Libreria.LogicaAplicacion.InterfacesCU.AuditoriaInterface;
using Libreria.LogicaNegocio.CasosDeUso;

namespace Obligatorio
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();
            builder.Services.AddSession();

            // Inyección de dependencias
            builder.Services.AddScoped<IRepositorioUsuario, RepositorioUsuarioEF>();
            builder.Services.AddScoped<IRepositorioAtleta, RepositorioAtletaEF>();
            builder.Services.AddScoped<IRepositorioDisciplina, RepositorioDisciplinaEF>();
            builder.Services.AddScoped<IRepositorioEvento, RepositorioEventoEF>();
            builder.Services.AddScoped<IRepositorioAtletasParticipantes, RepositorioAtletasDelEventoEF>();
            builder.Services.AddScoped<IRepositorioAuditoria, RepositorioAuditoriaEF>();

            builder.Services.AddDbContext<LibreriaContext>(options =>
                options.UseSqlServer(builder.Configuration.GetConnectionString("ConexionOlimpiada")));

            // Casos de uso
            builder.Services.AddScoped<IAltaUsuario, AltaUsuario>();
            builder.Services.AddScoped<IBajaUsuario, BajaUsuario>();
            builder.Services.AddScoped<IEditarUsuario, EditarUsuario>();
            builder.Services.AddScoped<IBuscarUsuario, BuscarUsuario>();
            builder.Services.AddScoped<IObtenerTodos, ObtenerTodos>();
            builder.Services.AddScoped<IAutenticarUsuario, AutenticarUsuario>();


            //Atletas
            builder.Services.AddScoped<IObtenerAtletas, ObtenerAtletas>();
            builder.Services.AddScoped<IBuscarAtletas, BuscarAtleta>();
            builder.Services.AddScoped<IAsignarDisciplina, AsignarDisciplina>();

            builder.Services.AddScoped<IObtenerAtletaPorId, ObtenerAtletaPorId>();



            //Disciplina
            builder.Services.AddScoped<IAltaDisciplina, AltaDisciplina>();
            builder.Services.AddScoped<IObtenerDisciplina, ObtenerDisciplina>();
            builder.Services.AddScoped<IBuscarDisciplina, BuscarDisciplina>();
            builder.Services.AddScoped<IEditarDisciplina, EditarDisciplina>();
            builder.Services.AddScoped<IEliminarDisciplina, EliminarDisciplina>();  

            //Evento
            builder.Services.AddScoped<IAltaEvento, AltaEvento>();
            builder.Services.AddScoped<IObtenerEventos, ObtenerEventos>();
            builder.Services.AddScoped<IAtletasDeLosEventos, AtletasDeLosEventos>();


            builder.Services.AddScoped<IBuscarAtletaEnEvento, BuscarAtletaParticipante>();
            builder.Services.AddScoped<IRegistrarPuntaje, RegistrarPuntaje>();

            builder.Services.AddScoped<IFiltrarEventos, FiltrarEventos>();

            //Auditoria
            builder.Services.AddScoped<IRegistrarAuditoria, RegistrarAuditoria>();




            builder.Services.AddControllers();
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen(); // Agregar SwaggerGen

            builder.Services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(options =>
            {
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    ValidIssuer = builder.Configuration["Jwt:Issuer"],
                    ValidAudience = builder.Configuration["Jwt:Audience"],
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(builder.Configuration["Jwt:Key"]))
                };
            });

            //Indicar a Swagger que use el archivo generado durante la compilación 
            //a partir de los comentarios XML
            var rutaArchivo = Path.Combine(AppContext.BaseDirectory, "Obligatorio.xml");
            builder.Services.AddSwaggerGen(c =>
            {
                //c.IncludeXmlComments(rutaArchivo);
                // Configurar el esquema de seguridad JWT
                c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    Name = "Authorization",
                    Description = "Ingrese 'Bearer' seguido de un espacio y el token JWT.",
                    In = ParameterLocation.Header,
                    Type = SecuritySchemeType.Http,
                    Scheme = "Bearer",
                    BearerFormat = "JWT"
                });

                // Agregar requerimiento de seguridad global
                c.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type=ReferenceType.SecurityScheme,
                    Id="Bearer"
                }
            },
            new string[] {}
        }
    });
            });


            var app = builder.Build();

            // Habilitar Swagger en cualquier entorno
            app.UseSwagger();
            app.UseSwaggerUI();

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseSession();

            app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization();

            app.MapControllers();

            app.Run();
        }
    }
}