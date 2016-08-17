using System;

namespace Jeuci.SalesSystem.Entities
{
    public class UserServiceAuthInfo 
    {
        public UserServiceAuthInfo()
        {
            CreateTime = DateTime.Now;
        }

        public int UId { get; set; }

        public int SId { get; set; }

        public int AuthType { get; set; }

        public DateTime AuthExpiration { get; set; }

        public int PUid { get; set; }

        public DateTime CreateTime { get; set; }
    }
}
