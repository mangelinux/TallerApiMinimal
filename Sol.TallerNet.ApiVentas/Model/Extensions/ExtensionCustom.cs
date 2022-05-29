using Sol.TallerNet.ApiVentas.Applications.Dtos.input;
using Sol.TallerNet.ApiVentas.Applications.Operations;
using Sol.TallerNet.ApiVentas.Repositories.Operations;

namespace Sol.TallerNet.ApiVentas.Model.Extensions
{
    public static class ExtensionCustom
    {
        public static IServiceCollection AddInjection(this IServiceCollection services)
        {
            //Add dependencies
            services.AddTransient<IArticuloRepository, ArticuloRepository>();
            services.AddTransient<IArticuloApplication, ArticuloApplication>();
            services.AddTransient<IUsuarioRepository, UsuarioRepository>();
            services.AddTransient<IUsuarioApplication, UsuarioApplication>();

            return services;
        }


        public static WebApplication AddOperation(this WebApplication app)
        {

            app.MapGet("/articulo", (IArticuloRepository articuloRepository, IArticuloApplication articuloApplication) =>
            {
                return (Results.Ok(articuloRepository.List()));
            });

            app.MapGet("/usuario", async (IUsuarioRepository usuarioRepository) =>
            {
                var res = await usuarioRepository.List();
                return (Results.Ok(res));
            });

            app.MapPost("/user/autentica", async (IUsuarioApplication usuarioApplication, UserAutenticaInput user) =>
            {
                var result = await usuarioApplication.Login(user);
                return (Results.Ok(result));
            });

            return (app);
        }
    }
}
