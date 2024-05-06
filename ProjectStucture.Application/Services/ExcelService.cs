using ClosedXML.Excel;
using ProjectStructure.Domain;
using ProjectStucture.Application.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectStucture.Application.Services
{
    public class ExcelService : IExcelService
    {
        public byte[] ExportToExcel(List<Person> people)
        {
            using (var workbook = new XLWorkbook())
            {
                var worksheet = workbook.Worksheets.Add("Persons");

                // Get properties of Person class
                var properties = typeof(Person).GetProperties();

                // Add headers
                for (int i = 0; i < properties.Length; i++)
                {
                    worksheet.Cell(1, i + 1).Value = properties[i].Name;
                }

                // Add data
                int row = 2;
                foreach (var person in people)
                {
                    worksheet.Cell(row, 1).Value = person.FirstName;
                    worksheet.Cell(row, 2).Value = person.LastName;
                    worksheet.Cell(row, 3).Value = person.Gender.ToString();
                    worksheet.Cell(row, 4).Value = person.DateOfBirth.ToShortDateString();
                    worksheet.Cell(row, 5).Value = person.PhoneNumber;
                    worksheet.Cell(row, 6).Value = person.BirthPlace;
                    worksheet.Cell(row, 7).Value = person.IsGraduated ? "Yes" : "No";
                    if (person.IsGraduated)
                    {
                        worksheet.Row(row).Style.Fill.BackgroundColor = XLColor.Green;
                    }
                    else
                    {
                        worksheet.Row(row).Style.Fill.BackgroundColor = XLColor.Red;
                    }
                    row++;
                }

                using (var stream = new System.IO.MemoryStream())
                {
                    workbook.SaveAs(stream);
                    return stream.ToArray();
                }
            }
        }
    }
}
