using System;
using System.Collections.Generic;
using System.Text;

namespace CopyAndRenameObj.BL.Model
{
    interface IOptions
    {
        void Save(string path);

        string Load();
    }
}
