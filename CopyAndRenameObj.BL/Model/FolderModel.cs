using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace CopyAndRenameObj.BL.Model
{
    class FolderModel
    {
        public List<FileInfo> SelectFolderFilesList { get; set; }
        public List<string> OldFilesNamesList { get; set; }
        public List<string> NewFilesNamesList { get; set; }
        public string NewDirectory { get; set; }

        public FolderModel()
        {
            SelectFolderFilesList = new List<FileInfo>();
            OldFilesNamesList = new List<string>();
            NewFilesNamesList = new List<string>();
        }
    }
}
