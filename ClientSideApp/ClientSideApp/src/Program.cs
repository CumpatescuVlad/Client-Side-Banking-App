using Syncfusion.Licensing;
namespace ClientSideApp
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();
            SyncfusionLicenseProvider.RegisterLicense("NzcxNDQ0QDMyMzAyZTMzMmUzMFhjbTNwdnNTNGQ4TmlEV3A3SjZxSHNQaDhlSWlSNDBmRHBtZkJkSisvclk9");
            Directory.CreateDirectory(Temp.FolderPath);
            Temp.CreateFile("Count.txt", $"{0}");
            Temp.CreateFile("Readme.txt", @"This is the folder whre your credentials are stored , do not delete!! 
            Otherwise You Will be needed to activate the app again.");
            Application.Run(new Form1());
        }
    }
}