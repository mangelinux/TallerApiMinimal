using Sol.TallerNet.ApiVentas.Applications.Dtos.input;
using Sol.TallerNet.ApiVentas.Applications.Dtos.output;

namespace Sol.TallerNet.ApiVentas.Applications.Operations
{
    public interface IUsuarioApplication
    {
        Task<UserAutenticaOutput> Login(UserAutenticaInput userAutenticaInput );
    }
}
