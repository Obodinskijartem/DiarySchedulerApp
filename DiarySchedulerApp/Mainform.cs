using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DiarySchedulerApp
{
    public partial class MainForm : Form
    {
        private Event eventData;

        // Конструктор для додавання нового запису
        public MainForm()
        {
            InitializeComponent();
            InitializeForm();
            eventData = new Event(); // Створення нового об'єкта
        }

        // Конструктор для редагування існуючого запису
        public MainForm(Event existingEvent)
        {
            InitializeComponent();
            InitializeForm();
            eventData = existingEvent;
            LoadEventData(); // Завантаження даних у форму
        }

        private void InitializeForm()
        {
            cmbReminderTime.Items.AddRange(new string[] { "10 хв", "30 хв", "1 год" });
            cmbReminderTime.SelectedIndex = 0; // Значення за замовчуванням
        }

        private void LoadEventData()
        {
            datePickerEvent.Value = DateTime.Parse(eventData.Date);
            timePickerEvent.Value = DateTime.Parse(eventData.Time);
            numDurationHours.Value = eventData.DurationHours;
            numDurationMinutes.Value = (decimal)eventData.DurationMinutes;
            txtLocation.Text = eventData.Location;
            chkReminder.Checked = eventData.EnableReminder;
            cmbReminderTime.SelectedItem = eventData.ReminderTime;
            txtDescription.Text = eventData.Description;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            // Перевірка обов'язкових полів
            if (string.IsNullOrWhiteSpace(txtLocation.Text))
            {
                MessageBox.Show("Поле 'Місце проведення' обов'язкове для заповнення.");
                return;
            }



            // Збереження даних у об'єкт
            eventData.Date = datePickerEvent.Value.ToShortDateString();
            eventData.Time = timePickerEvent.Value.ToShortTimeString();
            eventData.DurationHours = (int)numDurationHours.Value;
            eventData.DurationMinutes = (int)numDurationMinutes.Value;
            eventData.Location = txtLocation.Text.Trim();
            eventData.EnableReminder = chkReminder.Checked;
            eventData.ReminderTime = chkReminder.Checked ? cmbReminderTime.SelectedItem.ToString() : "Немає";
            eventData.Description = txtDescription.Text.Trim();

            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;

            this.Close();
        }

        public Event GetEvent()
        {
            return eventData;
        }

    }
}