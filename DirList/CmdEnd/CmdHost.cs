using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace DirList.CmdEnd
{
    public class CmdHost
    {
        private readonly CmdParam _cmdParam;

        public CmdHost(CmdParam cmdParam)
        {
            _cmdParam = cmdParam;
        }

        public IEnumerable<string> GetExecuteResult()
        {
            var proc = Process.Start(GetCmdProcessStartInfo());
            var result = new List<string>();
            if (proc == null) return result;
            var reader = proc.StandardOutput;
            while (!reader.EndOfStream) result.Add(reader.ReadLine());
            return result;
        }

        

        private ProcessStartInfo GetCmdProcessStartInfo()
        {
            var process = new ProcessStartInfo("cmd.exe")
            {
                Arguments = " /c " + _cmdParam.GetCmdRunParam(),
                CreateNoWindow = true,
                RedirectStandardOutput = true,
                UseShellExecute = false
            };
            return process;
        }
    }
}
