using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EmuladorProcesador
{

    static class Program
    {

        
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());

            


        }
        //static Form1 form;
        public static void Mostrar()
        {
            Console.WriteLine("alg o s");
        }
        public static void Emular()
        {
            
        }
    }
}
