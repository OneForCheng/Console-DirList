using System.Collections.Generic;
using System.Linq;
using DirList.Core;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DirListTests.Core
{
    [TestClass()]
    public class WidthDirListTests
    {
        [TestMethod()]
        public void should_display_one_line_when_limited_width_is_enough_big()
        {
            var list = new List<string>()
            {
                "555成",
                "7777777",
                "20202020202020202020",
                "88888888",
            };

            WidthDirList widthDirList = new WidthDirList(list, 104);
            IEnumerable<string> result = widthDirList.GetResult();
            Assert.AreEqual("[01] 555成                " +
                            "[02] 7777777              "+
                            "[03] 20202020202020202020 " +
                            "[04] 88888888             ", result.ElementAt(0)
                            );
        }

        [TestMethod()]
        public void should_automatically_adjust_the_number_of_columns_when_limited_width_is_smaller()
        {
            var list = new List<string>()
            {
                "555成",
                "7777777",
                "20202020202020202020",
                "88888888",
            };

            WidthDirList widthDirList = new WidthDirList(list, 52);
            IEnumerable<string> result = widthDirList.GetResult();
            Assert.AreEqual("[01] 555成                " +
                            "[03] 20202020202020202020 " , result.ElementAt(0)
                            );
            Assert.AreEqual("[02] 7777777              " +
                            "[04] 88888888             ", result.ElementAt(1)
                            );
        }
    }
}