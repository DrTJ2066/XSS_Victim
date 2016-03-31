using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace RoyaMVC_EN.Models
{
    public class DirectoryData
    {
        public string FolderName { get; set; }
        public string FolderPath { get; set; }
        public string IconPath { get; set; }
        public string ParentFolderPath { get; set; }
        public List<DirectoryData> Folders { get; set; }
        public List<FileData> Files { get; set; }

        public DirectoryData(string path, int deepLevel, bool encryptPath = false, string encryptionSalt = "") {
            var directories = Directory.GetDirectories(path);
            var files = Directory.GetFiles(path);
            var dir = new DirectoryInfo(path);

            this.FolderName = dir.Name;
            this.FolderPath = (encryptPath) ? RoyaSecurity.Cryptography.Crypto.EncryptStringAES(dir.FullName, encryptionSalt) : dir.FullName;
            this.IconPath = "";
            this.ParentFolderPath = (encryptPath) ? RoyaSecurity.Cryptography.Crypto.EncryptStringAES(dir.Parent.FullName, encryptionSalt) : dir.Parent.FullName;

            this.Files = FileData.Parse(files, encryptPath, encryptionSalt);

            if (deepLevel != 0)
                this.Folders = ParseDirectories(directories, --deepLevel, encryptPath, encryptionSalt);
        }

        public static List<DirectoryData> ParseDirectories(string[] foldersList, int deepLevel, bool encryptPath = false, string encryptionSalt = "") {
            var res = new List<DirectoryData>();

            foreach (var item in foldersList) {
                res.Add(new DirectoryData(item, deepLevel, encryptPath, encryptionSalt));
            }

            return res;
        }
    }

    public class FileData
    {
        public string FileName { get; set; }
        public string Extension { get; set; }
        public string IconPath { get; set; }
        public string FilePath { get; set; }
        public string FolderPath { get; set; }
        
        public long FileSize { get; set; }
        public DateTime modified { get; set; }
        public DateTime created { get; set; }
        public DateTime accessed { get; set; }

        public static List<FileData> Parse(string[] filesList, bool encryptPath=false, string encryptionSalt ="") {
            var res = new List<FileData>();

            foreach (var item in filesList) {
                var file = new FileInfo(item);
                res.Add(new FileData() {
                    FileName = file.Name,
                    Extension = file.Extension,
                    FilePath = (encryptPath) ? RoyaSecurity.Cryptography.Crypto.EncryptStringAES(file.FullName, encryptionSalt) : file.FullName,
                    IconPath = "",
                    FileSize = file.Length,
                    FolderPath = (encryptPath) ? RoyaSecurity.Cryptography.Crypto.EncryptStringAES(file.DirectoryName, encryptionSalt) : file.DirectoryName,
                    created = file.CreationTime,
                    modified = file.LastWriteTime,
                    accessed = file.LastAccessTime
                });
            }

            return res;
        }

    }
}
