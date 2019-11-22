using System;
using System.IO;
using Xamarin.Forms;
using MobileTasker.Droid;

[assembly: Dependency(typeof(AndroidDbPath))]
namespace MobileTasker.Droid
{
    class AndroidDbPath : IPath
    {
        public string GetDatabasePath(string filename)
        {
            return Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Personal), filename);
        }
    }
}