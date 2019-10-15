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
    
    public partial class FormGrafica : Form
    {
        public FormGrafica()
        {
            InitializeComponent();
        }
         public void AgregarRow(int tiempo)
        {
            dataGridGrafica.Rows.Add();
            dataGridGrafica.Rows[tiempo].HeaderCell.Value = Convert.ToString(tiempo);
        }

        public void MarcarCelda(int tiempo,int numCelda,string proceso)
        {
            dataGridGrafica.Rows[tiempo].Cells[numCelda].Value = proceso;
            switch(proceso)
            {
                case "Proceso 1":
                    dataGridGrafica.Rows[tiempo].Cells[numCelda].Style.BackColor = Color.MediumOrchid;
                    break;
                case "Proceso 2":
                    dataGridGrafica.Rows[tiempo].Cells[numCelda].Style.BackColor = Color.MediumSeaGreen;
                    break;
                case "Proceso 3":
                    dataGridGrafica.Rows[tiempo].Cells[numCelda].Style.BackColor = Color.MediumSpringGreen;
                    break;
                case "Proceso 4":
                    dataGridGrafica.Rows[tiempo].Cells[numCelda].Style.BackColor = Color.MediumPurple;
                    break;
                
            }
        }
        
    }
}
