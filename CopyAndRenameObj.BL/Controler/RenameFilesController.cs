using CopyAndRenameObj.BL.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace CopyAndRenameObj.BL.Controler
{
    public class RenameFilesController
    {
        private readonly FolderModel folderModel;

        public RenameFilesController(FolderController fc)
        {
            folderModel = fc.GetFolderModel();
        }

        public bool ChangeFilesNames(string selectString, string newString)
        {
            bool flag = false;
            folderModel.NewFilesNamesList.Clear();
            if (newString != "" && (selectString != null && selectString != ""))
            {
                for (int i = 0; i < folderModel.OldFilesNamesList.Count; i++)
                {
                    if (folderModel.OldFilesNamesList[i].Contains(selectString))
                    {
                        folderModel.NewFilesNamesList.Add(folderModel.OldFilesNamesList[i].Replace(selectString, newString));
                        flag = true;
                    }
                    else
                    {
                        folderModel.NewFilesNamesList.Add(folderModel.OldFilesNamesList[i]);
                    }
                    
                }
                folderModel.NewDirectory = folderModel.SelectDirectory.Replace(selectString, newString);
                if (flag)
                {
                    return true;
                }
                return false;
            }
            return false;
        }
    }
}
