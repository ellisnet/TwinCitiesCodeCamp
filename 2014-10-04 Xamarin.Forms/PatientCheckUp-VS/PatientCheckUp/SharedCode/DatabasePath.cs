using System;
using Portable.Data.Sqlite;

[assembly: Xamarin.Forms.Dependency (typeof(DatabasePath))]
public class DatabasePath : IDatabasePath
{
    public DatabasePath () { }

    public string GetPath (string databaseName)
    {
#if __ANDROID__
    	//Android code:
        string libraryPath = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);
        return System.IO.Path.Combine(libraryPath, databaseName);
#endif

#if __IOS__
        //iOS code:
        string documentsPath = Environment.GetFolderPath(Environment.SpecialFolder.Personal); // Documents folder
        string libraryPath = System.IO.Path.Combine(documentsPath, "..", "Library"); // Library folder
        return System.IO.Path.Combine(libraryPath, databaseName);
#endif
   
    }
}