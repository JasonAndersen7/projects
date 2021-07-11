using System;
using Cloudmersive.APIClient.NETCore.DocumentAndDataConvert.Api;
using Cloudmersive.APIClient.NETCore.DocumentAndDataConvert.Client;
using Cloudmersive.APIClient.NETCore.DocumentAndDataConvert.Model;
using Patagames.Pdf.Net;

namespace PdfConverter
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            // Configure API key authorization: Apikey
            Configuration.Default.AddApiKey("Apikey", "2e3c03e4-3b6f-4c01-b691-15724df67e0f");

            var apiInstance = new ConvertDocumentApi();
            var inputFile = new System.IO.FileStream("C:\\temp\\Standards.docx", System.IO.FileMode.Open); // System.IO.Stream | Input file to perform the operation on.

            try
            {
                // Word DOCX to PDF
                var result = apiInstance.ConvertDocumentDocxToPdf(inputFile);
                Console.WriteLine(result);
                System.IO.File.WriteAllBytes("C:\\temp\\Standards.pdf", result);

                //PDFIUM
                var forms = new PdfForms();
                var doc = Patagames.Pdf.Net.PdfDocument.Load(@"c:\temp\testfill.pdf", forms); // C# Read PDF Document

                int i = 0;
                foreach (var field in forms.InterForm.Fields)
                {
                    if (field.FieldType == Patagames.Pdf.Enums.FormFieldTypes.FPDF_FORMFIELD_TEXTFIELD)
                    {
                        field.Value = "This is a field #" + (++i);
                        Console.WriteLine(field.Value + " " + field.FullName);
                    }
                }


                //PDFIUM


            }
            catch (Exception e)
            {
                Console.WriteLine("Exception when calling ConvertDocumentApi.ConvertDocumentDocxToPdf: " + e.Message);
            }

            Console.Read();
        }
    }


}
