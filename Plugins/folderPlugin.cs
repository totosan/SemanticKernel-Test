using System.ComponentModel;
using Microsoft.SemanticKernel;

namespace Plugins
{
    public class FolderPlugin 
    {
        [KernelFunction, Description("Create a folder")]
        public void CreateFolder([Description("The path of the folder to create")]string path) => System.IO.Directory.CreateDirectory(path);

        [KernelFunction, Description("Delete a folder")]
        public void DeleteFolder([Description("The path of the folder to delete")]string path) => System.IO.Directory.Delete(path, true);

        [KernelFunction, Description("Check if a folder exists")]
        public bool FolderExists([Description("The path of the folder to check")]string path) => System.IO.Directory.Exists(path);

        [KernelFunction, Description("Get the files in a folder")]
        public string[] GetFiles([Description("The path of the folder to get the files from")]string path) => System.IO.Directory.GetFiles(path);

        [KernelFunction, Description("Get the directories in a folder")]
        public string[] GetDirectories([Description("The path of the folder to get the directories from")]string path) => System.IO.Directory.GetDirectories(path);

    }
}