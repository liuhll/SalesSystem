using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntityFramework.DynamicFilters;
using Jeuci.SalesSystem.EntityFramework;

namespace Jeuci.SalesSystem.Migrations.SeedData
{
    public class InitialHostDbBuilder
    {
        private readonly SalesSystemDbContext _context;

        public InitialHostDbBuilder(SalesSystemDbContext context)
        {
            _context = context;
            context.Database.CreateIfNotExists();
        }

        public void Create()
        {
            _context.DisableAllFilters();

            new DefaultEditionsCreator(_context).Create();          
          //  new HostRoleAndUserCreator(_context).Create();
        }
    }
}
