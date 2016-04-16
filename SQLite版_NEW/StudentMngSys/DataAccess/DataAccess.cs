using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using TJWUIData;

namespace TJWCommon
{
    public class DataAccess
    {
        #region ●Class

        #region Search
        public int GetClassInfo(DataWork classInfo, out List<DataWork> classInfoList, out string message)
        {
            classInfoList = new List<DataWork>();
            message = string.Empty;

            int status = GetClassInfoProc(classInfo, ref classInfoList, ref message);
            return status;
        }

        private int GetClassInfoProc(DataWork param, ref List<DataWork> classInfoList, ref string message)
        {
            int status = -1;

            IDataReader myReader = null;

            try
            {
                SQLiteHelper.Conn.Open();
                SQLiteCommand command = SQLiteHelper.Conn.CreateCommand();

                string sqlText = "SELECT classID, className FROM tb_Class ";
                SQLiteParameter[] para = null;
                if (!string.IsNullOrEmpty(param.ClassID) && !param.ClassID.Equals("0"))
                {
                    sqlText += "WHERE classID=@CLASSID ";
                    para = new SQLiteParameter[] { new SQLiteParameter("@CLASSID", param.ClassID) };
                }
                sqlText += "ORDER BY classID ";

                myReader = SQLiteHelper.ExecuteReader(command, sqlText, para);

                while (myReader.Read())
                {
                    DataWork classInfo = new DataWork();
                    classInfo.ClassID = SqlOperation.GetString(myReader, myReader.GetOrdinal("classID"));
                    classInfo.ClassName = SqlOperation.GetString(myReader, myReader.GetOrdinal("className"));

                    classInfoList.Add(classInfo);

                    status = 0;

                }
            }
            catch (Exception ex)
            {
                message = ex.Message;
                status = -1;
            }
            finally
            {
                if (myReader != null)
                {
                    myReader.Close();
                }
                SQLiteHelper.Conn.Close();
            }

            return status;
        }
        #endregion

        #region Write
        public int WriteClassList(List<DataWork> paramList, out string message)
        {
            int status = -1;
            message = string.Empty;

            foreach (DataWork param in paramList)
            {
                status = WriteClassProc(param, out message);
            }

            return status;
        }

        public int WriteClass(DataWork param, out string message)
        {
            int status = -1;
            message = string.Empty;

            status = WriteClassProc(param, out message);

            return status;
        }

        private int WriteClassProc(DataWork param, out string message)
        {
            int status = -1;
            message = string.Empty;
            IDataReader myReader = null;

            try
            {
                SQLiteHelper.Conn.Open();

                SQLiteCommand command = SQLiteHelper.Conn.CreateCommand();

                string selectText = "SELECT * FROM tb_Class WHERE classID=@CLASSID ";
                SQLiteParameter[] selectPara = { new SQLiteParameter("@CLASSID", param.ClassID) };

                myReader = SQLiteHelper.ExecuteReader(command, selectText, selectPara);

                string sqlText = string.Empty;
                SQLiteParameter[] para = null;
                if (!myReader.Read())
                {
                    sqlText = "INSERT INTO tb_Class ( classID " + Environment.NewLine;
                    sqlText += " ,className ) " + Environment.NewLine;
                    sqlText += "VALUES ( " + Environment.NewLine;
                    sqlText += "  @CLASSID " + Environment.NewLine;
                    sqlText += " ,@CLASSNAME ) " + Environment.NewLine;
                }
                else
                {
                    sqlText = "UPDATE tb_Class SET classID = @CLASSID " + Environment.NewLine;
                    sqlText += " ,className = @CLASSNAME " + Environment.NewLine;
                    sqlText += "WHERE classID = @CLASSID";
                }

                // 关闭myReader
                if (myReader != null)
                {
                    myReader.Close();
                }

                para = new SQLiteParameter[]{ new SQLiteParameter("@CLASSID", param.ClassID)
                                        ,new SQLiteParameter("@CLASSNAME", param.ClassName)};

                SQLiteHelper.ExecuteNonQuery(sqlText, para);

                status = 0;
            }
            catch (Exception ex)
            {
                message = ex.Message;
                status = -1;
            }
            finally
            {
                SQLiteHelper.Conn.Close();
            }

            return status;
        }
        #endregion

        #region Delete
        public int DeleteClass(DataWork param, out string message)
        {
            int status = -1;
            message = string.Empty;

            status = DeleteClassProc(param, out message);

            return status;
        }

        private int DeleteClassProc(DataWork param, out string message)
        {
            int status = -1;
            message = string.Empty;

            try
            {
                SQLiteHelper.Conn.Open();
                string sqlText = string.Empty;

                SQLiteParameter[] para = null;
                sqlText = "DELETE FROM tb_Class WHERE classID = @CLASSID " + Environment.NewLine;

                para = new SQLiteParameter[] { new SQLiteParameter("@CLASSID", param.ClassID) };

                SQLiteHelper.ExecuteNonQuery(sqlText, para);

                status = 0;
            }
            catch (Exception ex)
            {
                message = ex.Message;
                status = -1;
            }
            finally
            {
                SQLiteHelper.Conn.Close();
            }

            return status;
        }
        #endregion

        #endregion

        #region ●Student

        #region Search
        public int GetStuInfo(DataWork classInfo, out List<DataWork> stuInfoList, out string message)
        {
            stuInfoList = new List<DataWork>();
            message = string.Empty;

            int status = GetStuInfoProc(classInfo, ref stuInfoList, ref message);
            return status;
        }

