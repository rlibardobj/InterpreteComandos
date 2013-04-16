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
            List<String> Result = (List<String>)Nucleo.EjecutarComando();
            foreach (String s in Result)
            {
                textBox1.Text = s + "\n";
            }
        }
    }
}
