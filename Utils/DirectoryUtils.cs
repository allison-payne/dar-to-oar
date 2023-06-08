namespace DARtoOAR.Utils
{
    internal class DirectoryUtils
    {
        public static void CopyDirectory(DirectoryInfo sourceDir, DirectoryInfo destinationDir, bool recursive)
        {

            // Check if the source directory exists
            if (!sourceDir.Exists)
                throw new DirectoryNotFoundException($"Source directory not found: {sourceDir.FullName}");

            // Cache directories before we start copying
            DirectoryInfo[] dirs = sourceDir.GetDirectories();

            // Create the destination directory
            Directory.CreateDirectory(destinationDir.FullName);

            // Get the files in the source directory and copy to the destination directory
            foreach (FileInfo file in sourceDir.GetFiles())
            {
                string targetFilePath = Path.Combine(destinationDir.FullName, file.Name);
                file.CopyTo(targetFilePath, true);
            }

            // If recursive and copying subdirectories, recursively call this method
            if (recursive)
            {
                foreach (DirectoryInfo subDir in dirs)
                {
                    string newDestinationDir = Path.Combine(destinationDir.FullName, subDir.Name);
                    CopyDirectory(subDir, new DirectoryInfo(newDestinationDir), true);
                }
            }
        }
    }
}
