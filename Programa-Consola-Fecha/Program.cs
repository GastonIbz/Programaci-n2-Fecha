using System;
using System.Security.Cryptography;

class Program
{
    static void Main(string[] args)
    {
        int Dia, Mes, Año;

        Console.Write("Ingrese el Día (1-31):");
        Dia = int.Parse(Console.ReadLine());
        Console.Write("Ingrese el Mes (1-12): ");
        Mes = int.Parse(Console.ReadLine());
        Console.Write("Ingrese el Año: ");
        Año = int.Parse(Console.ReadLine());

        bool FechaValida = ValidarFecha(Dia, Mes, Año);

        if (FechaValida)
        {
            Dia++;

            if (Dia > DiasM(Mes, Año))
            {
                Dia = 1;
                Mes++;

                if (Mes > 12)
                {
                    Mes = 1;
                    Año++;
                }
            }
            string fechaEscrita = FechaEscrita(Dia, Mes, Año);
            Console.WriteLine(fechaEscrita);

        }
        else
        {
            Console.WriteLine("La fecha ingresada no es válida");
        }

        Console.ReadKey();
    }
    static bool ValidarFecha(int Dia, int Mes, int Año)
    {
        bool Validar = true;

        if (Dia < 1 || Dia > DiasM(Mes, Año))
        {
            Validar = false;
        }

        if (Mes < 1 || Mes > 12)
        {
            Validar = false;
        }

        if (Año < 1)
        {
            Validar = false;
        }

        return Validar;
    }

    static int DiasM(int Mes, int Año)
    {
        int Dias;

        switch (Mes)
        {
            case 2:
                if (Año % 4 == 0 && (Año % 100 != 0 || Año % 400 == 0))
                {
                    Dias = 29;
                }
                else
                {
                    Dias = 28;
                }
                break;
            case 4:
            case 6:
            case 9:
            case 11:
                Dias = 30;
                break;
            default:
                Dias = 31;
                break;
        }
        return Dias;
    }
    static string FechaEscrita(int Dia, int Mes, int Año)
    {
        string[] NombreMes = { "Enero", "Febrero", "Marzo", "Abril", "Mayo", "Junio", "Julio", "Agosto", "Septiembre", "Octubre", "Noviembre", "Diciembre" };
        string FechaEscrita = $"{Dia} de {NombreMes[Mes - 1]} de {Año}";

        return FechaEscrita;
    }
}