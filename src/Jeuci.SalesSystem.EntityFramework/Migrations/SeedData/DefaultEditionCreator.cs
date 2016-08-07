using Jeuci.SalesSystem.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Jeuci.SalesSystem.Entities;

namespace Jeuci.SalesSystem.Migrations.SeedData
{
 
    public class DefaultEditionCreator
    {
        private readonly SalesSystemDbContext _context;

        public DefaultEditionCreator(SalesSystemDbContext context)
        {
            _context = context;
        }

        public void Create()
        {
            CreateTestUser();
        }

        private void CreateTestUser()
        {
            _context.UserInfos.AddOrUpdate(new UserInfo()
            {
                Id = 1035,
                AppType = 1,
                Email = "1029765111@qq.com"

            });
            _context.SaveChanges();
        }
    }
}
