namespace ClientSideApp;

internal class Temp
{

    private static string _folderPath = $@"C:\Users\{Environment.UserName}\Documents\Bank App";

    private static string _tokenFolder = $@"C:\Users\{Environment.UserName}\Documents\Token";

    public static string TokenFolder { get => _tokenFolder; }

    public static string FolderPath { get => _folderPath; }

    public static void CreateFile(string file, string content) => File.WriteAllText($@"C:\Users\{Environment.UserName}\Documents\Bank App\{file}", content);

    public static string ReadFile(string file) => File.ReadAllText($@"C:\Users\{Environment.UserName}\Documents\Bank App\{file}");

    public static string ReadTokenFiles(string file) => File.ReadAllText($@"{TokenFolder}\{file}");

    public static void DisposeFile(string path) => File.Delete($@"{FolderPath}\{path}");
}

