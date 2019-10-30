using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmuladorProcesador
{
    class MasCortoPrimero : SISTEMA
    {
        public MasCortoPrimero(FormGrafica formGrafica) : base(formGrafica)
        {
        }

        public override Boolean Ejecutando()
        {
            if (listo.Count > 0 || ejecutando != null) // ejecuta
            {

                if (ejecutando == null) //si nada se esta ejecuando ya, mete el primer proceso de listo a ejecutando
                {
                    
                    fin = 0;
                    contadorProcesando = 0;
                    ejecutando = (PROCESO)listo[0];
                    foreach (PROCESO p in listo)//revisa si no hay un proceso mas corto para meter a ejecutar
                    {                        
                        if(p.MostrarRafaga() < ejecutando.MostrarRafaga())
                        {                         
                            ejecutando = p;                            
                        }
                    }
                    listo.Remove(ejecutando);
                    fin = ejecutando.tomarRafaga();
                    formGrafica.MarcarCelda(tiempo, numSO, ejecutando.Nombre);
                    return true;
                }
                if (ContadorProcesando < fin) //Entra mientras haya procesado menos veces que la rafaga
                {
                    formGrafica.MarcarCelda(tiempo, numEjecutando, ejecutando.Nombre);
                    ContadorProcesando++; //contador de tiempos ejecutados
                }
                else if (ejecutando.ContadorRafaga < 1) //si no quedan mas rafagas termina el proceso
                {
                    formGrafica.MarcarCelda(tiempo, numTerminado, ejecutando.Nombre);
                    ejecutando = null;
                    terminados++;
                }
                else //si quedan envia el proceso a bloqueado
                {
                    formGrafica.MarcarCelda(tiempo, numSO, ejecutando.Nombre);
                    ejecutando.ContadorBloqueado = tiempo;
                    bloqueado.Add(ejecutando);
                    ejecutando = null;
                }
                return true;
            }

            return false;
        }
    }
}

