using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Dwnlder
{
    class Program
    {
        static void Main(string[] args)
        {
            for (int i = 8992; i < 10000; i++)
                DownloadCurrent($"https://www.area51editore.com/userCanDownload/{i}", "Z:\\Dwnlder\\");
        }


        private static void DownloadCurrent(string fileUrl, string local)
        {
            try
            {
                HttpWebRequest httpRequest = (HttpWebRequest)WebRequest.Create(fileUrl);
                httpRequest.Method = WebRequestMethods.Http.Get;

                HttpWebResponse httpResponse = (HttpWebResponse)httpRequest.GetResponse();
                Stream httpResponseStream = httpResponse.GetResponseStream();
                var fileName = httpResponse.ResponseUri.Segments.Last();

                // Define buffer and buffer size
                int bufferSize = 1024;
                byte[] buffer = new byte[bufferSize];
                int bytesRead = 0;

                // Concatenate the domain with the Web resource filename.
                Console.WriteLine("Downloading File \"{0}\" from \"{1}\" .......\n\n", fileName, fileUrl);
                // Read from response and write to file
                FileStream fileStream = File.Create(local+fileName);
                while ((bytesRead = httpResponseStream.Read(buffer, 0, bufferSize)) != 0)
                {
                    fileStream.Write(buffer, 0, bytesRead);
                } // end while
                // Download the Web resource and save it into the current filesystem folder.
                Console.WriteLine("Successfully Downloaded File \"{0}\" from \"{1}\"", fileName, fileUrl);
            }
            catch (Exception ex)
            {

            }
        }
    }
}
