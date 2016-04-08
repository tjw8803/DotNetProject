using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace TJWUIData
{
    public class DataWorkForExcel
    {
        private string _sheetName;
        private DataTable _excelDataTable;

        public DataTable ExcelDataTable
        {
            get { return _excelDataTable; }
            set { _excelDataTable = value; }
        }

        public string SheetName
        {
            get { return _sheetName; }
            set { _sheetName = value; }
        }
    }
}
