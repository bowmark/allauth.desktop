using System.IO;
using System.IO.Compression;
using System.Text;

namespace AllAuth.Desktop
{
    internal static class Util
    {
        public static byte[] CompressData(string data)
        {
            using (var memoryStreamIn = new MemoryStream(Encoding.UTF8.GetBytes(data)))
            using (var memoryStreamOut = new MemoryStream())
            {
                using (var gzipStream = new GZipStream(memoryStreamOut, CompressionMode.Compress))
                {
                    var buffer = new byte[4096];
                    int count;
                    while ((count = memoryStreamIn.Read(buffer, 0, buffer.Length)) != 0)
                    {
                        gzipStream.Write(buffer, 0, count);
                    }
                }
                return memoryStreamOut.ToArray();
            }
        }
        
        public static string DecompressData(byte[] data)
        {
            using (var memoryStreamIn = new MemoryStream(data))
            using (var memoryStreamOut = new MemoryStream())
            using (var memoryStreamReader = new StreamReader(memoryStreamOut))
            {
                using (var gzipStream = new GZipStream(memoryStreamIn, CompressionMode.Decompress))
                    gzipStream.CopyTo(memoryStreamOut);

                memoryStreamOut.Position = 0;

                return memoryStreamReader.ReadToEnd();
            }
        }
    }
}
