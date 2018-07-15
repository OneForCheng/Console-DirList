using System;
using System.Collections.Generic;
using System.Linq;

namespace DirList.Core
{
    public class DetailedDirList
    {
        private readonly string[] _dirList;
        private readonly Tuple<int, int> _segment;

        public DetailedDirList(IEnumerable<string> collection)
        {
            _dirList = collection.ToArray();
            _segment = GetSegment(_dirList);
        }

        private Tuple<int, int> GetSegment(string[] array)
        {
            var segment = new Tuple<int, int>(17, 36);
            if (IsEnglishCommandLineInput(array)) segment = new Tuple<int, int>(20, 39);
            return segment;
        }

        private static bool IsEnglishCommandLineInput(string[] array)
        {
            return array.Length > 0 && array[0].Substring(19, 1) == "M";
        }


        public IEnumerable<string> GetResult()
        {
            var result = new List<string>();
            var num = 0;
            foreach (var line in _dirList)
            {
                num++;
                result.Add(line.Contains("<DIR>") ?
                           GetFolderInfoLine(line, num) :
                           GetFileInfoLine(line, num));
            }
            return result;
        }

        private string GetFileInfoLine(string line, int num)
        {
            return line.Substring(0, _segment.Item1) + "    " + line.Substring(_segment.Item1, 18).Replace(" ", "").GetFormatFileSize() + "  [" + GetFormatNumber(num) + "] " + line.Substring(_segment.Item2);
        }

        private string GetFolderInfoLine(string line, int num)
        {
            return line.Substring(0, _segment.Item1) + "    <DIR>  ☆  [" + GetFormatNumber(num) + "] " + line.Substring(_segment.Item2);
        }

        private static string GetFormatNumber(int i)
        {
            return i < 10 ? "0" + i : i.ToString();
        }
    }
}
