using System.IO;

namespace SavingBooks.Pdf.Interfaces
{
    public interface IPdfExportService
    {
        byte[] ExportToPdf(string text);
    }
}
