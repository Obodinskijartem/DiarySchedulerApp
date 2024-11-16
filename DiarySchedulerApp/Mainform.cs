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
        private string[] entryData;

        // Конструктор для додавання
        public MainForm()
        {
            InitializeComponent();
            InitializeForm();
            entryData = new string[6];
        }

        // Конструктор для редагування
        public MainForm(string[] existingEntry)
        {
            InitializeComponent();
            InitializeForm();

            entryData = existingEntry;
            LoadEntryData();
        }

        private void InitializeForm()
        {
            cmbReminderTime.Items.AddRange(new string[] { "10 хв", "30 хв", "1 год" });
            cmbReminderTime.SelectedIndex = 0; // Значення за замовчуванням
        }

        // Завантаження даних у поля форми
        private void LoadEntryData()
        {
            datePickerEvent.Value = DateTime.Parse(entryData[0]);
            timePickerEvent.Value = DateTime.Parse(entryData[1]);
            numDurationHours.Value = int.Parse(entryData[2].Split(' ')[0]);
            numDurationMinutes.Value = int.Parse(entryData[2].Split(' ')[2]);
            txtLocation.Text = entryData[3];
            cmbReminderTime.SelectedItem = entryData[4];
            txtDescription.Text = entryData[5];
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            // Збираємо дані з форми
            string date = datePickerEvent.Value.ToShortDateString();
            string time = timePickerEvent.Value.ToShortTimeString();
            string duration = $"{numDurationHours.Value} год {numDurationMinutes.Value} хв";
            string location = txtLocation.Text;
            string reminder = chkReminder.Checked ? cmbReminderTime.SelectedItem.ToString() : "Немає";
            string description = txtDescription.Text;

            // Перевірка полів
            if (string.IsNullOrWhiteSpace(location))
            {
                MessageBox.Show("Будь ласка, заповніть поле 'Місце проведення'.");
                return;
            }

            // Записуємо дані
            entryData = new string[] { date, time, duration, location, reminder, description };
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        public string[] GetEntry()
        {
            return entryData;
        }
    }
}