namespace Token.UnderTheHood
{
    public static class Temp
    {
        private static string _folderPath = $@"C:\Users\{Environment.UserName}\Documents\Temp";

        public static string FolderPath { get => _folderPath; }

        public static void CreateFile(string file, string content) => File.WriteAllText($@"C:\Users\{Environment.UserName}\Documents\Temp\{file}", content);
        public static string ReadFile(string file) => File.ReadAllText($@"C:\Users\{Environment.UserName}\Documents\Temp\{file}");
        public static void DisposeFile(string path) => File.Delete($@"{FolderPath}\{path}");


    }
}
