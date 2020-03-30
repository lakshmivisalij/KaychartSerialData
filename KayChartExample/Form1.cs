using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using rtChart;
using System.IO.Ports;

namespace KayChartExample
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            System.IO.Ports.SerialPort.GetPortNames();
            serialPort1.DataReceived += Serial_DataReceived;
        }
        kayChart kc;

        private void Serial_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {          
            string serialData = serialPort1.ReadLine();
         
            kc.TriggeredUpdate(Convert.ToDouble(serialData));
        }

        

        private void Form1_Load(object sender, EventArgs e)
        {
            serialPort1.Open();
            string serialData = serialPort1.ReadLine();
            serialData.Trim().ToString();
          
            kc = new kayChart(chart1, 60);
            kc.TriggeredUpdate(Convert.ToDouble(serialData));  
        }
    }
}
