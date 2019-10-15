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
         public void AgregarRow()
        {
            this.dataGridGrafica.Rows.Add();
        }
        
    }
}
