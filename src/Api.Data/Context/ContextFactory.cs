using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace Api.Data.Context
{
    public class ContextFactory : IDesignTimeDbContextFactory<MyContext>
    {
        //Usado para criar as migrações
        public MyContext CreateDbContext(string[] args)
        {           
            //var connectionString = "Server=localhost;Port=3306;Database=dbAPP;Uid=root;Pwd=mudar@123";
            //optionsBuilder.UseMySql(connectionString);

            var connectionString = "Server=.\\SQLEXPRESS2017;Database=dbAPP;User Id=sa;Pwd=mudar@123";
            var optionsBuilder = new DbContextOptionsBuilder<MyContext>();

            optionsBuilder.UseSqlServer(connectionString);
            return new MyContext(optionsBuilder.Options);
        }
    }
}