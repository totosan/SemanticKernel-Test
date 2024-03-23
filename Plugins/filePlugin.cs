using System.ComponentModel;
using Microsoft.SemanticKernel;

namespace Plugins
{
    public class FilePlugin 
    {
        [KernelFunction, Description("The path of the file to read")]
        public string ReadFile([Description("the filename with the current or given path")]string path) => System.IO.File.ReadAllText(path);

        [KernelFunction, Description("Create a file with the given content")]        
        public void WriteFile(
            [Description("path of the file")]string path, 
            [Description("The content, that should be written to the file")]string content
            ) => System.IO.File.WriteAllText(path, content);

        [KernelFunction, Description("Append content to a file")]
        public void AppendFile(
            [Description("the path of the file")] string path,
            [Description("The content that will be appended to the file")] string content) => System.IO.File.AppendAllText(path, content);

        [KernelFunction, Description("Delete a file")]
        public void DeleteFile([Description("path of the file, that is to be deleted")]string path) => System.IO.File.Delete(path);

    }
}