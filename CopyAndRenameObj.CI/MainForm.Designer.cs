namespace CopyAndRenameObj.CI
{
    partial class MainForm
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.label1 = new System.Windows.Forms.Label();
            this.textOld = new System.Windows.Forms.TextBox();
            this.textNew = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.buttonSelect = new System.Windows.Forms.Button();
            this.buttonRename = new System.Windows.Forms.Button();
            this.SelectFolderDialog = new System.Windows.Forms.FolderBrowserDialog();
            this.listViewOld = new System.Windows.Forms.ListView();
            this.panel1 = new System.Windows.Forms.Panel();
            this.buttonDel = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.SelectDirs = new System.Windows.Forms.ListBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.buttonCopy = new System.Windows.Forms.Button();
            this.listViewNew = new System.Windows.Forms.ListView();
            this.panel3 = new System.Windows.Forms.Panel();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.Description = new System.Windows.Forms.Label();
            this.menuStrip2 = new System.Windows.Forms.MenuStrip();
            this.OptionsMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.SelectFolderMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.menuStrip2.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(159, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(441, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Система копирования подвижного состава RTrainSim, путем изменения части имени";
            // 
            // textOld
            // 
            this.textOld.Location = new System.Drawing.Point(223, 11);
            this.textOld.Name = "textOld";
            this.textOld.Size = new System.Drawing.Size(123, 20);
            this.textOld.TabIndex = 1;
            this.textOld.Click += new System.EventHandler(this.TextOld_TextChanged);
            this.textOld.TextChanged += new System.EventHandler(this.TextOld_TextChanged);
            this.textOld.DoubleClick += new System.EventHandler(this.TextOld_TextChanged);
            // 
            // textNew
            // 
            this.textNew.Location = new System.Drawing.Point(612, 11);
            this.textNew.Name = "textNew";
            this.textNew.Size = new System.Drawing.Size(126, 20);
            this.textNew.TabIndex = 2;
            this.textNew.Click += new System.EventHandler(this.TextNew_TextChanged);
            this.textNew.TextChanged += new System.EventHandler(this.TextNew_TextChanged);
            this.textNew.DoubleClick += new System.EventHandler(this.TextNew_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(15, 14);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(202, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Меняемая часть имени файла / папки";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(372, 14);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(234, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "На что меняется часть имени файла / папки";
            // 
            // buttonSelect
            // 
            this.buttonSelect.Location = new System.Drawing.Point(18, 269);
            this.buttonSelect.Name = "buttonSelect";
            this.buttonSelect.Size = new System.Drawing.Size(107, 30);
            this.buttonSelect.TabIndex = 5;
            this.buttonSelect.Text = "Выбрать папку";
            this.buttonSelect.UseVisualStyleBackColor = true;
            this.buttonSelect.Click += new System.EventHandler(this.ButtonSelect_Click);
            // 
            // buttonRename
            // 
            this.buttonRename.Location = new System.Drawing.Point(59, 269);
            this.buttonRename.Name = "buttonRename";
            this.buttonRename.Size = new System.Drawing.Size(137, 29);
            this.buttonRename.TabIndex = 6;
            this.buttonRename.Text = "Заменить";
            this.buttonRename.UseVisualStyleBackColor = true;
            this.buttonRename.Click += new System.EventHandler(this.ButtonRename_Click);
            // 
            // listViewOld
            // 
            this.listViewOld.HideSelection = false;
            this.listViewOld.Location = new System.Drawing.Point(16, 25);
            this.listViewOld.Name = "listViewOld";
            this.listViewOld.Size = new System.Drawing.Size(225, 238);
            this.listViewOld.TabIndex = 7;
            this.listViewOld.UseCompatibleStateImageBehavior = false;
            this.listViewOld.View = System.Windows.Forms.View.List;
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel1.Controls.Add(this.buttonDel);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.SelectDirs);
            this.panel1.Controls.Add(this.buttonSelect);
            this.panel1.Location = new System.Drawing.Point(3, 79);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(251, 315);
            this.panel1.TabIndex = 8;
            // 
            // buttonDel
            // 
            this.buttonDel.Location = new System.Drawing.Point(136, 268);
            this.buttonDel.Name = "buttonDel";
            this.buttonDel.Size = new System.Drawing.Size(107, 30);
            this.buttonDel.TabIndex = 8;
            this.buttonDel.Text = "Удалить папку";
            this.buttonDel.UseVisualStyleBackColor = true;
            this.buttonDel.Click += new System.EventHandler(this.ButtonDel_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(15, 9);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(163, 13);
            this.label4.TabIndex = 7;
            this.label4.Text = "Папки с подвижным составом";
            // 
            // SelectDirs
            // 
            this.SelectDirs.FormattingEnabled = true;
            this.SelectDirs.Location = new System.Drawing.Point(18, 25);
            this.SelectDirs.Name = "SelectDirs";
            this.SelectDirs.Size = new System.Drawing.Size(225, 238);
            this.SelectDirs.TabIndex = 6;
            this.SelectDirs.DoubleClick += new System.EventHandler(this.SelectDirs_DoubleClick);
            // 
            // panel2
            // 
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel2.Controls.Add(this.label6);
            this.panel2.Controls.Add(this.label5);
            this.panel2.Controls.Add(this.buttonCopy);
            this.panel2.Controls.Add(this.listViewOld);
            this.panel2.Controls.Add(this.listViewNew);
            this.panel2.Controls.Add(this.buttonRename);
            this.panel2.Location = new System.Drawing.Point(260, 79);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(500, 315);
            this.panel2.TabIndex = 9;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(253, 9);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(190, 13);
            this.label6.TabIndex = 9;
            this.label6.Text = "Файлы нового подвижного состава\r\n";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(13, 9);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(221, 13);
            this.label5.TabIndex = 8;
            this.label5.Text = "Файлы копируемого подвижного состава\r\n";
            // 
            // buttonCopy
            // 
            this.buttonCopy.Location = new System.Drawing.Point(302, 268);
            this.buttonCopy.Name = "buttonCopy";
            this.buttonCopy.Size = new System.Drawing.Size(139, 30);
            this.buttonCopy.TabIndex = 8;
            this.buttonCopy.Text = "Скопировать";
            this.buttonCopy.UseVisualStyleBackColor = true;
            this.buttonCopy.Click += new System.EventHandler(this.ButtonCopy_Click);
            // 
            // listViewNew
            // 
            this.listViewNew.HideSelection = false;
            this.listViewNew.Location = new System.Drawing.Point(256, 24);
            this.listViewNew.Name = "listViewNew";
            this.listViewNew.Size = new System.Drawing.Size(225, 238);
            this.listViewNew.TabIndex = 7;
            this.listViewNew.UseCompatibleStateImageBehavior = false;
            this.listViewNew.View = System.Windows.Forms.View.List;
            // 
            // panel3
            // 
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel3.Controls.Add(this.label2);
            this.panel3.Controls.Add(this.textOld);
            this.panel3.Controls.Add(this.textNew);
            this.panel3.Controls.Add(this.label3);
            this.panel3.Location = new System.Drawing.Point(3, 30);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(757, 43);
            this.panel3.TabIndex = 10;
            // 
            // menuStrip1
            // 
            this.menuStrip1.Location = new System.Drawing.Point(0, 24);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(764, 24);
            this.menuStrip1.TabIndex = 11;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // Description
            // 
            this.Description.Location = new System.Drawing.Point(3, 397);
            this.Description.Name = "Description";
            this.Description.Size = new System.Drawing.Size(757, 182);
            this.Description.TabIndex = 12;
            this.Description.Text = resources.GetString("Description.Text");
            this.Description.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // menuStrip2
            // 
            this.menuStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.OptionsMenu});
            this.menuStrip2.Location = new System.Drawing.Point(0, 0);
            this.menuStrip2.Name = "menuStrip2";
            this.menuStrip2.Size = new System.Drawing.Size(764, 24);
            this.menuStrip2.TabIndex = 13;
            this.menuStrip2.Text = "menuStrip2";
            // 
            // OptionsMenu
            // 
            this.OptionsMenu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.SelectFolderMenuItem});
            this.OptionsMenu.Name = "OptionsMenu";
            this.OptionsMenu.Size = new System.Drawing.Size(79, 20);
            this.OptionsMenu.Text = "Настройки";
            // 
            // SelectFolderMenuItem
            // 
            this.SelectFolderMenuItem.Name = "SelectFolderMenuItem";
            this.SelectFolderMenuItem.Size = new System.Drawing.Size(198, 22);
            this.SelectFolderMenuItem.Text = "Выбрать папку с MSTS";
            this.SelectFolderMenuItem.Click += new System.EventHandler(this.SelectFolderMenuItem_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(764, 572);
            this.Controls.Add(this.Description);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.menuStrip2);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "MainForm";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.menuStrip2.ResumeLayout(false);
            this.menuStrip2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textOld;
        private System.Windows.Forms.TextBox textNew;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button buttonSelect;
        private System.Windows.Forms.Button buttonRename;
        private System.Windows.Forms.FolderBrowserDialog SelectFolderDialog;
        private System.Windows.Forms.ListView listViewOld;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.ListView listViewNew;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Button buttonCopy;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.Label Description;
        private System.Windows.Forms.ListBox SelectDirs;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.MenuStrip menuStrip2;
        private System.Windows.Forms.ToolStripMenuItem OptionsMenu;
        private System.Windows.Forms.ToolStripMenuItem SelectFolderMenuItem;
        private System.Windows.Forms.Button buttonDel;
    }
}

