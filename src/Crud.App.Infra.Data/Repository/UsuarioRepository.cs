using Crud.App.Infra.Data.Context;
using Crud.App.Domain.Usuarios;

namespace Crud.App.Infra.Data.Repository
{
    public class UsuarioRepository : Repository<Usuario>, IUsuarioRepository
    {
        public UsuarioRepository(CrudAppContext context) : base(context) { }
    }
}
