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
        List<String> Files = new List<String>();
        public List<String> FindFile(String FileName)
        {
            Files.Clear();
            //foreach (DriveInfo d in DriveInfo.GetDrives().Where(x => x.IsReady == true))
            FindInDirectory(new DirectoryInfo("E:/"), FileName, 0);
            return Files;
        }

        public void FindInDirectory(DirectoryInfo Directory,String FileName,int SearchType)
        {
            try
            {
                switch (SearchType)
                {
                    default:
                        {
                            foreach (FileInfo FileInfo in Directory.GetFiles())
                            {
                                if (FileInfo.Name.Equals(FileName))
                                    this.Files.Add(FileInfo.FullName);
                            }
                            break;
                        }
                    case 0:
                        {
                            foreach (FileInfo FileInfo in Directory.GetFiles())
                            {
                                if (FileInfo.Name.StartsWith(FileName))
                                    this.Files.Add(FileInfo.FullName);
                            }
                            break;
                        }
                    case 1:
                        {
                            String[] FileNameTextString = FileName.Split();
                            foreach (FileInfo FileInfo in Directory.GetFiles())
                            {
                                if (FileInfo.Name.Equals(FileNameTextString[0]))
                                {
                                    FileStream FileContent = FileInfo.OpenRead();
                                    if (FileContent.ToString().Contains(FileNameTextString[1]))
                                        this.Files.Add(FileInfo.FullName);
                                }
                            }
                            break;
                        }
                }
                
            }
            catch (UnauthorizedAccessException exc)
            {
            }
            try
            {
                foreach (DirectoryInfo SubDirInfo in Directory.GetDirectories())
                {
                    FindInDirectory(SubDirInfo, FileName, SearchType);
                }   
            }
            catch (UnauthorizedAccessException exc)
            {
            }
        }
    }
}
