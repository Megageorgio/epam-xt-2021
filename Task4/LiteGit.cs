using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;

namespace Task4
{
    public class LiteGit
    {
        private const string BackupDirName = ".litegit";
        private const string BackupFileName = "backup.json";

        public LiteGit(string directory)
        {
            MainDirectory = new DirectoryInfo(directory);
            if (!MainDirectory.Exists)
            {
                throw new DirectoryNotFoundException();
            }

            BackupDirectory = new DirectoryInfo(Path.Combine(MainDirectory.FullName, BackupDirName));
            if (!BackupDirectory.Exists)
            {
                BackupDirectory.Create();
                BackupDirectory.Attributes |= FileAttributes.Hidden;
            }

            var backupFile = new FileInfo(Path.Combine(BackupDirectory.FullName, BackupFileName));
            if (backupFile.Exists)
            {
                Changes = JsonSerializer.Deserialize<ICollection<ChangeInfo>>(File.ReadAllText(backupFile.FullName));
            }
            else
            {
                Changes = new List<ChangeInfo>();
            }

            RecursiveAddFilePaths(MainDirectory);
        }

        private DirectoryInfo BackupDirectory { get; }
        private ICollection<ChangeInfo> Changes { get; }
        private ICollection<string> FilePaths { get; } = new List<string>();
        private DirectoryInfo MainDirectory { get; }
        private IEnumerable<string> Whitelist => new[] {".txt"};

        public void Rollback(DateTime rollbackDate)
        {
            foreach (var subFile in MainDirectory.GetFiles())
            {
                subFile.Delete();
            }

            foreach (var subDir in MainDirectory.GetDirectories())
            {
                if (subDir.Name == BackupDirName)
                {
                    continue;
                }

                subDir.Delete();
            }

            foreach (var change in Changes
                .Where(change => change.Date <= rollbackDate)
                .GroupBy(change => change.OriginalPath)
                .Select(changeGroup => changeGroup.LastOrDefault()))
            {
                if (change.Type is ChangeType.Add or ChangeType.Modify)
                {
                    var path = Path.Combine(MainDirectory.FullName, change.OriginalPath);
                    var backupPath = Path.Combine(BackupDirectory.FullName, change.BackupPath);
                    Directory.CreateDirectory(Path.GetDirectoryName(path));
                    File.Copy(backupPath, path);
                }
            }
        }

        public override string ToString() =>
            string.Join(Environment.NewLine,
                Changes.Select(change => $"[{change.Date:dd.MM.yyyy hh:mm:ss}] {change.Type}: {change.OriginalPath}"));

        public void Watch()
        {
            var watcher = new FileSystemWatcher(MainDirectory.FullName)
                {IncludeSubdirectories = true, EnableRaisingEvents = true};
            watcher.Deleted += OnDelete;
            watcher.Renamed += OnRenamed;
            watcher.Changed += OnChanged;
            watcher.Created += OnCreate;
        }

        private string BackupFile(string path)
        {
            var backupPath = Path.Combine(BackupDirectory.FullName, Path.GetRandomFileName().Replace(".", ""));
            File.Copy(path, backupPath);
            return backupPath;
        }

        private void OnChanged(object sender, FileSystemEventArgs e)
        {
            SaveChange(e.FullPath, ChangeType.Modify);
        }

        private void OnCreate(object sender, FileSystemEventArgs e)
        {
            FilePaths.Add(e.FullPath);
            SaveChange(e.FullPath, ChangeType.Add);
        }

        private void OnDelete(object sender, FileSystemEventArgs e)
        {
            SaveChange(e.FullPath, ChangeType.Delete);
        }

        private void OnRenamed(object sender, RenamedEventArgs e)
        {
            SaveChange(e.OldFullPath, ChangeType.Delete);
            SaveChange(e.FullPath, ChangeType.Add);
        }

        private void RecursiveAddFilePaths(DirectoryInfo directory)
        {
            foreach (var subFile in directory.GetFiles())
            {
                FilePaths.Add(subFile.FullName);
            }

            foreach (var subDir in directory.GetDirectories())
            {
                if (subDir.Name is not BackupDirName)
                {
                    RecursiveAddFilePaths(subDir);
                }
            }
        }

        private void SaveChange(string path, ChangeType type)
        {
            if (Directory.Exists(path))
            {
                foreach (var subPath in Directory.GetFileSystemEntries(path))
                {
                    SaveChange(subPath, type);
                }

                return;
            }

            if (type is ChangeType.Delete)
            {
                var isDirectory = false;
                if (!FilePaths.Contains(path))
                {
                    isDirectory = true;
                }

                foreach (var filePath in FilePaths.Where(filePath =>
                    filePath.Contains(path + Path.DirectorySeparatorChar)))
                {
                    isDirectory = true;
                    SaveChange(filePath, ChangeType.Delete);
                }

                if (isDirectory)
                {
                    return;
                }
            }

            if (!Whitelist.Contains(Path.GetExtension(path)))
            {
                return;
            }

            string backupPath = null;
            if (type is ChangeType.Add or ChangeType.Modify)
            {
                backupPath = BackupFile(path).Replace(BackupDirectory.FullName + Path.DirectorySeparatorChar, "");
            }

            path = path.Replace(MainDirectory.FullName + Path.DirectorySeparatorChar, "");
            Changes.Add(new ChangeInfo(type, DateTime.Now, path, backupPath));
            UpdateBackupList();
        }

        private void UpdateBackupList() => File.WriteAllText(Path.Combine(BackupDirectory.FullName, BackupFileName),
            JsonSerializer.Serialize(Changes));
    }
}