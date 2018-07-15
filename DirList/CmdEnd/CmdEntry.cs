using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DirList.Core;

namespace DirList.CmdEnd
{
    public class CmdEntry
    {
        private readonly CmdParam _cmdParam;
        
        public CmdEntry(CmdParam cmdParam)
        {
            _cmdParam = cmdParam;
        }

        public IEnumerable<string> GetExecuteResult()
        {
            var cmdHost = new CmdHost(_cmdParam);
            var executeResult = cmdHost.GetExecuteResult();
            var result = _cmdParam.IsWidthListShowParam()
                ? new WidthDirList(executeResult, Extentions.GetConsoleWindowWidth()).GetResult()
                : new DetailedDirList(GetFilterDirList(executeResult)).GetResult();
            return result;
        }

        private string[] GetFilterDirList(IEnumerable<string> collection)
        {
            var skip = collection.Skip(5).ToArray();
            var first = skip.First();
            if (first.Length == 37 && first.Substring(36, 1) == ".")
                skip = skip.Skip(2).ToArray();
            else if (first.Substring(19, 1) == "M" && first.Length == 40 && first.Substring(39, 1) == ".")
                skip = skip.Skip(2).ToArray();
            return skip.Take(skip.Length - 2).ToArray();
        }
    }
}
