namespace Common.Utils.Utils.Interface
{
    public interface IFileService
    {
        bool CreateCsvFile(string filePath, string fileName, string data, bool rewrite);

        void SendFileToFtp(string filePath, string fileName, string keyPathFtp, string username, string password);
    }
}
