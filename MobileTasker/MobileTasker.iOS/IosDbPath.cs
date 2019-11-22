using System;
using Xamarin.Forms;
using System.IO;
using MobileTasker.iOS;

[assembly: Dependency(typeof(IosDbPath))]
namespace MobileTasker.iOS
{
    class IosDbPath : IPath
    {
        public string GetDatabasePath(string sqliteFilename)
        {
            return Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "..", "Library", sqliteFilename);
        }
    }
}