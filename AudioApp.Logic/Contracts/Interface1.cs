using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AudioApp.Logic.Contracts
{
    public interface IMigrateService
    {
        public void MigrateDatabase();
    }
}
