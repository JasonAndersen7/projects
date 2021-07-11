using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Text.Json.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");


            string directoryPath = @"C:\Temp\Compressed";

            DirectoryInfo directorySelected = new DirectoryInfo(directoryPath);
            //Compress(directorySelected);

            foreach (FileInfo fileToDecompress in directorySelected.GetFiles("*.gz"))
            {
                Decompress(fileToDecompress);
            }



            Console.Read();
        }

        public static void Decompress(FileInfo fileToDecompress)
        {

            try
            {
                using (FileStream originalFileStream = fileToDecompress.OpenRead())
                {
                    string currentFileName = fileToDecompress.FullName;
                    //string newFileName = currentFileName.Remove(currentFileName.Length - fileToDecompress.Extension.Length);

                    //using (FileStream decompressedFileStream = File.Create(newFileName))
                    //{
                    using (GZipStream decompressionStream =
                        new GZipStream(originalFileStream, CompressionMode.Decompress))
                    {
                        // decompressionStream.CopyTo(decompressedFileStream);
                        Console.WriteLine($"Decompressed: {fileToDecompress.Name}");
                        //convert stream to list of Profile Objects

                        StreamReader reader = new StreamReader(decompressionStream);
                        string text = "["+ reader.ReadToEnd()+ "]" ;
                        Console.WriteLine(text);

                        var profiles = JsonConvert.DeserializeObject<List<Profile>>(text);
                     
                        Console.WriteLine(profiles);

                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                throw;
            }
                //}
           
        }




    }


    public class Profile
    {
        public string user_id { get; set; } 
        public string email { get; set; } 
    }

}
