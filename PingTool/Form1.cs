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

        public Form1() {
            InitializeComponent();

            Init();
        }

        private void Init() {
            gPingToolDll = new PingToolDll.PingToolDll();
        }

        private void button1_Click(object sender, EventArgs e) {
            var stringIP = textBox1.Text;
            bool rt = false;

            rt = gPingToolDll.Check(stringIP);

            if(rt == true) {
                label2.Text = "Result: Connected";
            } else {
                label2.Text = "Result: Disconnected";
            }
        }
    }
}
