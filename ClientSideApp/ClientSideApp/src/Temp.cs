namespace ClientSideApp;

internal class Temp
{

    private static string _folderPath = $@"C:\Users\{Environment.UserName}\Documents\Bank App";

    public static string FolderPath { get => _folderPath; }

    public static void CreateFile(string file, string content) => File.WriteAllText($@"C:\Users\{Environment.UserName}\Documents\Bank App\{file}", content);

    public static string ReadFile(string file) => File.ReadAllText($@"C:\Users\{Environment.UserName}\Documents\Bank App\{file}");

    public static void DisposeFile(string path) => File.Delete($@"{FolderPath}\{path}");
}

