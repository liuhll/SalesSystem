using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jeuci.SalesSystem.Entities
{
    /// <summary>
    /// 用户/管理员状态
    /// </summary>
    public enum UserState
    {
        /// <summary>
        /// 激活
        /// </summary>
        Active = 1,


        /// <summary>
        /// 冻结
        /// </summary>
        Freeze = 0,
    }
}
