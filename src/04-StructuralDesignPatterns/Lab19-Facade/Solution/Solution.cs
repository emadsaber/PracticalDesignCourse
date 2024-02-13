using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.IO;
using Lab19_Facade.Shared;

namespace Lab19_Facade.Solution
{
    public class FileFacade
    {
        private readonly EncryptionManager encryptionManager;
        private readonly FileManager fileManager;
        private readonly FileAttributesManager fileAttributesManager;

        public FileFacade(
            string path /*FileManager fileManager, EncryptionManager encryptionManager, FileAttributesManager fileAttributesManager*/
        )
        {
            this.fileAttributesManager ??= new FileAttributesManager(path);
            this.fileManager ??= new FileManager(path);
            this.encryptionManager ??= new EncryptionManager(path);
        }

        public void PrintFile()
        {
            string file;
            //check that file is encrypted
            if (encryptionManager.IsEncrypted())
            {
                file = encryptionManager.Decrypt();
            }

            //check file attributes
            if (fileAttributesManager.IsReadOnly())
                fileAttributesManager.RemoveReadOnly();
            if (fileAttributesManager.IsHidden())
                fileAttributesManager.RemoveHidden();
            if (fileAttributesManager.IsSystemFile())
                fileAttributesManager.RemoveSystem();

            //read the file
            var size = fileManager.GetFileSize();
            var contents = fileManager.GetFileContents();

            Console.WriteLine($"File size is: {size} bytes");
            Console.WriteLine($"File contents are:");
            Console.WriteLine();
            Console.Write(contents);
        }
    }

    public class Application
    {
        public void Test()
        {
            //print the file via Facade

            var facade = new FileFacade("SampleFile.txt");
            facade.PrintFile();
        }
    }
}
