using System.IO;
using System.Xml.Serialization;

namespace CopyAndRenameObj.BL.Model
{
    public class SerializeModel : IOptions
    {
        public string Load()
        {
            var formatter = new XmlSerializer(typeof(string));
            var fileName = "defaultdir.xml";

            if (File.Exists(fileName))
            {
                using (var fs = new FileStream(fileName, FileMode.Open))
                {
                    if (fs.Length > 0 && formatter.Deserialize(fs) is string targetPath)
                    {
                        if (Directory.Exists(targetPath))
                            return targetPath;
                        else return "";
                    }
                    else
                    {
                        return "";
                    }
                }
            }
            else
            {
                return "";
            }
        }

        public void Save(string path)
        {
            var formatter = new XmlSerializer(typeof(string));
            var fileName = "defaultdir.xml";

            using (var fs = new FileStream(fileName, FileMode.Create))
            {
                formatter.Serialize(fs, path);
            }
        }
    }
}
