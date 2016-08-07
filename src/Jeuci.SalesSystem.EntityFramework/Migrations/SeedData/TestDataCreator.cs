using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Jeuci.SalesSystem.EntityFramework;

namespace Jeuci.SalesSystem.Migrations.SeedData
{
    public class TestDataCreator
    {
        private SalesSystemDbContext _context;

        public TestDataCreator(SalesSystemDbContext context)
        {
            this._context = context;
        }

        public void Create()
        {

        }
    }
}
