using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiarySchedulerApp
{
    public class OfflineEvent : BaseEvent
    {
        public string Address { get; set; }

        public OfflineEvent(string organizer, string address)
        {
            Organizer = organizer;
            Address = address;
        }

        public override string GetDetails()
        {
            return $"Організатор: {Organizer}, Адреса: {Address}";
        }
    }
}
