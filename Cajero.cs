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
    class Cajero : ClaseAbstracta
    {
        public void PresentacionAutor()
        {
            CentrarTexto();
            Console.WriteLine("Universidad Nacional Abierta y a Distancia");
            CentrarTexto();
            Console.WriteLine("              Etapa 5");
            CentrarTexto();
            Console.WriteLine("Implementación de una solución funcional");
            CentrarTexto();
            Console.WriteLine("   Autor: Johan Sebastián Hernandez ");
            CentrarTexto();
            Console.WriteLine("    Tutor: Ing. JORGE ALBERTO CORREA JARAMILLO	");
            Console.Write("\n\n\nPresione una tecla para iniciar...");
            Console.ReadKey();
            Console.Clear();
        }
        public void IniciarServicio()
        {
            CentrarTexto();
            Console.WriteLine("BIENVENIDO A LOS SERVICIOS DE CAJERO AUTOMÁTICO");
            CentrarTexto();
            Console.WriteLine("Registrese como usuario en nuestro Banco");
            usuario = new Cliente();
            Console.WriteLine("\nSu registro ha finalizado...");
            Console.ReadKey();
            Console.WriteLine();
            int contadorIntentos = 3;
            while (true)
            {
                Console.WriteLine();
                if (usuario.LoguearCliente())
                {
                    Console.Clear();

                    string opcion = "";
                    while (opcion != "7")
                    {
                        Console.Clear();
                        opcion = OpcionesCajero();
                        switch (opcion)
                        {
                            case "1":
                                usuario.ConsultaDeSaldo();
                                break;
                            case "2":
                                usuario.Retiros();
                                break;
                            case "3":
                                usuario.Transferencias();
                                break;
                            case "4":
                                usuario.consultaDePuntos();
                                break;
                            case "5":
                                usuario.CanjearPuntos();
                                break;
                            case "6":
                                usuario.InscriccionDeCuentasDestinos();
                                break;
                            case "7":
                                Console.WriteLine("Que tenga un buen dia. Vuelva pronto.");
                                break;
                        }
                        Console.ReadKey();
                    }
                    break;
                }
                else
                {
                    contadorIntentos--;

                    if (contadorIntentos == 0)
                    {
                        Console.WriteLine("Su cuenta ha sido temporalmente bloqueada");
                        Console.WriteLine("Diríjase a una de nuestras oficinas");
                        Console.ReadKey();
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Los datos son incorrectos...");
                        Console.WriteLine("Usted tiene máximo {0} intentos adicionales", contadorIntentos);
                    }
                }
            }

        }

        public string OpcionesCajero()
        {
            Console.WriteLine("1....Consultar saldo");
            Console.WriteLine("2....Retirar");
            Console.WriteLine("3....Transferir");
            Console.WriteLine("4....Consultar puntos Vive Colombia ");
            Console.WriteLine("5....Canjear puntos Vive Colombia");
            Console.WriteLine("6....Inscribir cuenta amiga");
            Console.WriteLine("7....Salir");
            Console.Write("opción: ");
            string lectura = Console.ReadLine();
            return lectura;
        }

        Cliente usuario;
    }
}

