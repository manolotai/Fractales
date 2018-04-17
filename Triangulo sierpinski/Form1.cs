using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows;
using System.Windows.Forms.DataVisualization.Charting;
using Mandelbrot;
using System.Numerics;

namespace Triangulo_sierpinski
{
    public partial class Form1 : Form
    {

        public Form1()
        {
            InitializeComponent();

            DrawSierpRand(5);
            DrawSierpAutomata(1000, 1000);
            DrawMandelbrot(50);
        }

        public void DrawMandelbrot(int iteraciones)
        {
            for (int y = 0; y < 400; y++)
            {
                double cy = (200 - y) / 100.0;
                for (int i, x = 0; x < 400; x++)
                {
                    Complex z = 0;
                    double cx = (x - 200) / 100.0;
                    for (i = 0; i < iteraciones; i++)
                    {
                        z = Conjunto.F(z, new Complex(cx, cy));
                        if ((z.Real * z.Real) + (z.Imaginary * z.Imaginary) >= 4)
                        {
                            __GraficoMandelbrot.Series[1].Points.Add(new DataPoint(x, y));
                            break;
                        }
                    }
                    if(i >= 50)
                        __GraficoMandelbrot.Series[0].Points.Add(new DataPoint(x, y));
                }
            }
        }

        public void DrawSierpAutomata(int MaxX, int MaxY, int MinX = 0, int MinY = 0)
        {
            __GraficaCelular.ChartAreas[0].AxisX.Maximum = MaxX ;
            __GraficaCelular.ChartAreas[0].AxisX.Minimum = MinX;
            __GraficaCelular.ChartAreas[0].AxisY.Maximum = MaxY;
            __GraficaCelular.ChartAreas[0].AxisY.Minimum = MinY;

            Sierpinski.Automata(__GraficaCelular);
        }

        public void DrawSierpRand(int grado)
        {
            Random rnd = new Random();

            Vector p1 = new Vector(rnd.Next(0, 100), rnd.Next(0, 100));
            Vector p2 = new Vector(rnd.Next(0, 100), rnd.Next(0, 100));
            Vector p3 = new Vector(rnd.Next(0, 100), rnd.Next(0, 100));
            Sierpinski.DrawTriangulo(p1, p2, p3, __GraficaRnd);

            Sierpinski.Random(p1, p2, p3, grado, __GraficaRnd);
        }
    }
}
