using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DirList.CmdEnd;

namespace DirList
{
    class CmdApp
    {
        private const int Error = 1;
        private const int Success = 0;


        static int Main(string[] args)
        {
            var cmdParam = new CmdParam(args);
            if (cmdParam.ContainsUasgeParam())
            {
                Console.WriteLine(CmdMessage.GetUsage());
            }
            else if (cmdParam.IsError())
            {
                Console.WriteLine(CmdMessage.GetUsageErrorPrompt());
                return Error;
            }
            else 
            {
                ShowCurrentDirectory();
                var cmdEntry = new CmdEntry(cmdParam);
                foreach (var line in cmdEntry.GetExecuteResult()) Console.WriteLine(line);
            }
            
            return Success;
        }

        private static void ShowCurrentDirectory()
        {
            Console.WriteLine();
            Console.WriteLine($" {Directory.GetCurrentDirectory()} 的目录");
            Console.WriteLine();
        }
    }
}
