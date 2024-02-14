using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Lab19_Facade.Shared;

namespace Lab19_Facade.Problem
{
    public class Application
    {
        public void Test(){
            string path = "SampleFile.txt";
            //you can access the sub-systems directly and bloat your code!
            var encryptionManager = new EncryptionManager(path);
            var fileAttributesManager = new FileAttributesManager(path);
            var fileManager = new FileManager(path);

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
}