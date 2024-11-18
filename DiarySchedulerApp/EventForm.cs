using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DiarySchedulerApp
{
    public partial class EventForm : Form
    {
        public Event EventDetails { get; private set; }

        public EventForm()
        {
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            this.Text = "Додавання події";
            this.Size = new Size(400, 400);

            // Поле "Дата"
            Label lblDate = new Label
            {
                Text = "Дата (дд/мм/рррр):",
                Location = new Point(20, 20),
                AutoSize = true
            };
            TextBox txtDate = new TextBox
            {
                Location = new Point(150, 20),
                Width = 200
            };

            // Поле "Час"
            Label lblTime = new Label
            {
                Text = "Час (гг:хх):",
                Location = new Point(20, 60),
                AutoSize = true
            };
            TextBox txtTime = new TextBox
            {
                Location = new Point(150, 60),
                Width = 200
            };

            // Поле "Тривалість годин"
            Label lblDurationHours = new Label
            {
                Text = "Тривалість (год):",
                Location = new Point(20, 100),
                AutoSize = true
            };
            TextBox txtDurationHours = new TextBox
            {
                Location = new Point(150, 100),
                Width = 200
            };

            // Поле "Тривалість хвилин"
            Label lblDurationMinutes = new Label
            {
                Text = "Тривалість (хв):",
                Location = new Point(20, 140),
                AutoSize = true
            };
            TextBox txtDurationMinutes = new TextBox
            {
                Location = new Point(150, 140),
                Width = 200
            };

            // Поле "Локація"
            Label lblLocation = new Label
            {
                Text = "Локація:",
                Location = new Point(20, 180),
                AutoSize = true
            };
            TextBox txtLocation = new TextBox
            {
                Location = new Point(150, 180),
                Width = 200
            };

            // Чекбокс для нагадування
            CheckBox chkEnableReminder = new CheckBox
            {
                Text = "Нагадування",
                Location = new Point(150, 220),
                AutoSize = true
            };

            // Поле "Час нагадування"
            Label lblReminderTime = new Label
            {
                Text = "Час нагадування:",
                Location = new Point(20, 260),
                AutoSize = true
            };
            TextBox txtReminderTime = new TextBox
            {
                Location = new Point(150, 260),
                Width = 200
            };

            // Поле "Опис"
            Label lblDescription = new Label
            {
                Text = "Опис події:",
                Location = new Point(20, 300),
                AutoSize = true
            };
            TextBox txtDescription = new TextBox
            {
                Location = new Point(150, 300),
                Width = 200,
                Height = 50,
                Multiline = true
            };

            // Кнопка "Зберегти"
            Button btnSave = new Button
            {
                Text = "Зберегти",
                Location = new Point(150, 360)
            };

            btnSave.Click += (sender, e) =>
            {
                // Перевірка введених даних
                if (string.IsNullOrWhiteSpace(txtDate.Text) ||
                    string.IsNullOrWhiteSpace(txtTime.Text) ||
                    string.IsNullOrWhiteSpace(txtLocation.Text) ||
                    !int.TryParse(txtDurationHours.Text, out int durationHours) ||
                    !int.TryParse(txtDurationMinutes.Text, out int durationMinutes) ||
                    durationMinutes < 0 || durationMinutes >= 60)
                {
                    MessageBox.Show("Перевірте правильність введених даних!", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Створюємо нову подію
                EventDetails = new Event
                {
                    Date = txtDate.Text,
                    Time = txtTime.Text,
                    DurationHours = durationHours,
                    DurationMinutes = durationMinutes,
                    Location = txtLocation.Text,
                    EnableReminder = chkEnableReminder.Checked,
                    ReminderTime = txtReminderTime.Text,
                    Description = txtDescription.Text
                };

                this.DialogResult = DialogResult.OK;
            };

            // Додаємо всі елементи до форми
            this.Controls.Add(lblDate);
            this.Controls.Add(txtDate);
            this.Controls.Add(lblTime);
            this.Controls.Add(txtTime);
            this.Controls.Add(lblDurationHours);
            this.Controls.Add(txtDurationHours);
            this.Controls.Add(lblDurationMinutes);
            this.Controls.Add(txtDurationMinutes);
            this.Controls.Add(lblLocation);
            this.Controls.Add(txtLocation);
            this.Controls.Add(chkEnableReminder);
            this.Controls.Add(lblReminderTime);
            this.Controls.Add(txtReminderTime);
            this.Controls.Add(lblDescription);
            this.Controls.Add(txtDescription);
            this.Controls.Add(btnSave);
        }
    }
}
