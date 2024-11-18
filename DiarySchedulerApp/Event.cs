using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiarySchedulerApp
{

    public class Event
    {
        // Поля
        private string date;
        private string time;
        private int durationHours;
        private int durationMinutes;
        private string location;
        private bool enableReminder;
        private string reminderTime;
        private string description;

        // Властивості
        public string Date
        {
            get => date;
            set
            {
                if (DateTime.TryParse(value, out _))
                    date = value;
                else
                    throw new ArgumentException("Невірний формат дати.");
            }
        }

        public string Time
        {
            get => time;
            set
            {
                if (TimeSpan.TryParse(value, out _))
                    time = value;
                else
                    throw new ArgumentException("Невірний формат часу.");
            }
        }

        public int DurationHours
        {
            get => durationHours;
            set
            {
                if (value >= 0)
                    durationHours = value;
                else
                    throw new ArgumentException("Тривалість у годинах не може бути від'ємною.");
            }
        }

        public int DurationMinutes
        {
            get => durationMinutes;
            set
            {
                if (value >= 0 && value < 60)
                    durationMinutes = value;
                else
                    throw new ArgumentException("Тривалість у хвилинах має бути в межах від 0 до 59.");
            }
        }

        public string Location
        {
            get => location;
            set => location = string.IsNullOrWhiteSpace(value) ? "Невідомо" : value;
        }

        public bool EnableReminder
        {
            get => enableReminder;
            set => enableReminder = value;
        }

        public string ReminderTime
        {
            get => reminderTime;
            set => reminderTime = string.IsNullOrWhiteSpace(value) ? "Без нагадування" : value;
        }

        public string Description
        {
            get => description;
            set => description = string.IsNullOrWhiteSpace(value) ? "Без опису" : value;
        }

        // Конструктори
        public Event() { }

        public Event(string date, string time, int durationHours, int durationMinutes, string location, bool enableReminder, string reminderTime, string description)
        {
            Date = date;
            Time = time;
            DurationHours = durationHours;
            DurationMinutes = durationMinutes;
            Location = location;
            EnableReminder = enableReminder;
            ReminderTime = reminderTime;
            Description = description;
        }

        // Віртуальний метод для отримання деталей події
        public virtual string GetEventDetails()
        {
            return $"Дата: {Date}, Час: {Time}, Тривалість: {DurationHours} год {DurationMinutes} хв, Місце: {Location}, " +
                   $"Опис: {Description}, Нагадування: {(EnableReminder ? "увімкнене" : "вимкнене")}, Час нагадування: {ReminderTime}";
        }
    }
}