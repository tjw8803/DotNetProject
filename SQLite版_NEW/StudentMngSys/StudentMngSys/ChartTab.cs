using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using TJWUIData;

namespace TJWForms
{
    public partial class ChartTab : Form
    {
        private List<DataWork> _list;
        private List<DataWork> _list2;
        private List<DataWork4Chart> _chartList;
        private double _average;
        private int _mode;

        public ChartTab(int mode, List<DataWork> list, List<DataWork> list2)
        {
            InitializeComponent();

            _list = list;
            _mode = mode;
            _list2 = list2;
        }

        private void ChartTab_Load(object sender, EventArgs e)
        {
            _chartList = new List<DataWork4Chart>();
            if (_mode == 0)
            {
                foreach (DataWork w in _list)
                {
                    _average = w.Average;

                    DataWork4Chart work = new DataWork4Chart();
                    work.Section = "90分以上";
                    work.Count = w.Up90Cnt;
                    _chartList.Add(work);

                    work = new DataWork4Chart();
                    work.Section = "80-90分";
                    work.Count = w.Between8090Cnt;
                    _chartList.Add(work);

                    work = new DataWork4Chart();
                    work.Section = "70-80分";
                    work.Count = w.Between7080Cnt;
                    _chartList.Add(work);

                    work = new DataWork4Chart();
                    work.Section = "60-70分";
                    work.Count = w.Between6070Cnt;
                    _chartList.Add(work);

                    work = new DataWork4Chart();
                    work.Section = "60分以下";
                    work.Count = w.Down60Cnt;
                    _chartList.Add(work);
                }

                CreatePieChart(_chartList);
            }
            else if (_mode == 1)
            {
                CreateLineChart(_list);
            }
            else if (_mode == 2)
            {
                CreateColumnChart(_list, _list2);
            }
        }

