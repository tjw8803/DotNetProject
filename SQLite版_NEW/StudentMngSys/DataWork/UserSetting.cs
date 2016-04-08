using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TJWUIData
{
    public class UserSetting
    {
        private int _excelDataSource;

        public int ExcelDataSource
        {
            get { return _excelDataSource; }
            set { _excelDataSource = value; }
        }
    }
}
