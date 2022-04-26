using OxyPlot;
using OxyPlot.Axes;
using OxyPlot.Wpf;
using ProgrammSystem.Web.Commands;
using ProgramSystem.Bll.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.IO;
using OxyPlot.Series;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgrammSystem.Web.vm
{
    internal class ResultWindowViewModel
    {
        private Results _res;
        #region Fields
        private string? temp; 
        private string? visc;
        private string? q;

        private List<double> len;
        private List<double> tempIn;
        private List<double> viscIn;
        private List<string[]> dataForTable;
        private DataTable dt;
        private PlotModel viscInCanalModel;
        private PlotModel tempInCanalModel;
        private string? textMessage;

        #endregion

        #region Properties      
        public string? Temp
        {
            get
            {
                return temp;
            }
            set
            {
                temp = value;
            }
        }
        public string? Q
        {
            get
            {
                return q;
            }
            set
            {
                q = value;
            }
        }
        public string? Visc
        {
            get
            {
                return visc;
            }
            set
            {
                visc = value;
            }
        }

        public string? TextMessage
        {
            get
            {
                return textMessage;
            }
            set
            {
                textMessage = value;
            }
        }

        public List<double> Len
        {
            get
            {
                return len;
            }
            set
            {
                len = value;
            }
        }
        public List<double> TempIn
        {
            get
            {
                return tempIn;
            }
            set
            {
                tempIn = value;
            }
        }
        public List<double> ViscIn
        {
            get
            {
                return viscIn;
            }
            set
            {
                viscIn = value;
            }
        }
        public DataTable DT
        {
            get
            {
                return dt;
            }
            set
            {
                dt = value;
            }
        }

        public List<string[]> DataForTable
        {
            get
            {
                return dataForTable;
            }
            set
            {
                dataForTable = value;
            }
        }


        public PlotModel TempInCanalModel
        {
            get
            {
                return tempInCanalModel;
            }
            set
            {
                tempInCanalModel = value;
            }
        }

        public PlotModel ViscInCanalModel
        {
            get
            {
                return viscInCanalModel;
            }
            set
            {
                viscInCanalModel = value;
            }
        }

        #endregion

        #region Commands
        #endregion

        public ResultWindowViewModel(Results res, ref Stopwatch sw, ref long memory0)
        {
            _res = res;

            Temp = "Температура продукта= " + Math.Round(res.T, 2).ToString() + " С";
            Q = "Производительность = " + Math.Round(res.Q, 2).ToString() + " кг/ч";
            Visc = "Вязкость продукта = " + Math.Round(res.Visc, 2).ToString() + " Па*с";

            Len = res.LengthOfCanal;
            TempIn = res.TempInside;
            ViscIn = res.ViscosityInside;

            DT = new DataTable();
            DataColumn column;
            DataRow row;

            column = new DataColumn();
            column.DataType = System.Type.GetType("System.String");
            column.ColumnName = "len";
            DT.Columns.Add(column);

            column = new DataColumn();
            column.DataType = System.Type.GetType("System.String");
            column.ColumnName = "temp";
            DT.Columns.Add(column);

            column = new DataColumn();
            column.DataType = System.Type.GetType("System.String");
            column.ColumnName = "visc";
            DT.Columns.Add(column);

            List<string[]> d = new List<string[]>();

            PlotModel t = new PlotModel { Title = "Распределение температуры материала по длине канала:" };
            t.Axes.Add(new OxyPlot.Axes.LinearAxis { Position = AxisPosition.Left, Title = "Температура материала, С" });
            t.Axes.Add(new OxyPlot.Axes.LinearAxis { Position = AxisPosition.Bottom, Title = "Длина канала, м" });
            PlotModel v = new PlotModel { Title = "Распределение вязкости материала по длине канала:" };
            v.Axes.Add(new OxyPlot.Axes.LinearAxis { Position = AxisPosition.Left, Title = "Вязкость материала, Па*с" });
            v.Axes.Add(new OxyPlot.Axes.LinearAxis { Position = AxisPosition.Bottom, Title = "Длина канала, м" });
            var ls1 = new OxyPlot.Series.LineSeries();
            var ls2 = new OxyPlot.Series.LineSeries();

            for (int i = 0; i < Len.Count; i++)
            {
                //string[] str = new string[] { Math.Round(Len[i], 2).ToString(), Math.Round(TempIn[i], 2).ToString(), Math.Round(ViscIn[i], 2).ToString() };
                //d.Add(str);

                row = DT.NewRow();
                row[0] = Math.Round(Len[i], 2).ToString();
                row["temp"] = Math.Round(TempIn[i], 2).ToString();
                row["visc"] = Math.Round(ViscIn[i], 2).ToString();
                DT.Rows.Add(row);

                ls1.Points.Add(new DataPoint(Math.Round(Len[i], 2), Math.Round(TempIn[i], 2)));
                ls2.Points.Add(new DataPoint(Math.Round(Len[i], 2), Math.Round(ViscIn[i], 2)));
            }

            DataForTable = d;

            t.Series.Add(ls1);
            TempInCanalModel = t;

            v.Series.Add(ls2);
            ViscInCanalModel = v;

            sw.Stop();
            TimeSpan time = sw.Elapsed;
            Process p = Process.GetCurrentProcess();
            var memuse = p.WorkingSet64 - memory0;

            string elaosedTime = String.Format("{0:00}.{1:00}", time.Seconds, time.Milliseconds / 10);
            string str = "Время расчета и визуализации = " + elaosedTime.ToString() + " c," + "  объем затраченной оперативной памяти = " + Math.Round(memuse / 1024.0 / 1024.0, 2).ToString() + " МБ";
            TextMessage = str;

            string path = Environment.CurrentDirectory;

            var pngExporter1 = new PngExporter { Width = 600, Height = 400, Background = OxyColors.White };
            pngExporter1.ExportToFile(TempInCanalModel, path + "/temp.png");

            var pngExporter2 = new PngExporter { Width = 600, Height = 400, Background = OxyColors.White };
            pngExporter2.ExportToFile(ViscInCanalModel, path + "/visc.png");

        }

        #region Methods        

        #endregion

    }
}
