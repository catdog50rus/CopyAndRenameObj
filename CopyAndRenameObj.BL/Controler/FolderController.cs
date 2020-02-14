using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using CopyAndRenameObj.BL.Model;

namespace CopyAndRenameObj.BL.Controler
{
    public class FolderController
    {
        private readonly FolderModel folderModel;
        
        private string selectDir;
        private string newDir;
        
        public FolderController()
        {
            folderModel = new FolderModel();
        }


        public void SetSelectDir(string path)
        {
            DirectoryInfo selectPath = new DirectoryInfo(path);
            folderModel.SelectFolderFilesList.AddRange(selectPath.GetFiles());
            foreach (var file in folderModel.SelectFolderFilesList)
            {
                folderModel.OldFilesNamesList.Add(file.Name);
            }
            selectDir = selectPath.FullName;
        }

        public List<FileInfo> GetSelectFoldersFilesNamesList()
        {
            return folderModel.SelectFolderFilesList;
        }

        public bool ChangeFilesNames(string selectString, string newString)
        {
            folderModel.NewFilesNamesList.Clear();
            if (newString != "" && (selectString != null && selectString != ""))
            {
                for (int i = 0; i < folderModel.OldFilesNamesList.Count; i++)
                {
                    folderModel.NewFilesNamesList.Add(folderModel.OldFilesNamesList[i].Contains(selectString) ?
                        folderModel.OldFilesNamesList[i].Replace(selectString, newString) : folderModel.OldFilesNamesList[i]);
                }

                newDir = selectDir.Replace(selectString, newString);
                return true;
            }
            else
            {
                return false;
            }
        }

        public List<string> GetNewFilesNamesList()
        {
            return folderModel.NewFilesNamesList;
        }

        public bool CopyFiles()
        {
            if (newDir != null)
            {
                if (!Directory.Exists(newDir))
                {
                    Directory.CreateDirectory(newDir);
                }

                var t = Task.Run(() =>
                {
                    for (var i = 0; i < folderModel.SelectFolderFilesList.Count; i++)
                    {
                        File.Copy(folderModel.SelectFolderFilesList[i].FullName,
                            Path.Combine(newDir, folderModel.NewFilesNamesList[i]), true);
                    }
                });

                t.Wait();

                return true;
            }
            else return false;
        }
    }
}
