using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using InterpreteComandos;

namespace InterpreteComandos
{
    public partial class Form1 : Form
    {
        Núcleo Nucleo = new Núcleo();
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            List<String> Result = (List<String>)Nucleo.ExecuteCommand(richTextBox1.Text);
            foreach (String s in Result)
            {
                richTextBox1.Text = richTextBox1.Text + s + "\n";
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            new V_procesos_servicios().Show();
        }
    }
}
