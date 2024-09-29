namespace DesignPattern.Controllers.StructuralPatterns
{
    using Microsoft.AspNetCore.Mvc;
    using System.Reflection;
    using System.Xml.Linq;
    using static System.Net.Mime.MediaTypeNames;

    /// <summary>
    /// Composite is a structural design pattern that lets you compose objects into tree structures and then work with these structures as if they were individual objects.
    /// </summary>
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class CompositeController : ControllerBase
    {
        /// <summary>
        /// Pros:
        ///     You can work with complex tree structures more conveniently: use polymorphism and recursion to your advantage.
        ///     Open/Closed Principle.You can introduce new element types into the app without breaking the existing code, which now works with the object tree.
        ///     
        /// Cons:
        ///     It might be difficult to provide a common interface for classes whose functionality differs too much.
        ///         In certain scenarios, you’d need to overgeneralize the component interface, making it harder to comprehend.
        ///         
        /// Reference:
        ///     https://refactoring.guru/design-patterns/composite
        /// </summary>

        private static Dictionary<string, IFileSystem> fileDictionary;

        [HttpPost]
        public IActionResult GetFileAndPaths()
        {
            if (fileDictionary == null)
            {
                GetFileDictionary();
            }

            return Ok(fileDictionary["Root"].Files);
        }

        [HttpPost]
        public IActionResult CountFolderAndFileFromPathWithChildPath(string? path = "Root")
        {
            if (fileDictionary == null)
            {
                GetFileDictionary();
            }

            if (fileDictionary.TryGetValue(path, out var fileSystem))
            {
                return Ok(new { TotalFiles = fileSystem.TotalFiles(), TotalFolder = fileSystem.TotalFolder() - 1 });
            }
            else
            {
                return NotFound();
            }
        }

        private void GetFileDictionary()
        {
            string directloc = Path.GetDirectoryName(Assembly.GetEntryAssembly().Location);

            string[] files = Directory.GetFiles(directloc, "*", SearchOption.AllDirectories);

            fileDictionary = new Dictionary<string, IFileSystem>()
            {
                { "Root", new FolderSystem() { FileName = "Root" } }
            };

            foreach (string file in files)
            {
                var index = 0;
                var pathArr = file.Split("\\");
                var lastPath = pathArr.Last();

                foreach (var x in pathArr)
                {
                    var path = file.Substring(0, index);
                    var systemFilePath = string.IsNullOrEmpty(path) ? "Root" : path;

                    if (fileDictionary.TryGetValue(systemFilePath, out var systemFile))
                    {
                        if (systemFile.Files == null)
                        {
                            systemFile.Files = new List<IFileSystem>();
                        }

                        if (!systemFile.Files.Any(y => y.FileName == x))
                        {
                            IFileSystem newSystemFile = x == lastPath ? new FileSystem() : new FolderSystem();
                            newSystemFile.FileName = x;
                            newSystemFile.Path = systemFilePath;

                            var rootName = string.IsNullOrEmpty(path) ? x : path + "\\" + x;

                            fileDictionary[rootName] = newSystemFile;
                            systemFile.Files.Add(newSystemFile);
                        }
                    }

                    index = file.IndexOf("\\", index + "\\".Length);
                }
            }
        }

        private interface IFileSystem
        {
            public string FileName { get; set; }

            public string Path { get; set; }

            public List<IFileSystem> Files { get; set; }

            public int TotalFiles();

            public int TotalFolder();
        }

        private class FileSystem : IFileSystem
        {
            public string FileName { get; set; }

            public string Path { get; set; }

            public List<IFileSystem> Files { get => null; set => new NotImplementedException(); }

            public int TotalFiles() => 1;

            public int TotalFolder() => 0;
        }

        private class FolderSystem : IFileSystem
        {
            public string FileName { get; set; }

            public string Path { get; set; }

            public List<IFileSystem> Files { get; set; }

            public int TotalFiles()
            {
                var count = 0;

                Files?.ForEach(f => count += f.TotalFiles());

                return count;
            }

            public int TotalFolder()
            {
                var count = 1;

                Files?.ForEach(f => count += f.TotalFolder());

                return count;
            }
        }
    }
}
