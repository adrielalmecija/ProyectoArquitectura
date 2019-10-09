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

        public void agregarRafaga(int rafaga)
        {
            array.Add(rafaga);
        }

        public int tomarRafaga()
        {
            
            int aux;
            aux = Convert.ToInt32(array[array.Count - 1]);
            array.RemoveAt(array.Count - 1);
            return aux;
        }

        public ArrayList Array { get => array; set => array = value; }
        public bool Nuevo { get => nuevo; set => nuevo = value; }
        public bool Listo { get => listo; set => listo = value; }
        public bool Bloqueado { get => bloqueado; set => bloqueado = value; }
        public bool Ejecutando { get => ejecutando; set => ejecutando = value; }
        public bool Terminado { get => terminado; set => terminado = value; }

        
    }
}
