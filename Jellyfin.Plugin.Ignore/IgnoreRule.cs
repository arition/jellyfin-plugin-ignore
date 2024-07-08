using System;
using System.IO;
using MediaBrowser.Controller.Entities;
using MediaBrowser.Controller.Resolvers;
using MediaBrowser.Model.IO;

namespace Jellyfin.Plugin.Ignore
{
    /// <summary>
    /// Resolver rule class for ignoring files.
    /// </summary>
    public class IgnoreRule : IResolverIgnoreRule
    {
        private FileInfo? FindIgnoreFile(DirectoryInfo directory)
        {
            var ignoreFile = new FileInfo(Path.Join(directory.FullName, ".jellyfinignore"));
            if (ignoreFile.Exists)
            {
                return ignoreFile;
            }

            var parentDir = directory.Parent;
            if (parentDir == null || parentDir.FullName == directory.FullName)
            {
                return null;
            }

            return FindIgnoreFile(parentDir);
        }

        /// <inheritdoc />
        public bool ShouldIgnore(FileSystemMetadata fileInfo, BaseItem? parent)
        {
            var parentDirPath = Path.GetDirectoryName(fileInfo.FullName);
            if (string.IsNullOrEmpty(parentDirPath))
            {
                return false;
            }

            var folder = new DirectoryInfo(parentDirPath);
            var ignoreFile = FindIgnoreFile(folder);
            if (ignoreFile == null)
            {
                return false;
            }

            string ignoreFileString;
            using (var reader = ignoreFile.OpenText())
            {
                ignoreFileString = reader.ReadToEnd();
            }

            var ignoreRules = ignoreFileString.Split("\n", StringSplitOptions.RemoveEmptyEntries);
            var ignore = new global::Ignore.Ignore();
            ignore.Add(ignoreRules);

            return ignore.IsIgnored(fileInfo.FullName);
        }
    }
}
