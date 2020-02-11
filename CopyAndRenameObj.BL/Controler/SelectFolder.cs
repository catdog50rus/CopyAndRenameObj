using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Abstractions;
using System.Text;
using System.Threading.Tasks;


namespace CopyAndRenameObj.BL.Controler
{
    public class SelectFolder
    {
        public DirectoryInfo SelectPath { get; set; }
        public List<FileInfo> FilesNamesList { get; set; }
        public List<string> NewFilesNamesList { get; set; }

        readonly List<string> oldFilesNames = new List<string>();
        readonly List<string> newFilesNames = new List<string>();
        string oldDir;
        string newDir;
        
        public string OldName { get; set; }
        public string NewName { get; set; } = null;

        public SelectFolder()
        {
            FilesNamesList = new List<FileInfo>();
            NewFilesNamesList = new List<string>();
            

        }

        public void SetFilesNamesList(string path)
        {
            SelectPath = new DirectoryInfo(path);
            FilesNamesList.AddRange(SelectPath.GetFiles());
            foreach(var file in FilesNamesList)
            {
                oldFilesNames.Add(file.Name);
            }
            oldDir = SelectPath.FullName;
        }

        public bool ChangeFilesNames()
        {
            if (NewName != "" && (OldName != null && OldName != ""))
            {
                for (int i = 0; i < oldFilesNames.Count; i++)
                {
                    newFilesNames.Add(oldFilesNames[i].Contains(OldName) ? oldFilesNames[i].Replace(OldName, NewName) : oldFilesNames[i]);
                }
                NewFilesNamesList.AddRange(newFilesNames);
                newDir = oldDir.Replace(OldName, NewName);
                return true;
            }
            else
            {
                return false;
            }
        }

        public void CopyFiles()
        {
            if(newDir != null)
            {
                var t = Task.Run(() =>
                {
                    for (var i = 0; i < FilesNamesList.Count; i++)
                    {
                        //var currentTargerFolder = Path.Combine(TargetPath, SourceFiles.DirectoriesNeedCopy[i]);
                        if (!Directory.Exists(newDir))
                        {
                            Directory.CreateDirectory(newDir);
                        }

                        File.Copy(FilesNamesList[i].FullName, Path.Combine(newDir, newFilesNames[i]), true);


                    }


                });

                t.Wait();
            }
            
            
        }
    }
}
