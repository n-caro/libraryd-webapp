using PSoft.Libraryd.Domain.Queries;
using SqlKata.Compilers;
using System.Data;
using System.Linq;

namespace PSoft.Libraryd.AcessData.Queries
{
    public class ClienteQuery : IClienteQuery
    {
        private readonly IDbConnection connection;
        private readonly Compiler sqlKataCompiler;
        private readonly LibrarydDbContext _dbContext;

        public ClienteQuery(IDbConnection connection, LibrarydDbContext dbContext, Compiler sqlKataCompiler)
        {
            this.connection = connection;
            this._dbContext = dbContext;
            this.sqlKataCompiler = sqlKataCompiler;
        }
        public bool ClienteExists(int ClienteId)
        {
            var query = _dbContext.Clientes.Where(c => c.ClienteId == ClienteId).FirstOrDefault();
            if (query == null) return false;
            return true;
        }
    }
}
