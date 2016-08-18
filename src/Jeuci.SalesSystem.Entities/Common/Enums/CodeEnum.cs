using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jeuci.SalesSystem.Entities.Common.Enums
{
    public enum CodeEnum
    {
        /// <summary>  
        /// 成功  
        /// </summary>  
        Success = 200,

        /// <summary>  
        /// 失败  
        /// </summary>  
        Fail = -1,

        /// <summary>  
        /// 未将对象引用到对象实例  
        /// </summary>  
        NullReference = -2,

        /// <summary>  
        /// 空指针  
        /// </summary>  
        NullPointer = -3,

    }
}
