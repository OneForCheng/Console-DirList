using System.Collections.Generic;
using System.Linq;
using DirList.Core;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DirListTests.Core
{
    [TestClass()]
    public class DetailedDirListTests
    {
        

        [TestMethod()]
        public void should_return_correct_format_strings_when_input_strings_come_from_the_chinese_command_line()
        {
            var list = new List<string>()
            {
             
                "2018/06/24  08:57             59452 1.jpg",
                "2018/06/25  13:49    <DIR>          DirList",
                "2018/07/12  10:24         191865302 Shingeki no Kyojin 11.mp4",
                "2018/07/11  22:16    <DIR>          练习打字",
        
            };

            var dirList = new DetailedDirList(list);
            IEnumerable<string> result = dirList.GetResult();
            Assert.AreEqual("2018/06/24  08:57    58.1   KB  [01] 1.jpg", result.ElementAt(0));
            Assert.AreEqual("2018/06/25  13:49    <DIR>  ☆  [02] DirList", result.ElementAt(1));
            Assert.AreEqual("2018/07/12  10:24    183    MB  [03] Shingeki no Kyojin 11.mp4",result.ElementAt(2));
            Assert.AreEqual("2018/07/11  22:16    <DIR>  ☆  [04] 练习打字", result.ElementAt(3));
        }

        [TestMethod()]
        public void should_return_correct_format_strings_when_input_strings_come_from_the_english_command_line()
        {
            var list = new List<string>()
            {
                
                "06/24/2018  08:57 AM             59452 1.jpg",
                "06/25/2018  01:49 PM    <DIR>          DirList",
                "07/12/2018  10:24 AM         191865302 Shingeki no Kyojin 11.mp4",
                "07/11/2018  10:16 PM    <DIR>          练习打字",
            };

            var dirList = new DetailedDirList(list);
            IEnumerable<string> result = dirList.GetResult();
            Assert.AreEqual("06/24/2018  08:57 AM    58.1   KB  [01] 1.jpg", result.ElementAt(0));
            Assert.AreEqual("06/25/2018  01:49 PM    <DIR>  ☆  [02] DirList", result.ElementAt(1));
            Assert.AreEqual("07/12/2018  10:24 AM    183    MB  [03] Shingeki no Kyojin 11.mp4", result.ElementAt(2));
            Assert.AreEqual("07/11/2018  10:16 PM    <DIR>  ☆  [04] 练习打字", result.ElementAt(3));
        }
    }
}