using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiarySchedulerApp
{
    public class Event : IComparable<Event>
    {
        private string date;
        private string time;
        private int duration;
        private string location;
        private string reminder;
        private string description;
        internal int DurationHours;
        internal int DurationMinutes;
        internal bool EnableReminder;
        internal string ReminderTime;

        public string Date { get => date; set => date = value; }
        public string Time { get => time; set => time = value; }
        public int Duration { get => duration; set => duration = value; }
        public string Location { get => location; set => location = value; }
        public string Reminder { get => reminder; set => reminder = value; }
        public string Description { get => description; set => description = value; }

        public Event() { }

        public Event(string date, string time, int duration, string location, string reminder, string description)
        {
            Date = date;
            Time = time;
            Duration = duration;
            Location = location;
            Reminder = reminder;
            Description = description;
        }

        public override string ToString()
        {
            return $"{Date};{Time};{Duration};{Location};{Reminder};{Description}";
        }

        public static Event Parse(string data)
        {
            var parts = data.Split(';');
            return new Event(parts[0], parts[1], int.Parse(parts[2]), parts[3], parts[4], parts[5]);
        }

        public int CompareTo(Event other)
        {
            return DateTime.Parse($"{Date} {Time}").CompareTo(DateTime.Parse($"{other.Date} {other.Time}"));
        }
    }
}