        private int GetStuInfoProc(DataWork param, ref List<DataWork> classInfoList, ref string message)
        {
            int status = -1;

            IDataReader myReader = null;

            try
            {
                SQLiteHelper.Conn.Open();
                SQLiteCommand command = SQLiteHelper.Conn.CreateCommand();

                string sqlText = "SELECT STU.stuID, STU.stuName, STU.classID, CLS.className " + Environment.NewLine +
                    "FROM (tb_Student AS STU " + Environment.NewLine +
                    "LEFT JOIN tb_Class AS CLS ON STU.classID = CLS.classID ) " + Environment.NewLine +
                    "WHERE 1=1 ";

                SQLiteParameter[] para = null;
                List<SQLiteParameter> paraList = new List<SQLiteParameter>();
                if (!string.IsNullOrEmpty(param.StuID))
                {
                    sqlText += "AND STU.stuID=@STUID ";
                    paraList.Add(new SQLiteParameter("@STUID", param.StuID));
                }
                if (!string.IsNullOrEmpty(param.ClassID) && !param.ClassID.Equals("0"))
                {
                    sqlText += "AND STU.classID=@CLASSID ";
                    paraList.Add(new SQLiteParameter("@CLASSID", param.ClassID));
                }
                sqlText += "ORDER BY STU.classID, STU.stuID ";
                para = paraList.ToArray();

                myReader = SQLiteHelper.ExecuteReader(command, sqlText, para);

                while (myReader.Read())
                {
                    DataWork stuInfo = new DataWork();
                    stuInfo.StuID = SqlOperation.GetString(myReader, myReader.GetOrdinal("stuID"));
                    stuInfo.StuName = SqlOperation.GetString(myReader, myReader.GetOrdinal("stuName"));
                    stuInfo.ClassID = SqlOperation.GetString(myReader, myReader.GetOrdinal("classID"));
                    stuInfo.ClassName = SqlOperation.GetString(myReader, myReader.GetOrdinal("className"));

                    classInfoList.Add(stuInfo);
                    status = 0;

                }
            }
            catch (Exception ex)
            {
                message = ex.Message;
                status = -1;
            }
            finally
            {
                if (myReader != null)
                {
                    myReader.Close();
                }
                SQLiteHelper.Conn.Close();
            }

            return status;
        }
        #endregion

        #region Write
        public int WriteStuList(List<DataWork> paramList, out string message)
        {
            int status = -1;
            message = string.Empty;

            foreach (DataWork param in paramList)
            {
                status = WriteStuProc(param, out message);
            }

            return status;
        }

        public int WriteStu(DataWork param, out string message)
        {
            int status = -1;
            message = string.Empty;

            status = WriteStuProc(param, out message);

            return status;
        }

        private int WriteStuProc(DataWork param, out string message)
        {
            int status = -1;
            message = string.Empty;
            IDataReader myReader = null;

            try
            {
                SQLiteHelper.Conn.Open();
                SQLiteCommand command = SQLiteHelper.Conn.CreateCommand();

                string selectText = "SELECT * FROM tb_Student WHERE stuID=@STUID AND classID=@CLASSID ";
                SQLiteParameter[] selectPara = { new SQLiteParameter("@STUID", param.StuID)
                                              ,new SQLiteParameter("@CLASSID", param.ClassID)};

                myReader = SQLiteHelper.ExecuteReader(command, selectText, selectPara);

                string sqlText = string.Empty;
                SQLiteParameter[] para = null;

                if (!myReader.Read())
                {
                    sqlText = "INSERT INTO tb_Student ( stuID " + Environment.NewLine;
                    sqlText += " ,stuName " + Environment.NewLine;
                    sqlText += " ,classID ) " + Environment.NewLine;
                    sqlText += "VALUES ( " + Environment.NewLine;
                    sqlText += "  @STUID " + Environment.NewLine;
                    sqlText += " ,@STUNAME " + Environment.NewLine;
                    sqlText += " ,@CLASSID ) " + Environment.NewLine;
                }
                else
                {
                    sqlText = "UPDATE tb_Student SET stuID = @STUID " + Environment.NewLine;
                    sqlText += " ,stuName = @STUNAME " + Environment.NewLine;
                    sqlText += " ,classID = @CLASSID " + Environment.NewLine;
                    sqlText += "WHERE stuID = @STUID";
                }

                // 关闭myReader
                if (myReader != null)
                {
                    myReader.Close();
                }

                para = new SQLiteParameter[]{ new SQLiteParameter("@STUID", param.StuID)
                                        ,new SQLiteParameter("@STUNAME", param.StuName)
                                        ,new SQLiteParameter("@CLASSID", param.ClassID)};

                SQLiteHelper.ExecuteNonQuery(sqlText, para);

                status = 0;
            }
            catch (Exception ex)
            {
                message = ex.Message;
                status = -1;
            }
            finally
            {
                SQLiteHelper.Conn.Close();
            }

            return status;
        }
        #endregion

        #region Delete
        public int DeleteStu(DataWork param, out string message)
        {
            int status = -1;
            message = string.Empty;

            status = DeleteStuProc(param, out message);

            return status;
        }

        private int DeleteStuProc(DataWork param, out string message)
        {
            int status = -1;
            message = string.Empty;

            try
            {
                SQLiteHelper.Conn.Open();
                string sqlText = string.Empty;

                SQLiteParameter[] para = null;
                sqlText = "DELETE FROM tb_Student WHERE stuID = @STUID " + Environment.NewLine;

                para = new SQLiteParameter[] { new SQLiteParameter("@STUID", param.StuID) };

                SQLiteHelper.ExecuteNonQuery(sqlText, para);

                status = 0;
            }
            catch (Exception ex)
            {
                message = ex.Message;
                status = -1;
            }
            finally
            {
                SQLiteHelper.Conn.Close();
            }

            return status;
        }
        #endregion

        #endregion

        #region ●Course
        #region Search
        public int GetCourseInfo(DataWork courseInfo, out List<DataWork> courseInfoList, out string message)
        {
            courseInfoList = new List<DataWork>();
            message = string.Empty;

            int status = GetCourseInfoProc(courseInfo, ref courseInfoList, ref message);
            return status;
        }

        private int GetCourseInfoProc(DataWork param, ref List<DataWork> courseInfoList, ref string message)
        {
            int status = -1;

            IDataReader myReader = null;

            try
            {
                SQLiteHelper.Conn.Open();
                SQLiteCommand command = SQLiteHelper.Conn.CreateCommand();

                string sqlText = "SELECT courseID, courseName FROM tb_Course ";
                SQLiteParameter[] para = null;
                if (param.CourseID != 0)
                {
                    sqlText += "WHERE courseID=@COURSEID ";
                    para = new SQLiteParameter[] { new SQLiteParameter("@COURSEID", param.CourseID) };
                }
                sqlText += "ORDER BY courseID ";

                myReader = SQLiteHelper.ExecuteReader(command, sqlText, para);

                while (myReader.Read())
                {
                    DataWork courseInfo = new DataWork();
                    courseInfo.CourseID = SqlOperation.GetInt32(myReader, myReader.GetOrdinal("courseID"));
                    courseInfo.CourseName = SqlOperation.GetString(myReader, myReader.GetOrdinal("courseName"));

                    courseInfoList.Add(courseInfo);

                    status = 0;

                }
            }
            catch (Exception ex)
            {
                message = ex.Message;
                status = -1;
            }
            finally
            {
                if (myReader != null)
                {
                    myReader.Close();
                }
                SQLiteHelper.Conn.Close();
            }

            return status;
        }
        #endregion
        #endregion

