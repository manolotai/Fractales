using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms.DataVisualization.Charting;

namespace Triangulo_sierpinski
{
    public partial class Sierpinski
    {
        public static void Automata(Chart graph)
        {
            bool[] cinta = new bool[(int)graph.ChartAreas[0].AxisX.Maximum];
            
            cinta[0] = false;
            cinta[1] = true;

            for (int y = 0; y < graph.ChartAreas[0].AxisY.Maximum - 1; y++)
            {
                bool act, ant = cinta[0];
                for (int i = 1; i < cinta.Length; i++)
                {
                    act = cinta[i];
                    if (act)
                        graph.Series[0].Points.Add(new DataPoint(i, y));
                    cinta[i] = ant ^ act ? true : false;
                    ant = act;
                }
            }
        }
    }
}
