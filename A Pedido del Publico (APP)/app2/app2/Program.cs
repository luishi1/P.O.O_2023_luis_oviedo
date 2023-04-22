using System;

namespace app2
{
    internal class Program
    {
        class cajero
        {
            public float saldo;
            public float monto;
            public cajero() { }

            public cajero(float saldo, float monto)
            {
                this.saldo = saldo;
                this.monto = monto;
            }

            public void depositar(float saldo, float monto , cajero cajero1)
            {
                cajero1.monto = cajero1.monto + saldo;
                Console.WriteLine("Saldo depositado correctamente");
            
            }

            public void retirar(float saldo , float monto , cajero cajero1)
            {
                cajero1.monto = cajero1.monto - saldo;
                Console.WriteLine("Saldo retirado correctamente");
              
            }

            public void consultar (float monto, cajero cajero1)
            {
                Console.WriteLine("Usted posee un monton de " + cajero1.monto );
            }
            static void Main(string[] args)
            {
                cajero cajero1 = new cajero();
                int opcion;
                float saldo;
                float monto = 0;
                while (true)
                {
                  
                    Console.Clear();
                    Console.WriteLine("CAJERO OPCIONES WOOOOOO");
                    Console.WriteLine("1. REALIZAR DEPOSITO");
                    Console.WriteLine("2. REALIZAR RETIRO");
                    Console.WriteLine("3. CONSULTAR SALDO");
                    Console.WriteLine("4. salir");
                    opcion = int.Parse(Console.ReadLine());
                    if (opcion == 1)
                    {
                        Console.Clear();
                        Console.WriteLine("INGRESE EL MONTO QUE DECIDA INGRESAR");
                        saldo = float.Parse(Console.ReadLine());
                        cajero1.depositar(saldo, monto , cajero1);
                        Console.ReadKey();
                    }
                    if (opcion == 2)
                    {
                        Console.Clear();
                        Console.WriteLine("INGRESE EL MONTO QUE DECIDIO RETIRAR");
                        saldo = float.Parse(Console.ReadLine());
                        cajero1.retirar(saldo, monto, cajero1);
                        Console.ReadKey();
                    }
                    if (opcion == 3)
                    {
                        Console.Clear() ;
                        cajero1.consultar(monto , cajero1);
                        Console.ReadKey();
                    }
                    if (opcion == 4)
                    {
                        break;

                    }
                }
            }
        }
    }
}
