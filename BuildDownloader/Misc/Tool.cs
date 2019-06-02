using Newtonsoft.Json;
using System;
using System.IO;

namespace BuildDownloader
{
    public static class Tool
    {

        /// <summary>
        /// Convert JSON string to Class T
        /// </summary>
        /// <typeparam name="T">Class Type</typeparam>
        /// <param name="jsonString"></param>
        /// <returns>Class</returns>
        public static T JsonConvertToClass<T>(string jsonString)
        {
            return (T)JsonConvert.DeserializeObject<T>(jsonString);
        }

        
        /// <summary>
        /// Browse for Folder dialog
        /// </summary>
        /// <param name="defaultFolder">Default folder to browse to</param>
        /// <param name="desc">Title</param>
        /// <returns>Selected folder or Default folder if cancelled</returns>
        public static string BrowseForFolder(string defaultFolder, string desc, bool showNewButton = false)
        {
            if (defaultFolder == null)
            {
                throw new ArgumentNullException(nameof(defaultFolder));
            }

            if (desc == null)
            {
                throw new ArgumentNullException(nameof(desc));
            }

            var folderBrowser = new System.Windows.Forms.FolderBrowserDialog
            {
                Description = desc,
                SelectedPath = defaultFolder,
                ShowNewFolderButton = showNewButton
            };
            if (folderBrowser.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                return folderBrowser.SelectedPath;
            }
            else
            {
                return defaultFolder;
            }
        }

        /// <summary>
        /// Create folder if it does not exist
        /// </summary>
        /// <param name="folder"></param>
        public static void CreateFolder(string folder)
        {
            if (!Directory.Exists(folder))
            {
                Directory.CreateDirectory(folder);
            }
        }
    }
}
