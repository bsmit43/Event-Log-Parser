using System.IO;
using System.IO.MemoryMappedFiles;
using System.Text;

namespace WpfApplication1
{
    class Txtreader
    {
        public string Readtxtfile(string fileName)
        {
            //declare empty string
            string contents = "";
            //Using memory mappedfile to read log for the time being. Seems marginally faster than Streamreader even with buffer.
            using (MemoryMappedFile mmf = MemoryMappedFile.CreateFromFile(fileName, FileMode.Open))
            {
                using (MemoryMappedViewStream stream = mmf.CreateViewStream())
                {
                    var contentArray = new byte[1000000/*stream.Length*/];
                    stream.Read(contentArray, 0, contentArray.Length);
                    contents = Encoding.UTF8.GetString(contentArray);
                    return contents;                   
                }
            } 
        }
    }
}
