namespace Token.BackEndComponents
{
    public static class Temp
    {
        private static string _folderPath = $@"{Environment.CurrentDirectory}";

        private static string _tokenFolder = $@"C:Users\{Environment.UserName}\Documents\Token";
        public static string FolderPath { get => _folderPath; }
        public static string TokenFolder { get => _tokenFolder; }
        public static void CreateFile(string file, string content) => File.WriteAllText($@"{FolderPath}\{file}", content);
        public static string ReadFile(string file) => File.ReadAllText($@"{FolderPath}\{file}");
        public static void DisposeFile(string file) => File.Delete($@"{FolderPath}\{file}");
        public static void CopyFile(string file) => File.Copy($@"{FolderPath}\{file}", $@"{TokenFolder}\CustomerData.json",true);

    }
}
