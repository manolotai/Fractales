using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Forms.DataVisualization.Charting;

namespace Triangulo_sierpinski
{
    public partial class Sierpinski
    {
        public static void Random(Vector p1, Vector p2, Vector p3, int n, Chart graph)
        {
            Vector m1 = (p1 + p2) / 2;
            Vector m2 = (p2 + p3) / 2;
            Vector m3 = (p3 + p1) / 2;
            DrawTriangulo(m1, m2, m3, graph);

            if (n > 0)
            {
                Random(p1, m1, m3, n - 1, graph);
                Random(p2, m2, m1, n - 1, graph);
                Random(p3, m3, m2, n - 1, graph);
            }
        }

        public static void DrawTriangulo(Vector p1, Vector p2, Vector p3, Chart graph)
        {
            graph.Series.Last().Points.Add(new DataPoint(p1.X, p1.Y));
            graph.Series.Last().Points.Add(new DataPoint(p2.X, p2.Y));
            graph.Series.Last().Points.Add(new DataPoint(p3.X, p3.Y));
            graph.Series.Last().Points.Add(new DataPoint(p1.X, p1.Y));

            graph.Series.Add(new Series()
            {
                Color = graph.Series.Last().Color,
                ChartType = SeriesChartType.Line,
                IsVisibleInLegend = false
            });
        }
    }
}