        private void CreatePieChart(List<DataWork4Chart> list)
        {
            #region 设置图表的属性
            //图表的背景色
            chart1.BackColor = Color.FromArgb(211, 223, 240);
            //图表背景色的渐变方式
            chart1.BackGradientStyle = GradientStyle.TopBottom;
            //图表的边框颜色、
            chart1.BorderlineColor = Color.FromArgb(26, 59, 105);
            //图表的边框线条样式
            chart1.BorderlineDashStyle = ChartDashStyle.Solid;
            //图表边框线条的宽度
            chart1.BorderlineWidth = 2;
            //图表边框的皮肤
            chart1.BorderSkin.SkinStyle = BorderSkinStyle.Emboss;
            #endregion

            this.chart1.Series.Clear();
            this.chart1.Legends.Clear();
            this.chart1.Series.Add(new Series("Data"));
            this.chart1.Legends.Add(new Legend("Stores"));
            this.chart1.Legends["Stores"].BackColor = Color.Transparent;

            this.chart1.Series["Data"].ChartType = SeriesChartType.Pie;

            this.chart1.Series["Data"]["PieLineColor"] = "Black";

            this.chart1.Series["Data"].ToolTip = "#VAL{D}人";//鼠标移动到上面显示的文字  
            this.chart1.Series["Data"].BackSecondaryColor = Color.DarkCyan;
            this.chart1.Series["Data"].BorderColor = Color.DarkOliveGreen;
            this.chart1.Series["Data"].LabelBackColor = Color.Transparent;//设置图案颜色
            chart1.Series["Data"].Color = Color.FromArgb(220, 65, 140, 240);

            foreach (DataWork4Chart w in list)
            {
                int ptIdx = this.chart1.Series["Data"].Points.AddY(w.Count);
                DataPoint pt = this.chart1.Series["Data"].Points[ptIdx];
                pt.LegendText = w.Section;//右边标签列显示的文字  
                pt.Label = w.Section + "：#VAL{D}人" + " [ " + "#PERCENT{P2}" + " ]"; //圆饼外显示的信息
            }

            ////////////////////ChartArea1属性设置///////////////////////////
            //设置网格的颜色
            chart1.ChartAreas["ChartArea1"].AxisX.MajorGrid.LineColor = Color.LightGray;
            chart1.ChartAreas["ChartArea1"].AxisY.MajorGrid.LineColor = Color.LightGray;
            //背景色
            chart1.ChartAreas["ChartArea1"].BackColor = Color.FromArgb(64, 165, 191, 228);
            //背景渐变方式
            chart1.ChartAreas["ChartArea1"].BackGradientStyle = GradientStyle.TopBottom;
            //渐变和阴影的辅助背景色
            chart1.ChartAreas["ChartArea1"].BackSecondaryColor = Color.White;
            //边框颜色
            chart1.ChartAreas["ChartArea1"].BorderColor = Color.FromArgb(64, 64, 64, 64);
            //阴影颜色
            chart1.ChartAreas["ChartArea1"].ShadowColor = Color.Transparent;

            chart1.ChartAreas["ChartArea1"].AxisX.Interval = 1;   //设置X轴坐标的间隔为1
            chart1.ChartAreas["ChartArea1"].AxisX.IntervalOffset = 1;  //设置X轴坐标偏移为1
            chart1.ChartAreas["ChartArea1"].AxisX.LabelStyle.IsStaggered = true;   //设置是否交错显示,比如数据多的时间分成两行来显示 

            this.chart1.ChartAreas["ChartArea1"].AxisX.IsMarginVisible = false;
            this.chart1.ChartAreas["ChartArea1"].Area3DStyle.Enable3D = true;

            this.chart1.Titles[0].Text = "学生成绩统计";
            this.chart1.Titles[0].Font = new System.Drawing.Font("Arial Unicode MS", 11, FontStyle.Bold);
            this.chart1.Titles[0].ForeColor = Color.FromArgb(26, 59, 105);
            this.chart1.Titles[0].ShadowColor = Color.FromArgb(32, 0, 0, 0);
            this.chart1.Titles[0].ShadowOffset = 3;

            this.chart1.Titles[1].Text = "平均分：" + _average + " 分";
            this.chart1.Titles[1].Font = new System.Drawing.Font("Arial Unicode MS", 11, FontStyle.Bold);
            this.chart1.Titles[1].ForeColor = Color.FromArgb(26, 59, 105);
            this.chart1.Titles[1].ShadowColor = Color.FromArgb(32, 0, 0, 0);
            this.chart1.Titles[1].ShadowOffset = 3;
        }

