using System.IO;
using Syncfusion.XlsIO;
using System;
using System.Data;
using SavingBooks.Excel.Interfaces;
using System.Collections.Generic;

namespace SavingBooks.Excel
{
    public class ExcelExportService : IExcelExportService
    {     
        public byte[] ExportToExcel<T>(IEnumerable<T> objects)
        {
            using (ExcelEngine excelEngine = new ExcelEngine())
            {
                IApplication application = excelEngine.Excel;
                application.DefaultVersion = ExcelVersion.Excel2016;

                IWorkbook workbook = application.Workbooks.Create(1);

                IWorksheet worksheet = workbook.Worksheets[0];

                var dataTable = ExportObjectsToDatatable(objects);
                worksheet.ImportDataTable(dataTable, true, 1, 1);
                worksheet.UsedRange.AutofitColumns();

                var memoryStream = new MemoryStream();

                workbook.SaveAs(memoryStream);

                return memoryStream.ToArray();
            }
        }

        private DataTable ExportObjectsToDatatable<T>(IEnumerable<T> objects)
        {
            DataTable table = new DataTable();

            var propertyInfos = typeof(T).GetProperties();

            foreach(var propertyInfo in propertyInfos)
            {
                table.Columns.Add(propertyInfo.Name, propertyInfo.PropertyType);
            }

            foreach(var obj in objects) {
                
                var objValueParams = new List<object>();

                foreach(var property in propertyInfos)
                {
                    objValueParams.Add(property.GetValue(obj));
                }

                table.Rows.Add(objValueParams.ToArray());
            }
            return table;
        }
    }
}
