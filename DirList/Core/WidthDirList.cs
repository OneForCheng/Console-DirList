using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DirList.Core
{

     public class ColumnItem
    {
        public int Width { get; }
        public string Value { get; }

        public ColumnItem(int width, string value)
        {
            Width = width;
            Value = value;
        }
    }

    public class WidthDirList
    {
           
        private readonly List<ColumnItem> _columnItems;
        private readonly int _outputColumnWidth;
        private readonly int _cols;
        private readonly int _rows;

        public WidthDirList(IEnumerable<string> collection, int limitedWidth)
        {
            _columnItems = GetColumnItems(collection);
            _outputColumnWidth = _columnItems.Max(m => m.Width) + 1;

            _cols = limitedWidth / _outputColumnWidth;
            if (_cols < 1) _cols = 1;

            _rows = _columnItems.Count / _cols;
            if (_columnItems.Count % _cols != 0) _rows++;
        }

        private List<ColumnItem> GetColumnItems(IEnumerable<string> collection)
        {
            var columnItems = new List<ColumnItem>();
            var array = collection.ToArray();
            for (var i = 1; i <= array.Length; i++)
            {
                var num = i < 10 ? "0" + i : i.ToString();
                var columnItem = $"[{num}] {array[i - 1]}";
                columnItems.Add(new ColumnItem(Encoding.Default.GetByteCount(columnItem), columnItem));
            }
            return columnItems;
        }

        public IEnumerable<string> GetResult()
        {
            var result = new List<string>();
            if (!_columnItems.Any()) return result;
            for (var row = 1; row <= _rows; row++) result.Add(GetLine(row));
            return result;
        }

        private string GetLine(int row)
        {
            var line = string.Empty;
            for (var col = 1; col <= _cols; col++)
            {
                var index = (col-1)*_rows + row - 1;
                if (index < _columnItems.Count)
                {
                    line += _columnItems[index].Value + string.Empty.PadRight(_outputColumnWidth - _columnItems[index].Width, ' ');
                }
            }
            return line;
        }
    }
}
