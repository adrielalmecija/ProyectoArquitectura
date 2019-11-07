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
            comboBoxPrioridad.Items.Add("FIFO");
            comboBoxPrioridad.Items.Add("Mas corto primero");
            comboBoxPrioridad.Items.Add("Mas corto primero c/desalojo");
            comboBoxPrioridad.Items.Add("Round Robin");
            comboBoxPrioridad.SelectedIndex = 0;
            comboBoxPrioridad.DropDownStyle = ComboBoxStyle.DropDownList;
            textBoxTiempodeRafaga.Enabled = false;
            labelTiempodeRafaga.Enabled = false;

        }
        

        private void button1_Click(object sender, EventArgs e)//click inicio de la simulacion
        {
            
            FormGrafica fGrafica = new FormGrafica();
            SISTEMA sistema = new SISTEMA(fGrafica);
            Boolean flagFunciona = true;

            switch(comboBoxPrioridad.SelectedIndex)
            {
                case 0:
                    sistema = new FIFO(fGrafica);
                    break;
                case 1:
                    sistema = new MasCortoPrimero(fGrafica);
                    break;
                case 2:
                    sistema = new MasCortoPrimeroCD(fGrafica);
                    break;
                case 3:
                    sistema = new RoundRobin(fGrafica);
                    try
                    {
                        sistema.TiempodeRoundRobin = Convert.ToInt32(textBoxTiempodeRafaga.Text);
                    }
                    catch (FormatException)
                    {
                        flagFunciona = false;
                    }
                    
                    break;
            }
            

            try
            {
                sistema.TiempoIO = Convert.ToInt32(textBox_IO.Text);

            }
            catch (Exception)
            {
                flagFunciona = false;
                MessageBox.Show("El tiempo de I/O no es valido");
            }

            if(P1checkBox.Checked)
            {
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
                        
                    }
                    catch (ExcepcionNoAnda)
                    {

                    }
                    catch (FormatException)
                    {
                        MessageBox.Show("El inicio 1 no es valido");
                    }
                }
                else
                {
                    MessageBox.Show("El inicio 1 no es valido");
                } 
            }


            if(P2checkBox.Checked)
            {
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
                        
                    }
                    catch (ExcepcionNoAnda)
                    {

                    }
                    catch (FormatException)
                    {
                        MessageBox.Show("El inicio 2 no es valido");
                    }
                }
                else
                {
                    MessageBox.Show("El inicio 2 no es valido");
                }
            }

            if (P3checkBox.Checked)
            {
                if (P3textBoxInicio.Text != "")
                {
                    PROCESO p3 = new PROCESO();
                    try
                    {
                        p3.Inicio = Convert.ToInt32(P3textBoxInicio.Text);
                        p3.Nombre = "Proceso 3";
                        p3.agregarRafaga(P3textBox1.Text);
                        p3.agregarRafaga(P3textBox2.Text);
                        p3.agregarRafaga(P3textBox3.Text);
                        p3.agregarRafaga(P3textBox4.Text);
                        sistema.AgregarProceso(p3);
                        
                    }
                    catch (FormatException)
                    {
                        MessageBox.Show("El inicio 3 no es valido");
                    }
                    catch (ExcepcionNoAnda)
                    {

                    }
                }
                else
                {
                    MessageBox.Show("El inicio 3 no es valido");
                }
            }

            if (P4checkBox.Checked)
            {
                if (P4textBoxInicio.Text != "")
                {
                    PROCESO p4 = new PROCESO();
                    try
                    {
                        p4.Inicio = Convert.ToInt32(P4textBoxInicio.Text);
                        p4.Nombre = "Proceso 4";
                        p4.agregarRafaga(P4textBox1.Text);
                        p4.agregarRafaga(P4textBox2.Text);
                        p4.agregarRafaga(P4textBox3.Text);
                        p4.agregarRafaga(P4textBox4.Text);
                        sistema.AgregarProceso(p4);
                        
                    }
                    catch (ExcepcionNoAnda)
                    {
                        
                    }
                    catch (FormatException)
                    {
                        MessageBox.Show("El inicio 4 no es valido");
                    }
                }
                else
                {
                    MessageBox.Show("El inicio 4 no es valido");
                }
            }


            if (sistema.CantidaddeProcesos() > 0 && flagFunciona)
            {
                                    
                sistema.Ejecucion(); //comienzo de la simulacion
                fGrafica.ShowDialog();

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

        private void P4checkBox_CheckedChanged_1(object sender, EventArgs e)
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

        private void comboBoxPrioridad_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(comboBoxPrioridad.SelectedIndex==3)
            {
                textBoxTiempodeRafaga.Enabled = true;
                labelTiempodeRafaga.Enabled = true;
            }
            else
            {
                textBoxTiempodeRafaga.Enabled = false;
                labelTiempodeRafaga.Enabled = false;
            }
        }

        private void labelTiempodeRafaga_Click(object sender, EventArgs e)
        {

        }
    }
}
