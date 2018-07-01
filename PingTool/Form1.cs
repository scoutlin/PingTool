using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace PingTool {
    public partial class Form1 : Form {

        private PingToolDll.PingToolDll gPingToolDll;
        System.Timers.Timer gTimer;

        public Form1() {
            InitializeComponent();

            Init();
        }

        private void Init() {
            gPingToolDll = new PingToolDll.PingToolDll();
            gTimer = new System.Timers.Timer(10000);
            gTimer.Elapsed += GTimer_Elapsed;
        }

        private void GTimer_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            bool rt = false;

            var stringIP = textBox1.Text;
            rt = gPingToolDll.SyncCheck(stringIP, 5000);

            if (rt == true)
            {
                gTimer.Stop();
                MessageBox.Show("Conneted");
            }
            else
            {
                gTimer.Stop();
                MessageBox.Show("Disconnected");
            }
        }

        private void button1_Click(object sender, EventArgs e) {
            var stringIP = textBox1.Text;

            gPingToolDll.AsyncCheck(stringIP, 5000);
            MessageBox.Show("Is Async Ping!!");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //bool rt = false;

            //var stringIP = textBox1.Text;
            //rt = gPingToolDll.SyncCheck(stringIP, 5000);
            gTimer.Start();
            MessageBox.Show("Is Sync Ping By Timer!!");

            //if(rt == true)
            //{
            //    MessageBox.Show("Conneted");
            //}
            //else
            //{
            //    MessageBox.Show("Disconnected");
            //}

            
        }
    }
}
