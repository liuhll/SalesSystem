using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jeuci.SalesSystem.Domain.Users.Authorization
{
    [Serializable]
    public class UserPermissionCacheItem
    {
        public const string CacheStoreName = "JueciUserPermissions";

        /// <summary>
        /// Gets/sets expire time for cache items.
        /// Default: 20 minutes.
        /// TODO: This is not used yet!
        /// </summary>
        public static TimeSpan CacheExpireTime { get; private set; }

        public long UserId { get; set; }

        public List<int> RoleIds { get; set; }

        public HashSet<string> GrantedPermissions { get; set; }

        public HashSet<string> ProhibitedPermissions { get; set; }

        static UserPermissionCacheItem()
        {
            UserPermissionCacheItem.CacheExpireTime = TimeSpan.FromMinutes(20.0);
        }

        public UserPermissionCacheItem()
        {
            this.RoleIds = new List<int>();
            this.GrantedPermissions = new HashSet<string>();
            this.ProhibitedPermissions = new HashSet<string>();
        }

        public UserPermissionCacheItem(long userId)
          : this()
        {
            this.UserId = userId;
        }
    }
}

