using System;
using System.IO;

namespace CopyAndRenameObj.BL.Controler
{
    public class DeleteController
    {
        public (bool, string) Delete(string path)
        {
            try
            {
                Directory.Delete(path, true);
                return (true, "Папка удалена!");
            }
            catch (Exception)
            {
                return (false, "Что-то пошло не так!");
            }
        }
    }
}
