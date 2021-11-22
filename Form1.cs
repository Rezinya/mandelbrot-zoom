using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HW4_MandelbrotZoom
{
    public partial class Form1 : Form
    {
        // Variables for the graph
        const double BAILOUT = 200;

        double xMin, xMax, yMin, yMax;
        int maxIters;

        // Variables for the zoom function
        Point startPos, currentPos, tempPos;
        Rectangle zoomBox;
        bool isDrawing;

        public Form1()
        {
            InitializeComponent();
        }

        // Draws initial Mandelbrot set based on input (max number of iterations)
        // Default graph is set to [-2, 2] on both axes
        private void BttnDraw_Click(object sender, EventArgs e)
        {
            xMin = -2;
            xMax = 2;
            yMin = -2;
            yMax = 2;

            DrawMandelbrot(xMin, xMax, yMin, yMax);
        }

        private void DrawMandelbrot(double realMin, double realMax, double imagMin, double imagMax)
        {
            int result = 0;
            bool success = Int32.TryParse(tboxMaxIter.Text, out result);

            // Check if input is valid
            if (success)
            {
                maxIters = result;

                if (maxIters <= 0)
                {
                    MessageBox.Show("Please enter an integer greater than 0.");
                    return;
                }
            }
            else
            {
                MessageBox.Show("Please enter a valid integer.");
                return;
            }

            // Create bitmap
            Bitmap img = new Bitmap(picCanvas.ClientSize.Width, picCanvas.ClientSize.Height);
            Graphics gfx = Graphics.FromImage(img);
            gfx.Clear(picCanvas.BackColor);
            picCanvas.Image = img;

            // Calculate values for fractal (using an unoptimized escape time algorithm)
            double zx = 0.0, zy = 0.0;
            double cx = 0.0, cy = 0.0;
            double compSquared = 0.0;
            double scaleX = Math.Abs(realMax - realMin) / picCanvas.ClientSize.Width;
            double scaleY = Math.Abs(imagMax - imagMin) / picCanvas.ClientSize.Height;

            for (int px = 0; px < picCanvas.ClientSize.Width; ++px)
            {
                cx = realMin + (px * scaleX);

                for (int py = 0; py < picCanvas.ClientSize.Height; ++py)
                {
                    cy = imagMin + (py * scaleY);
                    zx = 0.0;
                    zy = 0.0;
                    compSquared = 0.0;

                    int iterations = 0;

                    while (compSquared <= BAILOUT && iterations < maxIters)
                    {
                        double tempX = (zx * zx) - (zy * zy) + cx;
                        zy = (2 * zx * zy) + cy;
                        zx = tempX;

                        compSquared = (zx * zx) + (zy * zy);
                        ++iterations;
                    }

                    // If that pixel is part of the set, then it is colored black
                    // Otherwise, it's colored royal blue
                    if (iterations < maxIters)
                        img.SetPixel(px, py, Color.RoyalBlue);
                    else
                        img.SetPixel(px, py, Color.Black);
                }
            }

            picCanvas.Image = img;
        }

        // Set starting point of zoomBox on mouse-click
        private void PicCanvas_MouseDown(object sender, MouseEventArgs e)
        {
            startPos = e.Location;

            if (picCanvas.Image != null)
                isDrawing = true;
        }

        // "Locks" startPos as a corner while drawing zoomBox
        // Forces zoomBox to be a square since picCanvas is also a square
        private void PicCanvas_MouseMove(object sender, MouseEventArgs e)
        {
            Size squareLen;

            currentPos = e.Location;

            if (isDrawing)
            {
                int length = Math.Max(
                    Math.Abs(startPos.X - currentPos.X),
                    Math.Abs(startPos.Y - currentPos.Y));

                // Negative X Quadrants (with respect to startPos)
                if (currentPos.X < startPos.X)
                {
                    tempPos.X = startPos.X - length;

                    if (currentPos.Y < startPos.Y)
                        tempPos.Y = startPos.Y - length;
                    else
                        tempPos.Y = startPos.Y;
                }
                // Positive X Quadrants
                else
                {
                    tempPos.X = startPos.X;

                    if (currentPos.Y < startPos.Y)
                        tempPos.Y = startPos.Y - length;
                    else
                        tempPos.Y = startPos.Y;
                }

                squareLen = new Size(length, length);
                zoomBox = new Rectangle(tempPos, squareLen);

                picCanvas.Invalidate();
            }
        }

        // Draws zoomBox while the mouse button is held down
        private void PicCanvas_Paint(object sender, PaintEventArgs e)
        {
            if (isDrawing)
                e.Graphics.DrawRectangle(Pens.White, zoomBox);
        }

        // Get final end point of zoomBox once mouse button is released
        // Then draw zoomed in Mandelbrot set
        private void PicCanvas_MouseUp(object sender, MouseEventArgs e)
        {
            if (isDrawing)
            {
                isDrawing = false;
                picCanvas.Invalidate();

                double newXMin = xMin + (zoomBox.Left * ((xMax - xMin) / picCanvas.ClientSize.Width));
                double newYMin = yMin + (zoomBox.Top * ((yMax - yMin) / picCanvas.ClientSize.Height));

                xMax = xMin + (zoomBox.Right * ((xMax - xMin) / picCanvas.ClientSize.Width));
                yMax = yMin + (zoomBox.Bottom * ((yMax - yMin) / picCanvas.ClientSize.Height));
                xMin = newXMin;
                yMin = newYMin;

                DrawMandelbrot(xMin, xMax, yMin, yMax);
            }
        }

        // Clears and resets the picturebox
        private void BttnReset_Click(object sender, EventArgs e)
        {
            xMin = -2;
            xMax = 2;
            yMin = -2;
            yMax = 2;

            picCanvas.Image = null;
        }
    }
}
