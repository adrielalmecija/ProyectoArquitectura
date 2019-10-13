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
            P1groupBox.Enabled = false;
            P2groupBox.Enabled = false;
            P3groupBox.Enabled = false;
            P4groupBox.Enabled = false;

        }
        
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)//click inicio de la simulacion
        {
            Boolean flagFunciona = false;
            SISTEMA sistema = new SISTEMA();
            try
            {
                sistema.TiempoIO = Convert.ToInt32(textBox_IO.Text);

            }
            catch (Exception)
            {
                MessageBox.Show("El tiempo de I/O no es valido");
            }

            if (P1textBoxInicio.Text != "")
            {
                PROCESO p1 = new PROCESO();
                try
                {        
                    p1.Inicio = Convert.ToInt32(P1textBoxInicio.Text);
                    p1.Nombre = "Proceso 1";
                    p1.agregarRafaga(P1textBox1.Text);
                    p1.agregarRafaga(P1textBox2.Text);
                    p1.agregarRafaga(P1textBox3.Text);
                    p1.agregarRafaga(P1textBox4.Text);
                    sistema.AgregarProceso(p1);
                    flagFunciona = true;
                }
                catch (Exception)
                {
                    MessageBox.Show("El inicio 1 no es valido");
                }               
            }
            else
            {
                MessageBox.Show("El inicio 1 no es valido");
            }

            if (P2textBoxInicio.Text != "")
            {
                PROCESO p2 = new PROCESO();
                try
                {
                    p2.Inicio = Convert.ToInt32(P2textBoxInicio.Text);
                    p2.Nombre = "Proceso 2";
                    p2.agregarRafaga(P2textBox1.Text);
                    p2.agregarRafaga(P2textBox2.Text);
                    p2.agregarRafaga(P2textBox3.Text);
                    p2.agregarRafaga(P2textBox4.Text);
                    sistema.AgregarProceso(p2);
                    flagFunciona = true;
                }
                catch (Exception)
                {
                    MessageBox.Show("El inicio 2 no es valido");
                }
            }
            else
            {
                MessageBox.Show("El inicio 2 no es valido");
            }



            if (flagFunciona)
            {
                sistema.Ejecucion(); //comienzo de la simulacion
            }
            
            


        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
            
            
        }

        private void P1checkBox_CheckedChanged(object sender, EventArgs e)
        {
            if(P1checkBox.Checked == true)
            {
                P1groupBox.Enabled = true;
            }
            else
            {
                P1groupBox.Enabled = false;
            }
        }

        private void P2checkBox_CheckedChanged(object sender, EventArgs e)
        {
            if (P2checkBox.Checked == true)
            {
                P2groupBox.Enabled = true;
            }
            else
            {
                P2groupBox.Enabled = false;
            }
        }

        private void P3checkBox_CheckedChanged(object sender, EventArgs e)
        {
            if (P3checkBox.Checked == true)
            {
                P3groupBox.Enabled = true;
            }
            else
            {
                P3groupBox.Enabled = false;
            }
        }

        private void P4checkBox_CheckedChanged(object sender, EventArgs e)
        {
            if (P4checkBox.Checked == true)
            {
                P4groupBox.Enabled = true;
            }
            else
            {
                P4groupBox.Enabled = false;
            }
        }
    }
}
