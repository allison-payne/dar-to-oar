namespace DARtoOAR.Utils
{
    internal class DirectoryUtils
    {
        public static void CopyDirectory(DirectoryInfo sourceDir, DirectoryInfo destinationDir, bool overwrite, bool recursive = false)
        {
            if (!sourceDir.Exists)
                throw new DirectoryNotFoundException($"Source directory not found: {sourceDir.FullName}");

            DirectoryInfo[] dirs = sourceDir.GetDirectories();
            Directory.CreateDirectory(destinationDir.FullName);

            foreach (FileInfo file in sourceDir.GetFiles())
            {
                string targetFilePath = Path.Combine(destinationDir.FullName, file.Name);
                file.CopyTo(targetFilePath, overwrite);
            }

            if (recursive)
            {
                foreach (DirectoryInfo subDir in dirs)
                {
                    string newDestinationDir = Path.Combine(destinationDir.FullName, subDir.Name);
                    CopyDirectory(subDir, new DirectoryInfo(newDestinationDir), true, true);
                }
            }
        }
    }
}
