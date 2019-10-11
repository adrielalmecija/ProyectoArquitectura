using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EmuladorProcesador
{
    public partial class Form1 : Form
    {

 
        public Form1()
        {
            InitializeComponent();
            

        }
        
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)//click inicio de la simulacion
        {
            SISTEMA sistema = new SISTEMA();
            sistema.TiempoIO = Convert.ToInt32(textBox_IO.Text);
            if (P1textBoxInicio.Text != "")
            {
                PROCESO p1 = new PROCESO();
                try
                {        
                    p1.Inicio = Convert.ToInt32(P1textBoxInicio.Text);
                    p1.agregarRafaga(P1textBox1.Text);
                    p1.agregarRafaga(P1textBox2.Text);
                    p1.agregarRafaga(P1textBox3.Text);
                    p1.agregarRafaga(P1textBox4.Text);
                    sistema.AgregarProceso(p1);
                }
                catch (Exception)
                {
                    MessageBox.Show("El inicio 1 no es valido") ;
                }
                p1.MostrarRafagas();
            }
            sistema.Ejecucion();
            


        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
            
            
        }

     
    }
}
