using CopyAndRenameObj.BL.Controler;
using System;
using System.Collections.Generic;
using System.IO;
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
            //Пробуем загрузить расположение папки с MSTS
            selectedPath = new OptionsController().Load();
            if (selectedPath.Length != 0)
            {
                SelectDirsUpdate();
            }
            
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
                SelectDirsUpdate();
            }
        }

        private void ButtonRename_Click(object sender, EventArgs e)
        {
            if(textNew.Text != textOld.Text)
            {
                var result = new RenameFilesController(controller).ChangeFilesNames(textOld.Text, textNew.Text);
                if (result)
                {
                    ListNewUpdate();
                    buttonCopy.Enabled = true;
                }
                else
                {
                    MessageBox.Show("Изменяемая часть названия файла не найдена!", "Изменений не найдено", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    buttonCopy.Enabled = false;
                }
            } 
            else
            {
                MessageBox.Show("Не указан, что меняется в файлах!", "Что-то пошло не так!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                buttonCopy.Enabled = false;
            }
        }

        private void ButtonCopy_Click(object sender, EventArgs e)
        {
            var res = new CopyFilesController(controller).CopyFiles(); 
            
            if (res)
            {
                SelectDirsUpdate();
                listViewNew.Items.Clear();
                MessageBox.Show("Копирование успешно завершено!", "Выполнено!", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
        /// <summary>
        /// Обновления спска файлов в выбранной директории
        /// </summary>
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
        /// <summary>
        /// Обновления списка измененных имен файлов
        /// </summary>
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
        /// <summary>
        /// Обновление списка директорий
        /// </summary>
        private void SelectDirsUpdate()
        {
            SelectDirs.Items.Clear();
            //Создаем коллекцию директорий в выбранной папке
            var collection = new List<string>();
            collection.AddRange(Directory.GetDirectories(selectedPath));
            //заполняем список назаваниями директорий в выбраной папке
            foreach (var item in collection)
            {
                SelectDirs.Items.Add(item.Remove(0, selectedPath.Length + 1));
            }
        }

        #endregion

        #region Активация кнопок и надписей

        private void TextOld_TextChanged(object sender, EventArgs e)
        {
            buttonCopy.Enabled = false;
            buttonRename.Enabled = false;
            textNew.Enabled = textOld.Text != "" ? true : false;
            buttonRename.Enabled = (textNew.Text != "" && textOld.Text != "") ? true : false;
            listViewNew.Items.Clear();
        }

        private void TextNew_TextChanged(object sender, EventArgs e)
        {
            buttonCopy.Enabled = false;
            buttonRename.Enabled = false;
            buttonRename.Enabled = (textNew.Text != "" && textOld.Text !="")?   true : false;
            listViewNew.Items.Clear();
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

        ///<summary>
        ///Выбираем и сохраняем расположение папки с MSTS
        ///</summary>
        private void SelectFolderMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult result = SelectFolderDialog.ShowDialog();
            if (result == DialogResult.OK)
            {
                var path = SelectFolderDialog.SelectedPath;
                selectedPath = Path.Combine(path, "TRAINS", "TRAINSET");
                new OptionsController().Save(selectedPath);
            }
            SelectDirsUpdate();
        }

        /// <summary>
        /// Удаляет выбранную папку с диска
        /// </summary>
        private void ButtonDel_Click(object sender, EventArgs e)
        {
            if (SelectDirs.SelectedItem != null)
            {
                var path = $"{selectedPath}/{SelectDirs.SelectedItem.ToString()}";
                var res = new DeleteController().Delete(path);
                if (res)
                {
                    Clear();
                    SelectDirsUpdate();
                    MessageBox.Show("Папка удалена!", "Папка удалена!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Что-то пошло не так!", "Ошибка удаления!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                
            }
        }
    }
}