        #region ●CourseDetail

        #region Search
        public int GetExamTypeInfo(DataWork param, out List<DataWork> examTypeInfoList, out string message)
        {
            examTypeInfoList = new List<DataWork>();
            message = string.Empty;

            int status = GetExamTypeInfoProc(param, ref examTypeInfoList, ref message);
            return status;
        }

        private int GetExamTypeInfoProc(DataWork param, ref List<DataWork> examTypeInfoList, ref string message)
        {
            int status = -1;

            IDataReader myReader = null;

            try
            {
                SQLiteHelper.Conn.Open();
                SQLiteCommand command = SQLiteHelper.Conn.CreateCommand();

                string sqlText = "SELECT EXAM.typeID, EXAM.courseID, EXAM.courseDetailName, EXAM.courseDetailID, COUR.courseName " + Environment.NewLine +
                    "FROM tb_CourseDetail AS EXAM LEFT JOIN tb_Course AS COUR ON COUR.courseID = EXAM.courseID " + Environment.NewLine +
                    "WHERE 1=1 ";
                SQLiteParameter[] para = null;
                List<SQLiteParameter> paraList = new List<SQLiteParameter>();
                if (param.ExamTypeID != -1)
                {
                    sqlText += "AND typeID=@TYPEID ";
                    paraList.Add( new SQLiteParameter("@TYPEID", param.ExamTypeID) );
                }
                if (param.CourseNewID != 0)
                {
                    sqlText += "AND EXAM.courseID=@COURNEWID ";
                    paraList.Add(new SQLiteParameter("@COURNEWID", param.CourseNewID));
                }
                sqlText += "ORDER BY typeID, EXAM.courseID, EXAM.courseDetailName";
                para = paraList.ToArray();
                myReader = SQLiteHelper.ExecuteReader(command, sqlText, para);

                while (myReader.Read())
                {
                    DataWork examTypeInfo = new DataWork();
                    examTypeInfo.ExamTypeID = SqlOperation.GetInt32(myReader, myReader.GetOrdinal("typeID"));
                    examTypeInfo.CourseID = SqlOperation.GetInt32(myReader, myReader.GetOrdinal("courseDetailID"));
                    examTypeInfo.CourseName = SqlOperation.GetString(myReader, myReader.GetOrdinal("courseDetailName"));
                    examTypeInfo.CourseNewID = SqlOperation.GetInt32(myReader, myReader.GetOrdinal("courseID"));
                    examTypeInfo.CourseNewName = SqlOperation.GetString(myReader, myReader.GetOrdinal("courseName"));

                    examTypeInfoList.Add(examTypeInfo);

                    status = 0;

                }
            }
            catch (Exception ex)
            {
                message = ex.Message;
                status = -1;
            }
            finally
            {
                if (myReader != null)
                {
                    myReader.Close();
                }
                SQLiteHelper.Conn.Close();
            }

            return status;
        }
        #endregion

        #region Write
        public int WriteExamTypeList(List<DataWork> paramList, out string message)
        {
            int status = -1;
            message = string.Empty;
            foreach (DataWork param in paramList)
            {
                status = WriteExamTypeProc(param, ref message);
            }

            return status;
        }

        public int WriteExamType(DataWork param, out string message)
        {
            int status = -1;
            message = string.Empty;
            status = WriteExamTypeProc(param, ref message);

            return status;
        }

        private int WriteExamTypeProc(DataWork param, ref string message)
        {
            int status = -1;
            message = string.Empty;
            IDataReader myReader = null;

            try
            {
                SQLiteHelper.Conn.Open();
                SQLiteCommand command = SQLiteHelper.Conn.CreateCommand();
                string sqlText = string.Empty;
                int courseID = param.CourseID;

                SQLiteParameter[] para = null;

                string selectText = "SELECT * FROM tb_CourseDetail WHERE typeID=@TYPEID AND courseID = @COURNEWID ";

                List<SQLiteParameter> paraList = new List<SQLiteParameter>();
                paraList.Add(new SQLiteParameter("@TYPEID", param.ExamTypeID));
                paraList.Add(new SQLiteParameter("@COURNEWID", param.CourseNewID));

                if (param.CourseID > 0) // 更新
                {
                    selectText += "AND courseDetailID=@COURSEID";
                    paraList.Add(new SQLiteParameter("@COURSEID", param.CourseID));
                }
                else // 创建
                {
                    selectText += "AND courseDetailName=@COURSENAME";
                    paraList.Add(new SQLiteParameter("@COURSENAME", param.CourseName));
                }
                SQLiteParameter[] selectPara = paraList.ToArray();
                myReader = SQLiteHelper.ExecuteReader(command, selectText, selectPara);

                bool isExists = false;
                if (myReader.Read())
                {
                    isExists = true;
                }
                if (myReader != null)
                {
                    myReader.Close();
                }

                if (!isExists)
                {
                    if (param.CourseID > 0)
                    {
                        courseID = param.CourseID;
                    }
                    else
                    {
                        string getMaxIDText = "SELECT MAX(courseDetailID) AS maxID FROM tb_CourseDetail WHERE typeID=@TYPEID AND courseID = @COURNEWID ";
                        selectPara = new SQLiteParameter[] { new SQLiteParameter("@TYPEID", param.ExamTypeID)
                                                        ,new SQLiteParameter("@COURNEWID", param.CourseNewID)};
                        myReader = SQLiteHelper.ExecuteReader(command, getMaxIDText, selectPara);

                        if (myReader.Read())
                        {
                            courseID = SqlOperation.GetInt32(myReader, myReader.GetOrdinal("maxID")) + 1;
                        }
                    }

                    // 关闭myReader
                    if (myReader != null)
                    {
                        myReader.Close();
                    }

                    sqlText = "INSERT INTO tb_CourseDetail ( typeID " + Environment.NewLine;
                    sqlText += " ,courseID " + Environment.NewLine;
                    sqlText += " ,courseDetailID " + Environment.NewLine;
                    sqlText += " ,courseDetailName ) " + Environment.NewLine;
                    sqlText += "VALUES ( " + Environment.NewLine;
                    sqlText += "  @TYPEID " + Environment.NewLine;
                    sqlText += " ,@COURSEID " + Environment.NewLine;
                    sqlText += " ,@COURSEDETAILID " + Environment.NewLine;
                    sqlText += " ,@COURSEDETAILNAME ) " + Environment.NewLine;
                }
                else if (param.CourseID > 0)
                {
                    sqlText = "UPDATE tb_CourseDetail SET typeID = @TYPEID " + Environment.NewLine;
                    sqlText += " ,courseID = @COURSEID " + Environment.NewLine;
                    sqlText += " ,courseDetailID = @COURSEDETAILID " + Environment.NewLine;
                    sqlText += " ,courseDetailName = @COURSEDETAILNAME " + Environment.NewLine;
                    sqlText += "WHERE typeID = @TYPEID AND courseID = @COURSEID AND courseDetailID = @COURSEDETAILID ";
                }
                else
                {
                    status = -1;
                    return status;
                }

                para = new SQLiteParameter[]{ new SQLiteParameter("@TYPEID", param.ExamTypeID)
                                    ,new SQLiteParameter("@COURSEID", param.CourseNewID)
                                    ,new SQLiteParameter("@COURSEDETAILNAME", param.CourseName)
                                    ,new SQLiteParameter("@COURSEDETAILID", courseID)};

                SQLiteHelper.ExecuteNonQuery(sqlText, para);

                status = 0;
            }
            catch (Exception ex)
            {
                message = ex.Message;
                status = -1;
            }
            finally
            {
                SQLiteHelper.Conn.Close();
            }

            return status;
        }
        #endregion

