using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using DB.Interface;
using DB.Models;
using Microsoft.AspNetCore.Mvc;
using SavingBooks.Excel.Interfaces;
using SavingBooks.Options;
using SavingBooks.Pdf.Interfaces;

namespace SavingBooks.Controllers
{
    [ApiController]
    public class BookController : ControllerBase
    {
        private readonly IBooksRepository _booksRepository;
        private readonly IPdfExportService _pdfExportService;
        private readonly IExcelExportService _excelExportService;

        public BookController(IBooksRepository booksRepository, IPdfExportService pdfExportService, IExcelExportService excelExportService)
        {
            _booksRepository = booksRepository;
            _pdfExportService = pdfExportService;
            _excelExportService = excelExportService;
        }

        [HttpGet("api/books")]
        public IActionResult Get()
        {
            var books = _booksRepository.QueryAll();

            return Ok(books);
        }

        [HttpGet("api/pdf")]
        public IActionResult GetPdf(DateTime? dateFilter, string name)
        {
            var books = _booksRepository.QueryAll();

            if (dateFilter != null)
            {
                books = books.Where(c => c.PublicationDate == dateFilter);
            }

            if (!string.IsNullOrEmpty(name))
            {
                books = books.Where(c => c.Name == name);
            }

            if (!books.Any())
            {
                return BadRequest("Not found any books by given filter");
            }

            var exportPdfString = string.Join("\n",
                books.Select(c => $"{c.BookId} | {c.Name} - {c.PageAmount} ({c.PublicationDate})"));

            var pdfBytes = _pdfExportService.ExportToPdf(exportPdfString);

            return File(pdfBytes, "application/pdf", "books.pdf");
        }

        [HttpGet("api/excel")]
        public IActionResult GetExcel(DateTime? dateFilter, string name)
        {
            var books = _booksRepository.QueryAll();

            if (dateFilter != null)
            {
                books = books.Where(c => c.PublicationDate == dateFilter);
            }

            if (!string.IsNullOrEmpty(name))
            {
                books = books.Where(c => c.Name == name);
            }


            if (!books.Any())
            {
                return BadRequest("Not found any books by given filter");
            }

            var excelBytes = _excelExportService.ExportToExcel(books);

            //Работает с любым классом
            //var test = new list<swaggeroptions>() { new swaggeroptions { description = "descr1", jsonroute = "r1", uiendpoint = "ui1" }, new swaggeroptions { description = "descr2", jsonroute = "r2", uiendpoint = "ui2" } };
            //var excelbytes = _excelexportservice.exporttoexcel(test);

            return File(excelBytes, "application/octet-stream", "books.xls");
        }

        [HttpGet("api/books/{id}")]
        public async Task<IActionResult> Get(int id)
        {
            try
            {
                var books = await _booksRepository.GetById(id);

                return Ok(books);
            }
            catch (Exception c)
            {
                return BadRequest($"Not found book with id {id}");
            }
        }

        [HttpPost("api/createBook")]
        public async Task<IActionResult> Post([FromBody] Book book)
        {
            try
            {
                if (book != null)
                    await _booksRepository.Add(book);

                return Ok(book);
            }
            catch (Exception c)
            {
                return BadRequest($"Not found book with id {book.BookId}");
            }
        }

        [HttpPost("api/editBook")]
        public async Task<IActionResult> Put([FromBody] Book book)
        {
            try
            {
                if (book != null)
                await _booksRepository.Update(book);

            return Ok(book);
            }
            catch (Exception c)
            {
                return BadRequest($"Not found book with id {book.BookId}");
            }
        }

        [HttpDelete("api/deleteBook/{id}")]
        public async Task Delete(int id)
        {
            try
            {
                await _booksRepository.Delete(id);
            }
            catch (Exception c)
            {
                BadRequest($"Dont delete book with id {id}");
            }
        }
    }
}
