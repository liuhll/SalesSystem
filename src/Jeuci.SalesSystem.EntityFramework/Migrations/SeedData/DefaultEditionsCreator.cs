using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Jeuci.SalesSystem.Entities;
using Jeuci.SalesSystem.EntityFramework;

namespace Jeuci.SalesSystem.Migrations.SeedData
{
    public class DefaultEditionsCreator
    {
        private readonly SalesSystemDbContext _context;

        public DefaultEditionsCreator(SalesSystemDbContext context)
        {
            _context = context;
        }

        public void Create()
        {
            CreateEditions();
        }

        private void CreateEditions()
        {
            //var defaultEdition = _context.Editions.FirstOrDefault(e => e.Name == EditionManager.DefaultEditionName);
            //if (defaultEdition == null)
            //{
            //    defaultEdition = new Edition { Name = EditionManager.DefaultEditionName, DisplayName = EditionManager.DefaultEditionName };
            //    _context.Editions.Add(defaultEdition);
            //    _context.SaveChanges();

            //    //TODO: Add desired features to the standard edition, if wanted!
            //}

            _context.UserInfos.AddOrUpdate(new UserInfo()
            {
                Id = 1,
                AppType = 1,
                Email = "1029762111=@qq.com",

            });
            _context.AdministratorInfos.AddOrUpdate(new AdministratorInfo()
            {
                Id = 1,
                UserName = "Admin",
                Password = "E0BC60C82713F64EF8A57C0C40D02CE24FD0141D5CC3086259C19B1E62A62BEA",
                RealName = "张三",
                Brands = "1,2,3",
                Mobile = "18998765112",
                State = 1,
                AdminRoles = "1,2",

            });
            _context.SaveChanges();
        }
    }
}
