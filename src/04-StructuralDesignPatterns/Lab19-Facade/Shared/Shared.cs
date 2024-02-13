using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lab19_Facade.Shared
{
    public class FileManager
    {
        private string _path;

        public FileManager(string path)
        {
            this._path = path;
        }

        public long GetFileSize()
        {
            var fi = new FileInfo(_path);
            return fi.Length;
        }

        public string GetFileName()
        {
            var fi = new FileInfo(_path);
            return fi.Name;
        }

        public string GetFileContents()
        {
            return File.ReadAllText(_path);
        }
    }

    public class FileAttributesManager
    {
        private string _path;

        public FileAttributesManager(string path)
        {
            this._path = path;
        }

        public bool IsReadOnly()
        {
            return false;
        }

        public bool IsSystemFile()
        {
            return false;
        }

        public bool IsHidden()
        {
            return false;
        }

        public void SetAsReadOnly() { /*Some Logic goes here*/
        }

        public void RemoveReadOnly() { /*Some Logic goes here*/
        }

        public void SetSystem() { /*Some Logic goes here*/
        }

        public void RemoveSystem() { /*Some Logic goes here*/
        }

        public void SetHidden() { /*Some Logic goes here*/
        }

        public void RemoveHidden() { /*Some Logic goes here*/
        }
    }

    public class EncryptionManager
    {
        private string _path;

        public EncryptionManager(string path)
        {
            this._path = path;
        }

        public bool IsEncrypted()
        {
            return false;
        }

        public string Encrypt()
        {
            return ""; /*Some Logic goes here*/
        }

        public string Decrypt()
        {
            return ""; /*Some Logic goes here*/
        }
    }
}
