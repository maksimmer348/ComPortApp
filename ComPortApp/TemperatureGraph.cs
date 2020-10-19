using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZedGraph;

namespace ComPortApp
{
    public  class TemperatureGraph
    {
        private ZedGraphControl GraphPanel;

        public TemperatureGraph(ZedGraphControl gp)
        {
            GraphPanel = gp;
        }

        public void Graph()
        {
            GraphPane pane = GraphPanel.GraphPane;
            pane.CurveList.Clear();

            PointPairList list = new PointPairList();

            double Xmin = 0;
            double Xmax = 1;
            double Ymin = 0;
            double Ymax = 1;

            pane.Title.Text = "Temperatures";
            pane.XAxis.Title.Text = "Time";
            pane.YAxis.Title.Text = "Temperature";

            for (double i = Xmin; i < Xmax; i += 1)
            {
                list.Add(1,2);
                list.Add(2, 3);
                list.Add(4, 5);
            }

            LineItem myCurve = pane.AddCurve("Delta", list, Color.Crimson, SymbolType.None);



            pane.XAxis.Scale.Min = 0;
            pane.YAxis.Scale.Min = 0;
            pane.XAxis.Scale.Max = 20;
            pane.YAxis.Scale.Max = 80;



            GraphPanel.AxisChange();
            GraphPanel.Invalidate();


        }
    }
}
