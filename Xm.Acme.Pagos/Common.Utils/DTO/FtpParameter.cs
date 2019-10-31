namespace Common.Utils.Dto
{
    public class FtpParameter
    {
        public string FtpPath { get; set; }

        public string FilePath { get; set; }

        public string FileName { get; set; }

        public string Username { get; set; }

        public string Password { get; set; }

        public bool KeepAlive { get; set; }

        public bool UsePassive { get; set; }

        public bool UseBinary { get; set; }
    }

}
