using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmuladorProcesador
{
    class SISTEMA
    {
        protected PROCESO ejecutando;
        private int tiempo=0,contadorProcesando=0,tiempoIO = 0;
        private ArrayList nuevo = new ArrayList();
        private ArrayList listo = new ArrayList();
        private ArrayList bloqueado = new ArrayList();
        private ArrayList procesos = new ArrayList();

        public int Tiempo { get => tiempo; set => tiempo = value; }
        public int ContadorProcesando { get => contadorProcesando; set => contadorProcesando = value; }
        public int TiempoIO { get => tiempoIO; set => tiempoIO = value; }

        public void Ejecucion()
        {

            do
            {
                Console.Write(Tiempo);
                Tiempo++;
                if (bloqueado[0] != null) //comprobacion de procesos bloqueados
                {
                    foreach (PROCESO p in bloqueado)
                    {
                        p.ContadorBloqueado++;
                        if (p.ContadorBloqueado >= tiempoIO)
                        {
                            listo.Add(p);
                            bloqueado.Remove(p);
                        }
                        else
                        {
                            Console.WriteLine("Proceso " + nameof(p) + " bloqueado, tiempo " + p.ContadorBloqueado);
                        }
                    }
                }



                if(ejecutando == null && listo[0] != null) // ejecuta
                {
                    ejecutando = (PROCESO)listo[0];
                    int fin = ejecutando.tomarRafaga();                    
                    if(ContadorProcesando <= fin)
                    {
                        Console.Write("Ejecutando " + nameof(ejecutando) + " " + ContadorProcesando);
                        ContadorProcesando++; 
                    }
                    if(ejecutando.ContadorRafaga < 1 )
                    {
                        Console.WriteLine("Proceso " + nameof(ejecutando) + " terminado");
                        ejecutando = null;
                    }
                    else
                    {
                        bloqueado.Add(ejecutando);
                    }
                    
                }
                else
                {
                    if (nuevo[0] != null) //comprueba si hay procesos nuevos para entrar a listo
                    {
                        ejecutando = (PROCESO)nuevo[0];
                        Console.WriteLine("S.O. " + nameof(ejecutando) + " de Nuevo a Listo ");
                    }
                    else //comprueba si hay proceso para entrar a nuevo
                    {
                            foreach (PROCESO p in procesos)
                            {
                                if (p.Inicio >= tiempo)
                                {
                                    nuevo.Add(p);
                                    procesos.Remove(p);
                                    break;
                                }
                            }
                    }

                }

                

            } while (false);

        }

        public void AgregarProceso(PROCESO p)
        {
            procesos.Add(p);
        }
        

    }
}
