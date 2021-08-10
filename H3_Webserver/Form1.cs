using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace H3_Webserver
{
    public partial class Form1 : Form
    {
        Server webserver = new Server();
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            IPAddress ipAddress = IPAddress.Parse(textBox1.Text + "." + textBox2.Text + "." + textBox3.Text + "." + textBox4.Text);
            if (webserver.start(ipAddress, Convert.ToInt32(textBox5.Text), 100, textBox6.Text))
            {
                button1.Enabled = false;
                button2.Enabled = true;
            }
            else
                MessageBox.Show(this, "Couldn't start the server. Make sure port " + textBox4.Text.ToString() + " is not being listened by other servers.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            webserver.stop();
            button1.Enabled = true;
            button2.Enabled = false;
        }
    }
}
