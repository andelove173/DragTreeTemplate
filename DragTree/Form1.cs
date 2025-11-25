using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DragTree 
{
    public partial class Form1 : Form
    {
        //global variables
        int currentRow;
        Stopwatch stopwatch = new Stopwatch();
        double timer;

        public Form1()
        {
            InitializeComponent();

            timerLights.Interval = 400;
            timerLights.Tick += timerLights_Tick;

            reactionTimer.Interval = 1;
            reactionTimer.Tick += elapsedTime_Tick;
        }

        private void timerLights_Tick(object sender, EventArgs e)
        {
            currentRow++;
            if (currentRow == 1)
            {
                row1col1.BackColor = Color.Orange;
                row1col2.BackColor = Color.Orange;
            }
            if (currentRow == 2)
            {
                row2col1.BackColor = Color.Orange;
                row2col2.BackColor = Color.Orange;
            }
            if (currentRow == 3)
            {
                row3col1.BackColor = Color.Orange;
                row3col2.BackColor = Color.Orange;
            }
            if (currentRow == 4)
            {
                row4col1.BackColor = Color.Green;
                row4col2.BackColor = Color.Green;
                timerLights.Enabled = false;
                stopwatch.Restart();
                reactionTimer.Enabled = true;
            }
            
        }

        private void elapsedTime_Tick(object sender, EventArgs e)
        {
            timer = stopwatch.Elapsed.TotalSeconds;
            timeLabel.Text = timer.ToString("F3");
        }

        private void startButton_Click(object sender, EventArgs e)
        {
            resetLights();
            timerLights.Enabled = true;
            currentRow = 0;
            timer = 0;
            timeLabel.Text = "0.000";

            stopwatch.Reset();
            reactionTimer.Enabled = false;

            
        }

        private void resetButton_Click(object sender, EventArgs e)
        {
            stopwatch.Reset();
            reactionTimer.Enabled = false;
            timerLights.Enabled = false;

            resetLights();

            timer = 0;
            timeLabel.Text = "0.000";

            currentRow = 0;
        }

        private void resetLights()
        {
            row4col1.BackColor = Color.DarkOliveGreen;
            row4col2.BackColor = Color.DarkOliveGreen;
            Thread.Sleep(1000);

            row3col1.BackColor = Color.DimGray;
            row3col2.BackColor = Color.DimGray;
            Thread.Sleep(1000);

            row2col1.BackColor = Color.DimGray;
            row2col2.BackColor = Color.DimGray;
            Thread.Sleep(1000);

            row1col1.BackColor = Color.DimGray;
            row1col2.BackColor = Color.DimGray;
        }

        private void goButton_Click(object sender, EventArgs e)
        {
            stopwatch.Stop();
            reactionTimer.Enabled = false;

            if (stopwatch.ElapsedMilliseconds >= 0.000)
            {
                timeLabel.Text = stopwatch.Elapsed.TotalSeconds.ToString("F3");
            }
            else
            {
                timeLabel.Text = "FOUL START";
            }
        }
    }
}
