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
        /// <returns>Метод возвращает true, если копирование файлов прошло успешно или false, если произошла ошибка</returns>
        public (bool, string) CopyFiles()
        {
            if (folderModel.NewDirectory != null)
            {
                //Создаем директорию
                if (!Directory.Exists(folderModel.NewDirectory))
                {
                    Directory.CreateDirectory(folderModel.NewDirectory);
                }
                
                try
                {
                    //Создаем задачу по копированию
                    var t = Task.Run(() =>
                    {
                        
                        for (var i = 0; i < folderModel.SelectFolderFilesList.Count; i++) //Копируем по одному файлу
                        {
                             File.Copy(folderModel.SelectFolderFilesList[i].FullName,
                                       Path.Combine(folderModel.NewDirectory, folderModel.NewFilesNamesList[i]), true);
                      
                        }
                    });
                    //Ожидаем завершения выполнения задачи и возвращаем результат
                    t.Wait();
                    return (true, "Копирование успешно завершено!");
                }
                catch (System.Exception)
                {

                    return(false, "Что-то пошло не так!");
                }
                
                
                
            }
            else return (false, "Что-то пошло не так!");
        }
    } 
}
