using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiarySchedulerApp
{
    public abstract class BaseEvent
    {
        public string Organizer { get; protected set; } // Protected доступ
        public abstract string GetDetails(); // Абстрактний метод
    }
}
