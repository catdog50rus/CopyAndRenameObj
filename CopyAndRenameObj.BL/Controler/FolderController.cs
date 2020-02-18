using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using CopyAndRenameObj.BL.Model;

namespace CopyAndRenameObj.BL.Controler
{
    public class FolderController
    {
        private readonly FolderModel folderModel;
        private DirectoryInfo selectPath;

        private string selectDir;
        private string newDir;

        /// <summary>
        /// В конструкторе создаем экземпляр модели.
        /// </summary>
        public FolderController()
        {
            folderModel = new FolderModel();
        }


        /// <summary>
        /// Метод для обработки выбранного каталога
        /// </summary>
        /// <param name="path">В метод передаем путь к выбранной папке</param>
        public void SetSelectDir(string path)
        {
            //создаем экземпляр класса DirectoryInfo
            selectPath = new DirectoryInfo(path);
            //передаем в модель коллекцию файлов в выбранном каталоге
            folderModel.SelectFolderFilesList.AddRange(selectPath.GetFiles());
            //перебираем в модель коллекцию имен файлов
            foreach (var file in folderModel.SelectFolderFilesList)
            {
                folderModel.OldFilesNamesList.Add(file.Name);
            }
            //передаем в модель наименование выбранного каталога
            selectDir = selectPath.FullName;
        }


        /// <summary>
        /// Метод для получения из модели списка файлов
        /// </summary>
        /// <returns>Метод для получения из модели списка файлов</returns>
        public List<FileInfo> GetSelectFoldersFilesNamesList()
        {
            return folderModel.SelectFolderFilesList;  
        }

        public bool ChangeFilesNames(string selectString, string newString)
        {
            folderModel.NewFilesNamesList.Clear();
            if (newString != "" && (selectString != null && selectString != ""))
            {
                for (int i = 0; i < folderModel.OldFilesNamesList.Count; i++)
                {
                    folderModel.NewFilesNamesList.Add(folderModel.OldFilesNamesList[i].Contains(selectString) ?
                        folderModel.OldFilesNamesList[i].Replace(selectString, newString) : folderModel.OldFilesNamesList[i]);
                }

                newDir = selectDir.Replace(selectString, newString);
                
                for(int i = 0; i < folderModel.OldFilesNamesList.Count; i++)
                {
                    if (folderModel.NewFilesNamesList[i] != folderModel.OldFilesNamesList[i])
                    {
                        return true;
                    }
                    
                }
                return false;
            }
            else
            {
                return false;
            }
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
        /// Метод копирует файлы из выбранного каталога в новый
        /// </summary>
        /// <returns>Метод возвращает true, если копирование файлой прошло успешно или false, если произошла ошибка</returns>
        public bool CopyFiles()
        {
            if (newDir != null)
            {
                if (!Directory.Exists(newDir))
                {
                    Directory.CreateDirectory(newDir);
                }

                var t = Task.Run(() =>
                {
                    for (var i = 0; i < folderModel.SelectFolderFilesList.Count; i++)
                    {
                        File.Copy(folderModel.SelectFolderFilesList[i].FullName,
                            Path.Combine(newDir, folderModel.NewFilesNamesList[i]), true);
                    }
                });

                t.Wait();

                return true;
            }
            else return false;
        }
    }
}
