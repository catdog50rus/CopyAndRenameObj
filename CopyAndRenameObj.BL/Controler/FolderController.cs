using System.Collections.Generic;
using System.IO;
using CopyAndRenameObj.BL.Model;

namespace CopyAndRenameObj.BL.Controler
{
    public class FolderController
    {
        #region Поля
        private readonly FolderModel folderModel;
        #endregion

        #region Конструктор
        /// <summary>
        /// В конструкторе создаем экземпляр модели.
        /// </summary>
        public FolderController()
        {
            folderModel = new FolderModel();
            
        }
        #endregion
        
        #region Методы
        /// <summary>
        /// Метод для обработки выбранного каталога
        /// </summary>
        /// <param name="path">В метод передаем путь к выбранной папке</param>
        public void SetSelectDir(string path)
        {
            //создаем экземпляр класса DirectoryInfo
            var selectPath = new DirectoryInfo(path);

            //передаем в модель коллекцию файлов в выбранном каталоге
            folderModel.SelectFolderFilesList.AddRange(selectPath.GetFiles());
            
            //добавляем в модель коллекцию имен файлов
            foreach (var file in folderModel.SelectFolderFilesList)
            {
                folderModel.OldFilesNamesList.Add(file.Name);
            }
            //передаем в модель наименование выбранного каталога
            folderModel.SelectDirectory = selectPath.FullName;
        }

        /// <summary>
        /// Метод для получения из модели списка файлов
        /// </summary>
        /// <returns>Метод для получения из модели списка файлов</returns>
        public List<FileInfo> GetSelectFoldersFilesNamesList()
        {
            return folderModel.SelectFolderFilesList;  
        }

        /// <summary>
        /// Метод для получения списка файлов с новыми именами
        /// </summary>
        /// <returns>Метод возвращает список файлов с новыми именами</returns>
        public List<string> GetNewFilesNamesList()
        {
            return folderModel.NewFilesNamesList;

        }

        /// <summary>
        /// Возвращает Модель
        /// </summary>
        /// <returns></returns>
        public FolderModel GetFolderModel()
        {
            return folderModel;
        }
        #endregion
    }
}
