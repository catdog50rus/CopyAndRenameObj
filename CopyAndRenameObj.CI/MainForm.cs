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
        private FolderController controller;
        private string selectedPath;
        
        public MainForm()
        {
            InitializeComponent();
            buttonRename.Enabled = false;
            buttonCopy.Enabled = false;
            textOld.Enabled = false;
            textNew.Enabled = false;
            
        }

        #region Обработка нажатия кнопок
        private void ButtonSelect_Click(object sender, EventArgs e)
        {
            
            Clear();
            //Окно выбора директории
            DialogResult result = SelectFolderDialog.ShowDialog();
            if (result == DialogResult.OK)
            {
                
                selectedPath = SelectFolderDialog.SelectedPath;
                //Создаем коллекцию директорий в выбранной папке
                var collection = new List<string>();
                collection.AddRange(Directory.GetDirectories(selectedPath));
                //заполняем список назаваниями директорий в выбраной папке
                foreach (var item in collection)
                {
                    SelectDirs.Items.Add(item.Remove(0, selectedPath.Length+1));
                }
            }
        }

        private void ButtonRename_Click(object sender, EventArgs e)
        {

            
            if(textNew.Text != textOld.Text)
            {
                try
                {
                    controller.ChangeFilesNames(textOld.Text, textNew.Text);
                    ListNewUpdate();
                    buttonCopy.Enabled = true;
                }
                catch (Exception ex)
                {

                    MessageBox.Show("Изменяемая часть названия файла не найдена!", ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                Clear();
                SelectDirs.Items.AddRange(Directory.GetDirectories(SelectFolderDialog.SelectedPath));
            }
            else
            {
                MessageBox.Show("Что-то пошло не так!", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
           
        }
        #endregion

        #region Обработка выбора директории
        private void SelectDirs_DoubleClick(object sender, EventArgs e)
        {


            if (SelectDirs.SelectedItem != null)
            {
                var path = $"{selectedPath}/{SelectDirs.SelectedItem.ToString()}";
                controller = new FolderController();
                controller.SetSelectDir(@path);
                //
                ListFoldersUpdate();
                textOld.Enabled = true;
            }


        }
        #endregion

        #region Обновление списков
        private void ListFoldersUpdate()
        {
            
            //очищаем список копируемых файлов
            listViewOld.Items.Clear();
            //заполняем список копируемых файлов
            foreach (var file in controller.GetSelectFoldersFilesNamesList())
            {
                listViewOld.Items.Add(file.Name);
            }
           
        }

        private void ListNewUpdate()
        {

            //очищаем список новых файлов
            listViewNew.Items.Clear();
            //заполняем список новых файлов
            foreach (var file in controller.GetNewFilesNamesList())
            {
                listViewNew.Items.Add(file);
            }
        }
        #endregion

        #region Активация кнопок и надписей

        private void TextOld_TextChanged(object sender, EventArgs e)
        {
            
            textNew.Enabled = textOld.Text != "" ? true : false;
            buttonRename.Enabled = (textNew.Text != "" && textOld.Text != "") ? true : false;
        }

        private void TextNew_TextChanged(object sender, EventArgs e)
        {
            buttonRename.Enabled = (textNew.Text != "" && textOld.Text !="")?   true : false;
        }
        #endregion

        /// <summary>
        /// Очистка UI
        /// </summary>
        private void Clear()
        {
            listViewOld.Items.Clear();
            listViewNew.Items.Clear();
            textOld.Text = null;
            textNew.Text = null;
            buttonRename.Enabled = false;
            buttonCopy.Enabled = false;
            textOld.Enabled = false;
            textNew.Enabled = false;
            SelectDirs.Items.Clear();
            
        }
    }
}
