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
            AddRandomEvents();
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
        private void InitializeComboBox()
        {
            cmbViewTasks.Items.AddRange(new string[]
            {
                "Всі події",
                "На сьогодні",
                "На завтра",
                "На післязавтра",
                "На найближчі 3 дні",
                "На найближчі 7 днів"
            });
            cmbViewTasks.SelectedIndex = 0; // Вибір "Всі події" за замовчуванням
            cmbViewTasks.SelectedIndexChanged += cmbViewTasks_SelectedIndexChanged;
        }

        private void AddRandomEvents()
        {
            var random = new Random();
            var locations = new[] { "Київ", "Львів", "Одеса", "Харків", "Дніпро", "Запоріжжя", "Івано-Франківськ", "Чернігів", "Житомир", "Полтава" };
            var descriptions = new[]
            {
        "Робоча зустріч з колегами",
        "Відвідування конференції з ІТ",
        "Підготовка до презентації проєкту",
        "Онлайн-тренінг з тайм-менеджменту",
        "Зустріч з клієнтами для узгодження деталей",
        "Урок англійської мови",
        "Заняття у спортзалі",
        "Кулінарний майстер-клас",
        "Виступ на міському заході",
        "Відвідування культурного фестивалю",
        "Семінар з лідерства",
        "Екскурсія в музеї міста",
        "День відкритих дверей в університеті",
        "Медичний огляд у клініці",
        "Час для сімейної вечері",
        "Репетиція музичного гурту",
        "Зустріч зі старими друзями",
        "Прогулянка парком з собакою",
        "Читання у бібліотеці",
        "Вечір кіно з друзями"
    };
            var reminderTimes = new[] { "10 хв", "30 хв", "1 год", "2 год", "5 хв" };

            for (int i = 0; i < 50; i++)
            {
                // Генеруємо дати у діапазоні: від учора до 7 днів у майбутньому
                var generatedDate = DateTime.Today.AddDays(random.Next(-1, 8)); // Дати: від учора до 7 днів вперед
                var newEvent = new Event
                {
                    Date = generatedDate.ToShortDateString(),
                    Time = new TimeSpan(random.Next(0, 24), random.Next(0, 60), 0).ToString(@"hh\:mm"),
                    DurationHours = random.Next(0, 3),
                    DurationMinutes = random.Next(0, 60),
                    Location = locations[random.Next(locations.Length)],
                    EnableReminder = random.Next(2) == 1,
                    ReminderTime = reminderTimes[random.Next(reminderTimes.Length)],
                    Description = descriptions[random.Next(descriptions.Length)]
                };

                events.Add(newEvent);
                dgvEvents.Rows.Add(
                    newEvent.Date,
                    newEvent.Time,
                    newEvent.DurationHours,
                    newEvent.DurationMinutes,
                    newEvent.Location,
                    newEvent.EnableReminder,
                    newEvent.ReminderTime,
                    newEvent.Description
                );
            }
        }
        private void cmbViewTasks_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectedPeriod = cmbViewTasks.SelectedItem.ToString();
            DateTime today = DateTime.Today;
            List<Event> filteredEvents = new List<Event>();

            switch (selectedPeriod)
            {
                case "Всі події":
                    filteredEvents = events;
                    break;

                case "На сьогодні":
                    filteredEvents = events.Where(ev => DateTime.Parse(ev.Date) == today).ToList();
                    break;

                case "На завтра":
                    filteredEvents = events.Where(ev => DateTime.Parse(ev.Date) == today.AddDays(1)).ToList();
                    break;

                case "На післязавтра":
                    filteredEvents = events.Where(ev => DateTime.Parse(ev.Date) == today.AddDays(2)).ToList();
                    break;

                case "На найближчі 3 дні":
                    filteredEvents = events.Where(ev => DateTime.Parse(ev.Date) >= today && DateTime.Parse(ev.Date) <= today.AddDays(3)).ToList();
                    break;

                case "На найближчі 7 днів":
                    filteredEvents = events.Where(ev => DateTime.Parse(ev.Date) >= today && DateTime.Parse(ev.Date) <= today.AddDays(7)).ToList();
                    break;
            }

            UpdateEventGrid(filteredEvents);
        }
        private void btnSearch_Click(object sender, EventArgs e)
        {
            string searchQuery = txtSearch.Text.Trim().ToLower();

            if (string.IsNullOrEmpty(searchQuery))
            {
                MessageBox.Show("Введіть ключові слова для пошуку.", "Увага", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var filteredEvents = events.Where(ev =>
                ev.Description.ToLower().Contains(searchQuery) ||
                ev.Location.ToLower().Contains(searchQuery) ||
                ev.Date.Contains(searchQuery) ||
                ev.Time.Contains(searchQuery)
            ).ToList();

            UpdateEventGrid(filteredEvents);

            if (filteredEvents.Count == 0)
            {
                MessageBox.Show("Не знайдено записів за вказаним запитом.", "Результат пошуку", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnResetFilter_Click(object sender, EventArgs e)
        {
            UpdateEventGrid(events);
        }

        private void UpdateEventGrid(List<Event> eventList)
        {
            dgvEvents.Rows.Clear();

            foreach (var ev in eventList)
            {
                dgvEvents.Rows.Add(
                    ev.Date,
                    ev.Time,
                    ev.DurationHours,
                    ev.DurationMinutes,
                    ev.Location,
                    ev.EnableReminder,
                    ev.ReminderTime,
                    ev.Description
                );
            }
        }


        private void btnAdd_Click(object sender, EventArgs e)
        {
            MainForm addForm = new MainForm();
            if (addForm.ShowDialog() == DialogResult.OK)
            {
                Event newEvent = addForm.GetEvent();
                events.Add(newEvent);

                dgvEvents.Rows.Add(
                    newEvent.Date,
                    newEvent.Time,
                    newEvent.DurationHours,
                    newEvent.DurationMinutes,
                    newEvent.Location,
                    newEvent.EnableReminder,
                    newEvent.ReminderTime,
                    newEvent.Description
                );

                MessageBox.Show("Новий захід успішно додано.", "Інформація", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (dgvEvents.CurrentRow != null)
            {
                int selectedIndex = dgvEvents.CurrentRow.Index;
                Event selectedEvent = events[selectedIndex];

                MainForm editForm = new MainForm(selectedEvent);
                if (editForm.ShowDialog() == DialogResult.OK)
                {
                    Event updatedEvent = editForm.GetEvent();
                    events[selectedIndex] = updatedEvent;

                    DataGridViewRow row = dgvEvents.Rows[selectedIndex];
                    row.Cells[0].Value = updatedEvent.Date;
                    row.Cells[1].Value = updatedEvent.Time;
                    row.Cells[2].Value = updatedEvent.DurationHours;
                    row.Cells[3].Value = updatedEvent.DurationMinutes;
                    row.Cells[4].Value = updatedEvent.Location;
                    row.Cells[5].Value = updatedEvent.EnableReminder;
                    row.Cells[6].Value = updatedEvent.ReminderTime;
                    row.Cells[7].Value = updatedEvent.Description;
                }
            }
            else
            {
                MessageBox.Show("Оберіть запис для редагування.", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dgvEvents.CurrentRow != null)
            {
                int selectedIndex = dgvEvents.CurrentRow.Index;

                // Перевіряємо, чи індекс у допустимому діапазоні
                if (selectedIndex >= 0 && selectedIndex < events.Count)
                {
                    var confirmation = MessageBox.Show(
                        "Ви впевнені, що хочете видалити цей запис?",
                        "Підтвердження",
                        MessageBoxButtons.YesNo,
                        MessageBoxIcon.Question
                    );

                    if (confirmation == DialogResult.Yes)
                    {
                        // Видаляємо запис із списку та таблиці
                        events.RemoveAt(selectedIndex);
                        dgvEvents.Rows.RemoveAt(selectedIndex);

                        MessageBox.Show("Запис успішно видалено.", "Інформація", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                else
                {
                    MessageBox.Show("Неможливо видалити: обраний рядок не відповідає запису.", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            else
            {
                MessageBox.Show("Оберіть запис для видалення.", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            // Підтвердження очищення
            var confirmation = MessageBox.Show(
                "Ви впевнені, що хочете очистити всі записи?",
                "Підтвердження",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning
            );

            if (confirmation == DialogResult.Yes)
            {
                // Очищаємо список подій і таблицю
                events.Clear();
                dgvEvents.Rows.Clear();

                MessageBox.Show("Всі записи успішно очищені.", "Інформація", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnClearPastEvents_Click(object sender, EventArgs e)
        {
            var confirmation = MessageBox.Show(
        "Ви хочете видалити всі вчорашні події або перенести їх на наступний день?",
        "Підтвердження",
        MessageBoxButtons.YesNoCancel,
        MessageBoxIcon.Question
    );

            if (confirmation == DialogResult.Yes)
            {
                // Видалення всіх вчорашніх подій
                events.RemoveAll(ev => DateTime.Parse(ev.Date) < DateTime.Today);
                UpdateEventGrid(events);

                MessageBox.Show("Всі вчорашні події успішно видалені.", "Інформація", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else if (confirmation == DialogResult.No)
            {
                // Перенесення вчорашніх подій на наступний день
                foreach (var ev in events.Where(ev => DateTime.Parse(ev.Date) < DateTime.Today).ToList())
                {
                    ev.Date = DateTime.Now.AddDays(1).ToShortDateString(); // Переносимо подію на наступний день
                }
                UpdateEventGrid(events);

                MessageBox.Show("Всі вчорашні події успішно перенесені на наступний день.", "Інформація", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        // Перевірка накладок
        private bool IsEventOverlap(Event newEvent)
        {
            foreach (var existingEvent in events)
            {
                DateTime newEventStart = DateTime.Parse(newEvent.Date + " " + newEvent.Time);
                DateTime newEventEnd = newEventStart.AddHours(newEvent.DurationHours).AddMinutes(newEvent.DurationMinutes);

                DateTime existingEventStart = DateTime.Parse(existingEvent.Date + " " + existingEvent.Time);
                DateTime existingEventEnd = existingEventStart.AddHours(existingEvent.DurationHours).AddMinutes(existingEvent.DurationMinutes);

                if (newEventStart < existingEventEnd && existingEventStart < newEventEnd)
                {
                    return true;
                }
            }
            return false;
        }

        // Кнопка для перевірки накладок
        private void btnOverlaps_Click(object sender, EventArgs e)
        {
            var overlappingEvents = FindOverlappingEvents();

            if (overlappingEvents.Count > 0)
            {
                string message = "Знайдено накладки між наступними подіями:\n";
                foreach (var (index1, index2) in overlappingEvents)
                {
                    message += $"- Подія {index1 + 1} ({events[index1].Description}) і подія {index2 + 1} ({events[index2].Description})\n";
                }

                MessageBox.Show(message, "Накладки подій", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                // Підсвічування накладок
                HighlightOverlappingEvents(overlappingEvents);
            }
            else
            {
                MessageBox.Show("Накладок між подіями не знайдено.", "Перевірка накладок", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        // Підсвічування накладок
        private void HighlightOverlappingEvents(List<(int, int)> overlappingEvents)
        {
            foreach (DataGridViewRow row in dgvEvents.Rows)
            {
                row.DefaultCellStyle.BackColor = Color.White; // Скидання кольору
            }

            foreach (var (index1, index2) in overlappingEvents)
            {
                dgvEvents.Rows[index1].DefaultCellStyle.BackColor = Color.LightCoral;
                dgvEvents.Rows[index2].DefaultCellStyle.BackColor = Color.LightCoral;
            }
        }

        // Пошук накладок між подіями
        private List<(int, int)> FindOverlappingEvents()
        {
            var overlaps = new List<(int, int)>();

            for (int i = 0; i < events.Count; i++)
            {
                DateTime startTime1 = DateTime.Parse(events[i].Date).Add(TimeSpan.Parse(events[i].Time));
                DateTime endTime1 = startTime1.AddHours(events[i].DurationHours).AddMinutes(events[i].DurationMinutes);

                for (int j = i + 1; j < events.Count; j++)
                {
                    DateTime startTime2 = DateTime.Parse(events[j].Date).Add(TimeSpan.Parse(events[j].Time));
                    DateTime endTime2 = startTime2.AddHours(events[j].DurationHours).AddMinutes(events[j].DurationMinutes);

                    // Перевірка на перетин
                    if (startTime1 < endTime2 && startTime2 < endTime1)
                    {
                        overlaps.Add((i, j));
                    }
                }
            }

            return overlaps;
        }


        private void btnFilter_Click(object sender, EventArgs e)
        {
            string searchQuery = txtSearch.Text.Trim().ToLower();

            // Пошук подій за запитом
            if (!string.IsNullOrEmpty(searchQuery))
            {
                var filteredEvents = events.Where(ev =>
                    ev.Description.ToLower().Contains(searchQuery) ||
                    ev.Location.ToLower().Contains(searchQuery) ||
                    ev.Date.Contains(searchQuery) ||
                    ev.Time.Contains(searchQuery)
                ).ToList();

                UpdateEventGrid(filteredEvents);

                if (filteredEvents.Count == 0)
                {
                    MessageBox.Show("Не знайдено записів за вказаним запитом.", "Результат пошуку", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                // Скидання фільтра
                UpdateEventGrid(events);
            }

            // Перевірка на накладки
            var overlappingEvents = FindOverlappingEvents();
            if (overlappingEvents.Count > 0)
            {
                string message = "Знайдено накладки між наступними подіями:\n";
                foreach (var (index1, index2) in overlappingEvents)
                {
                    message += $"- Подія {index1 + 1} ({events[index1].Description}) і подія {index2 + 1} ({events[index2].Description})\n";
                }

                MessageBox.Show(message, "Накладки подій", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                HighlightOverlappingEvents(overlappingEvents);
            }
            else
            {
                MessageBox.Show("Накладок між подіями не знайдено.", "Перевірка накладок", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            // Додавання або редагування подій
            if (dgvEvents.SelectedRows.Count == 0)
            {
                MainForm addForm = new MainForm();
                if (addForm.ShowDialog() == DialogResult.OK)
                {
                    Event newEvent = addForm.GetEvent();
                    events.Add(newEvent);
                    UpdateEventGrid(events);
                    MessageBox.Show("Новий захід успішно додано.", "Інформація", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                // Редагування вибраної події
                int selectedIndex = dgvEvents.CurrentRow.Index;
                Event selectedEvent = events[selectedIndex];

                MainForm editForm = new MainForm(selectedEvent);
                if (editForm.ShowDialog() == DialogResult.OK)
                {
                    events[selectedIndex] = editForm.GetEvent();
                    UpdateEventGrid(events);
                }
            }
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            cmbViewTasks.SelectedIndex = 0; // Скидання вибору
            UpdateEventGrid(events); // Показ всіх подій
        }

        private void btnReminder_Click(object sender, EventArgs e)
        {
            var reminderEvents = events.Where(ev => ev.EnableReminder).ToList();
            UpdateEventGrid(reminderEvents);

            if (reminderEvents.Count == 0)
            {
                MessageBox.Show("Немає подій з увімкненим нагадуванням.", "Нагадування", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnSaveAsBinary_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog
            {
                Filter = "Бінарні файли (*.bin)|*.bin|All files (*.*)|*.*",
                Title = "Зберегти події у бінарному форматі"
            };

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                using (BinaryWriter bw = new BinaryWriter(File.Open(saveFileDialog.FileName, FileMode.Create)))
                {
                    foreach (var ev in events)
                    {
                        bw.Write(ev.Date);
                        bw.Write(ev.Time);
                        bw.Write(ev.DurationHours);
                        bw.Write(ev.DurationMinutes);
                        bw.Write(ev.Location);
                        bw.Write(ev.EnableReminder);
                        bw.Write(ev.ReminderTime);
                        bw.Write(ev.Description);
                    }
                }
                MessageBox.Show("Події успішно збережено у бінарний файл.", "Інформація", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnSaveAsText_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog
            {
                Filter = "Текстові файли (*.txt)|*.txt|All files (*.*)|*.*",
                Title = "Зберегти події у текстовому форматі"
            };

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                using (StreamWriter sw = new StreamWriter(saveFileDialog.FileName, false, System.Text.Encoding.UTF8))
                {
                    foreach (var ev in events)
                    {
                        sw.WriteLine($"{ev.Date}\t{ev.Time}\t{ev.DurationHours}\t{ev.DurationMinutes}\t{ev.Location}\t{ev.EnableReminder}\t{ev.ReminderTime}\t{ev.Description}");
                    }
                }
                MessageBox.Show("Події успішно збережено у текстовий файл.", "Інформація", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnOpenFromBinary_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog
            {
                Filter = "Бінарні файли (*.bin)|*.bin|All files (*.*)|*.*",
                Title = "Відкрити події з бінарного файлу"
            };

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                events.Clear();
                using (BinaryReader br = new BinaryReader(File.Open(openFileDialog.FileName, FileMode.Open)))
                {
                    while (br.BaseStream.Position != br.BaseStream.Length)
                    {
                        events.Add(new Event
                        {
                            Date = br.ReadString(),
                            Time = br.ReadString(),
                            DurationHours = br.ReadInt32(),
                            DurationMinutes = br.ReadInt32(),
                            Location = br.ReadString(),
                            EnableReminder = br.ReadBoolean(),
                            ReminderTime = br.ReadString(),
                            Description = br.ReadString()
                        });
                    }
                }
                UpdateEventGrid(events);
                MessageBox.Show("Події успішно завантажено з бінарного файлу.", "Інформація", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnOpenFromText_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog
            {
                Filter = "Текстові файли (*.txt)|*.txt|All files (*.*)|*.*",
                Title = "Відкрити події з текстового файлу"
            };

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                events.Clear();
                using (StreamReader sr = new StreamReader(openFileDialog.FileName, System.Text.Encoding.UTF8))
                {
                    string line;
                    while ((line = sr.ReadLine()) != null)
                    {
                        string[] parts = line.Split('\t');
                        if (parts.Length >= 8)
                        {
                            events.Add(new Event
                            {
                                Date = parts[0],
                                Time = parts[1],
                                DurationHours = int.Parse(parts[2]),
                                DurationMinutes = int.Parse(parts[3]),
                                Location = parts[4],
                                EnableReminder = bool.Parse(parts[5]),
                                ReminderTime = parts[6],
                                Description = parts[7]
                            });
                        }
                    }
                }
                UpdateEventGrid(events);
                MessageBox.Show("Події успішно завантажено з текстового файлу.", "Інформація", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}