        #region Delete
        public int DeleteExamType(DataWork param, out string message)
        {
            int status = -1;
            message = string.Empty;

            status = DeleteExamTypeProc(param, out message);

            return status;
        }

        private int DeleteExamTypeProc(DataWork param, out string message)
        {
            int status = -1;
            message = string.Empty;

            try
            {
                SQLiteHelper.Conn.Open();
                string sqlText = string.Empty;

                SQLiteParameter[] para = null;
                sqlText = "DELETE FROM tb_CourseDetail WHERE typeID = @TYPEID AND courseID = @COURNEWID AND courseDetailID = @COURSEID " + Environment.NewLine;

                para = new SQLiteParameter[]{ new SQLiteParameter("@TYPEID", param.ExamTypeID)
                                    ,new SQLiteParameter("@COURNEWID", param.CourseNewID)
                                    ,new SQLiteParameter("@COURSEID", param.CourseID)};

                SQLiteHelper.ExecuteNonQuery(sqlText, para);

                status = 0;
            }
            catch (Exception ex)
            {
                message = ex.Message;
                status = -1;
            }
            finally
            {
                SQLiteHelper.Conn.Close();
            }

            return status;
        }
        #endregion

        #endregion

        #region ●Score

        #region Search
        public int GetScoreInfo(DataWork scoreInfo, out List<DataWork> scoreInfoList, out string message)
        {
            scoreInfoList = new List<DataWork>();
            message = string.Empty;

            int status = GetScoreInfoProc(scoreInfo, ref scoreInfoList, ref message);
            return status;
        }

