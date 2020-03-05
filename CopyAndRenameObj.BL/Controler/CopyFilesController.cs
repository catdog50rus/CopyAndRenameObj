using CopyAndRenameObj.BL.Model;
using System.IO;
using System.Threading.Tasks;

namespace CopyAndRenameObj.BL.Controler
{
    public class CopyFilesController
    {
        private readonly FolderModel folderModel;
        public CopyFilesController(FolderController fc)
        {
            folderModel = fc.GetFolderModel();
        }

        /// <summary>
        /// Метод копирует файлы из выбранного каталога в новый
        /// </summary>
        /// <returns>Метод возвращает true, если копирование файлой прошло успешно или false, если произошла ошибка</returns>
        public bool CopyFiles()
        {
            if (folderModel.NewDirectory != null)
            {
                //Создаем директорию
                if (!Directory.Exists(folderModel.NewDirectory))
                {
                    Directory.CreateDirectory(folderModel.NewDirectory);
                }
                //Создаем задачу по копированию
                var t = Task.Run(() =>
                {
                    //Копируем по-файлово
                    for (var i = 0; i < folderModel.SelectFolderFilesList.Count; i++)
                    {
                        File.Copy(
                            folderModel.SelectFolderFilesList[i].FullName,
                            Path.Combine(folderModel.NewDirectory, folderModel.NewFilesNamesList[i]), true);
                    }
                });
                //Ожидаем завершения выполнения задачи и возвращаем результат
                t.Wait();
                return true;
            }
            else return false;
        }
    } 
}
