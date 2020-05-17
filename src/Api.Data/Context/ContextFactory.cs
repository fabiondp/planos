using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace Api.Data.Context
{
    public class ContextFactory : IDesignTimeDbContextFactory<MyContext>
    {
        public MyContext CreateDbContext(string[] args)
        {
            //Usado para criar as migrações
            //var connectionString = "Server=localhost;Port=3306;Database=dbAPP;Uid=root;Pwd=mudar@123";
            var connectionString = "Server=.\\SQLEXPRESS2017;Database=dbAPP;User Id=sa;Pwd=mudar@123";
            var optionsBuilder = new DbContextOptionsBuilder<MyContext>();
            //optionsBuilder.UseMySql(connectionString);
            optionsBuilder.UseSqlServer(connectionString);
            return new MyContext(optionsBuilder.Options);
        }
    }
}