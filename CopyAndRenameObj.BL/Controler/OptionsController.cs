using CopyAndRenameObj.BL.Model;

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