        private int GetScoreInfoProc(DataWork param, ref List<DataWork> scoreInfoList, ref string message)
        {
            int status = -1;

            IDataReader myReader = null;

            try
            {
                SQLiteHelper.Conn.Open();
                SQLiteCommand command = SQLiteHelper.Conn.CreateCommand();

                string sqlText = "SELECT SCO.classID, CLS.className, SCO.stuID, STU.stuName, SCO.typeID, SCO.courseDetailID, EXAM.courseDetailName, SCO.score, SCO.isPass, SCO.newScore, SCO.testAgain, SCO.examDate, SCO.courseID, COUR.courseName " + Environment.NewLine +
                    "FROM tb_Score AS SCO " + Environment.NewLine +
                    "LEFT JOIN tb_Student AS STU ON STU.stuID = SCO.stuID AND STU.classID = SCO.classID " + Environment.NewLine +
                    "LEFT JOIN tb_Class AS CLS ON CLS.classID = SCO.classID " + Environment.NewLine +
                    "LEFT JOIN tb_CourseDetail AS EXAM ON EXAM.typeID = SCO.typeID AND EXAM.courseID = SCO.courseID AND EXAM.courseDetailID = SCO.courseDetailID " + Environment.NewLine +
                    "LEFT JOIN tb_Course AS COUR ON COUR.courseID = EXAM.courseID " + Environment.NewLine +
                    "WHERE 1=1 ";

                SQLiteParameter[] para = null;
                List<SQLiteParameter> paraList = new List<SQLiteParameter>();
                if (param.SearchScoreByStuID && !string.IsNullOrEmpty(param.StuID))
                {
                    sqlText += "AND SCO.stuID=@STUID ";
                    paraList.Add( new SQLiteParameter("@STUID", param.StuID) );
                }
                if (!string.IsNullOrEmpty(param.ClassID) && !param.ClassID.Equals("0"))
                {
                    sqlText += "AND SCO.classID=@CLASSID ";
                    paraList.Add(new SQLiteParameter("@CLASSID", param.ClassID));
                }
                if (param.ExamTypeID != -1)
                {
                    sqlText += "AND SCO.typeID=@TYPEID ";
                    paraList.Add(new SQLiteParameter("@TYPEID", param.ExamTypeID));
                }
                if (param.CourseNewID != 0)
                {
                    sqlText += "AND SCO.courseID=@COURSENEWID ";
                    paraList.Add(new SQLiteParameter("@COURSENEWID", param.CourseNewID));
                }
                if (param.CourseID != 0)
                {
                    sqlText += "AND SCO.courseDetailID=@COURSEID ";
                    paraList.Add(new SQLiteParameter("@COURSEID", param.CourseID));
                }
                if (param.ExamDate != DateTime.MinValue)
                {
                    sqlText += "AND SCO.examDate=@EXAMDATE ";
                    paraList.Add(new SQLiteParameter("@EXAMDATE", SqlOperation.SetYYYYMMDDFromDateTime(param.ExamDate)));
                }
                if (param.SearchDateTimeSt != DateTime.MinValue)
                {
                    sqlText += "AND SCO.examDate>=@EXAMDATEST ";
                    paraList.Add(new SQLiteParameter("@EXAMDATEST", SqlOperation.SetYYYYMMDDFromDateTime(param.SearchDateTimeSt)));
                }
                if (param.SearchDateTimeEd != DateTime.MinValue)
                {
                    sqlText += "AND SCO.examDate<=@EXAMDATEED ";
                    paraList.Add(new SQLiteParameter("@EXAMDATEED", SqlOperation.SetYYYYMMDDFromDateTime(param.SearchDateTimeEd)));
                }

                para = paraList.ToArray();

                sqlText += "ORDER BY SCO.classID, SCO.stuID, SCO.typeID, SCO.courseID, EXAM.courseDetailName";

                myReader = SQLiteHelper.ExecuteReader(command, sqlText, para);

                while (myReader.Read())
                {
                    DataWork stuInfo = new DataWork();
                    stuInfo.ClassID = SqlOperation.GetString(myReader, myReader.GetOrdinal("classID"));
                    stuInfo.ClassName = SqlOperation.GetString(myReader, myReader.GetOrdinal("className"));
                    stuInfo.StuID = SqlOperation.GetString(myReader, myReader.GetOrdinal("stuID"));
                    stuInfo.StuName = SqlOperation.GetString(myReader, myReader.GetOrdinal("stuName"));
                    stuInfo.ExamTypeID = SqlOperation.GetInt32(myReader, myReader.GetOrdinal("typeID"));
                    stuInfo.CourseNewID = SqlOperation.GetInt32(myReader, myReader.GetOrdinal("courseID"));
                    stuInfo.CourseNewName = SqlOperation.GetString(myReader, myReader.GetOrdinal("courseName"));
                    stuInfo.CourseID = SqlOperation.GetInt32(myReader, myReader.GetOrdinal("courseDetailID"));
                    stuInfo.CourseName = SqlOperation.GetString(myReader, myReader.GetOrdinal("courseDetailName"));
                    stuInfo.Score = SqlOperation.GetDouble(myReader, myReader.GetOrdinal("score"));
                    stuInfo.Pass = SqlOperation.GetInt32(myReader, myReader.GetOrdinal("isPass"));
                    stuInfo.Score2 = SqlOperation.GetDouble(myReader, myReader.GetOrdinal("newScore"));
                    stuInfo.TestAgain = SqlOperation.GetInt32(myReader, myReader.GetOrdinal("testAgain"));
                    stuInfo.ExamDate = SqlOperation.GetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("examDate"));

                    scoreInfoList.Add(stuInfo);
                    status = 0;

                }
            }
            catch (Exception ex)
            {
                message = ex.Message;
                status = -1;
            }
            finally
            {
                if (myReader != null)
                {
                    myReader.Close();
                }
                SQLiteHelper.Conn.Close();
            }

            return status;
        }

        public int GetAvgScore(DataWork scoreInfo, out List<DataWork> scoreInfoList, out string message)
        {
            scoreInfoList = new List<DataWork>();
            message = string.Empty;

            int status = GetAvgScoreProc(scoreInfo, ref scoreInfoList, ref message);
            return status;
        }

