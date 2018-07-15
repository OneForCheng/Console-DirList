using System;

namespace DirList.CmdEnd
{
    public class CmdMessage
    {
        public const string OnlyShowFolderParam  = "dir /a:d /o:n /-c";
        public const string OnlyShowFileParam = "dir /a:-d /o:n /-c";
        public const string WidthListShowParam = "dir /a /o:n /b";
        public const string ShowFileAndFolderParam  = "dir /a /o:n /-c";

        public static string GetUsageErrorPrompt()
        {
            return $"{Environment.NewLine}信息: 键入 \"{Extentions.GetApplicationShortName().ToUpper()} /? \" 了解用法信息。";
        }

        public static string GetUsage()
        {
            var spaces = new string(' ', 4);
            var applicationShortName = Extentions.GetApplicationShortName().ToUpper();
            var firstLine = $"{Environment.NewLine}显示目录中的文件和子目录列表。{Environment.NewLine}";
            var secondLine = $"{applicationShortName} /d";
            var thirdLine = $"{applicationShortName} /f";
            var fourthLine = $"{applicationShortName} /w";
            var fifthLine = $"{Environment.NewLine}{spaces}/d           表示只显示当前目录下的子目录。";
            var sixthLine = $"{spaces}/f           表示只显示当前目录下的文件。";
            var seventhLine = $"{spaces}/w           表示用宽列表格式。";
            var eighthLine = $"{Environment.NewLine}{spaces}注：当参数为空时，默认显示子目录和文件。";

            return firstLine + Environment.NewLine +
                   secondLine + Environment.NewLine +
                   thirdLine + Environment.NewLine +
                   fourthLine + Environment.NewLine +
                   fifthLine + Environment.NewLine +
                   sixthLine + Environment.NewLine +
                   seventhLine + Environment.NewLine +
                   eighthLine;
        }
    }
}
