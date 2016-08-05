namespace Jeuci.SalesSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.UserInfo",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserName = c.String(maxLength: 50),
                        Password = c.String(nullable: false, maxLength: 64),
                        PayPassword = c.String(maxLength: 64),
                        Mobile = c.String(maxLength: 22),
                        Email = c.String(nullable: false, maxLength: 100),
                        WeChat = c.String(maxLength: 100),
                        QQ = c.String(nullable: false, maxLength: 100),
                        NickName = c.String(maxLength: 100),
                        Sex = c.Byte(nullable: false),
                        SafeMobile = c.String(maxLength: 22),
                        SafeEmail = c.String(nullable: false),
                        RegTime = c.DateTime(nullable: false),
                        State = c.Int(nullable: false),
                        AppType = c.Int(nullable: false),
                        IP = c.String(maxLength: 50),
                        SID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.UserInfo");
        }
    }
}
