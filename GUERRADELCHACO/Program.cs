using System;

class Program
{
    static void Main()
    {
        int opcion;
        int soldados = 0;
        int alimentos = 0;
        double agua = 0;

        do
        {
            Console.Clear();

            Console.WriteLine("==========================================");
            Console.WriteLine("     SISTEMA DE CONTROL DE SUMINISTROS");
            Console.WriteLine("          GUERRA DEL CHACO");
            Console.WriteLine("==========================================");

            Console.WriteLine("\n1. Registrar suministros");
            Console.WriteLine("2. Evaluar suministros");
            Console.WriteLine("3. Distribuir alimentos");
            Console.WriteLine("4. Calcular duración de suministros");
            Console.WriteLine("5. Salir");

            Console.Write("\nSeleccione una opción: ");
            opcion = int.Parse(Console.ReadLine());

            Console.Clear();

            switch (opcion)
            {
                case 1:
                    Console.WriteLine("=== REGISTRO DE SUMINISTROS ===");
                    do
                    {
                        Console.Write("Cantidad de soldados: ");
                        soldados = int.Parse(Console.ReadLine());

                    } while (soldados <= 0);

                    do
                    {
                        Console.Write("Cantidad de raciones de alimento: ");
                        alimentos = int.Parse(Console.ReadLine());

                    } while (alimentos < 0);

                    do
                    {
                        Console.Write("Litros de agua disponibles: ");
                        agua = double.Parse(Console.ReadLine());

                    } while (agua < 0);

                    Console.WriteLine("\nDatos registrados correctamente.");
                    break;


                case 2:
                    if (soldados == 0)
                    {
                        Console.WriteLine("Primero debe registrar los suministros.");
                    }
                    else
                    {
                        double aguaPorSoldado = agua / soldados;
                        double alimentoPorSoldado =
                            (double)alimentos / soldados;

                        Console.WriteLine("=== ESTADO DE LOS SUMINISTROS ===");
                        Console.WriteLine($"Soldados: {soldados}");
                        Console.WriteLine($"Raciones: {alimentos}");
                        Console.WriteLine($"Agua: {agua:F2} litros");

                        Console.WriteLine(
                            $"\nRaciones por soldado: {alimentoPorSoldado:F2}"
                        );

                        Console.WriteLine(
                            $"Agua por soldado: {aguaPorSoldado:F2} litros"
                        );
                        if (alimentoPorSoldado >= 3 &&
                            aguaPorSoldado >= 3)
                        {
                            Console.WriteLine(
                                "\nEstado: SUMINISTROS SUFICIENTES"
                            );
                        }
                        else if (alimentoPorSoldado >= 2 &&
                                 aguaPorSoldado >= 2)
                        {
                            Console.WriteLine(
                                "\nEstado: SUMINISTROS LIMITADOS"
                            );
                        }
                        else
                        {
                            Console.WriteLine(
                                "\nEstado: SUMINISTROS ESCASOS"
                            );
                        }
                    }

                    break;


                case 3:
                    if (soldados == 0)
                    {
                        Console.WriteLine("Primero registre los suministros.");
                    }
                    else
                    {
                        Console.WriteLine("=== DISTRIBUCIÓN DE ALIMENTOS ===");

                        int racion = alimentos / soldados;
                        for (int i = 1; i <= soldados; i++)
                        {
                            Console.WriteLine(
                                $"Soldado {i}: {racion} raciones"
                            );
                        }
                    }

                    break;


                case 4:
                    if (soldados == 0)
                    {
                        Console.WriteLine("Primero registre los suministros.");
                    }
                    else
                    {
                        int dias = 0;
                        int reserva = alimentos;

                        // Cada soldado consume 3 raciones al día
                        int consumoDiario = soldados * 3;
                        while (reserva >= consumoDiario)
                        {
                            reserva -= consumoDiario;
                            dias++;
                        }

                        Console.WriteLine("=== DURACIÓN DE SUMINISTROS ===");

                        Console.WriteLine(
                            $"Consumo diario: {consumoDiario} raciones"
                        );

                        Console.WriteLine(
                            $"Los alimentos alcanzan para {dias} días completos."
                        );

                        Console.WriteLine(
                            $"Raciones restantes: {reserva}"
                        );
                    }

                    break;


                case 5:
                    Console.WriteLine("Programa finalizado.");
                    break;


                default:
                    Console.WriteLine("Opción incorrecta.");
                    break;
            }

            if (opcion != 5)
            {
                Console.WriteLine("\nPresione una tecla para continuar...");
                Console.ReadKey();
            }

        } while (opcion != 5);
    }
}