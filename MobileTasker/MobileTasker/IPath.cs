using System;
using System.Collections.Generic;
using System.Text;

namespace MobileTasker
{
    public interface IPath
    {
        string GetDatabasePath(string filename);
    }
}