        private int GetAvgScoreProc(DataWork param, ref List<DataWork> scoreInfoList, ref string message)
        {
            int status = -1;

            IDataReader myReader = null;

            try
            {
                SQLiteHelper.Conn.Open();
                SQLiteCommand command = SQLiteHelper.Conn.CreateCommand();

                SQLiteParameter[] para = null;
                List<SQLiteParameter> paraList = new List<SQLiteParameter>();

                string sqlText = "SELECT " + Environment.NewLine +
                    "SUB.classID " + Environment.NewLine +
                    ",CLS.className " + Environment.NewLine +
                    ",SUB.typeID " + Environment.NewLine +
                    ",SUB.courseID " + Environment.NewLine;

                if (param.SearchMode == 0)
                {
                    sqlText += ",SUB.courseDetailID " + Environment.NewLine +
                    ",EXAM.courseDetailName " + Environment.NewLine;
                }
                else
                {
                    sqlText += ",SUB.stuID " + Environment.NewLine;
                    sqlText += ",STU.stuName " + Environment.NewLine;
                }
                    sqlText += ",SUB.AvgScore " + Environment.NewLine +
                    ",SUB.Up90 " + Environment.NewLine +
                    ",SUB.Btw8090 " + Environment.NewLine +
                    ",SUB.Btw7080 " + Environment.NewLine +
                    ",SUB.Btw6070 " + Environment.NewLine +
                    ",SUB.Down60 " + Environment.NewLine +
                    "FROM ( " + Environment.NewLine +
                    "SELECT " + Environment.NewLine +
                    "SCO.classID " + Environment.NewLine +
                    ",SCO.typeID " + Environment.NewLine +
                    ",SCO.courseID " + Environment.NewLine;

                if (param.SearchMode == 0)
                {
                    sqlText += ",SCO.courseDetailID " + Environment.NewLine;
                }
                else
                {
                    sqlText += ",SCO.stuID " + Environment.NewLine;
                }

                sqlText += ",AVG(SCO.score) AS AvgScore " + Environment.NewLine +
                    ",SUM(CASE WHEN SCO.score>=90 THEN 1 ELSE 0 END) AS Up90 " + Environment.NewLine +
                    ",SUM(CASE WHEN SCO.score>=80 AND SCO.score<90 THEN 1 ELSE 0 END) AS Btw8090 " + Environment.NewLine +
                    ",SUM(CASE WHEN SCO.score>=70 AND SCO.score<80 THEN 1 ELSE 0 END) AS Btw7080 " + Environment.NewLine +
                    ",SUM(CASE WHEN SCO.score>=60 AND SCO.score<70 THEN 1 ELSE 0 END) AS Btw6070 " + Environment.NewLine +
                    ",SUM(CASE WHEN SCO.score<60 THEN 1 ELSE 0 END) AS Down60 " + Environment.NewLine +
                    "FROM tb_Score AS SCO " + Environment.NewLine +
                    "WHERE 1=1 " + Environment.NewLine;

                if (param.SearchDateTimeSt != DateTime.MinValue)
                {
                    sqlText += "AND SCO.examDate>=@EXAMDATEST ";
                    paraList.Add(new SQLiteParameter("@EXAMDATEST", SqlOperation.SetYYYYMMDDFromDateTime(param.SearchDateTimeSt)));
                }
                if (param.SearchDateTimeEd != DateTime.MinValue)
                {
                    sqlText += "AND SCO.examDate<=@EXAMDATEED ";
                    paraList.Add(new SQLiteParameter("@EXAMDATEED", SqlOperation.SetYYYYMMDDFromDateTime(param.SearchDateTimeEd)));
                }

                sqlText += "GROUP BY SCO.classID,SCO.typeID,SCO.courseID " + Environment.NewLine;

                    if (param.SearchMode == 0)
                    {
                        sqlText += ",SCO.courseDetailID " + Environment.NewLine;
                    }
                    else
                    { 
                        sqlText += ",SCO.stuID " + Environment.NewLine; 
                    }


                    sqlText += ") AS SUB " + Environment.NewLine +
                "LEFT JOIN tb_Class AS CLS ON CLS.classID = SUB.classID " + Environment.NewLine;
                    if (param.SearchMode == 0)
                    {
                        sqlText += "LEFT JOIN tb_CourseDetail AS EXAM ON EXAM.typeID = SUB.typeID AND EXAM.courseID = SUB.courseID AND EXAM.courseDetailID = SUB.courseDetailID " + Environment.NewLine;
                    }
                    else
                    {
                        sqlText += "LEFT JOIN tb_Student AS STU ON STU.classID=SUB.classID AND STU.stuID=SUB.stuID " + Environment.NewLine;
                    }

                   sqlText +=  "WHERE 1=1 ";

                if (!string.IsNullOrEmpty(param.ClassID) && !param.ClassID.Equals("0"))
                {
                    sqlText += "AND SUB.classID=@CLASSID ";
                    paraList.Add(new SQLiteParameter("@CLASSID", param.ClassID));
                }
                if (param.ExamTypeID != -1)
                {
                    sqlText += "AND SUB.typeID=@TYPEID ";
                    paraList.Add(new SQLiteParameter("@TYPEID", param.ExamTypeID));
                }
                if (param.CourseNewID != 0)
                {
                    sqlText += "AND SUB.courseID=@COURSENEWID ";
                    paraList.Add(new SQLiteParameter("@COURSENEWID", param.CourseNewID));
                }
                if (param.CourseID != 0)
                {
                    sqlText += "AND SUB.courseDetailID=@COURSEID ";
                    paraList.Add(new SQLiteParameter("@COURSEID", param.CourseID));
                }

                para = paraList.ToArray();

                sqlText += "ORDER BY SUB.classID, SUB.typeID, SUB.courseID";
                if (param.SearchMode == 0)
                {
                    sqlText += ", EXAM.courseDetailName";
                }
                else
                {
                    sqlText += ", SUB.stuID";
                }

                myReader = SQLiteHelper.ExecuteReader(command, sqlText, para);

                while (myReader.Read())
                {
                    DataWork stuInfo = new DataWork();
                    stuInfo.ClassID = SqlOperation.GetString(myReader, myReader.GetOrdinal("classID"));
                    stuInfo.ClassName = SqlOperation.GetString(myReader, myReader.GetOrdinal("className"));
                    stuInfo.ExamTypeID = SqlOperation.GetInt32(myReader, myReader.GetOrdinal("typeID"));
                    stuInfo.CourseNewID = SqlOperation.GetInt32(myReader, myReader.GetOrdinal("courseID"));
                    if (param.SearchMode == 0)
                    {
                        stuInfo.CourseID = SqlOperation.GetInt32(myReader, myReader.GetOrdinal("courseDetailID"));
                        stuInfo.CourseName = SqlOperation.GetString(myReader, myReader.GetOrdinal("courseDetailName"));
                    }
                    else
                    {
                        stuInfo.StuID = SqlOperation.GetString(myReader, myReader.GetOrdinal("stuID"));
                        stuInfo.StuName = SqlOperation.GetString(myReader, myReader.GetOrdinal("stuName"));
                    }
                    stuInfo.Average = Math.Round(SqlOperation.GetDouble(myReader, myReader.GetOrdinal("AvgScore")), 2, MidpointRounding.AwayFromZero);
                    stuInfo.Up90Cnt = (Int32)SqlOperation.GetDouble(myReader, myReader.GetOrdinal("Up90"));
                    stuInfo.Between8090Cnt = (Int32)SqlOperation.GetDouble(myReader, myReader.GetOrdinal("Btw8090"));
                    stuInfo.Between7080Cnt = (Int32)SqlOperation.GetDouble(myReader, myReader.GetOrdinal("Btw7080"));
                    stuInfo.Between6070Cnt = (Int32)SqlOperation.GetDouble(myReader, myReader.GetOrdinal("Btw6070"));
                    stuInfo.Down60Cnt = (Int32)SqlOperation.GetDouble(myReader, myReader.GetOrdinal("Down60"));

                    scoreInfoList.Add(stuInfo);
                    status = 0;

                }
            }
            catch (Exception ex)
            {
                message = ex.Message;
                status = -1;
            }
            finally
            {
                if (myReader != null)
                {
                    myReader.Close();
                }
                SQLiteHelper.Conn.Close();
            }

            return status;
        }
        #endregion

        #region Write
        public int WriteScoreList(List<DataWork> paramList, out string message)
        {
            int status = -1;
            message = string.Empty;

            foreach (DataWork param in paramList)
            {
                status = WriteScore(param, out message);
            }

            return status;
        }

