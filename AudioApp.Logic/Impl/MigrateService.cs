using AudioApp.Logic.Contracts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using System.Runtime.InteropServices;

namespace AudioApp.Logic.Impl
{
    public class MigrateService : IMigrateService
    {
        readonly IDbContextFactory<DbContext> _dbContext;
        public MigrateService(IDbContextFactory<DbContext> dbContext)
        {
            _dbContext = dbContext;
        }
        public void MigrateDatabase()
        {
            using (var context = _dbContext.CreateDbContext()) 
            context.Database.Migrate();
        }
    }
}
