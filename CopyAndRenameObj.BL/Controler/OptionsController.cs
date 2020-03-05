using CopyAndRenameObj.BL.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace CopyAndRenameObj.BL.Controler
{
    public class OptionsController : IOptions
    {
        private readonly SerializeModel model;

        public OptionsController()
        {
            model = new SerializeModel();
        }
        
        public string Load()
        {
            return model.Load();
        }

        public void Save(string path)
        {
            model.Save(path);
        }
    }
}
