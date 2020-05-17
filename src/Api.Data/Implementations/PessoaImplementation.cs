using System.Threading.Tasks;
using Api.Data.Context;
using Api.Data.Repository;
using Api.Domain.Entities;
using Api.Domain.Repository;
using Microsoft.EntityFrameworkCore;

namespace Api.Data.Implementations
{
    public class PessoaImplementation: BaseRepository<ChaveAPIEntity>, IPessoaRepository
    {

        private DbSet<ChaveAPIEntity> _dataSet;

        public PessoaImplementation(MyContext context): base(context)
        {
            _dataSet = context.Set<ChaveAPIEntity>();
        }

        public async Task<ChaveAPIEntity> FindByLogin(string email, string senha)
        {
            return await _dataSet.FirstOrDefaultAsync(u=> u.Login == email && u.Senha == senha);
        }
    }
}