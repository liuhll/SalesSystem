using System.Data.Common;
using Abp.EntityFramework;
using Jeuci.SalesSystem.Entities;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using Jeuci.SalesSystem.Mapping;
using Jeuci.SalesSystem.Mapping.SalesMapping;
using Jeuci.SalesSystem.Mapping.UserMapping;

namespace Jeuci.SalesSystem.EntityFramework
{
    public class SalesSystemDbContext : AbpDbContext
    {
      
        /* NOTE: 
         *   Setting "Default" to base class helps us when working migration commands on Package Manager Console.
         *   But it may cause problems when working Migrate.exe of EF. If you will apply migrations on command line, do not
         *   pass connection string name to base classes. ABP works either way.
         */
        public SalesSystemDbContext()
            : base("Default")
        {

        }

        /* NOTE:
         *   This constructor is used by ABP to pass connection string defined in SalesSystemDataModule.PreInitialize.
         *   Notice that, actually you will not directly create an instance of SalesSystemDbContext since ABP automatically handles it.
         */
        public SalesSystemDbContext(string nameOrConnectionString)
            : base(nameOrConnectionString)
        {

        }


        //This constructor is used in tests
        public SalesSystemDbContext(DbConnection connection)
            : base(connection, true)
        {

        }


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();

            base.OnModelCreating(modelBuilder);

            modelBuilder.Configurations.Add(new UserInfoMap());
            modelBuilder.Configurations.Add(new AgentInfoMap());
            modelBuilder.Configurations.Add(new AdministratorInfoMap());
            modelBuilder.Configurations.Add(new AdminLoginHistoryMap());
            modelBuilder.Configurations.Add(new BrandInfoMap());
            modelBuilder.Configurations.Add(new ServiceInfoMap());
            modelBuilder.Configurations.Add(new ServicePriceMap());
            modelBuilder.Configurations.Add(new UserServiceSubscriptionInfoMap());
            modelBuilder.Configurations.Add(new UserServiceAuthInfoMap());

        }

        #region Define an IDbSet for each Entity

        //TODO: EveryEntity

        //Example:
        //public virtual IDbSet<User> Users { get; set; }

        public virtual IDbSet<UserInfo> UserInfos { get; set; }

        public virtual IDbSet<AgentInfo> AgentInfos { get; set; }

        public virtual IDbSet<AdministratorInfo> AdministratorInfos { get; set; }

        public virtual IDbSet<BrandInfo> BrandInfos { get; set; }

        public virtual IDbSet<ServiceInfo> ServiceInfos { get; set; }

        public virtual IDbSet<ServicePrice> ServicePrices { get; set; }

        public virtual IDbSet<UserServiceSubscriptionInfo> UserServiceSubscriptionInfos { get; set; }

        public virtual IDbSet<UserServiceAuthInfo> UserServiceAuthInfos { get; set; }

        #endregion
    }
}
