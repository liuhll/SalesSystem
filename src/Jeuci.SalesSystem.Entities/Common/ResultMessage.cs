using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Jeuci.SalesSystem.Entities.Common.Enums;

namespace Jeuci.SalesSystem.Entities.Common
{
    public class ResultMessage<T>
    {
        public ResultMessage()
        {
            this.Code = (int)CodeEnum.Success;
            this.Msg = "SUCCESS";
        }

        /// <summary>  
        /// 正确返回结果集时使用  
        /// </summary>  
        /// <param name="data"></param>  
        public ResultMessage(T data)
            : this()
        {
            Data = data;
        }

        /// <summary>  
        /// 有错误时使用  
        /// </summary>  
        /// <param name="code"></param>  
        /// <param name="msg"></param>  
        public ResultMessage(int code, string msg)
        {
            this.Code = code;
            this.Msg = msg;
        }

        public ResultMessage(int code, string msg, T data)
            : this(code, msg)
        {
            Data = data;
        }

        /// <summary>  
        /// 异常时使用  
        /// </summary>  
        /// <param name="ex"></param>  
        public ResultMessage(Exception ex)
        {
            if (null != ex)
            {
                this.Code = (int)CodeEnum.Fail;
                this.Msg = ex.Message;
            }
        }

        /// <summary>    
        /// Information message    
        /// </summary>    
        public T Data { get; set; }

        /// <summary>    
        /// Result code    
        /// </summary>    
        public int Code { get; set; }

        /// <summary>    
        /// Result description    
        /// </summary>    
        public string Msg { get; set; }
    }

}
