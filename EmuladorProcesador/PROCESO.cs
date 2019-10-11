using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmuladorProcesador
{
    class PROCESO
    {
        private ArrayList array = new ArrayList();
        private Boolean nuevo = false,listo = false, bloqueado = false, ejecutando = false, terminado = false;
        private int inicio = 0;
        public void agregarRafaga(string dato)
        {

            try
            {
                array.Add(Convert.ToInt32(dato));
                
            }
            catch (Exception)
            {               
            }
        }

        public int tomarRafaga()
        {
            
            int aux;   
            aux = Convert.ToInt32(array[0]);
            array.RemoveAt(0);
            
            return aux;
        }

        public void MostrarRafagas()
        {
            foreach(int i in array)
            {
                Console.WriteLine(i);
            }
        }

        public ArrayList Array { get => array; set => array = value; }
        public bool Nuevo { get => nuevo; set => nuevo = value; }
        public bool Listo { get => listo; set => listo = value; }
        public bool Bloqueado { get => bloqueado; set => bloqueado = value; }
        public bool Ejecutando { get => ejecutando; set => ejecutando = value; }
        public bool Terminado { get => terminado; set => terminado = value; }
        public int Inicio { get => inicio; set => inicio = value; }
    }
}
