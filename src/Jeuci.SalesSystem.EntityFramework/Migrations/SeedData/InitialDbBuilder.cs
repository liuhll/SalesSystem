using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntityFramework.DynamicFilters;
using Jeuci.SalesSystem.EntityFramework;

namespace Jeuci.SalesSystem.Migrations.SeedData
{
    public class InitialDbBuilder
    {
        private readonly SalesSystemDbContext _context;

        public InitialDbBuilder(SalesSystemDbContext context)
        {
            this._context = context;
        }

        public void Create()
        {
            _context.DisableAllFilters();

            new DefaultEditionCreator(_context).Create();
            //new DefaultLanguagesCreator(_context).Create();
            //new DefaultTenantRoleAndUserCreator(_context).Create();
            //new DefaultSettingsCreator(_context).Create();

            _context.SaveChanges();
        }
    }
}
