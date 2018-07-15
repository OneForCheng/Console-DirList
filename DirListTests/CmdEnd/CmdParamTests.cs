using DirList.CmdEnd;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DirListTests.CmdEnd
{
    [TestClass()]
    public class CmdParamTests
    {
        [TestMethod()]
        public void should_return_true_when_args_contains_the_usage_parameter()
        {
            var cmdParam1 = new CmdParam(new[] { "/f", "/?" });
            var cmdParam2 = new CmdParam(new[] { "/?" });
            Assert.AreEqual(true, cmdParam1.ContainsUasgeParam());
            Assert.AreEqual(true, cmdParam2.ContainsUasgeParam());

        }

        [TestMethod()]
        public void should_return_false_when_args_not_contains_the_usage_parameter()
        {

            var cmdParam1 = new CmdParam(new[] { "/f" });
            var cmdParam2 = new CmdParam(new string[] { });
            Assert.AreEqual(false, cmdParam1.ContainsUasgeParam());
            Assert.AreEqual(false, cmdParam2.ContainsUasgeParam());
        }

        [TestMethod()]
        public void should_return_true_when_args_is_error()
        {
            var cmdParam1 = new CmdParam(new[] { "f", });
            var cmdParam2 = new CmdParam(new[] { "/" });
            Assert.AreEqual(true, cmdParam1.IsError());
            Assert.AreEqual(true, cmdParam2.IsError());
        }

        [TestMethod()]
        public void should_return_false_when_args_is_not_error()
        {
            var cmdParam1 = new CmdParam(new[] { "/f" });
            var cmdParam2 = new CmdParam(new[] { "/d" });
            var cmdParam3 = new CmdParam(new[] { "/w" });
            var cmdParam4 = new CmdParam(new[] { "/?" });
            var cmdParam5 = new CmdParam(new string[] { });
            Assert.AreEqual(false, cmdParam1.IsError());
            Assert.AreEqual(false, cmdParam2.IsError());
            Assert.AreEqual(false, cmdParam3.IsError());
            Assert.AreEqual(false, cmdParam4.IsError());
            Assert.AreEqual(false, cmdParam5.IsError());
        }

        [TestMethod]
        public void  should_return_true_when_first_parameter_is_width_list_show_parameter()
        {
            var cmdParam1 = new CmdParam(new[] { "/w" });
            var cmdParam2 = new CmdParam(new []{"/W"});
            var cmdParam3 = new CmdParam(new []{"/w", "/f"});
            Assert.AreEqual(true, cmdParam1.IsWidthListShowParam());
            Assert.AreEqual(true, cmdParam2.IsWidthListShowParam());
            Assert.AreEqual(true, cmdParam3.IsWidthListShowParam());
        }

        [TestMethod]
        public void should_return_false_when_first_parameter_is_not_width_list_show_parameter()
        {
            var cmdParam1 = new CmdParam(new[] { "/f" });
            var cmdParam2 = new CmdParam(new string[] { });
            Assert.AreEqual(false, cmdParam1.IsWidthListShowParam());
            Assert.AreEqual(false, cmdParam2.IsWidthListShowParam());
        }

        [TestMethod]
        public void should_return_matching_parameter_string_when_given_parameter_is_correct()
        {
            var cmdParam1 = new CmdParam(new[] { "/d" });
            var cmdParam2 = new CmdParam(new[] { "/f" });
            var cmdParam3 = new CmdParam(new[] { "/w" });
            var cmdParam4 = new CmdParam(new string[] { });
            Assert.AreEqual(CmdMessage.OnlyShowFolderParam, cmdParam1.GetCmdRunParam());
            Assert.AreEqual(CmdMessage.OnlyShowFileParam, cmdParam2.GetCmdRunParam());
            Assert.AreEqual(CmdMessage.WidthListShowParam, cmdParam3.GetCmdRunParam());
            Assert.AreEqual(CmdMessage.ShowFileAndFolderParam, cmdParam4.GetCmdRunParam());
        }
    }
}