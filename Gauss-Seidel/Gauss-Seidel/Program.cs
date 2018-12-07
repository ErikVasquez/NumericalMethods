using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Threading.Tasks;

namespace MetodoGaussSeidel
{
    class Program
    {

        static void Main(string[] args)
        {
            double[,] Numeros = new double[3, 4];
            double[] Incognitas = new double[3];
            int TipoParada;
            double Valor;
            bool Salir = false, SalirProceso = false;
            do
            {
                do
                {
                    Console.Clear();
                    Console.WriteLine("\t\t\t\tMetodo Gauss-Seidel");
                    Console.WriteLine("\t\t\t   a11x1 + a12x2 + a13x3 = a14\n" +
                                      "\t\t\t   a21x1 + a22x2 + a23x3 = a24\n" +
                                      "\t\t\t   a31x1 + a32x2 + a33x3 = a34\n");
                    try
                    {
                        for (int Contador1 = 1; Contador1 < 4; Contador1++)
                        {
                            for (int Contador2 = 1; Contador2 < 5; Contador2++)
                            {
                                Console.Write("Ingrese a" + Contador1 + Contador2 + ": ");
                                Numeros[(Contador1 - 1), (Contador2 - 1)] = Convert.ToDouble(Console.ReadLine());
                            }
                        }
                        SalirProceso = true;
                    }
                    catch
                    {
                        SalirProceso = false;
                        Console.WriteLine("Ocurrio un error.\nPresione una tecla para continuar.");
                        Console.ReadKey();
                    }
                } while (SalirProceso == false);

                do
                {
                    Console.Clear();
                    Console.WriteLine("\t\t\t\tMetodo Gauss-Seidel");
                    Console.WriteLine("\t\t\t   a11x1 + a12x2 + a13x3 = a14\n" +
                                      "\t\t\t   a21x1 + a22x2 + a23x3 = a24\n" +
                                      "\t\t\t   a31x1 + a32x2 + a33x3 = a34\n");
                    try
                    {
                        for (int Contador1 = 1; Contador1 < 4; Contador1++)
                        {
                            Console.Write("Ingrese x" + Contador1 + ": ");
                            Incognitas[(Contador1 - 1)] = Convert.ToDouble(Console.ReadLine());
                        }
                        SalirProceso = true;
                    }
                    catch
                    {
                        SalirProceso = false;
                        Console.WriteLine("Ocurrio un error.\nPresione una tecla para continuar.");
                        Console.ReadKey();
                    }
                } while (SalirProceso == false);

                Proceso P = new Proceso(Numeros, Incognitas);
                do
                {
                    Console.Clear();
                    Console.WriteLine("\t\t\t\tMetodo Gauss-Seidel");
                    Console.WriteLine("\t\t\t   a11x1 + a12x2 + a13x3 = a14\n" +
                                      "\t\t\t   a21x1 + a22x2 + a23x3 = a24\n" +
                                      "\t\t\t   a31x1 + a32x2 + a33x3 = a34\n");
                    Console.WriteLine("Ingresa el numero de la opcion que desee:");
                    Console.WriteLine("1.- Por error");
                    Console.WriteLine("2.- Por iteraccion");
                    Console.Write("R: ");
                    try
                    {
                        TipoParada = Convert.ToInt32(Console.ReadLine());
                        Console.Write("Ingresa el valor: ");
                        Valor = Convert.ToDouble(Console.ReadLine());
                        if (TipoParada == 1)
                        {
                            P.Solucion(TipoParada, Valor);
                            SalirProceso = true;
                        }
                        else if (TipoParada == 2)
                        {
                            P.Solucion(TipoParada, Valor);
                            SalirProceso = true;
                        }
                        else
                        {
                            Console.WriteLine("A ocurrido un error, intentelo de nuevo por favor.\nPresione una tecla para continuar.");
                            Console.ReadKey();
                            SalirProceso = false;
                        }
                    }
                    catch
                    {
                        Console.WriteLine("A ocurrido un error, intentelo de nuevo por favor.\nPresione una tecla para continuar.");
                        Console.ReadKey();
                        SalirProceso = false;
                    }
                } while (SalirProceso == false);
                Console.ReadKey();
            } while (Salir == false);
        }
        class Proceso
    {
        double[,] Numeros = new double[3, 4];
        double[] Incognitas = new double[3];
        double[] Errores = new double[3];
        double Auxiliar, Anterior1, Anterior2, Anterior3;
        int Iteraccion = 0;
        string[] VectorAuxiliar = new string[3];
        bool Existencia = false, PararProceso = false;
        public Proceso(double[,] Numeros, double[] Incognitas)
        {
            this.Numeros = Numeros;
            this.Incognitas = Incognitas;
        }