        private void CreateLineChart(List<DataWork> list)
        {
            this.chart1.Series.Clear();
            this.chart1.Legends.Clear();

            #region 设置图表的属性
            //图表的背景色
            chart1.BackColor = Color.FromArgb(211, 223, 240);
            //图表背景色的渐变方式
            chart1.BackGradientStyle = GradientStyle.TopBottom;
            //图表的边框颜色、
            chart1.BorderlineColor = Color.FromArgb(26, 59, 105);
            //图表的边框线条样式
            chart1.BorderlineDashStyle = ChartDashStyle.Solid;
            //图表边框线条的宽度
            chart1.BorderlineWidth = 2;
            //图表边框的皮肤
            chart1.BorderSkin.SkinStyle = BorderSkinStyle.Emboss;
            #endregion

            #region 设置图表的Title
            Title title = new Title();
            //标题内容
            title.Text = "学生成绩";
            //标题的字体
            title.Font = new System.Drawing.Font("Arial Unicode MS", 11, FontStyle.Bold);
            //标题字体颜色
            title.ForeColor = Color.FromArgb(26, 59, 105);
            //标题阴影颜色
            title.ShadowColor = Color.FromArgb(32, 0, 0, 0);
            //标题阴影偏移量
            title.ShadowOffset = 3;

            chart1.Titles.Add(title);
            #endregion

            ////////////////////ChartArea1属性设置///////////////////////////
            //设置网格的颜色
            chart1.ChartAreas["ChartArea1"].AxisX.MajorGrid.LineColor = Color.LightGray;
            chart1.ChartAreas["ChartArea1"].AxisY.MajorGrid.LineColor = Color.LightGray;
            //设置坐标轴名称
            chart1.ChartAreas["ChartArea1"].AxisX.TitleFont = new Font("Arial Unicode MS", float.Parse("10"), FontStyle.Regular);
            chart1.ChartAreas["ChartArea1"].AxisX.Title = "章节";
            chart1.ChartAreas["ChartArea1"].AxisX.TitleAlignment = StringAlignment.Far;
            chart1.ChartAreas["ChartArea1"].AxisY.TitleFont = new Font("Arial Unicode MS", float.Parse("10"), FontStyle.Regular);
            chart1.ChartAreas["ChartArea1"].AxisY.Title = "平均分";
            chart1.ChartAreas["ChartArea1"].AxisY.TitleAlignment = StringAlignment.Far;
            //启用3D显示
            chart1.ChartAreas["ChartArea1"].Area3DStyle.Enable3D = false;

            chart1.ChartAreas["ChartArea1"].AxisX.Interval = 1;   //设置X轴坐标的间隔为1
            chart1.ChartAreas["ChartArea1"].AxisX.IntervalOffset = 1;  //设置X轴坐标偏移为1
            chart1.ChartAreas["ChartArea1"].AxisX.LabelStyle.IsStaggered = true;   //设置是否交错显示,比如数据多的时间分成两行来显示

            //背景色
            chart1.ChartAreas["ChartArea1"].BackColor = Color.FromArgb(64, 165, 191, 228);
            //背景渐变方式
            chart1.ChartAreas["ChartArea1"].BackGradientStyle = GradientStyle.TopBottom;
            //渐变和阴影的辅助背景色
            chart1.ChartAreas["ChartArea1"].BackSecondaryColor = Color.White;
            //边框颜色
            chart1.ChartAreas["ChartArea1"].BorderColor = Color.FromArgb(64, 64, 64, 64);
            //阴影颜色
            chart1.ChartAreas["ChartArea1"].ShadowColor = Color.Transparent;

            chart1.ChartAreas["ChartArea1"].AxisY.Maximum = 100;
            chart1.ChartAreas["ChartArea1"].AxisY.Minimum = 0;
            chart1.ChartAreas["ChartArea1"].AxisY.Interval = 20;

            #region 图例及图例的位置
            Legend legend = new Legend();
            legend.Alignment = StringAlignment.Center;
            legend.Docking = Docking.Bottom;

            this.chart1.Legends.Add(legend);
            #endregion
            //////////////////////Series属性设置///////////////////////////
            this.chart1.Series.Add(new Series("scoreAvg"));
            //设置显示类型
            chart1.Series["scoreAvg"].ChartType = SeriesChartType.Spline;
            //设置坐标轴Value显示类型
            chart1.Series["scoreAvg"].XValueType = ChartValueType.String;
            //是否显示标签的数值
            chart1.Series["scoreAvg"].IsValueShownAsLabel = true;

            chart1.Series["scoreAvg"].LegendText = "平均分";
            chart1.Series["scoreAvg"].ToolTip = "章节：#AXISLABEL/平均分：#VAL{F2}";//鼠标移动到上面显示的文字

            //设置标记图案
            chart1.Series["scoreAvg"].MarkerStyle = MarkerStyle.Square;
            //设置图案颜色
            chart1.Series["scoreAvg"].Color = Color.FromArgb(220, 65, 140, 240);
            chart1.Series["scoreAvg"].MarkerColor = Color.Red;
            //设置图案的宽度
            chart1.Series["scoreAvg"].BorderWidth = 3;

            foreach (DataWork work in list)
            {
                chart1.Series["scoreAvg"].Points.AddXY(work.CourseName, work.Average.ToString("0.00"));
            }
        }

        public class DataWork4Chart
        {
            public string Section { get; set; }
            public int Count { get; set; }
        }

