using System.Linq;

namespace DirList.CmdEnd
{
    public  class CmdParam
    {
        private readonly string[] _args;

        public CmdParam(string[] args)
        {
            _args = args;
        }

        public bool ContainsUasgeParam()
        {
            return _args.Any(item => item.Contains("/?"));
        }
        
        public string GetCmdRunParam()
        {
            if (IsOnlyShowFolderParam()) return CmdMessage.OnlyShowFolderParam;
            if (IsOnlyShowFileParam()) return CmdMessage.OnlyShowFileParam;
            if (IsWidthListShowParam()) return CmdMessage.WidthListShowParam;
            return CmdMessage.ShowFileAndFolderParam;
        }

        private bool IsOnlyShowFileParam()
        {
            return _args.Length > 0 && _args[0].ToLower() == "/f";
        }

        private bool IsOnlyShowFolderParam()
        {
            return _args.Length > 0 && _args[0].ToLower() == "/d";
        }

        public bool IsWidthListShowParam()
        {
            return _args.Length > 0 && _args[0].ToLower() == "/w";
        }

        public bool IsError()
        {
            return !(_args.Length == 0 || ContainsUasgeParam() || IsOnlyShowFileParam() || IsOnlyShowFolderParam() || IsWidthListShowParam());
        }
    }
}
