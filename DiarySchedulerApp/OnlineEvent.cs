using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiarySchedulerApp
{
    public class OnlineEvent : BaseEvent
    {
        public string Platform { get; set; }

        public OnlineEvent(string organizer, string platform)
        {
            Organizer = organizer;
            Platform = platform;
        }

        public override string GetDetails()
        {
            return $"Організатор: {Organizer}, Платформа: {Platform}";
        }
    }
}
