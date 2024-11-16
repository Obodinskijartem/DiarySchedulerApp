using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DiarySchedulerApp
{
    public partial class Form1 : Form
    {
        private List<Event> events = new List<Event>();

        public Form1()
        {
            InitializeComponent();
            InitializeGrid();
        }

        private void InitializeGrid()
        {
            dgvEvents.Columns.Add("Date", "Дата");
            dgvEvents.Columns.Add("Time", "Час");
            dgvEvents.Columns.Add("DurationHours", "Тривалість (год)");
            dgvEvents.Columns.Add("DurationMinutes", "Тривалість (хв)");
            dgvEvents.Columns.Add("Location", "Місце проведення");

            var reminderColumn = new DataGridViewCheckBoxColumn
            {
                Name = "EnableReminder",
                HeaderText = "Увімкнути нагадування",
                TrueValue = true,
                FalseValue = false
            };
            dgvEvents.Columns.Add(reminderColumn);

            dgvEvents.Columns.Add("ReminderTime", "Час до нагадування");
            dgvEvents.Columns.Add("Description", "Опис заходу");
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            MainForm mainForm = new MainForm();
            if (mainForm.ShowDialog() == DialogResult.OK)
            {
                string[] newEntry = mainForm.GetEntry();

                // Перевірка: всі поля мають бути заповнені
                if (newEntry.Any(string.IsNullOrWhiteSpace))
                {
                    MessageBox.Show("Будь ласка, заповніть усі поля форми.",
                        "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Перевірка і парсинг даних
                if (!int.TryParse(newEntry[2], out int durationHours) || durationHours < 0)
                {
                    MessageBox.Show("Некоректне значення для тривалості (години). Введіть ціле число більше або рівне 0.",
                        "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                    if (!int.TryParse(newEntry[3], out int durationMinutes) || durationMinutes < 0 || durationMinutes >= 60)
                {
                    MessageBox.Show("Некоректне значення для тривалості (хвилини). Введіть число від 0 до 59.",
                        "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (!bool.TryParse(newEntry[5], out bool enableReminder))
                {
                    MessageBox.Show("Некоректне значення для 'Увімкнути нагадування'. Використовуйте 'True' або 'False'.",
                        "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Додаємо новий рядок у DataGridView
                dgvEvents.Rows.Add(newEntry[0], newEntry[1], durationHours, durationMinutes, newEntry[4],
                                   enableReminder, newEntry[6], newEntry[7]);

                // Додаємо нову подію до списку
                events.Add(new Event
                {
                    Date = newEntry[0],
                    Time = newEntry[1],
                    DurationHours = durationHours,
                    DurationMinutes = durationMinutes,
                    Location = newEntry[4],
                    EnableReminder = enableReminder,
                    ReminderTime = newEntry[6],
                    Description = newEntry[7]
                });
            }
        }


        private void txtDurationHours_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Дозволяємо лише цифри, Backspace та Delete
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true; // Заборонити інші символи
            }
        }




        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (dgvEvents.SelectedRows.Count == 0)
            {
                MessageBox.Show("Будь ласка, виберіть рядок для редагування.");
                return;
            }

            DataGridViewRow selectedRow = dgvEvents.SelectedRows[0];

            string[] currentData = new string[]
            {
                selectedRow.Cells[0].Value?.ToString() ?? "",
                selectedRow.Cells[1].Value?.ToString() ?? "",
                selectedRow.Cells[2].Value?.ToString() ?? "0",
                selectedRow.Cells[3].Value?.ToString() ?? "0",
                selectedRow.Cells[4].Value?.ToString() ?? "",
                selectedRow.Cells[5].Value != null && (bool)selectedRow.Cells[5].Value ? "True" : "False",
                selectedRow.Cells[6].Value?.ToString() ?? "",
                selectedRow.Cells[7].Value?.ToString() ?? ""
            };

            MainForm mainForm = new MainForm(currentData);
            if (mainForm.ShowDialog() == DialogResult.OK)
            {
                string[] updatedData = mainForm.GetEntry();

                // Перевірка даних
                bool enableReminder = ParseBoolean(updatedData[5]);

                // Оновлюємо вибраний рядок
                selectedRow.Cells[0].Value = updatedData[0];
                selectedRow.Cells[1].Value = updatedData[1];
                selectedRow.Cells[2].Value = updatedData[2];
                selectedRow.Cells[3].Value = updatedData[3];
                selectedRow.Cells[4].Value = updatedData[4];
                selectedRow.Cells[5].Value = enableReminder;
                selectedRow.Cells[6].Value = updatedData[6];
                selectedRow.Cells[7].Value = updatedData[7];

                // Оновлюємо дані у списку подій
                var eventToUpdate = events.FirstOrDefault(ev =>
                    ev.Date == currentData[0] &&
                    ev.Time == currentData[1] &&
                    ev.Location == currentData[4]);

                if (eventToUpdate != null)
                {
                    eventToUpdate.Date = updatedData[0];
                    eventToUpdate.Time = updatedData[1];
                    eventToUpdate.DurationHours = int.Parse(updatedData[2]);
                    eventToUpdate.DurationMinutes = int.Parse(updatedData[3]);
                    eventToUpdate.Location = updatedData[4];
                    eventToUpdate.EnableReminder = enableReminder;
                    eventToUpdate.ReminderTime = updatedData[6];
                    eventToUpdate.Description = updatedData[7];
                }
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dgvEvents.SelectedRows.Count == 0)
            {
                MessageBox.Show("Будь ласка, виберіть рядок для видалення.");
                return;
            }

            DataGridViewRow selectedRow = dgvEvents.SelectedRows[0];
            string date = selectedRow.Cells[0].Value?.ToString();
            string time = selectedRow.Cells[1].Value?.ToString();
            string location = selectedRow.Cells[4].Value?.ToString();

            dgvEvents.Rows.Remove(selectedRow);

            events.RemoveAll(ev => ev.Date == date && ev.Time == time && ev.Location == location);
        }

        private void btnSaveToFile_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog
            {
                Filter = "Text Files (*.txt)|*.txt",
                Title = "Зберегти дані"
            };

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    using (StreamWriter writer = new StreamWriter(saveFileDialog.FileName))
                    {
                        foreach (var ev in events)
                        {
                            writer.WriteLine(ev.ToString());
                        }
                    }
                    MessageBox.Show("Дані збережено успішно.", "Успіх", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Помилка під час збереження даних: {ex.Message}", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnLoadFromFile_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog
            {
                Filter = "Text Files (*.txt)|*.txt",
                Title = "Завантажити дані"
            };

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                using (StreamReader reader = new StreamReader(openFileDialog.FileName))
                {
                    string line;
                    while ((line = reader.ReadLine()) != null)
                    {
                        var ev = Event.Parse(line);
                        events.Add(ev);
                        dgvEvents.Rows.Add(ev.Date, ev.Time, ev.DurationHours, ev.DurationMinutes, ev.Location, ev.EnableReminder, ev.ReminderTime, ev.Description);
                    }
                }
                MessageBox.Show("Дані завантажено успішно.", "Успіх", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private bool ParseBoolean(string input)
        {
            if (string.Equals(input, "Так", StringComparison.OrdinalIgnoreCase) || string.Equals(input, "Yes", StringComparison.OrdinalIgnoreCase))
                return true;
            if (string.Equals(input, "Ні", StringComparison.OrdinalIgnoreCase) || string.Equals(input, "No", StringComparison.OrdinalIgnoreCase))
                return false;
            if (bool.TryParse(input, out bool result))
                return result;
            return false; // Значення за замовчуванням
        }
    }
}
