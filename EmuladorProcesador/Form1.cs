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

        PROCESO p1 = new PROCESO();
        public Form1()
        {
            InitializeComponent();
            

        }
        
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //click inicio de la simulacion
            Program.Mostrar();
            p1.agregarRafaga(Convert.ToInt32(P1textBox1.Text));
            p1.agregarRafaga(Convert.ToInt32(P1textBox2.Text));
            p1.agregarRafaga(Convert.ToInt32(P1textBox3.Text));
            p1.agregarRafaga(Convert.ToInt32(P1textBox4.Text));

            Console.WriteLine( p1.tomarRafaga());
            Console.WriteLine( p1.tomarRafaga());
            Console.WriteLine( p1.tomarRafaga());
            Console.WriteLine( p1.tomarRafaga());


        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
            
            
        }

     
    }
}
