using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace InterpreteComandos
{
    class Comandos
    {
        public List<String> FindFile(String FileName)
        {
            var Files = new List<String>();
            foreach (DriveInfo d in DriveInfo.GetDrives().Where(x => x.IsReady == true))
            {
                Files.Concat(FindInDirectory(d.RootDirectory));
            }
            return Files;
        }

        public List<String> FindInDirectory(DirectoryInfo Directory)
        {
            try
            {
                foreach (DirectoryInfo SubDirInfo in Directory.GetDirectories())
                {
                    return FindInDirectory(SubDirInfo);
                }
            }
            catch (UnauthorizedAccessException exc)
            {
                Console.WriteLine(exc.Message);
                continue;
            }
            try
            {
                List<String> FileList=new List<String>();
                foreach (FileInfo FileInfo in Directory.GetFiles())
                {
                    FileList.Add(FileInfo.FullName);
                }
                return FileList;
            }
            catch (UnauthorizedAccessException exc)
            {
                Console.WriteLine(exc.Message);
                continue;
            }
        }
    }
}
