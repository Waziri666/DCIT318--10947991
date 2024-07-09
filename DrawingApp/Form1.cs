using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace DrawingApp
{
    public partial class Form1 : Form
    {
        private List<Point> drawingPoints;
        private Pen drawPen;
        private bool isDrawing;

        public Form1()
        {
            InitializeComponent();
            InitializeDrawing();
        }

        private void InitializeDrawing()
        {
            drawingPoints = new List<Point>();
            drawPen = new Pen(Color.Black, 2);
            isDrawing = false;

            panelCanvas.MouseDown += PanelCanvas_MouseDown;
            panelCanvas.MouseMove += PanelCanvas_MouseMove;
            panelCanvas.MouseUp += PanelCanvas_MouseUp;
            panelCanvas.Paint += PanelCanvas_Paint;
        }

        private void PanelCanvas_MouseDown(object sender, MouseEventArgs e)
        {
            isDrawing = true;
            drawingPoints.Add(e.Location); // Add the starting point of the line
        }

        private void PanelCanvas_MouseMove(object sender, MouseEventArgs e)
        {
            if (isDrawing)
            {
                drawingPoints.Add(e.Location); // Add the current mouse position
                panelCanvas.Invalidate(); // Forces the panel to redraw
            }
        }

        private void PanelCanvas_MouseUp(object sender, MouseEventArgs e)
        {
            isDrawing = false;
        }

        private void PanelCanvas_Paint(object sender, PaintEventArgs e)
        {
            // Draw all the lines stored in drawingPoints
            if (drawingPoints.Count > 1)
            {
                e.Graphics.DrawLines(drawPen, drawingPoints.ToArray());
            }
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            drawPen.Dispose();
            base.OnFormClosing(e);
        }
    }
}
