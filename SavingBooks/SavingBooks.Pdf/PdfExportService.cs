using iTextSharp.text;
using iTextSharp.text.pdf;
using SavingBooks.Pdf.Interfaces;
using System.IO;

namespace SavingBooks.Pdf
{
    public class PdfExportService : IPdfExportService
    {
        public byte[] ExportToPdf(string text)
        {
            using (var memoryStream = new MemoryStream())
            {
                var doc = new Document(PageSize.A4, 10, 10, 10, 10);
                PdfWriter writer = PdfWriter.GetInstance(doc, memoryStream);

                doc.Open();

                var par = new Paragraph(text);
                doc.Add(par);

                doc.Close();

                return memoryStream.ToArray();
            }
           
        }
    }
}
