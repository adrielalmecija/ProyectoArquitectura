using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EmuladorProcesador
{
    class SISTEMA
    {
        protected PROCESO ejecutando;
        protected PROCESO aux;
        private int tiempo = -1, contadorProcesando = 0, tiempoIO = 0, fin = 0, terminados = 0,cantidadProcesos;
        private int politicaDeTrabajo=0;
        private ArrayList nuevo = new ArrayList();
        private ArrayList listo = new ArrayList();
        private ArrayList bloqueado = new ArrayList();
        private ArrayList procesos = new ArrayList();
        private Boolean flagBloqueadoSalida = false, flagNuevoSalida = false;
        private FormGrafica formGrafica;
        private int numSO = 0, numNuevo = 1, numListo = 2, numBloqueado = 3, numEjecutando = 4, numTerminado = 5;
        public SISTEMA(FormGrafica formGrafica)
        {
            this.formGrafica = formGrafica;
        }
        
        public int Tiempo { get => tiempo; set => tiempo = value; }
        public int ContadorProcesando { get => contadorProcesando; set => contadorProcesando = value; }
        public int TiempoIO { get => tiempoIO; set => tiempoIO = value; }
        public int PoliticaDeTrabajo { get => politicaDeTrabajo; set => politicaDeTrabajo = value; }
        
        public void Ejecucion()
        {
            
            cantidadProcesos = procesos.Count; //leo la cantidad de procesos agregados para esta ejecucion
            do //loop de ejecucion de la emulacion
            {
                Tiempo++; // contador de unidades de tiempo
                Console.WriteLine(Tiempo);
                
                formGrafica.AgregarRow(tiempo);

                MostrarProcesos(listo, tiempo, numListo);
                MostrarProcesos(nuevo, tiempo, numNuevo);
                MostrarProcesos(bloqueado, tiempo, numBloqueado);
 
                    foreach (PROCESO p in bloqueado)//comprobacion de procesos bloqueados
                    {
                        if ((p.ContadorBloqueado+TiempoIO) < tiempo && ejecutando == null)
                        {
                            Console.WriteLine("S.O de Bloqueado a Listo " + p.Nombre);
                            formGrafica.MarcarCelda(Tiempo, numSO, p.Nombre);
                            listo.Add(p);
                            bloqueado.Remove(p);
                            flagBloqueadoSalida = true;
                            break;
                        }
                        else
                        {
                            formGrafica.MarcarCelda(tiempo, numBloqueado, p.Nombre);
                            Console.WriteLine("Proceso " + p.Nombre + " bloqueado, tiempo " + (tiempo - (p.ContadorBloqueado)));
                        }
                    }
                    if(flagBloqueadoSalida)
                    {
                        flagBloqueadoSalida = false;
                        continue;//si ejecuto el if continua al proximo tiempo de ejecucion
                    }

                if(ejecutando == null) //comprueba si hay proceso para entrar a nuevo
                {
                    flagNuevoSalida = false;
                    foreach (PROCESO p in procesos)
                    {
                        if (p.Inicio <= tiempo)
                        {
                            nuevo.Add(p);
                            procesos.Remove(p);
                            formGrafica.MarcarCelda(tiempo, numSO, p.Nombre);
                            Console.WriteLine("S.O " + p.Nombre + " ingresa a Nuevo");
                            flagNuevoSalida = true;
                            break;
                        }
                    }
                    if(flagNuevoSalida)
                    {
                        continue;
                    }
                }

                if (nuevo.Count > 0 && ejecutando == null) //comprueba si hay procesos nuevos para entrar a listo
                {
                    aux = (PROCESO)nuevo[0];
                    formGrafica.MarcarCelda(tiempo, numSO, aux.Nombre);
                    Console.WriteLine("S.O. " + aux.Nombre + " de Nuevo a Listo ");
                    listo.Add(nuevo[0]);
                    nuevo.RemoveAt(0);
                    continue;
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
                        formGrafica.MarcarCelda(tiempo, numSO, ejecutando.Nombre);
                        Console.WriteLine("S.O "+ ejecutando.Nombre + " De listo a ejecutando");
                        continue;

                    }
                    if (ContadorProcesando < fin)
                    {
                        Console.WriteLine("Ejecutando " + ejecutando.Nombre + " " + ContadorProcesando);
                        formGrafica.MarcarCelda(tiempo, numEjecutando , ejecutando.Nombre);
                        ContadorProcesando++;
                    }
                    else if (ejecutando.ContadorRafaga < 1)
                    {
                        Console.WriteLine("S.O " + ejecutando.Nombre + " terminado");
                        formGrafica.MarcarCelda(tiempo, numTerminado, ejecutando.Nombre);
                        ejecutando = null;
                        terminados++;
                    }
                        else
                        {
                            Console.WriteLine("S.O " + ejecutando.Nombre + " de ejecutando a bloqueado");
                            formGrafica.MarcarCelda(tiempo, numSO, ejecutando.Nombre);
                            ejecutando.ContadorBloqueado = tiempo;
                            bloqueado.Add(ejecutando);
                            ejecutando = null;
                        }
                        continue;
                }



            } while (terminados != cantidadProcesos && tiempo<10000);//(tiempo < a 10mil en caso de falla no quede pegado)
            
            
        }

        public void AgregarProceso(PROCESO p)
        {
            procesos.Add(p);
        }

        public void MostrarProcesos(ArrayList array, int tiempo, int numCelda)
        {
            foreach(PROCESO p in array)
            {
                formGrafica.MarcarCelda(tiempo, numCelda, p.Nombre);
            }
        }
        

    }
}
