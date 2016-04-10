using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TJWUIData
{
    public class DataWork
    {
        public int YearId { get; set; }
        public string YearName { get; set; }
        public int TermId { get; set; }
        public string TermName { get; set; }
        public DateTime TermDateSt { get; set; }
        public DateTime TermDateEd { get; set; }

        public int TermFstId { get; set; }
        public DateTime TermDateFstSt { get; set; }
        public DateTime TermDateFstEd { get; set; }
        public int TermSecId { get; set; }
        public DateTime TermDateSecSt { get; set; }
        public DateTime TermDateSecEd { get; set; }


        public double OrigScore {  get;set; }

        public double TotalScore
        {
            get;
            set;
        }

        public int AllCount
        {
            get;
            set;
        }

        public int Down60Cnt
        {
            get;
            set;
        }

        public int Between6070Cnt
        {
            get;
            set;
        }

        public int Between7080Cnt
        {
            get;
            set;
        }

        public int Between8090Cnt
        {
            get;
            set;
        }

        public int Up90Cnt
        {
            get;
            set;
        }

        public double Average
        {
            get;
            set;
        }

        public int Rank
        {
            get;
            set;
        }

        /// <summary>
        /// 补考(0:没有补考 1:已补考)
        /// </summary>
        public int TestAgain
        {
            get;
            set;
        }

        /// <summary>
        /// 及格(0:及格 1:不及格)
        /// </summary>
        public int Pass
        {
            get;
            set;
        }

        public double Score2
        {
            get;
            set;
        }

        public DateTime ExamDate
        {
            get;
            set;
        }

        public double Score
        {
            get;
            set;
        }

        public int ScorePKID
        {
            get;
            set;
        }

        public int ExamTypePKID
        {
            get;
            set;
        }

        public string CourseName
        {
            get;
            set;
        }

        public int CourseID
        {
            get;
            set;
        }

        public int CourseNewID
        {
            get;
            set;
        }

        public string CourseNewName
        {
            get;
            set;
        }

        public int ExamTypeID
        {
            get;
            set;
        }

        public string StuName
        {
            get;
            set;
        }

        public string StuID
        {
            get;
            set;
        }

        public int StuPKID
        {
            get;
            set;
        }

        public string ClassName
        {
            get;
            set;
        }

        public string ClassID
        {
            get;
            set;
        }

        public int ClassPKID
        {
            get;
            set;
        }

        public bool SearchScoreByStuID { get; set; }

        public DataWork()
        {
            ExamTypeID = -1;
        }

        public static Dictionary<string, string> GetExamType()
        {
            Dictionary<string, string> dic = new Dictionary<string, string>();
            dic.Add("0", "作业");
            dic.Add("1", "考试");

            return dic;
        }

    }

}
