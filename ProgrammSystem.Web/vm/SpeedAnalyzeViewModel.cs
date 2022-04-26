using OxyPlot;
using OxyPlot.Axes;
using OxyPlot.Wpf;
using ProgramSystem.Bll.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgrammSystem.Web.vm
{
    internal class SpeedAnalyzeViewModel
    {
        private Results _res;
        #region Fields

        private List<string[]> dataForTable;
        private DataTable dt;
        private PlotModel viscInCanalModel;
        private PlotModel tempInCanalModel;
        private PlotModel qInCanalModel;

        #endregion

        #region Properties      

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

        public PlotModel QInCanalModel
        {
            get
            {
                return qInCanalModel;
            }
            set
            {
                qInCanalModel = value;
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
        #endregion
        #region Commands
        #endregion

        public SpeedAnalyzeViewModel(Results res)
        {
            _res = res;

            DT = new DataTable();
            DataColumn column;
            DataRow row;

            column = new DataColumn();
            column.DataType = System.Type.GetType("System.String");
            column.ColumnName = "speed";
            DT.Columns.Add(column);

            column = new DataColumn();
            column.DataType = System.Type.GetType("System.String");
            column.ColumnName = "q";
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

            PlotModel q = new PlotModel { Title = "Зависимость производительности канала от скорости крышки:" };
            q.Axes.Add(new OxyPlot.Axes.LinearAxis { Position = AxisPosition.Left, Title = "Производительность, кг/ч" });
            q.Axes.Add(new OxyPlot.Axes.LinearAxis { Position = AxisPosition.Bottom, Title = "Скорость крышки, м/с" });
            PlotModel t = new PlotModel { Title = "Зависимость температуры продукта канала от скорости крышки:" };
            t.Axes.Add(new OxyPlot.Axes.LinearAxis { Position = AxisPosition.Left, Title = "Температура материала, С" });
            t.Axes.Add(new OxyPlot.Axes.LinearAxis { Position = AxisPosition.Bottom, Title = "Скорость крышки, м/с" });
            PlotModel v = new PlotModel { Title = "Зависимость вязкости продукта от скорости крышки:" };
            v.Axes.Add(new OxyPlot.Axes.LinearAxis { Position = AxisPosition.Left, Title = "Вязкость материала, Па*с" });
            v.Axes.Add(new OxyPlot.Axes.LinearAxis { Position = AxisPosition.Bottom, Title = "Скорость крышки, м/с" });
            var ls1 = new OxyPlot.Series.LineSeries();
            var ls2 = new OxyPlot.Series.LineSeries();
            var ls3 = new OxyPlot.Series.LineSeries();

            for (int i = 0; i < res.SpeedInCanal.Count; i++)
            {
                //string[] str = new string[] { Math.Round(Len[i], 2).ToString(), Math.Round(TempIn[i], 2).ToString(), Math.Round(ViscIn[i], 2).ToString() };
                //d.Add(str);

                row = DT.NewRow();
                row[0] = Math.Round(res.SpeedInCanal[i], 2).ToString();
                row["q"] = Math.Round(res.QWithSpeed[i], 2).ToString();
                row["temp"] = Math.Round(res.TempWithSpeed[i], 2).ToString();
                row["visc"] = Math.Round(res.ViscWithSpeed[i], 2).ToString();
                DT.Rows.Add(row);

                ls1.Points.Add(new DataPoint(Math.Round(res.SpeedInCanal[i], 2), Math.Round(res.QWithSpeed[i], 2)));
                ls2.Points.Add(new DataPoint(Math.Round(res.SpeedInCanal[i], 2), Math.Round(res.TempWithSpeed[i], 2)));
                ls3.Points.Add(new DataPoint(Math.Round(res.SpeedInCanal[i], 2), Math.Round(res.ViscWithSpeed[i], 2)));
            }

            DataForTable = d;

            q.Series.Add(ls1);
            QInCanalModel = q;

            t.Series.Add(ls2);
            TempInCanalModel = t;
            
            v.Series.Add(ls3);
            ViscInCanalModel = v;

            //string path = Environment.CurrentDirectory;

            //var pngExporter1 = new PngExporter { Width = 600, Height = 400, Background = OxyColors.White };
            //pngExporter1.ExportToFile(TempInCanalModel, path + "/temp.png");

            //var pngExporter2 = new PngExporter { Width = 600, Height = 400, Background = OxyColors.White };
            //pngExporter2.ExportToFile(ViscInCanalModel, path + "/visc.png");

        }

        #region Methods        

        #endregion

    }
}

