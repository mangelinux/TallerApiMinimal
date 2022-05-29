using AutoMapper;
using Sol.TallerNet.ApiVentas.Applications.Dtos.input;
using Sol.TallerNet.ApiVentas.Applications.Dtos.output;
using Sol.TallerNet.ApiVentas.Repositories.Entities;
using Sol.TallerNet.ApiVentas.Repositories.Operations;

namespace Sol.TallerNet.ApiVentas.Applications.Operations
{
    public class UsuarioApplication : IUsuarioApplication
    {
        private readonly IUsuarioRepository usuarioRepository;
        private readonly ILogger<UsuarioApplication> logger;
        private readonly IMapper mapper;
        private readonly IArticuloRepository articuloRepository;

        public UsuarioApplication(IUsuarioRepository usuarioRepository, ILogger<UsuarioApplication> logger, IMapper mapper)
        {
            this.usuarioRepository = usuarioRepository;
            this.logger = logger;
            this.mapper = mapper;
        }
        public async Task<UserAutenticaOutput> Login(UserAutenticaInput userAutenticaInput)
        {
            Usuario user = await usuarioRepository.Autentica(userAutenticaInput.CodUsuario, userAutenticaInput.Clave);
            
            UserAutenticaOutput output = new UserAutenticaOutput();
            UserAutenticaOutput res = mapper.Map<UserAutenticaOutput>(user);
            //res.Credencial = user.Credenciales;
            //res.Codigo = user.IdUsuario;
            return res;

        }
    }
}
