using System;
using System.IO;
using System.Net;
using System.Text;
using Common.Utils.Dto;
using Common.Utils.Utils.Interface;

namespace Common.Utils.Utils

{
    public class FileService : IFileService
    {
        /// <summary>
        /// Crea un archivo en el sistema. Si se crea el archivo retorna true, de lo contrario false.
        /// </summary>
        /// <param name="filePath">Ubicación del archivo en el sistema local o de red</param>
        /// <param name="fileName">Nombre y extensión del archivo.</param>
        /// <param name="data">Información que se desea inscribir en el archivo.</param>
        /// <param name="encoding">Si se envia falso, se sobre escribe el archivo existente.
        /// De lo contario lo adiciona/anexa al contenido existente.</param>
        /// <returns></returns>
        public bool CreateCsvFile(string filePath, string fileName, string data, bool encoding)
        {
            try
            {
                if (!Directory.Exists(filePath))
                    Directory.CreateDirectory(filePath);

                using (StreamWriter io = new StreamWriter(Path.Combine(filePath, fileName), encoding))
                {
                    io.Write(data);
                    return true;
                }
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public void SendFileToFtp(string filePath, string fileName, string keyPathFtp, string username, string password)
        {
            try
            {
                FtpParameter ftpParameter = new FtpParameter
                {
                    KeepAlive = false,
                    UsePassive = false,
                    FileName = fileName,
                    FilePath = filePath,
                    FtpPath = keyPathFtp,
                    Username = username,
                    Password = password
                };

                SendFileToFtp(ftpParameter);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        private void SendFileToFtp(FtpParameter ftpParams)
        {
            FtpWebRequest requestFtp = (FtpWebRequest)WebRequest.Create(ftpParams.FtpPath + ftpParams.FileName);
            requestFtp.Method = WebRequestMethods.Ftp.UploadFile;
            requestFtp.KeepAlive = ftpParams.KeepAlive;
            requestFtp.UsePassive = ftpParams.UsePassive;
            requestFtp.Credentials = new NetworkCredential(ftpParams.Username, ftpParams.Password);
            StreamReader strmLectura = new StreamReader(ftpParams.FilePath + ftpParams.FileName);
            byte[] bInfoArchivo = Encoding.UTF8.GetBytes(strmLectura.ReadToEnd());
            strmLectura.Close();
            requestFtp.ContentLength = bInfoArchivo.Length;
            Stream strmRequest = requestFtp.GetRequestStream();
            strmRequest.Write(bInfoArchivo, 0, bInfoArchivo.Length);
            strmRequest.Close();
            FtpWebResponse response = (FtpWebResponse)requestFtp.GetResponse();
            response.Close();
        }
    }
}