        public int WriteScore(DataWork param, out string message)
        {
            int status = -1;
            message = string.Empty;
            status = WriteScoreProc(param, ref message);

            return status;
        }

        private int WriteScoreProc(DataWork param, ref string message)
        {
            int status = -1;
            message = string.Empty;
            IDataReader myReader = null;

            try
            {
                SQLiteHelper.Conn.Open();
                SQLiteCommand command = SQLiteHelper.Conn.CreateCommand();
                string sqlText = string.Empty;

                SQLiteParameter[] para = null;

                string selectText = "SELECT * FROM tb_Score WHERE stuID=@STUID AND classID=@CLASSID AND typeID=@TYPEID AND courseID = @COURSEID AND courseDetailID=@COURSEDETAILID";
                SQLiteParameter[] selectPara = { new SQLiteParameter("@STUID", param.StuID)
                                                ,new SQLiteParameter("@CLASSID", param.ClassID)
                                                ,new SQLiteParameter("@TYPEID", param.ExamTypeID)
                                                ,new SQLiteParameter("@COURSEID", param.CourseNewID)
                                                ,new SQLiteParameter("@COURSEDETAILID", param.CourseID)};
                myReader = SQLiteHelper.ExecuteReader(command, selectText, selectPara);

                if (!myReader.Read())
                {
                    sqlText = "INSERT INTO tb_Score ( stuID " + Environment.NewLine;
                    sqlText += " ,classID " + Environment.NewLine;
                    sqlText += " ,typeID " + Environment.NewLine;
                    sqlText += " ,courseID " + Environment.NewLine;
                    sqlText += " ,courseDetailID " + Environment.NewLine;
                    sqlText += " ,score " + Environment.NewLine;
                    sqlText += " ,examDate " + Environment.NewLine;
                    sqlText += " ,isPass " + Environment.NewLine;
                    sqlText += " ,testAgain " + Environment.NewLine;
                    sqlText += " ,newScore " + Environment.NewLine;
                    sqlText += " ,newExamDate ) " + Environment.NewLine;
                    sqlText += "VALUES ( " + Environment.NewLine;
                    sqlText += "  @STUID " + Environment.NewLine;
                    sqlText += " ,@CLASSID " + Environment.NewLine;
                    sqlText += " ,@TYPEID " + Environment.NewLine;
                    sqlText += " ,@COURSEID " + Environment.NewLine;
                    sqlText += " ,@COURSEDETAILID " + Environment.NewLine;
                    sqlText += " ,@SCORE " + Environment.NewLine;
                    sqlText += " ,@EXAMDATE " + Environment.NewLine;
                    sqlText += " ,@ISPASS " + Environment.NewLine;
                    sqlText += " ,@TESTAGAIN " + Environment.NewLine;
                    sqlText += " ,@NEWSCORE " + Environment.NewLine;
                    sqlText += " ,@NEWEXAMDATE ) " + Environment.NewLine;
                }
                else
                {
                    sqlText = "UPDATE tb_Score SET stuID=@STUID " + Environment.NewLine;
                    sqlText += " ,classID=@CLASSID " + Environment.NewLine;
                    sqlText += " ,typeID=@TYPEID " + Environment.NewLine;
                    sqlText += " ,courseID=@COURSEID " + Environment.NewLine;
                    sqlText += " ,courseDetailID=@COURSEDETAILID " + Environment.NewLine;
                    sqlText += " ,score=@SCORE " + Environment.NewLine;
                    sqlText += " ,examDate=@EXAMDATE " + Environment.NewLine;
                    sqlText += " ,isPass=@ISPASS " + Environment.NewLine;
                    sqlText += " ,testAgain=@TESTAGAIN " + Environment.NewLine;
                    sqlText += " ,newScore=@NEWSCORE " + Environment.NewLine;
                    sqlText += " ,newExamDate=@NEWEXAMDATE " + Environment.NewLine;
                    sqlText += "WHERE stuID=@STUID AND classID=@CLASSID AND typeID=@TYPEID AND courseID = @COURSEID AND courseDetailID=@COURSEDETAILID " + Environment.NewLine;
                }

                // 关闭myReader
                if (myReader != null)
                {
                    myReader.Close();
                }

                para = new SQLiteParameter[]{ new SQLiteParameter("@STUID", param.StuID)
                                                ,new SQLiteParameter("@CLASSID", param.ClassID)
                                                ,new SQLiteParameter("@TYPEID", param.ExamTypeID)
                                                ,new SQLiteParameter("@COURSEID", param.CourseNewID)
                                                ,new SQLiteParameter("@COURSEDETAILID", param.CourseID)
                                                ,new SQLiteParameter("@SCORE", param.Score)
                                                ,new SQLiteParameter("@EXAMDATE", SqlOperation.SetYYYYMMDDFromDateTime(param.ExamDate))
                                                ,new SQLiteParameter("@ISPASS", param.Pass)
                                                ,new SQLiteParameter("@TESTAGAIN", param.TestAgain)
                                                ,new SQLiteParameter("@NEWSCORE", param.Score2)
                                                ,new SQLiteParameter("@NEWEXAMDATE", SqlOperation.SetYYYYMMDDFromDateTime(param.ExamDate))};

                SQLiteHelper.ExecuteNonQuery(sqlText, para);

                status = 0;
            }
            catch (Exception ex)
            {
                message = ex.Message;
                status = -1;
            }
            finally
            {
                SQLiteHelper.Conn.Close();
            }

            return status;
        }
        #endregion

        #endregion

        #region ●Term

        #region Search
        public int GetTermInfo(DataWork termInfo, out List<DataWork> termInfoList, out string message)
        {
            termInfoList = new List<DataWork>();
            message = string.Empty;

            int status = GetTermInfoProc(termInfo, ref termInfoList, ref message);
            return status;
        }

