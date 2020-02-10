using CopyAndRenameObj.BL.Controler;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CopyAndRenameObj.CI
{
    public partial class Main : Form
    {
        readonly SelectFolder selectFolder = new SelectFolder();
        
        public Main()
        {
            InitializeComponent();
            buttonRun.Enabled = false;
            buttonCopy.Enabled = false;
        }

        private void ButtonSelect_Click(object sender, EventArgs e)
        {
            DialogResult result = SelectFolderDialog.ShowDialog();
            if (result == DialogResult.OK)
            {
                selectFolder.SetFilesNamesList(SelectFolderDialog.SelectedPath);
                
                ListOldUpdate();

            }
        }

        private void ListOldUpdate()
        {
            listView1.Items.Clear();

            foreach (var file in selectFolder.FilesNamesList)
            {
                listView1.Items.Add(file.Name);

            }

        }

        private void ListNewUpdate()
        {
            listView2.Items.Clear();
            foreach (var file in selectFolder.NewFilesNamesList)
            {
                listView2.Items.Add(file);
            }
        }

        private void TextOld_TextChanged(object sender, EventArgs e)
        {
            selectFolder.OldName = textOld.Text;
        }

        private void TextNew_TextChanged(object sender, EventArgs e)
        {
            selectFolder.NewName = textNew.Text;
            buttonRun.Enabled = textNew.Text != ""?  true : false;
        }

        private void ButtonRun_Click(object sender, EventArgs e)
        {
            
            var res = selectFolder.ChangeFilesNames();
            if (res)
            {
                ListNewUpdate();
                buttonCopy.Enabled = true;
            }
            else
            {
                MessageBox.Show("Не указан, что меняется в файлах!", "Что-то пошло не так!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
        }

        private void ButtonCopy_Click(object sender, EventArgs e)
        {
            selectFolder.CopyFiles();

            Thread.Sleep(500);
            MessageBox.Show("Копирование успешно завершено!", "Выполнено!", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
