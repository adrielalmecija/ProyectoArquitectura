using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmuladorProcesador
{
    class MasCortoPrimeroCD : MasCortoPrimero
    {
        public MasCortoPrimeroCD(FormGrafica formGrafica) : base(formGrafica)
        {
        }

        public override Boolean Nuevos()
        {
                foreach (PROCESO p in procesos)//comprueba si hay proceso para entrar a nuevo
                {
                    if (p.Inicio <= tiempo)
                    {
                        if(ejecutando!=null)
                        {
                            ejecutando.DevolverRafaga((fin-ContadorProcesando));
                            listo.Insert(0, ejecutando);
                            formGrafica.MarcarCelda(tiempo, numSO, ejecutando.Nombre);
                            ejecutando = null;
                            return true;
                        }else
                        {
                            nuevo.Add(p);
                            procesos.Remove(p);
                            formGrafica.MarcarCelda(tiempo, numSO, p.Nombre);
                            return true;
                        }
                    }
                }
            return false;
        }
    }
}
