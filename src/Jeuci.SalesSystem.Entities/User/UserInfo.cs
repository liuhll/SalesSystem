using Abp.Domain.Entities;
using System;
using System.ComponentModel.DataAnnotations.Schema;
using Abp.Events.Bus;
using Abp.Events.Bus.Entities;
using Jeuci.SalesSystem.Entities.CommonInterfaces;
using Jeuci.SalesSystem.Entities.EventData;
using Jeuci.SalesSystem.Entities.Exception;

namespace Jeuci.SalesSystem.Entities
{

    public class UserInfo : Entity , IIsAgentor
    {
        private bool _isAgentor = false;
        private AgentInfo _agentInfo;

        private bool m_isTriggerAssertAgentorEvent = false;

        public string UserName { get; set; }

        public string Password { get; set; }

        public string PayPassword { get; set; }

        public string Mobile { get; set; }

        public string Email { get; set; }

        public string WeChat { get; set; }

        public string QQ { get; set; }

        public string NickName { get; set; }

        public bool? Sex { get; set; }

        public string SafeMobile { get; set; }

        public string SafeEmail { get; set; }

        public DateTime RegTime { get; set; }

        public int State { get; set; }

        public int? AppType { get; set; }

        public string IP { get; set; }

        /// <summary>
        /// 从哪个服务注册的
        /// </summary>
        public int? SID { get; set; }

        /// <summary>
        ///如果是代理商，则获取代理商信息
        /// </summary>
        public AgentInfo AgentInfo {
            get
            {
                if (!_isAgentor)
                {
                    throw new SalesSysException(string.Format("Id为：{0}的用户不是代理商,无法获取相关信息", Id));
                }
                return _agentInfo;
            }
        }

        public bool IsAgentor {
            get
            {
                if (!m_isTriggerAssertAgentorEvent)
                {
                    var eventData = new UserInfoIsAgentorEventData(this);
                    EventBus.Default.Trigger(eventData);
                    _isAgentor = eventData.IsAgentor;
                    _agentInfo = eventData.AgentInfo;
                    m_isTriggerAssertAgentorEvent = true;

                }    
                return _isAgentor;
            }
        }
    }
}