        public void Solucion(int TipoParada, double Valor)
        {
            Existencia = VerificaSiExiste();
            if (Existencia == true)
            {
                AcomodaValores();
                Console.WriteLine("\n\n");
                for (int Contador1 = 0; Contador1 < 3; Contador1++)
                {
                    for (int Contador2 = 0; Contador2 < 4; Contador2++)
                    {
                        Console.Write(Numeros[Contador1, Contador2] + "\t");
                    }
                    Console.WriteLine();
                }
                Console.WriteLine("\n\n");
                Console.ReadKey();

                Console.WriteLine("|Iter|x1|x2|x3|Error x1|Error x2|Error x3|");
                do
                {
                    Iteraccion++;
                    Anterior1 = Incognitas[0];
                    Anterior2 = Incognitas[1];
                    Anterior3 = Incognitas[2];
                    Incognitas[0] = (Numeros[0, 3] - (Numeros[0, 1] * Incognitas[1]) - (Numeros[0, 2] * Incognitas[2])) / Numeros[0, 0];
                    Incognitas[1] = (Numeros[1, 3] - (Numeros[1, 0] * Incognitas[0]) - (Numeros[1, 2] * Incognitas[2])) / Numeros[1, 1];
                    Incognitas[2] = (Numeros[2, 3] - (Numeros[2, 0] * Incognitas[0]) - (Numeros[2, 1] * Incognitas[1])) / Numeros[2, 2];
                    if (Iteraccion == 1)
                    {
                        Errores[0] = 100;
                        Errores[1] = 100;
                        Errores[2] = 100;
                    }
                    else
                    {
                        Errores[0] = (Math.Abs((Incognitas[0] - Anterior1) / Incognitas[0]) * 100);
                        Errores[1] = (Math.Abs((Incognitas[1] - Anterior2) / Incognitas[1]) * 100);
                        Errores[2] = (Math.Abs((Incognitas[2] - Anterior3) / Incognitas[2]) * 100);
                    }

                    Impresion();
                    if (TipoParada == 1)
                    {
                        PararProceso = PorError(Errores[0], Errores[1], Errores[2], Valor);
                    }
                    else
                    {
                        PararProceso = PorIteraccion(Iteraccion, Valor);
                    }
                } while (PararProceso == false);
            }
            else
            {
                Console.WriteLine("El ejercicio no se puede realizar.\nPresione una tecla para continuar.");
            }

        }

        public bool VerificaSiExiste()
        {
            for (int Contador1 = 0; Contador1 < 3; Contador1++)
            {
                if (Numeros[(Contador1), 0] > Numeros[(Contador1), 1] && Numeros[(Contador1), 0] > Numeros[(Contador1), 2])
                {
                    VectorAuxiliar[Contador1] = "A";
                }
                else
                {
                    if (Numeros[(Contador1), 1] > Numeros[(Contador1), 0] && Numeros[(Contador1), 1] > Numeros[(Contador1), 2])
                    {
                        VectorAuxiliar[Contador1] = "B";
                    }
                    else
                    {
                        VectorAuxiliar[Contador1] = "C";
                    }
                }
            }

            if (VectorAuxiliar[0] != VectorAuxiliar[1] && VectorAuxiliar[0] != VectorAuxiliar[2])
            {
                if (VectorAuxiliar[1] != VectorAuxiliar[0] && VectorAuxiliar[1] != VectorAuxiliar[2])
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }

        public void AcomodaValores()
        {
            if (VectorAuxiliar[0] == "A")
            {
                if (VectorAuxiliar[1] == "B")
                { }
                else
                {
                    for (int Contador1 = 0; Contador1 < 4; Contador1++)
                    {
                        Auxiliar = Numeros[1, Contador1];
                        Numeros[1, Contador1] = Numeros[2, Contador1];
                        Numeros[2, Contador1] = Auxiliar;

                    }
                }
            }
            else if (VectorAuxiliar[0] == "B")
            {
                for (int Contador1 = 0; Contador1 < 4; Contador1++)
                {
                    Auxiliar = Numeros[0, Contador1];
                    Numeros[0, Contador1] = Numeros[1, Contador1];
                    Numeros[1, Contador1] = Auxiliar;

                }
                if (VectorAuxiliar[1] == "A")
                { }
                else
                {
                    for (int Contador1 = 0; Contador1 < 4; Contador1++)
                    {
                        Auxiliar = Numeros[0, Contador1];
                        Numeros[0, Contador1] = Numeros[2, Contador1];
                        Numeros[2, Contador1] = Auxiliar;

                    }
                }
            }
            else
            {
                for (int Contador1 = 0; Contador1 < 4; Contador1++)
                {
                    Auxiliar = Numeros[0, Contador1];
                    Numeros[0, Contador1] = Numeros[2, Contador1];
                    Numeros[2, Contador1] = Auxiliar;

                }
                if (VectorAuxiliar[2] == "A")
                { }
                else
                {
                    for (int Contador1 = 0; Contador1 < 4; Contador1++)
                    {
                        Auxiliar = Numeros[0, Contador1];
                        Numeros[0, Contador1] = Numeros[1, Contador1];
                        Numeros[1, Contador1] = Auxiliar;

                    }
                }
            }
        }

        public bool PorError(double Error1, double Error2, double Error3, double ErrorFinal)
        {
            if (Error1 < ErrorFinal || Error2 < ErrorFinal || Error3 < ErrorFinal)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool PorIteraccion(int IteraccionActual, double IteraccionFinal)
        {
            if (IteraccionActual == IteraccionFinal)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public void Impresion()
        {
            Console.WriteLine("|" + String.Format("{0:###}", Iteraccion) + "|" + String.Format("{0:##.#######}", Incognitas[0]) + "|" + String.Format("{0:##.#######}", Incognitas[1]) + "|" + String.Format("{0:##.#######}", Incognitas[2]) + "|" + String.Format("{0:###.##}", Errores[0]) + "|" + String.Format("{0:###.##}", Errores[1]) + "|" + String.Format("{0:###.##}", Errores[2]));
        }
    }
}

    }










