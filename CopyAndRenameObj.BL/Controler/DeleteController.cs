using System;
using System.IO;

namespace CopyAndRenameObj.BL.Controler
{
    public class DeleteController
    {
        public bool Delete(string path)
        {
            try
            {
                Directory.Delete(path, true);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
