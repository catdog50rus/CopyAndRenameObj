using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace CopyAndRenameObj.BL.Controler
{
    public class DeleteController
    {
        private readonly string path;

        public DeleteController(string path)
        {
            this.path = path;
            Delete(path);
        }
        
        public void Delete(string path)
        {
            try
            {
                Directory.Delete(path, true);
            }
            catch (Exception)
            {
                var subdirs = Directory.GetDirectories(path);
                Delete(subdirs[0]);
            }
            if (Directory.Exists(this.path))
            {
                Directory.Delete(this.path);
            }
        }
    }
}
