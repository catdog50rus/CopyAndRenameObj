namespace CopyAndRenameObj.BL.Model
{
    interface IOptions
    {
        void Save(string path);

        string Load();
    }
}
