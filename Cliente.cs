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
    class Cliente : ClaseAbstracta
    {
        private void GenerarCuenta()
        {
            Random generador = new Random();
            int c = generador.Next(11, 17);
            numeroDeLaCuenta = c * 1327;
            Console.WriteLine("Su nueva cuenta bancaria es " + numeroDeLaCuenta);
        }

        private void GenerarPuntosAlAzar()
        {
            Random generador = new Random();
            int num = generador.Next(0, 10);
            puntos = num * 100;
            Console.WriteLine("¡Felicitaciones! usted ha sido beneficiado con {0} puntos que podrá redimir en cualquiera de nuestros cajeros", puntos);
        }

        public void InscriccionDeCuentasDestinos()
        {
            ValidarLong("Digite una cuenta que desee registrar: ", out long cuenta);
            if (!CuentaExiste(cuenta))
            {
                otrasCuentasBancarias.Add(cuenta);
                Console.WriteLine("Ahora ya puede realizar transferencias a {0}", cuenta);
            }
            else
            {
                Console.WriteLine("La cuenta ya se encuentra registrada.");
            }
        }
        public bool LoguearCliente()
        {
            Console.WriteLine("Ingrese sus datos para iniciar los servicios del cajero");
            ValidarLong("Cuenta no.: ", out long lecturaCuenta);
            Console.Write("Contraseña: ");
            string lecturaContrasenia = Console.ReadLine();

            return (lecturaCuenta == numeroDeLaCuenta && lecturaContrasenia.Equals(contrasenia));
        }
        public void ConsultaDeSaldo()
        {
            Console.WriteLine("Usted tiene en su cuenta ${0} como saldo a favor", saldoAFavor);
        }
        public void Retiros()
        {
            ValidarDouble("Por favor, digite cantidad a retirar: ", out double cantidad);
            if (cantidad <= saldoAFavor && cantidad + acumuladorDeRetiros <= 2000000)
            {
                retiro = cantidad;
                Console.WriteLine("Su retiro se ha hecho con éxito.");
                saldoAFavor -= retiro;
                acumuladorDeRetiros += retiro;
            }
            else if (cantidad >= saldoAFavor)
                Console.WriteLine("Usted no tiene saldo suficiente para continuar esta operación.");
            else
                Console.WriteLine("Lo sentimos, el monto diario no puede ser mayor a $2.000.000");

        }
        public void Transferencias()
        {
            ValidarDouble("Monto de transferencia: ", out double cantidad);
            ValidarLong("Cuenta destino: ", out long cuentaDestino);
            if (CuentaExiste(cuentaDestino) && cantidad <= saldoAFavor)
            {
                saldoAFavor -= cantidad;
                Console.WriteLine("La transferencia a la cuenta {0} fue exitosa.", cuentaDestino);
            }
            else if (!CuentaExiste(cuentaDestino)) Console.WriteLine("La cuenta destino no está registrada. La operación no se puede completar.");
            else Console.WriteLine("Saldo insuficiente. La transferencia no se pudo realizar.");
        }

        public void consultaDePuntos()
        {
            Console.WriteLine("puntos vive Colombia en su cuenta:  " + puntos);
        }

        public void CanjearPuntos()
        {
            ValidarEntero("Ingrese cantidad de puntos a canjear: ", out int cantidad);
            if (cantidad <= puntos)
            {
                Console.WriteLine("Los puntos vive Colombia se han canjeado.");
                saldoAFavor += (cantidad * 1000);
                puntos -= cantidad;
            }
            else
                Console.WriteLine("Cantidad insuficiente de puntos acumulados");
        }

        public void MostrarCuentasInscritas()
        {
            if (otrasCuentasBancarias.Count > 0)
            {
                Console.WriteLine("Usted puede transferir a las siguientes cuentas: ");
                foreach (long cuenta in otrasCuentasBancarias)
                    Console.WriteLine(cuenta);
            }
            else
                Console.WriteLine("Su lista de cuentas a transferir está vacía");

        }
        private bool CuentaExiste(long cuenta)
        {
            return otrasCuentasBancarias.Exists(x => x == cuenta);
        }
        private void ValidarDouble(string mensaje, out double numero)
        {
            double i = -1;
            while (i == -1)
            {
                Console.Write(mensaje);
                i = LeerNumeroDouble(Console.ReadLine());
            }
            numero = i;
        }
        private void ValidarEntero(string mensaje, out int numero)
        {
            int i = -1;
            while (i == -1)
            {
                Console.Write(mensaje);
                i = LeerNumeroInt(Console.ReadLine());
            }
            numero = i;
        }

        private void ValidarLong(string mensaje, out long numero)
        {
            long i = -1;
            while (i == -1)
            {
                Console.Write(mensaje);
                i = LeerNumeroInt(Console.ReadLine());
            }
            numero = i;
        }
        public long numeroDeLaCuenta { get; set; }
        public string contrasenia { get; set; }

        public double saldoAFavor { get; set; }

        public int puntos { get; set; }
        public double retiro { get; set; }

        public double acumuladorDeRetiros { get; set; }

        private List<long> otrasCuentasBancarias = new List<long>();

        public Cliente()
        {
            CentrarTexto();
            Console.WriteLine("INICIALIZACIÓN DE LA CUENTA BANCARIA");

            Console.Write("Nombre del usuario: ");
            nombre = Console.ReadLine();
            Console.Write("Ingrese una contraseña para su cuenta: ");
            contrasenia = Console.ReadLine();

            ValidarDouble("Digite un saldo a favor inicial: ", out double saldo);
            saldoAFavor = saldo;
            Console.WriteLine();
            GenerarPuntosAlAzar();
            GenerarCuenta();
        }
    }
}

