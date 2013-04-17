using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace InterpreteComandos
{
    class Núcleo
    {
        private Comandos Comandos = new Comandos();
        List<String> Results = new List<String>();

        public Object ExecuteCommand(String Command)
        {
            Results.Clear();
            String[] SplittedCommand = Command.Split();
            switch (SplittedCommand[0])
            {
                case "find":
                    {
                        switch (SplittedCommand[1])
                        {
                            case "file": 
                                {
                                    switch (SplittedCommand[2])
                                    {
                                        case "-first": 
                                            { 
                                                break; 
                                            }
                                        case "-FIRST": 
                                            { 
                                                break; 
                                            }
                                        default: 
                                            {
                                                String[] FilesToBeSearched = SplittedCommand[2].Split(new char[] { ',' });
                                                for (int a = 0; a < FilesToBeSearched.Length; a++)
                                                {
                                                    this.Results.AddRange(Comandos.FindFile(FilesToBeSearched[a]));
                                                }
                                                return Results;
                                            }
                                    }
                                    break; 
                                }
                            case "FILE": { break; }
                            default: 
                                { 
                                    return "El comando " + Command + "no puede ser interpretado.";
                                    break; 
                                }
                        } 
                        break;
                    }
                case "kill": { break; }
                case "list": { break; }
                case "FIND": { break; }
                case "KILL": { break; }
                case "LIST": { break; }
                default: 
                    {
                        return "El comando " + Command + "no puede ser interpretado.";
                    }
            }
            return Results;
        }
    }
}
