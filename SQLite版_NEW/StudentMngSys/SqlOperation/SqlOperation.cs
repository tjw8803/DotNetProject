using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Common;
using System.Data.SqlClient;
using System.Data.OleDb;
using System.Data;

namespace TJWCommon
{
    public class SqlOperation
    {
        public static bool GetBoolean(IDataReader reader, int index)
        {
            bool b = false;
            try
            {
                b = reader.GetBoolean(index);
            }
            catch (Exception ex)
            {
                b = false;
            }
            return b;
        }
        public static DateTime GetDateTime(IDataReader reader, int index)
        {
            DateTime dt = DateTime.MinValue;
            try
            {
                dt = reader.GetDateTime(index);
            }
            catch (Exception ex)
            {
                dt = DateTime.MinValue;
            }
            return dt;
        }
        public static DateTime GetDateTimeFromYYYYMMDD(IDataReader reader, int index)
        {
            DateTime dt = DateTime.MinValue;
            try
            {
                int dateInt = reader.GetInt32(index);
                string dd = DateTime.ParseExact(dateInt.ToString(), "yyyyMMdd", null).ToString("yyyy-MM-dd");
                dt = Convert.ToDateTime(dd);
            }
            catch (Exception ex)
            {
                dt = DateTime.MinValue;
            }
            return dt;
        }
        public static short GetInt16(IDataReader reader, int index)
        {
            short s = 0;
            try
            {
                s = reader.GetInt16(index);
            }
            catch (Exception ex)
            {
                s = 0;
            }
            return s;
        }
        public static int GetInt32(IDataReader reader, int index)
        {
            int i = 0;
            try
            {
                i = reader.GetInt32(index);
            }
            catch (Exception ex)
            {
                i = 0;
            }
            return i;
        }
        public static long GetInt64(IDataReader reader, int index)
        {
            long l = 0;
            try
            {
                l = reader.GetInt64(index);
            }
            catch (Exception ex)
            {
                l = 0;
            }
            return l;
        }
        public static decimal GetDecimal(IDataReader reader, int index)
        {
            decimal d = 0;
            try
            {
                d = reader.GetDecimal(index);
            }
            catch (Exception ex)
            {
                d = 0;
            }
            return d;
        }
        public static double GetDouble(IDataReader reader, int index)
        {
            double d = 0;
            try
            {
                d = reader.GetDouble(index);
            }
            catch (Exception ex)
            {
                d = 0;
            }
            return d;
        }
        public static float GetFloat(IDataReader reader, int index)
        {
            float f = 0;
            try
            {
                f = reader.GetFloat(index);
            }
            catch (Exception ex)
            {
                f = 0;
            }
            return f;
        }
        public static string GetString(IDataReader reader, int index)
        {
            string str = string.Empty;
            try
            {
                str = reader.GetString(index);
            }
            catch (Exception ex)
            {
                str = string.Empty;
            }
            return str;
        }



        public static object SetString(string str)
        {
            object outStr = (object)str;
            if (string.IsNullOrEmpty(str))
            {
                outStr = DBNull.Value;
            }
            return outStr;
        }

        public static int SetYYYYMMDDFromDateTime(DateTime dt)
        {
            string date = dt.ToString("yyyyMMdd");
            int outInt = 0;
            Int32.TryParse(date, out outInt);
            return outInt;
        }
    }
}
