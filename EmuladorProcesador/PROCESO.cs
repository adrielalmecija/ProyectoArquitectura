using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EmuladorProcesador
{
    class PROCESO
    {
        private ArrayList array = new ArrayList();
        private int inicio = 0;
        private int contadorRafaga=0;
        private int contadorBloqueado=0;
        private string nombre= "";
        public void agregarRafaga(string dato)
        {
            if (dato != "")
            {
                try
                {
                    array.Add(Convert.ToInt32(dato));
                    ContadorRafaga++;
                }
                catch (Exception)
                {
                    MessageBox.Show("Las rafagas deben ser numericas");
                }               
            }

        }

        public int tomarRafaga()
        {           
            int aux;   
            aux = Convert.ToInt32(array[0]);
            array.RemoveAt(0);
            ContadorRafaga--;
            
            return aux;
        }

        public void DevolverRafaga(int rafaga)
        {
            array.Insert(0, rafaga);
        }

        public int MostrarRafaga()
        {
            int aux;
            aux = Convert.ToInt32(array[0]);
            return aux;
        }

        public ArrayList Array { get => array; set => array = value; }
        public int Inicio { get => inicio; set => inicio = value; }
        public int ContadorRafaga { get => contadorRafaga; set => contadorRafaga = value; }
        public int ContadorBloqueado { get => contadorBloqueado; set => contadorBloqueado = value; }
        public string Nombre { get => nombre; set => nombre = value; }
    }
}
