using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pong.MyEventArgs
{
    public class ChangeMapEvent : EventArgs
    {
        public string GroupId { get; set; }

        public string UserName { get; set; }
        public ChangeMapEvent(string groupId, string name)
        {
            GroupId = groupId;
            UserName = name;
        }
    }
}
