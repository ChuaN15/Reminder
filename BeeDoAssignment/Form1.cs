using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Speech.Synthesis;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BeeDoAssignment
{
    public partial class Form1 : Form
    {
        Timer timer;
        public Form1()
        {
            InitializeComponent();
            
            
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            DateTime now = DateTime.Now;
            label1.Text = (now.TimeOfDay.Hours - hour).ToString() + "hours " + (now.TimeOfDay.Minutes - minute).ToString() + "minutes until the time.";
            if (now.TimeOfDay.Hours == hour && now.TimeOfDay.Minutes == minute)
            {
                button1.PerformClick();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(string.IsNullOrEmpty(textBox1.Text))
            {
                MessageBox.Show("Please enter reminder.");
                return;
            }

            SpeechSynthesizer speech = new SpeechSynthesizer();
            speech.SetOutputToDefaultAudioDevice();

            bool isstop = false;
            while (!isstop)
            {
                speech.Speak(textBox1.Text);
            }
        }

        int hour, minute;

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyData == Keys.Escape)
            {
                if(timer != null)
                {
                    timer.Stop();

                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBox1.Text))
            {
                MessageBox.Show("Please enter reminder.");
                return;
            }

            hour = dateTimePicker1.Value.TimeOfDay.Hours;
            minute = dateTimePicker1.Value.TimeOfDay.Minutes;

            timer = new Timer(); timer.Interval = 1000;
            timer.Tick += Timer_Tick;
            timer.Start();
        }
    }
}