        private void CreateColumnChart(List<DataWork> list, List<DataWork> list2)
        {
            this.chart1.Series.Clear();
            this.chart1.Legends.Clear();

            #region 设置图表的属性
            //图表的背景色
            chart1.BackColor = Color.FromArgb(211, 223, 240);
            //图表背景色的渐变方式
            chart1.BackGradientStyle = GradientStyle.TopBottom;
            //图表的边框颜色、
            chart1.BorderlineColor = Color.FromArgb(26, 59, 105);
            //图表的边框线条样式
            chart1.BorderlineDashStyle = ChartDashStyle.Solid;
            //图表边框线条的宽度
            chart1.BorderlineWidth = 2;
            //图表边框的皮肤
            chart1.BorderSkin.SkinStyle = BorderSkinStyle.Emboss;
            #endregion

            #region 设置图表的Title
            this.chart1.Titles[0].Text = "学生成绩统计";
            this.chart1.Titles[0].Font = new System.Drawing.Font("Arial Unicode MS", 11, FontStyle.Bold);
            this.chart1.Titles[0].ForeColor = Color.FromArgb(26, 59, 105);
            this.chart1.Titles[0].ShadowColor = Color.FromArgb(32, 0, 0, 0);
            this.chart1.Titles[0].ShadowOffset = 3;

            this.chart1.Titles[1].Text = "学生：" + list2[0].StuName;
            this.chart1.Titles[1].Font = new System.Drawing.Font("Arial Unicode MS", 11, FontStyle.Bold);
            this.chart1.Titles[1].ForeColor = Color.FromArgb(26, 59, 105);
            this.chart1.Titles[1].ShadowColor = Color.FromArgb(32, 0, 0, 0);
            this.chart1.Titles[1].ShadowOffset = 3;
            #endregion

            ////////////////////ChartArea1属性设置///////////////////////////
            //设置网格的颜色
            chart1.ChartAreas["ChartArea1"].AxisX.MajorGrid.LineColor = Color.LightGray;
            chart1.ChartAreas["ChartArea1"].AxisY.MajorGrid.LineColor = Color.LightGray;
            //设置坐标轴名称
            chart1.ChartAreas["ChartArea1"].AxisX.TitleFont = new Font("Arial Unicode MS", float.Parse("10"), FontStyle.Regular);
            chart1.ChartAreas["ChartArea1"].AxisX.Title = "章节";
            chart1.ChartAreas["ChartArea1"].AxisX.TitleAlignment = StringAlignment.Far;
            chart1.ChartAreas["ChartArea1"].AxisY.TitleFont = new Font("Arial Unicode MS", float.Parse("10"), FontStyle.Regular);
            chart1.ChartAreas["ChartArea1"].AxisY.Title = "成绩";
            chart1.ChartAreas["ChartArea1"].AxisY.TitleAlignment = StringAlignment.Far;
            chart1.ChartAreas["ChartArea1"].AxisY2.TitleFont = new Font("Arial Unicode MS", float.Parse("10"), FontStyle.Regular);
            chart1.ChartAreas["ChartArea1"].AxisY2.Title = "平均分";
            chart1.ChartAreas["ChartArea1"].AxisY2.TitleAlignment = StringAlignment.Near;
            //启用3D显示
            chart1.ChartAreas["ChartArea1"].Area3DStyle.Enable3D = false;

            chart1.ChartAreas["ChartArea1"].AxisX.Interval = 1;   //设置X轴坐标的间隔为1
            chart1.ChartAreas["ChartArea1"].AxisX.IntervalOffset = 1;  //设置X轴坐标偏移为1
            chart1.ChartAreas["ChartArea1"].AxisX.LabelStyle.IsStaggered = true;   //设置是否交错显示,比如数据多的时间分成两行来显示

            //背景色
            chart1.ChartAreas["ChartArea1"].BackColor = Color.FromArgb(64, 165, 191, 228);
            //背景渐变方式
            chart1.ChartAreas["ChartArea1"].BackGradientStyle = GradientStyle.TopBottom;
            //渐变和阴影的辅助背景色
            chart1.ChartAreas["ChartArea1"].BackSecondaryColor = Color.White;
            //边框颜色
            chart1.ChartAreas["ChartArea1"].BorderColor = Color.FromArgb(64, 64, 64, 64);
            //阴影颜色
            chart1.ChartAreas["ChartArea1"].ShadowColor = Color.Transparent;

            chart1.ChartAreas["ChartArea1"].AxisY.Maximum = 100;
            chart1.ChartAreas["ChartArea1"].AxisY.Minimum = 0;
            chart1.ChartAreas["ChartArea1"].AxisY.Interval = 20;

            chart1.ChartAreas["ChartArea1"].AxisY2.Maximum = 100;
            chart1.ChartAreas["ChartArea1"].AxisY2.Minimum = 0;
            chart1.ChartAreas["ChartArea1"].AxisY2.Interval = 20;

            #region 图例及图例的位置
            Legend legend = new Legend();
            legend.Alignment = StringAlignment.Center;
            legend.Docking = Docking.Bottom;

            this.chart1.Legends.Add(legend);
            #endregion

            //////////////////////Series属性设置///////////////////////////
            this.chart1.Series.Add(new Series("score"));
            this.chart1.Series.Add(new Series("scoreAvg"));

            //设置显示类型
            chart1.Series["score"].ChartType = SeriesChartType.Column;
            //设置坐标轴Value显示类型
            chart1.Series["score"].XValueType = ChartValueType.String;
            //是否显示标签的数值
            chart1.Series["score"].IsValueShownAsLabel = true;

            chart1.Series["score"].XAxisType = AxisType.Primary;
            chart1.Series["score"].YAxisType = AxisType.Primary;

            chart1.Series["score"].LegendText = "分数";
            chart1.Series["score"].ToolTip = "章节：#AXISLABEL/分数：#VAL{F2}";//鼠标移动到上面显示的文字  

            //设置标记图案
            chart1.Series["score"].MarkerStyle = MarkerStyle.Triangle;
            //设置图案颜色
            chart1.Series["score"].Color = Color.FromArgb(220, 65, 140, 240);
            chart1.Series["score"].MarkerColor = Color.Red;
            //设置图案的宽度
            chart1.Series["score"].BorderWidth = 1;
            chart1.Series["score"]["PointWidth"] = "0.5";

            foreach (DataWork work in list2)
            {
                chart1.Series["score"].Points.AddXY(work.CourseName, work.Score.ToString("0.00"));
            }


            //设置显示类型
            chart1.Series["scoreAvg"].ChartType = SeriesChartType.Column;
            //设置坐标轴Value显示类型
            chart1.Series["scoreAvg"].XValueType = ChartValueType.String;
            //是否显示标签的数值
            chart1.Series["scoreAvg"].IsValueShownAsLabel = true;

            chart1.Series["scoreAvg"].XAxisType = AxisType.Primary;
            chart1.Series["scoreAvg"].YAxisType = AxisType.Secondary;

            chart1.Series["scoreAvg"].LegendText = "平均分";
            chart1.Series["scoreAvg"].ToolTip = "章节：#AXISLABEL/平均分：#VAL{F2}";//鼠标移动到上面显示的文字

            //设置标记图案
            chart1.Series["scoreAvg"].MarkerStyle = MarkerStyle.Square;
            //设置图案颜色
            chart1.Series["scoreAvg"].Color = Color.FromArgb(255, 204, 153);
            chart1.Series["scoreAvg"].MarkerColor = Color.Blue;
            //设置图案的宽度
            chart1.Series["scoreAvg"].BorderWidth = 1;
            this.chart1.Series["scoreAvg"]["PointWidth"] = "0.5";

            foreach (DataWork work in list)
            {
                chart1.Series["scoreAvg"].Points.AddXY(work.CourseName, work.Average.ToString("0.00"));
            }
        }
    }
}
