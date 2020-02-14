using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.IO;

namespace SavingBooks.Excel.Interfaces
{
    public interface IExcelExportService
    {
        public byte[] ExportToExcel<T>(IEnumerable<T> objects);
    }
}
