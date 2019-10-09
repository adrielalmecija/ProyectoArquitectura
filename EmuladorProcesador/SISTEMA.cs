using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmuladorProcesador
{
    class SISTEMA
    {
        protected PROCESO ejecutando;
        int tiempo=0,contadorProcesando=0;
        public void Ejecucion()
        {
            Console.Write(tiempo);
            tiempo++;
            do
            {
                if(ejecutando == null && ejecutando.Listo == true) // cambiar ejecutando listo por fila de listo de SISTEMA
                {
                    int fin = ejecutando.tomarRafaga();
                    do
                    {
                        Console.Write("Ejecutando " + nameof(ejecutando));
                        contadorProcesando++; 
                    } while (contadorProcesando < fin);
                    

                }

            } while (false);

        }
        

    }
}
