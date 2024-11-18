using System;

namespace DiarySchedulerApp
{
    partial class Form1
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
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.tabScheduledEvents = new System.Windows.Forms.TabPage();
            this.groupBoxFunctions = new System.Windows.Forms.GroupBox();
            this.btnClearPastEvents = new System.Windows.Forms.Button();
            this.cmbViewTasks = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btnOverlaps = new System.Windows.Forms.Button();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.btnSearch = new System.Windows.Forms.Button();
            this.btnReminder = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnReset = new System.Windows.Forms.Button();
            this.btnOpenFromBinary = new System.Windows.Forms.Button();
            this.btnOpenFromText = new System.Windows.Forms.Button();
            this.btnExit = new System.Windows.Forms.Button();
            this.btnSaveAsBinary = new System.Windows.Forms.Button();
            this.btnSaveAsText = new System.Windows.Forms.Button();
            this.btnClear = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnEdit = new System.Windows.Forms.Button();
            this.btnAdd = new System.Windows.Forms.Button();
            this.dgvEvents = new System.Windows.Forms.DataGridView();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabScheduledEvents.SuspendLayout();
            this.groupBoxFunctions.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvEvents)).BeginInit();
            this.tabControl1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabPage2
            // 
            this.tabPage2.Location = new System.Drawing.Point(4, 25);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(1381, 590);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "tabPage2";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // tabScheduledEvents
            // 
            this.tabScheduledEvents.Controls.Add(this.groupBoxFunctions);
            this.tabScheduledEvents.Controls.Add(this.groupBox1);
            this.tabScheduledEvents.Controls.Add(this.dgvEvents);
            this.tabScheduledEvents.Location = new System.Drawing.Point(4, 25);
            this.tabScheduledEvents.Name = "tabScheduledEvents";
            this.tabScheduledEvents.Padding = new System.Windows.Forms.Padding(3);
            this.tabScheduledEvents.Size = new System.Drawing.Size(1381, 590);
            this.tabScheduledEvents.TabIndex = 0;
            this.tabScheduledEvents.Text = "Перегляд Записів";
            this.tabScheduledEvents.UseVisualStyleBackColor = true;
            // 
            // groupBoxFunctions
            // 
            this.groupBoxFunctions.Controls.Add(this.btnClearPastEvents);
            this.groupBoxFunctions.Controls.Add(this.cmbViewTasks);
            this.groupBoxFunctions.Controls.Add(this.label1);
            this.groupBoxFunctions.Controls.Add(this.label5);
            this.groupBoxFunctions.Controls.Add(this.label2);
            this.groupBoxFunctions.Controls.Add(this.btnOverlaps);
            this.groupBoxFunctions.Controls.Add(this.txtSearch);
            this.groupBoxFunctions.Controls.Add(this.btnSearch);
            this.groupBoxFunctions.Controls.Add(this.btnReminder);
            this.groupBoxFunctions.Location = new System.Drawing.Point(1068, 256);
            this.groupBoxFunctions.Name = "groupBoxFunctions";
            this.groupBoxFunctions.Size = new System.Drawing.Size(307, 328);
            this.groupBoxFunctions.TabIndex = 18;
            this.groupBoxFunctions.TabStop = false;
            this.groupBoxFunctions.Text = "Додаткові функції";
            // 
            // btnClearPastEvents
            // 
            this.btnClearPastEvents.Location = new System.Drawing.Point(147, 155);
            this.btnClearPastEvents.Name = "btnClearPastEvents";
            this.btnClearPastEvents.Size = new System.Drawing.Size(155, 65);
            this.btnClearPastEvents.TabIndex = 26;
            this.btnClearPastEvents.Text = "Видалити/Перенести вчорашні справи";
            this.btnClearPastEvents.UseVisualStyleBackColor = true;
            this.btnClearPastEvents.Click += new System.EventHandler(this.btnClearPastEvents_Click);
            // 
            // cmbViewTasks
            // 
            this.cmbViewTasks.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbViewTasks.FormattingEnabled = true;
            this.cmbViewTasks.Items.AddRange(new object[] {
            "Всі події",
            "На сьогодні",
            "На завтра",
            "На післязавтра",
            "На найближчі 3 дні",
            "На найближчі 7 днів"});
            this.cmbViewTasks.Location = new System.Drawing.Point(98, 125);
            this.cmbViewTasks.Name = "cmbViewTasks";
            this.cmbViewTasks.Size = new System.Drawing.Size(121, 24);
            this.cmbViewTasks.TabIndex = 16;
            this.cmbViewTasks.SelectedIndexChanged += new System.EventHandler(this.cmbViewTasks_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(98, 106);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(115, 16);
            this.label1.TabIndex = 15;
            this.label1.Text = "Перегляд справ:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(114, 261);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(0, 16);
            this.label5.TabIndex = 22;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(209, 24);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(52, 16);
            this.label2.TabIndex = 19;
            this.label2.Text = "Пошук:";
            // 
            // btnOverlaps
            // 
            this.btnOverlaps.Location = new System.Drawing.Point(7, 155);
            this.btnOverlaps.Name = "btnOverlaps";
            this.btnOverlaps.Size = new System.Drawing.Size(113, 65);
            this.btnOverlaps.TabIndex = 1;
            this.btnOverlaps.Text = "Перевірка накладок";
            this.btnOverlaps.UseVisualStyleBackColor = true;
            this.btnOverlaps.Click += new System.EventHandler(this.btnOverlaps_Click);
            // 
            // txtSearch
            // 
            this.txtSearch.Location = new System.Drawing.Point(188, 43);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(107, 22);
            this.txtSearch.TabIndex = 4;
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(188, 71);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(107, 34);
            this.btnSearch.TabIndex = 3;
            this.btnSearch.Text = "Пошук";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // btnReminder
            // 
            this.btnReminder.Location = new System.Drawing.Point(7, 43);
            this.btnReminder.Name = "btnReminder";
            this.btnReminder.Size = new System.Drawing.Size(108, 60);
            this.btnReminder.TabIndex = 0;
            this.btnReminder.Text = "Нагадування";
            this.btnReminder.UseVisualStyleBackColor = true;
            this.btnReminder.Click += new System.EventHandler(this.btnReminder_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnReset);
            this.groupBox1.Controls.Add(this.btnOpenFromBinary);
            this.groupBox1.Controls.Add(this.btnOpenFromText);
            this.groupBox1.Controls.Add(this.btnExit);
            this.groupBox1.Controls.Add(this.btnSaveAsBinary);
            this.groupBox1.Controls.Add(this.btnSaveAsText);
            this.groupBox1.Controls.Add(this.btnClear);
            this.groupBox1.Controls.Add(this.btnDelete);
            this.groupBox1.Controls.Add(this.btnEdit);
            this.groupBox1.Controls.Add(this.btnAdd);
            this.groupBox1.Location = new System.Drawing.Point(1068, 6);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(301, 250);
            this.groupBox1.TabIndex = 17;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Основні функції";
            // 
            // btnReset
            // 
            this.btnReset.Location = new System.Drawing.Point(212, 176);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(90, 45);
            this.btnReset.TabIndex = 19;
            this.btnReset.Text = "Перезавантаження";
            this.btnReset.UseVisualStyleBackColor = true;
            this.btnReset.Click += new System.EventHandler(this.btnReset_Click);
            // 
            // btnOpenFromBinary
            // 
            this.btnOpenFromBinary.Location = new System.Drawing.Point(6, 176);
            this.btnOpenFromBinary.Name = "btnOpenFromBinary";
            this.btnOpenFromBinary.Size = new System.Drawing.Size(99, 44);
            this.btnOpenFromBinary.TabIndex = 14;
            this.btnOpenFromBinary.Text = "Відкрити з Бінарного";
            this.btnOpenFromBinary.UseVisualStyleBackColor = true;
            this.btnOpenFromBinary.Click += new System.EventHandler(this.btnOpenFromBinary_Click);
            // 
            // btnOpenFromText
            // 
            this.btnOpenFromText.Location = new System.Drawing.Point(111, 176);
            this.btnOpenFromText.Name = "btnOpenFromText";
            this.btnOpenFromText.Size = new System.Drawing.Size(95, 44);
            this.btnOpenFromText.TabIndex = 13;
            this.btnOpenFromText.Text = "Відкрити з Тексту";
            this.btnOpenFromText.UseVisualStyleBackColor = true;
            this.btnOpenFromText.Click += new System.EventHandler(this.btnOpenFromText_Click);
            // 
            // btnExit
            // 
            this.btnExit.Location = new System.Drawing.Point(210, 31);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(85, 38);
            this.btnExit.TabIndex = 10;
            this.btnExit.Text = "Вихід";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // btnSaveAsBinary
            // 
            this.btnSaveAsBinary.Location = new System.Drawing.Point(6, 125);
            this.btnSaveAsBinary.Name = "btnSaveAsBinary";
            this.btnSaveAsBinary.Size = new System.Drawing.Size(99, 45);
            this.btnSaveAsBinary.TabIndex = 12;
            this.btnSaveAsBinary.Text = "Зберегти як Бінарний";
            this.btnSaveAsBinary.UseVisualStyleBackColor = true;
            this.btnSaveAsBinary.Click += new System.EventHandler(this.btnSaveAsBinary_Click);
            // 
            // btnSaveAsText
            // 
            this.btnSaveAsText.Location = new System.Drawing.Point(111, 125);
            this.btnSaveAsText.Name = "btnSaveAsText";
            this.btnSaveAsText.Size = new System.Drawing.Size(95, 47);
            this.btnSaveAsText.TabIndex = 11;
            this.btnSaveAsText.Text = "Зберегти як Текст";
            this.btnSaveAsText.UseVisualStyleBackColor = true;
            this.btnSaveAsText.Click += new System.EventHandler(this.btnSaveAsText_Click);
            // 
            // btnClear
            // 
            this.btnClear.Location = new System.Drawing.Point(111, 75);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(95, 47);
            this.btnClear.TabIndex = 5;
            this.btnClear.Text = "Очистити";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(6, 75);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(99, 44);
            this.btnDelete.TabIndex = 4;
            this.btnDelete.Text = "Видалити";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnEdit
            // 
            this.btnEdit.Location = new System.Drawing.Point(111, 31);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(95, 38);
            this.btnEdit.TabIndex = 3;
            this.btnEdit.Text = "Редагувати";
            this.btnEdit.UseVisualStyleBackColor = true;
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(6, 31);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(99, 38);
            this.btnAdd.TabIndex = 2;
            this.btnAdd.Text = "Додати";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // dgvEvents
            // 
            this.dgvEvents.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvEvents.Location = new System.Drawing.Point(0, 0);
            this.dgvEvents.Name = "dgvEvents";
            this.dgvEvents.ReadOnly = true;
            this.dgvEvents.RowHeadersWidth = 51;
            this.dgvEvents.RowTemplate.Height = 24;
            this.dgvEvents.Size = new System.Drawing.Size(1059, 579);
            this.dgvEvents.TabIndex = 0;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabScheduledEvents);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Location = new System.Drawing.Point(12, 12);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1389, 619);
            this.tabControl1.TabIndex = 0;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1400, 628);
            this.Controls.Add(this.tabControl1);
            this.Name = "Form1";
            this.Text = "Щоденник запланованих заходів";
            this.tabScheduledEvents.ResumeLayout(false);
            this.groupBoxFunctions.ResumeLayout(false);
            this.groupBoxFunctions.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvEvents)).EndInit();
            this.tabControl1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TabPage tabScheduledEvents;
        private System.Windows.Forms.GroupBox groupBoxFunctions;
        private System.Windows.Forms.Button btnClearPastEvents;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnOverlaps;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.Button btnReminder;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnOpenFromBinary;
        private System.Windows.Forms.Button btnOpenFromText;
        private System.Windows.Forms.Button btnSaveAsBinary;
        private System.Windows.Forms.Button btnSaveAsText;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnEdit;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.ComboBox cmbViewTasks;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.DataGridView dgvEvents;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.Button btnReset;
    }
}