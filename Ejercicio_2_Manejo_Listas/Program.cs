using System;
using System.Collections.Generic;

namespace Ejercicio_2_Manejo_Listas
{
    class Transaccion
    {
        public string Tipo { get; set; }
        public decimal Monto { get; set; }

        public Transaccion(string tipo, decimal monto)
        {
            Tipo = tipo;
            Monto = monto;
        }

        public override string ToString()
        {
            return $"{Tipo}: {Monto:C}";
        }
    }

    class Cuenta
    {
        public decimal Saldo { get; private set; }
        private List<Transaccion> transacciones;

        public Cuenta()
        {
            Saldo = 0;
            transacciones = new List<Transaccion>();
        }

        public void Depositar(decimal monto)
        {
            Saldo += monto;
            transacciones.Add(new Transaccion("Depósito", monto));
        }

        public bool Retirar(decimal monto)
        {
            if (monto > Saldo)
            {
                return false; 
            }
            Saldo -= monto;
            transacciones.Add(new Transaccion("Retiro", monto));
            return true; 
        }

        public void MostrarHistorial()
        {
            if (transacciones.Count == 0)
            {
                Console.WriteLine("No se han realizado transacciones.");
            }
            else
            {
                foreach (var transaccion in transacciones)
                {
                    Console.WriteLine(transaccion);
                }
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Cuenta cuenta = new Cuenta();
            int opcion = 0;

            do
            {
                Console.WriteLine("\n--- Menú de Opciones ---");
                Console.WriteLine("1. Consultar saldo");
                Console.WriteLine("2. Depositar dinero");
                Console.WriteLine("3. Retirar dinero");
                Console.WriteLine("4. Ver historial de transacciones");
                Console.WriteLine("5. Salir");
                Console.Write("Seleccione una opción: ");
                opcion = int.Parse(Console.ReadLine());

                switch (opcion)
                {
                    case 1:
                            ConsultarSaldo(cuenta);
                            break;

                    case 2:
                            Console.Write("Ingrese la cantidad a depositar: ");
                            decimal deposito = decimal.Parse(Console.ReadLine());
                            Depositar(cuenta, deposito);
                            break;

                    case 3:
                            Console.Write("Ingrese la cantidad a retirar: ");
                            decimal retiro = decimal.Parse(Console.ReadLine());
                            Retirar(cuenta, retiro);
                            break;

                    case 4:
                            MostrarHistorial(cuenta);
                            break;

                    case 5:
                            Console.WriteLine("Acciones ejecutadas correctamente. ¡Hasta pronto!");
                            break;

                    default:
                            Console.WriteLine("Opción no válida, por favor intente nuevamente.");
                            break;
                }
            } while (opcion != 5);
        }

        static void ConsultarSaldo(Cuenta cuenta)
        {
            Console.WriteLine($"Su saldo actual es: {cuenta.Saldo:C}");
        }

        static void Depositar(Cuenta cuenta, decimal monto)
        {
            cuenta.Depositar(monto);
            Console.WriteLine($"Depósito realizado. Su nuevo saldo es: {cuenta.Saldo:C}");
        }

        static void Retirar(Cuenta cuenta, decimal monto)
        {
            Console.Write("Ingrese la cantidad a retirar: ");
            decimal retiro = decimal.Parse(Console.ReadLine());

            if (!cuenta.Retirar(monto))
            {
                Console.WriteLine("Fondos insuficientes.");
            }
            else
            {
                Console.WriteLine($"Retiro realizado. Su nuevo saldo es: {cuenta.Saldo:C}");
            }
        }

        static void MostrarHistorial(Cuenta cuenta)
        {
            Console.WriteLine("Historial de transacciones:");
            cuenta.MostrarHistorial();
        }
    }
}
