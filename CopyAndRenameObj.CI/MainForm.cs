using CopyAndRenameObj.BL.Controler;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace CopyAndRenameObj.CI
{
    public partial class MainForm : Form
    {
        private FolderController controller;// = new FolderController();
        
        public MainForm()
        {
            InitializeComponent();
            buttonRename.Enabled = false;
            buttonCopy.Enabled = false;
            textOld.Enabled = false;
            textNew.Enabled = false;
            
        }

        private void ButtonSelect_Click(object sender, EventArgs e)
        {
            
            DialogResult result = SelectFolderDialog.ShowDialog();
            if (result == DialogResult.OK)
            {
                controller = new FolderController();
                controller.SetSelectDir(SelectFolderDialog.SelectedPath);
                
                ListOldUpdate();
                textOld.Enabled = true;

            }
        }

        private void ButtonRename_Click(object sender, EventArgs e)
        {

            if(textNew.Text != textOld.Text)
            {
                var res = controller.ChangeFilesNames(textOld.Text, textNew.Text);
                if (res)
                {
                    ListNewUpdate();
                    buttonCopy.Enabled = true;
                }
               
            } 
            else
            {
                MessageBox.Show("Не указан, что меняется в файлах!", "Что-то пошло не так!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            

        }

        private void ButtonCopy_Click(object sender, EventArgs e)
        {
            bool res = controller.CopyFiles();

            if (res)
            {
                MessageBox.Show("Копирование успешно завершено!", "Выполнено!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Что-то пошло не так!", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
           
        }

        private void ListOldUpdate()
        {
            listView1.Items.Clear();

            foreach (var file in controller.GetSelectFoldersFilesNamesList())
            {
                listView1.Items.Add(file.Name);

            }

        }

        private void ListNewUpdate()
        {
            listView2.Items.Clear();
            foreach (var file in controller.GetNewFilesNamesList())
            {
                listView2.Items.Add(file);
            }
        }

        private void TextOld_TextChanged(object sender, EventArgs e)
        {
            
            textNew.Enabled = textOld.Text != "" ? true : false;
            buttonRename.Enabled = (textNew.Text != "" && textOld.Text != "") ? true : false;
        }

        private void TextNew_TextChanged(object sender, EventArgs e)
        {
            buttonRename.Enabled = (textNew.Text != "" && textOld.Text !="")?   true : false;
        }

        

    }
}
