using System;
using System.Collections.Generic;
using System.Text;

namespace Programacion_faseFinal_cajero
{
     /*
     * nombre completo : Johan Sebastian Hernandez 
       Nombre tutor :    JORGE ALBERTO CORREA JARAMILLO	
       Código de grupo : 213023_29 
     * 
     */
    class ClaseAbstracta
    {
        public string nombre { get; set; }
        public string direccion { get; set; }


        public long LeerNumeroLong(string numero)
        {
            long num = -1;
            try
            {
                num = long.Parse(numero);
            }
            catch (Exception)
            {
                Console.WriteLine("Error en la lectura del numero");
            }
            return num;
        }

        public int LeerNumeroInt(string numero)
        {
            int num = -1;
            try
            {
                num = int.Parse(numero);
            }
            catch (Exception)
            {
                Console.WriteLine("Error en la lectura del numero");
            }
            return num;
        }

        public double LeerNumeroDouble(string numero)
        {
            double num = -1;
            try
            {
                num = double.Parse(numero);
            }
            catch (Exception)
            {
                Console.WriteLine("Error en la lectura del numero");
            }
            return num;
        }

        public void CentrarTexto()
        {
            Console.Write("                                   ");
        }

    }
}
