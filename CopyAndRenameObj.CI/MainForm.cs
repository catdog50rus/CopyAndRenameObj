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
            
            Clear(); //Блокируем интерфейс
            
            LoadPath();//Пробуем загрузить расположение папки с MSTS

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

        /// <summary>
        /// Обработчик нажатия кнопки "Заменить"
        /// </summary>
        private void ButtonRename_Click(object sender, EventArgs e)
        {
            if(textNew.Text != textOld.Text) //Проверяем, что есть что менять
            {
                //Создаем контроллер и вызываем метод переименования файлов и директории
                var result = new RenameFilesController(controller).ChangeFilesNames(textOld.Text, textNew.Text);
                if (result.Item1) // Если все прошло удачно, обновляем списки и активируем кнопку
                {
                    ListNewUpdate();
                    buttonCopy.Enabled = true;
                }
                else // Иначе выводим сообщение об ошибке
                {
                    GetMessageBoxErr(result.Item2) ;
                    buttonCopy.Enabled = false;
                }
            } 
            else
            {
                GetMessageBoxErr("Не указан, что меняется в файлах!");
                buttonCopy.Enabled = false;
            }
        }

        private void ButtonCopy_Click(object sender, EventArgs e)
        {
            //Создаем контроллер, передаем в него модель и вызываем метод копирования файлов
            //По результату выводим сообщение и очищаем списки
            var result = new CopyFilesController(controller).CopyFiles(); 
            
            if (result.Item1)
            {
                SelectDirsUpdate();
                listViewNew.Items.Clear();
                GetMessageBoxErr(result.Item2);
            }
            else
            {
                GetMessageBoxErr(result.Item2);
            }
           
        }
        #endregion

        #region Обработка выбора директории
        private void SelectDirs_DoubleClick(object sender, EventArgs e)
        {
            if (SelectDirs.SelectedItem != null) // Если пользователь выбрал папку для изменения
            {
                var path = $"{selectedPath}/{SelectDirs.SelectedItem}";
                controller = new FolderController(); //Создаем контроллер
                controller.SetSelectDir(@path); //Передаем в контроллер выбранную папку
                //
                ListFoldersUpdate(); // ОБновляем списки с файлами в выбранной папке
                textOld.Enabled = true; // Активируем поле для ввода меняемой части
            }
        }
        #endregion

        #region Обновление списков
        /// <summary>
        /// Обновления списка файлов в выбранной директории
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
            //заполняем список названиями директорий в выбранной папке
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
            DialogResult result = SelectFolderDialog.ShowDialog(); //Открываем диалоговое окно выбора директории
            if (result == DialogResult.OK) //Если пользователь выбрал директорию
            {
                var path = SelectFolderDialog.SelectedPath; //Получаем путь к выбранной директории
                OptionsController.SetPath(path); //Пытаемся записать путь к MSTS в конфигурационный файл
                LoadPath(); // Пробуем получить путь к МСТС
                
            }
            
        }

        
        private void ButtonDel_Click(object sender, EventArgs e)
        {
            if (SelectDirs.SelectedItem != null) //Если существует элемент
            {
                var path = $"{selectedPath}/{SelectDirs.SelectedItem}"; //Получаем путь
                var result = new DeleteController().Delete(path); //Создаем контроллер, пытаемся удалить папку, получаем результат
                if (result.Item1)
                {
                    Clear();
                    SelectDirsUpdate();
                    GetMessageBoxErr(result.Item2);
                }
                else
                {
                    GetMessageBoxErr(result.Item2);
                }
                
            }
        }

        private void GetMessageBoxErr(string message)
        {
            MessageBox.Show(message, "Внимание!", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        /// <summary>
        /// Метод получает путь к МСТС
        /// </summary>
        private void LoadPath()
        {
            var result = OptionsController.GetPath(); //Получаем путь
            if (result.Item1) //Если удачно
            {
                selectedPath = result.Item2; //Присваиваем путь  переменную
                SelectDirsUpdate(); //Обновляем список папок
            }
            else
            {
                GetMessageBoxErr(result.Item2);
            }
        }

    }
}
