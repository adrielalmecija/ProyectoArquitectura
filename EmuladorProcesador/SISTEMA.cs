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
        private int tiempo=0,contadorProcesando=0,tiempoIO = 0,fin=0;
        private ArrayList nuevo = new ArrayList();
        private ArrayList listo = new ArrayList();
        private ArrayList bloqueado = new ArrayList();
        private ArrayList procesos = new ArrayList();

        public int Tiempo { get => tiempo; set => tiempo = value; }
        public int ContadorProcesando { get => contadorProcesando; set => contadorProcesando = value; }
        public int TiempoIO { get => tiempoIO; set => tiempoIO = value; }

        public void Ejecucion()
        {
            Console.WriteLine("ejecutando " + procesos.Count);
            do
            {
                Console.Write(Tiempo);
                Tiempo++;
                if (bloqueado.Count > 0 ) //comprobacion de procesos bloqueados
                {
                    foreach (PROCESO p in bloqueado)
                    {
                        p.ContadorBloqueado++;
                        if (p.ContadorBloqueado >= tiempoIO && ejecutando != null)
                        {
                            Console.WriteLine("De Bloqueado a Listo " + nameof(p));
                            listo.Add(p);
                            bloqueado.Remove(p);                           
                            continue;
                        }
                        else
                        {
                            Console.WriteLine("Proceso " + nameof(p) + " bloqueado, tiempo " + p.ContadorBloqueado);
                        }
                    }
                }



                if (listo.Count > 0) // ejecuta
                {
                    
                    if (ejecutando == null)
                    {
                        fin = 0;
                        ejecutando = (PROCESO)listo[0];
                        fin = ejecutando.tomarRafaga();                       
                    }
                    if (ContadorProcesando >= fin)
                    {
                        Console.Write("Ejecutando " + nameof(ejecutando) + " " + ContadorProcesando);
                        ContadorProcesando++;
                    }
                    else if (ejecutando.ContadorRafaga < 1)
                    {
                        Console.WriteLine("Proceso " + nameof(ejecutando) + " terminado");
                        ejecutando = null;
                        procesos.RemoveAt(0);
                    }
                    else
                    {
                        bloqueado.Add(ejecutando);
                        ejecutando = null;
                    }
                    continue;
                }
                else
                {
                    if (nuevo.Count > 0) //comprueba si hay procesos nuevos para entrar a listo
                    {
                        
                        Console.WriteLine("S.O. " + nameof(ejecutando) + " de Nuevo a Listo ");
                        listo.Add(nuevo[0]);
                        nuevo.RemoveAt(0);
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



            } while (procesos.Count==0 || tiempo>10000);

        }

        public void AgregarProceso(PROCESO p)
        {
            procesos.Add(p);
        }
        

    }
}
