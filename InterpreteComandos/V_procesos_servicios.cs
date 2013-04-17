using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace InterpreteComandos
{
    public partial class V_procesos_servicios : Form
    {
        private procesos p = new procesos();
        private Thread verificar_procesos;
        public V_procesos_servicios()
        {
           
            InitializeComponent();
           
        }
       
        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

            if (button1.Text == "Iniciar")
            {
                button1.Text = "Detener";
                p.procesos_ejecución();
                actualizartabla();
                verificar_procesos = new Thread(hilo_tabla);                
                verificar_procesos.Start();
            }
            else {
                button1.Text = "Iniciar";
                verificar_procesos.Abort();
                }
        }

        public void actualizartabla() { 
            
            lista_procesos temp = p.primero;
            while(temp != null)
            {
                String[] item = {temp.id,temp.nombre, temp.descripcion, temp.cpu, temp.memoria, temp.usuario};
                dataGridView1.Rows.Add(item);
                temp = temp.sig;
            }  
        }

        public void hilo_tabla() {
            if (p.actualizar()) {
                p.procesos_ejecución();
                this.Invoke((MethodInvoker) delegate {
                dataGridView1.Rows.Clear();
                actualizartabla();
                });
            }       
         
        }
    }
}
