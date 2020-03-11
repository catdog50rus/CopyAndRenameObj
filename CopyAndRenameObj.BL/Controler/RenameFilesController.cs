using CopyAndRenameObj.BL.Model;
using System.Collections.Generic;

namespace CopyAndRenameObj.BL.Controler
{
    public class RenameFilesController
    {
        private readonly FolderModel folderModel;

        public RenameFilesController(FolderController fc)
        {
            folderModel = fc.GetFolderModel();
        }

        /// <summary>
        /// Метод меняет имена файлов. Возвращает true, если изменено хотя бы одно имя или false если таких не найдено.
        /// </summary>
        /// <param name="selectString">искомая строка в имени файла</param>
        /// <param name="newString">новая строка в имени файла</param>
        /// <returns></returns>
        public bool ChangeFilesNames(string selectString, string newString)
        {
            folderModel.NewFilesNamesList.Clear();
            if (newString != "" && (selectString != null && selectString != ""))
            {
                //создаем временный список и заполняем его именами фалов, содержащих искомую строку
                var arr = new List<string>();
                arr.AddRange(folderModel.OldFilesNamesList.FindAll(el => el.Contains(selectString)));
                //проверяем, есть ли в списке хоть один элемент
                if(arr.Count != 0)
                {
                    //заполняем список новых имен файлов
                    foreach (var item in arr)
                    {
                        folderModel.NewFilesNamesList.Add(item.Replace(selectString, newString));
                    }
                    //добавляем неизменяемые файлы
                    folderModel.NewFilesNamesList.AddRange(folderModel.OldFilesNamesList.FindAll(el => !el.Contains(selectString)));
                    //переименовываем директорию
                    folderModel.NewDirectory = folderModel.SelectDirectory.Replace(selectString, newString);
                    return true;
                }
                return false;
            }
            return false;
        }
    }
}
