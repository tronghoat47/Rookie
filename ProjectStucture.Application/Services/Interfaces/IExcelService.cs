using ProjectStructure.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectStucture.Application.Services.Interfaces
{
    public interface IExcelService
    {
        byte[] ExportToExcel(List<Person> people);
    }
}
