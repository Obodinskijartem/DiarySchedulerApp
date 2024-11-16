using System;
using System.Windows.Forms;

namespace DiarySchedulerApp
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.chkReminder = new System.Windows.Forms.CheckBox();
            this.txtDescription = new System.Windows.Forms.TextBox();
            this.lblDescription = new System.Windows.Forms.Label();
            this.lblLocation = new System.Windows.Forms.Label();
            this.txtLocation = new System.Windows.Forms.TextBox();
            this.lblDurationMinutes = new System.Windows.Forms.Label();
            this.lblDurationHours = new System.Windows.Forms.Label();
            this.lblTime = new System.Windows.Forms.Label();
            this.lblDate = new System.Windows.Forms.Label();
            this.datePickerEvent = new System.Windows.Forms.DateTimePicker();
            this.timePickerEvent = new System.Windows.Forms.DateTimePicker();
            this.numDurationHours = new System.Windows.Forms.NumericUpDown();
            this.numDurationMinutes = new System.Windows.Forms.NumericUpDown();
            this.cmbReminderTime = new System.Windows.Forms.ComboBox();
            this.lblReminderTime = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lblEnableReminder = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.numDurationHours)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numDurationMinutes)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(270, 384);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(90, 35);
            this.btnCancel.TabIndex = 37;
            this.btnCancel.Text = "Скасувати";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(15, 384);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(90, 35);
            this.btnSave.TabIndex = 36;
            this.btnSave.Text = "Зберегти";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // chkReminder
            // 
            this.chkReminder.AutoSize = true;
            this.chkReminder.Location = new System.Drawing.Point(174, 218);
            this.chkReminder.Name = "chkReminder";
            this.chkReminder.Size = new System.Drawing.Size(53, 20);
            this.chkReminder.TabIndex = 31;
            this.chkReminder.Text = "Так";
            this.chkReminder.UseVisualStyleBackColor = true;
            // 
            // txtDescription
            // 
            this.txtDescription.Location = new System.Drawing.Point(155, 296);
            this.txtDescription.Multiline = true;
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.Size = new System.Drawing.Size(200, 22);
            this.txtDescription.TabIndex = 30;
            // 
            // lblDescription
            // 
            this.lblDescription.AutoSize = true;
            this.lblDescription.Location = new System.Drawing.Point(7, 299);
            this.lblDescription.Name = "lblDescription";
            this.lblDescription.Size = new System.Drawing.Size(92, 16);
            this.lblDescription.TabIndex = 29;
            this.lblDescription.Text = "Опис заходу:";
            // 
            // lblLocation
            // 
            this.lblLocation.AutoSize = true;
            this.lblLocation.Location = new System.Drawing.Point(7, 182);
            this.lblLocation.Name = "lblLocation";
            this.lblLocation.Size = new System.Drawing.Size(129, 16);
            this.lblLocation.TabIndex = 27;
            this.lblLocation.Text = "Місце проведення:";
            // 
            // txtLocation
            // 
            this.txtLocation.Location = new System.Drawing.Point(155, 182);
            this.txtLocation.Name = "txtLocation";
            this.txtLocation.Size = new System.Drawing.Size(200, 22);
            this.txtLocation.TabIndex = 26;
            // 
            // lblDurationMinutes
            // 
            this.lblDurationMinutes.AutoSize = true;
            this.lblDurationMinutes.Location = new System.Drawing.Point(7, 142);
            this.lblDurationMinutes.Name = "lblDurationMinutes";
            this.lblDurationMinutes.Size = new System.Drawing.Size(108, 16);
            this.lblDurationMinutes.TabIndex = 25;
            this.lblDurationMinutes.Text = "Тривалість (хв):";
            // 
            // lblDurationHours
            // 
            this.lblDurationHours.AutoSize = true;
            this.lblDurationHours.Location = new System.Drawing.Point(7, 102);
            this.lblDurationHours.Name = "lblDurationHours";
            this.lblDurationHours.Size = new System.Drawing.Size(116, 16);
            this.lblDurationHours.TabIndex = 23;
            this.lblDurationHours.Text = "Тривалість (год):";
            // 
            // lblTime
            // 
            this.lblTime.AutoSize = true;
            this.lblTime.Location = new System.Drawing.Point(7, 62);
            this.lblTime.Name = "lblTime";
            this.lblTime.Size = new System.Drawing.Size(34, 16);
            this.lblTime.TabIndex = 21;
            this.lblTime.Text = "Час:";
            // 
            // lblDate
            // 
            this.lblDate.AutoSize = true;
            this.lblDate.Location = new System.Drawing.Point(7, 22);
            this.lblDate.Name = "lblDate";
            this.lblDate.Size = new System.Drawing.Size(42, 16);
            this.lblDate.TabIndex = 19;
            this.lblDate.Text = "Дата:";
            // 
            // datePickerEvent
            // 
            this.datePickerEvent.Location = new System.Drawing.Point(155, 22);
            this.datePickerEvent.Name = "datePickerEvent";
            this.datePickerEvent.Size = new System.Drawing.Size(200, 22);
            this.datePickerEvent.TabIndex = 38;
            // 
            // timePickerEvent
            // 
            this.timePickerEvent.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.timePickerEvent.Location = new System.Drawing.Point(155, 62);
            this.timePickerEvent.Name = "timePickerEvent";
            this.timePickerEvent.Size = new System.Drawing.Size(200, 22);
            this.timePickerEvent.TabIndex = 39;
            // 
            // numDurationHours
            // 
            this.numDurationHours.Location = new System.Drawing.Point(155, 102);
            this.numDurationHours.Maximum = new decimal(new int[] {
            24,
            0,
            0,
            0});
            this.numDurationHours.Name = "numDurationHours";
            this.numDurationHours.Size = new System.Drawing.Size(200, 22);
            this.numDurationHours.TabIndex = 40;
            // 
            // numDurationMinutes
            // 
            this.numDurationMinutes.Location = new System.Drawing.Point(155, 140);
            this.numDurationMinutes.Maximum = new decimal(new int[] {
            59,
            0,
            0,
            0});
            this.numDurationMinutes.Name = "numDurationMinutes";
            this.numDurationMinutes.Size = new System.Drawing.Size(200, 22);
            this.numDurationMinutes.TabIndex = 41;
            // 
            // cmbReminderTime
            // 
            this.cmbReminderTime.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbReminderTime.FormattingEnabled = true;
            this.cmbReminderTime.Location = new System.Drawing.Point(155, 256);
            this.cmbReminderTime.Name = "cmbReminderTime";
            this.cmbReminderTime.Size = new System.Drawing.Size(200, 24);
            this.cmbReminderTime.TabIndex = 43;
            this.cmbReminderTime.SelectedIndexChanged += new System.EventHandler(this.cmbReminderTime_SelectedIndexChanged);
            // 
            // lblReminderTime
            // 
            this.lblReminderTime.AutoSize = true;
            this.lblReminderTime.Location = new System.Drawing.Point(8, 264);
            this.lblReminderTime.Name = "lblReminderTime";
            this.lblReminderTime.Size = new System.Drawing.Size(141, 16);
            this.lblReminderTime.TabIndex = 44;
            this.lblReminderTime.Text = "Час до нагадування:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(2, 246);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(162, 16);
            this.label2.TabIndex = 45;
            this.label2.Text = "Увімкнути нагадування";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lblEnableReminder);
            this.groupBox1.Controls.Add(this.lblReminderTime);
            this.groupBox1.Controls.Add(this.cmbReminderTime);
            this.groupBox1.Controls.Add(this.numDurationMinutes);
            this.groupBox1.Controls.Add(this.numDurationHours);
            this.groupBox1.Controls.Add(this.timePickerEvent);
            this.groupBox1.Controls.Add(this.datePickerEvent);
            this.groupBox1.Controls.Add(this.chkReminder);
            this.groupBox1.Controls.Add(this.txtDescription);
            this.groupBox1.Controls.Add(this.lblDescription);
            this.groupBox1.Controls.Add(this.lblLocation);
            this.groupBox1.Controls.Add(this.txtLocation);
            this.groupBox1.Controls.Add(this.lblDurationMinutes);
            this.groupBox1.Controls.Add(this.lblDurationHours);
            this.groupBox1.Controls.Add(this.lblTime);
            this.groupBox1.Controls.Add(this.lblDate);
            this.groupBox1.Location = new System.Drawing.Point(5, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(369, 341);
            this.groupBox1.TabIndex = 46;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Деталі заходу";
            // 
            // lblEnableReminder
            // 
            this.lblEnableReminder.AutoSize = true;
            this.lblEnableReminder.Location = new System.Drawing.Point(6, 218);
            this.lblEnableReminder.Name = "lblEnableReminder";
            this.lblEnableReminder.Size = new System.Drawing.Size(162, 16);
            this.lblEnableReminder.TabIndex = 45;
            this.lblEnableReminder.Text = "Увімкнути нагадування";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(379, 435);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnSave);
            this.Name = "MainForm";
            this.Text = " Додати нову подію";
            ((System.ComponentModel.ISupportInitialize)(this.numDurationHours)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numDurationMinutes)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private void label2_Click(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        private void cmbReminderTime_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Реалізація логіки для вибору часу нагадування
            string selectedTime = cmbReminderTime.SelectedItem?.ToString();
            if (!string.IsNullOrEmpty(selectedTime))
            {
                MessageBox.Show($"Ви вибрали нагадування за {selectedTime}");
            }
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        #endregion

        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.CheckBox chkReminder;
        private System.Windows.Forms.TextBox txtDescription;
        private System.Windows.Forms.Label lblDescription;
        private System.Windows.Forms.Label lblLocation;
        private System.Windows.Forms.TextBox txtLocation;
        private System.Windows.Forms.Label lblDurationMinutes;
        private System.Windows.Forms.Label lblDurationHours;
        private System.Windows.Forms.Label lblTime;
        private System.Windows.Forms.Label lblDate;
        private System.Windows.Forms.DateTimePicker datePickerEvent;
        private System.Windows.Forms.DateTimePicker timePickerEvent;
        private System.Windows.Forms.NumericUpDown numDurationHours;
        private System.Windows.Forms.NumericUpDown numDurationMinutes;
        private System.Windows.Forms.ComboBox cmbReminderTime;
        private System.Windows.Forms.Label lblReminderTime;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox groupBox1;
        private Label lblEnableReminder;
    }
}