﻿using System;
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
        protected PROCESO aux;
        private int tiempo=0,contadorProcesando=0,tiempoIO = 0,fin=0,terminados=0;
        private ArrayList nuevo = new ArrayList();
        private ArrayList listo = new ArrayList();
        private ArrayList bloqueado = new ArrayList();
        private ArrayList procesos = new ArrayList();
        private Boolean flagBloqueadoSalida = false;

        public int Tiempo { get => tiempo; set => tiempo = value; }
        public int ContadorProcesando { get => contadorProcesando; set => contadorProcesando = value; }
        public int TiempoIO { get => tiempoIO; set => tiempoIO = value; }

        public void Ejecucion()
        {
            Console.WriteLine("ejecutando " + procesos.Count);
            do
            {
                Console.WriteLine(Tiempo);
                Tiempo++;
                if (bloqueado.Count > 0 ) //comprobacion de procesos bloqueados
                {
                    flagBloqueadoSalida = false;
                    foreach (PROCESO p in bloqueado)
                    {
                        if ((p.ContadorBloqueado+TiempoIO) <= tiempo && ejecutando == null)
                        {
                            Console.WriteLine("De Bloqueado a Listo " + nameof(aux));
                            listo.Add(p);
                            bloqueado.Remove(p);
                            flagBloqueadoSalida = true;
                            break;
                        }
                        else
                        {
                            Console.WriteLine("Proceso " + nameof(aux) + " bloqueado, tiempo " + (tiempo - (p.ContadorBloqueado)));
                        }
                    }
                    if(flagBloqueadoSalida)
                    {
                        continue;
                    }
                }



                if (listo.Count > 0 || ejecutando!=null) // ejecuta
                {
                    
                    if (ejecutando == null)
                    {
                        fin = 0;
                        contadorProcesando = 0;
                        ejecutando = (PROCESO)listo[0];
                        listo.RemoveAt(0);
                        fin = ejecutando.tomarRafaga();
                        Console.WriteLine("De listo a ejecutando");
                        continue;

                    }
                    if (ContadorProcesando < fin)
                    {
                        Console.WriteLine("Ejecutando " + nameof(ejecutando) + " " + ContadorProcesando);
                        ContadorProcesando++;
                    }
                    else if (ejecutando.ContadorRafaga < 1)
                    {
                        Console.WriteLine("Proceso " + nameof(ejecutando) + " terminado");
                        ejecutando = null;
                        terminados++;
                    }
                        else
                        {
                            Console.WriteLine("De ejecutando a bloqueado");
                            ejecutando.ContadorBloqueado = tiempo;
                            bloqueado.Add(ejecutando);
                            ejecutando = null;
                        }
                        continue;
                }
                else
                {
                    if (nuevo.Count > 0) //comprueba si hay procesos nuevos para entrar a listo
                    {
                        
                        Console.WriteLine("S.O. <nombre proceso>"  + " de Nuevo a Listo ");
                        listo.Add(nuevo[0]);
                        nuevo.RemoveAt(0);
                    }
                    else //comprueba si hay proceso para entrar a nuevo
                    {
                        foreach (PROCESO p in procesos)
                        {
                            if (p.Inicio <= tiempo)
                            {
                                nuevo.Add(p);
                                procesos.Remove(p);
                                Console.WriteLine("S.O " + nameof(p) + " ingresa a Nuevo");
                                break;
                            }
                        }
                    }

                }



            } while (terminados == 0 && tiempo<10000);

        }

        public void AgregarProceso(PROCESO p)
        {
            procesos.Add(p);
        }
        

    }
}
