using Libreria.Acceso.Datos.Repositorio.EF;
using Libreria.LogicaAplicacion.ImplementacionesCU.Atletas;
using Libreria.LogicaAplicacion.ImplementacionesCU.AtletasParticipantes;
using Libreria.LogicaAplicacion.ImplementacionesCU.Disciplina;
using Libreria.LogicaAplicacion.ImplementacionesCU.Evento;
using Libreria.LogicaAplicacion.ImplementacionesCU.Usuario;
using Libreria.LogicaAplicacion.ImplementacionesCU.Usuario.Administrador;
using Libreria.LogicaAplicacion.InterfacesCU.AtletasInterface;
using Libreria.LogicaAplicacion.InterfacesCU.AtletasParticipantesInterface;
using Libreria.LogicaAplicacion.InterfacesCU.DisciplinaInterface;
using Libreria.LogicaAplicacion.InterfacesCU.EventoInterface;
using Libreria.LogicaAplicacion.InterfacesCU.UsuarioInterface;
using Libreria.LogicaAplicacion.InterfacesCU.UsuarioInterface.Administrador;
using Libreria.LogicaNegocio.InterfacesRepositorios;
using Microsoft.EntityFrameworkCore;

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


            //Inyeccion de dependencias
            builder.Services.AddScoped<IRepositorioUsuario, RepositorioUsuarioEF>();
            builder.Services.AddScoped<IRepositorioAtleta, RepositorioAtletaEF>();
            builder.Services.AddScoped<IRepositorioDisciplina, RepositorioDisciplinaEF>();
            builder.Services.AddScoped<IRepositorioEvento, RepositorioEventoEF>();
            builder.Services.AddScoped<IRepositorioAtletasParticipantes, RepositorioAtletasDelEventoEF>();


            builder.Services.AddDbContext<LibreriaContext>(options =>options.UseSqlServer(
                builder.Configuration.GetConnectionString("ConexionOlimpiada")));


            //Agregar servicio de inyeccion de dependencias de casos de uso
            //Usuario
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


            //Disciplina
            builder.Services.AddScoped<IAltaDisciplina, AltaDisciplina>();
            builder.Services.AddScoped<IObtenerDisciplina, ObtenerDisciplina>();
            builder.Services.AddScoped<IBuscarDisciplina, BuscarDisciplina>();


            //Eventos
            builder.Services.AddScoped<IAltaEvento, AltaEvento>();
            builder.Services.AddScoped<IObtenerEventos, ObtenerEventos>();
            builder.Services.AddScoped<IAtletasDeLosEventos, AtletasDeLosEventos>();

            //PuntajeAtletas (participantes)
            builder.Services.AddScoped<IBuscarAtletaEnEvento, BuscarAtletaParticipante>();
            builder.Services.AddScoped<IRegistrarPuntaje, RegistrarPuntaje>();



            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseSession();

            app.UseRouting();

            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}
