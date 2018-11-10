using Common.Interfaces;
using Domain.Entities.Other;
using Infrastructure.Utatilties;
using iTextSharp.text;
using iTextSharp.text.pdf;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Operations.Others
{
    public class ExportOperation
    {
        public string FieldName;
        public List<dynamic> items;
        public string Type;
        private string _contentType;
        private MemoryStream _result;
        private string _fileName;
        private string _path;
        public ExportResult Execute()
        {
            setupMemoryStream();
            return new ExportResult() { Stream = _result, ContentType = _contentType , FileName  = _fileName};
        }

        void setupMemoryStream()
        {
            var assemply = Assembly.Load("Domain");
            var type = assemply.GetType("Domain." + FieldName);
            var listType = typeof(List<>).MakeGenericType(type);
            var newList = Activator.CreateInstance(listType) as IList;
            foreach (var item in items)
            {
                var itemString = item.ToString();
                var testJson = Newtonsoft.Json.JsonConvert.DeserializeObject<dynamic>(itemString);
                // var test = testJson["ID"].ToString();
                // var tests = testJson["Name"].ToString();
                var newItem = Activator.CreateInstance(type);
                Mapper.Map(item, newItem);
                newList.Add(newItem);
            }

            var ienumerableObject = newList as IEnumerable<object>;
            var dataTable = ToDataTable(ienumerableObject.ToList());
            _fileName = Guid.NewGuid().ToString();
            if (string.Equals(Type, "PDF"))
            {
                _fileName = _fileName + ".pdf";
               
                _result = AsPDFAsync(dataTable, _fileName);
                _contentType = GetContentType(_path);
            }

            if (string.Equals(Type, "CSV"))
            {
                _fileName = _fileName + ".csv";
                _contentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
                _result = AsCSV(ref dataTable);
            }

            if (string.Equals(Type, "xlsx"))
            {
                _fileName = _fileName + ".xlsx";
                _contentType = "text/csv";
                _result = AsExcel(dataTable, _fileName);
            }
        }
        DataTable ToDataTable<T>(List<T> items)
        {
            var objectType = items.FirstOrDefault().GetType();
            DataTable dataTable = new DataTable(objectType.Name);

            //Get all the properties
            PropertyInfo[] Props = objectType.GetProperties(BindingFlags.Public | BindingFlags.Instance);
            foreach (PropertyInfo prop in Props)
            {
                //Defining type of data column gives proper data table 
                var type = (prop.PropertyType.IsGenericType && prop.PropertyType.GetGenericTypeDefinition() == typeof(Nullable<>) ? Nullable.GetUnderlyingType(prop.PropertyType) : prop.PropertyType);
                //Setting column names as Property names
                dataTable.Columns.Add(prop.Name, type);
            }
            foreach (T item in items)
            {
                var values = new object[Props.Length];
                for (int i = 0; i < Props.Length; i++)
                {
                    //inserting property values to datatable rows
                    values[i] = Props[i].GetValue(item, null);
                }
                dataTable.Rows.Add(values);
            }
            //put a breakpoint here and check datatable
            return dataTable;
        }
        MemoryStream AsPDFAsync(DataTable dtblTable, string fileName)
        {
            var strPdfPath = Path.Combine(
            Directory.GetCurrentDirectory(), "wwwroot/Documents",
            fileName);
            System.IO.FileStream fs = new FileStream(strPdfPath, FileMode.Create, FileAccess.Write, FileShare.None);
            Document document = new Document();
            document.SetPageSize(iTextSharp.text.PageSize.A2);
            PdfWriter writer = PdfWriter.GetInstance(document, fs);
            document.Open();

            //Report Header
            BaseFont bfntHead = BaseFont.CreateFont(BaseFont.TIMES_ROMAN, BaseFont.CP1252, BaseFont.NOT_EMBEDDED);
            Font fntHead = new Font(bfntHead, 16, 1, Color.GRAY);
            Paragraph prgHeading = new Paragraph();
            prgHeading.Alignment = Element.ALIGN_CENTER;
            prgHeading.Add(new Chunk(fileName.ToUpper(), fntHead));
            document.Add(prgHeading);

            //Author
            Paragraph prgAuthor = new Paragraph();
            BaseFont btnAuthor = BaseFont.CreateFont(BaseFont.TIMES_ROMAN, BaseFont.CP1252, BaseFont.NOT_EMBEDDED);
            Font fntAuthor = new Font(btnAuthor, 8, 2, Color.GRAY);
            prgAuthor.Alignment = Element.ALIGN_RIGHT;
            prgAuthor.Add(new Chunk("\nRun Date : " + DateTime.Now.ToShortDateString(), fntAuthor));
            document.Add(prgAuthor);

            //Add a line seperation
            Paragraph p = new Paragraph(new Chunk(new iTextSharp.text.pdf.draw.LineSeparator(0.0F, 100.0F, Color.BLACK, Element.ALIGN_LEFT, 1)));
            document.Add(p);

            //Add line break
            document.Add(new Chunk("\n", fntHead));

            //Write the table
            PdfPTable table = new PdfPTable(dtblTable.Columns.Count);
            //Table header
            BaseFont btnColumnHeader = BaseFont.CreateFont(BaseFont.TIMES_ROMAN, BaseFont.CP1252, BaseFont.NOT_EMBEDDED);
            Font fntColumnHeader = new Font(btnColumnHeader, 10, 1, Color.WHITE);
            for (int i = 0; i < dtblTable.Columns.Count; i++)
            {
                PdfPCell cell = new PdfPCell();
                cell.BackgroundColor = Color.GRAY;
                cell.AddElement(new Chunk(dtblTable.Columns[i].ColumnName.ToUpper(), fntColumnHeader));
                table.AddCell(cell);
            }
            //table Data
            for (int i = 0; i < dtblTable.Rows.Count; i++)
            {
                for (int j = 0; j < dtblTable.Columns.Count; j++)
                {
                    table.AddCell(dtblTable.Rows[i][j].ToString());
                }
            }

            document.Add(table);
            document.Close();
            writer.Close();
            fs.Close();
            _path = strPdfPath;
            var memory = new MemoryStream();
            using (var stream = new FileStream(strPdfPath, FileMode.Open))
            {
                stream.CopyTo(memory);
            }
            memory.Position = 0;

            return memory;
        }
        MemoryStream AsExcel(DataTable dataTable, string fileName)
        {
            ClosedXML.Excel.XLWorkbook wbook = new ClosedXML.Excel.XLWorkbook();
            wbook.Worksheets.Add(dataTable, fileName);
            var memoryStream = new MemoryStream();
            wbook.SaveAs(memoryStream);
            memoryStream.Position = 0;
            return memoryStream;
        }
        MemoryStream AsCSV(ref DataTable dTable)
        {
            StringBuilder sb = new StringBuilder();
            int intClmn = dTable.Columns.Count;

            int i = 0;
            for (i = 0; i <= intClmn - 1; i += 1)
            {
                sb.Append(@"""" + dTable.Columns[i].ColumnName.ToString() + @"""");
                if (i == intClmn - 1)
                {
                    sb.Append(" ");
                }
                else
                {
                    sb.Append(",");
                }
            }
            sb.Append(Environment.NewLine);

            //--------Data By  Columns---------------------------------------------------------------------------


            foreach (DataRow row in dTable.Rows)
            {
                int ir = 0;
                for (ir = 0; ir <= intClmn - 1; ir += 1)
                {
                    sb.Append(@"""" + row[ir].ToString().Replace(@"""", @"""""") + @"""");
                    if (ir == intClmn - 1)
                    {
                        sb.Append(" ");
                    }
                    else
                    {
                        sb.Append(",");
                    }

                }
                sb.Append(Environment.NewLine);
            }
            return new MemoryStream(Encoding.UTF8.GetBytes(sb.ToString()));
        }
         string GetContentType(string path)
        {
            var types = GetMimeTypes();
            var ext = Path.GetExtension(path).ToLowerInvariant();
            return types[ext];
        }
      Dictionary<string, string> GetMimeTypes()
        {
            return new Dictionary<string, string>
            {
                {".txt", "text/plain"},
                {".pdf", "application/pdf"},
                {".doc", "application/vnd.ms-word"},
                {".docx", "application/vnd.ms-word"},
                {".xls", "application/vnd.ms-excel"},
                {".xlsx", "application/vnd.openxmlformats officedocument.spreadsheetml.sheet"},
                {".png", "image/png"},
                {".jpg", "image/jpeg"},
                {".jpeg", "image/jpeg"},
                {".gif", "image/gif"},
                {".csv", "text/csv"}
            };
        }
    }
}