        private int GetTermInfoProc(DataWork param, ref List<DataWork> termInfoList, ref string message)
        {
            int status = -1;

            IDataReader myReader = null;

            try
            {
                SQLiteHelper.Conn.Open();
                SQLiteCommand command = SQLiteHelper.Conn.CreateCommand();

                string sqlText = "select A.[yearID],A.[yearName],B.[termID],B.[termName],B.[termDateSt],B.[termDateEd] " + Environment.NewLine +
                    "from tb_AcademicYear A" + Environment.NewLine +
                    "left join tb_Term B" + Environment.NewLine +
                    "on A.[yearID]=B.[yearID] where 1=1 " + Environment.NewLine;
                SQLiteParameter[] para = null;
                List<SQLiteParameter> paraList = new List<SQLiteParameter>();
                if (param.YearId != 0)
                {
                    sqlText += "and A.[yearID]=@yearID" + Environment.NewLine;
                    paraList.Add( new SQLiteParameter("@yearID", param.YearId) );
                }
                if (!string.IsNullOrEmpty(param.YearName))
                {
                    sqlText += "and A.[yearName]=@yearName" + Environment.NewLine;
                    paraList.Add(new SQLiteParameter("@yearName", param.YearName));
                }
                if (param.TermId != 0)
                {
                    sqlText += "and B.[termID]=@termID" + Environment.NewLine;
                    paraList.Add(new SQLiteParameter("@termID", param.TermId));
                }
                sqlText += "ORDER BY A.[yearName], B.[termID]";
                para = paraList.ToArray();
                myReader = SQLiteHelper.ExecuteReader(command, sqlText, para);

                while (myReader.Read())
                {
                    DataWork termInfo = new DataWork();
                    termInfo.YearId = SqlOperation.GetInt32(myReader, myReader.GetOrdinal("yearID"));
                    termInfo.YearName = SqlOperation.GetString(myReader, myReader.GetOrdinal("yearName"));
                    termInfo.TermId = SqlOperation.GetInt32(myReader, myReader.GetOrdinal("termID"));
                    termInfo.TermName = SqlOperation.GetString(myReader, myReader.GetOrdinal("termName"));
                    termInfo.TermDateSt = SqlOperation.GetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("termDateSt"));
                    termInfo.TermDateEd = SqlOperation.GetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("termDateEd"));

                    termInfoList.Add(termInfo);

                    status = 0;

                }
            }
            catch (Exception ex)
            {
                message = ex.Message;
                status = -1;
            }
            finally
            {
                if (myReader != null)
                {
                    myReader.Close();
                }
                SQLiteHelper.Conn.Close();
            }

            return status;
        }
        #endregion

        #region Write
        public int WriteTerm(ArrayList paramList, out string message)
        {
            int status = -1;
            message = string.Empty;

            status = WriteTermProc(paramList, out message);

            return status;
        }

        private int WriteTermProc(ArrayList paramList, out string message)
        {
            int status = -1;
            message = string.Empty;
            IDataReader myReader = null;

            try
            {
                SQLiteHelper.Conn.Open();

                SQLiteCommand command = SQLiteHelper.Conn.CreateCommand();

                DataWork yearWork = paramList[0] as DataWork;
                status = DeleteTermProc(yearWork, out message);

                if (status == 0 || status == 4)
                {
                    string sqlText = string.Empty;
                    SQLiteParameter[] para = null;
                    // 登录学年表
                    sqlText = "INSERT INTO tb_AcademicYear(yearName) values (@yearName) ";

                    para = new SQLiteParameter[] { new SQLiteParameter("@yearName", yearWork.YearName) };

                    SQLiteHelper.ExecuteNonQuery(sqlText, para);

                    // YearID
                    int yearID = 0;
                    string getYearIDText = "SELECT MAX(yearID) AS maxID FROM tb_AcademicYear ";

                    myReader = SQLiteHelper.ExecuteReader(command, getYearIDText, null);

                    if (myReader.Read())
                    {
                        yearID = SqlOperation.GetInt32(myReader, myReader.GetOrdinal("maxID"));
                    }

                    // 关闭myReader
                    if (myReader != null)
                    {
                        myReader.Close();
                    }

                    // 登录学期表
                    if (yearID > 0)
                    {
                        ArrayList termList = paramList[1] as ArrayList;
                        foreach (DataWork termWork in termList)
                        {
                            sqlText = "INSERT INTO tb_Term(yearID, termID, termName, termDateSt, termDateEd) values " + Environment.NewLine +
                                "(@yearID, @termID, @termName, @termDateSt, @termDateEd)";

                            para = new SQLiteParameter[] { new SQLiteParameter("@yearID", yearID),
                                                        new SQLiteParameter("@termID", termWork.TermId),
                                                        new SQLiteParameter("@termName", termWork.TermName),
                                                        new SQLiteParameter("@termDateSt", SqlOperation.SetYYYYMMDDFromDateTime(termWork.TermDateSt)),
                                                        new SQLiteParameter("@termDateEd", SqlOperation.SetYYYYMMDDFromDateTime(termWork.TermDateEd))};

                            SQLiteHelper.ExecuteNonQuery(sqlText, para);

                            status = 0;
                        }
                    }
                    else
                    {
                        status = -1;
                    }
                }
            }
            catch (Exception ex)
            {
                message = ex.Message;
                status = -1;
            }
            finally
            {
                SQLiteHelper.Conn.Close();
            }

            return status;
        }
        #endregion

        #region Delete
        public int DeleteTerm(DataWork param, out string message)
        {
            int status = -1;
            message = string.Empty;

            status = DeleteTermProc(param, out message);

            return status;
        }

        private int DeleteTermProc(DataWork param, out string message)
        {
            int status = -1;
            message = string.Empty;

            if (param.YearId == 0)
            {
                return 4;
            }

            try
            {
                if (SQLiteHelper.Conn.State != ConnectionState.Open)
                {
                    SQLiteHelper.Conn.Open();
                }
                string sqlText = string.Empty;

                SQLiteParameter[] para = null;
                sqlText = "DELETE FROM tb_AcademicYear WHERE yearID = @yearID; " + Environment.NewLine;
                sqlText += "DELETE FROM tb_Term WHERE yearID = @yearID; " + Environment.NewLine;

                para = new SQLiteParameter[] { new SQLiteParameter("@yearID", param.YearId) };
                 
                SQLiteHelper.ExecuteNonQuery(sqlText, para);

                status = 0;
            }
            catch (Exception ex)
            {
                message = ex.Message;
                status = -1;
            }
            finally
            {
                SQLiteHelper.Conn.Close();
            }

            return status;
        }
        #endregion

        #endregion
    }
}
