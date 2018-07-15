using System;
using System.Globalization;

namespace DirList
{
    public static class Extentions
    {
        public static int GetConsoleWindowWidth()
        {
            try
            {
                return Console.WindowWidth;
            }
            catch
            {
                return 80;
            }            
        }

        public static string GetApplicationShortName()
        {
            var applicationName = AppDomain.CurrentDomain.SetupInformation.ApplicationName;
            var applicationShortName = applicationName.Substring(0, applicationName.LastIndexOf('.'));
            return applicationShortName;
        }

        public static string GetFormatFileSize(this string str)
        {
            double size;
            if (!double.TryParse(str, out size)) return str.PadRight(6, ' ') + "   ";
            if (size < 1024) return Math.Round(size, 1).ToString(CultureInfo.InvariantCulture).PadRight(6, ' ') + " B ";
            if (size < 1048576) return Math.Round(size / 1024, 1).ToString(CultureInfo.InvariantCulture).PadRight(6, ' ') + " KB";
            if (size < 1073741824) return Math.Round(size / 1048576, 1).ToString(CultureInfo.InvariantCulture).PadRight(6, ' ') + " MB";
            else return Math.Round(size / 1073741824, 1).ToString(CultureInfo.InvariantCulture).PadRight(6, ' ') + " GB";
        }
    }
}
