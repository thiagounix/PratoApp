using System;
using System.Collections.Generic;

class Program
{
    private static Dictionary<string, List<string>> pratosPorTipo = new Dictionary<string, List<string>>()
    {
        { "massa", new List<string> { "lasanha" } }  
    };
    private static string ultimoTipoAdicionado = "massa"; 
    private static string ultimoPratoAdicionado = "lasanha";
    private static bool primeiraRodada = true; 

    static void Main()
    {
        Console.WriteLine("Pense em um prato que você gosta e eu tentarei adivinhar!");

        while (true)
        {
            
            Console.WriteLine("O prato que você pensou é uma massa? (sim/nao)");
            var respostaMassa = Console.ReadLine().Trim().ToLower();

            if (respostaMassa == "sim")
            {
                if (!PerguntarPorPrato("massa"))
                {
                    AprenderPrato("massa");
                }
            }
            else
            {
                if (primeiraRodada)
                {
                    PerguntarSobreBoloDeChocolate();
                }
                else
                {
                    if (!TentarAdivinharUltimoTipoEPrato())
                    {
                        PerguntarSobreBoloDeChocolate();
                    }
                }
            }

            Console.WriteLine("Quer jogar novamente? (sim/nao)");
            if (Console.ReadLine().Trim().ToLower() != "sim")
            {
                break;
            }
            primeiraRodada = false;
        }
    }

    static bool TentarAdivinharUltimoTipoEPrato()
    {
        if (PerguntarPorTipo(ultimoTipoAdicionado))
        {
            if (PerguntarPorPrato(ultimoTipoAdicionado))
            {
                return true;
            }
        }
        return false;
    }

    static void PerguntarSobreBoloDeChocolate()
    {
        Console.WriteLine("O prato que você pensou é Bolo de chocolate? (sim/nao)");
        var respostaBolo = Console.ReadLine().Trim().ToLower();
        if (respostaBolo == "sim")
        {
            Console.WriteLine("Acertei!");
        }
        else
        {
            AprenderNovoPrato();
        }
    }

    static bool PerguntarPorTipo(string tipo)
    {
        Console.WriteLine($"O tipo de prato que você pensou é {tipo}? (sim/nao)");
        var respostaTipo = Console.ReadLine().Trim().ToLower();
        return respostaTipo == "sim";
    }

    static bool PerguntarPorPrato(string tipo)
    {
        Console.WriteLine($"O prato é {pratosPorTipo[tipo][pratosPorTipo[tipo].Count - 1]}? (sim/nao)");
        var respostaPrato = Console.ReadLine().Trim().ToLower();
        if (respostaPrato == "sim")
        {
            Console.WriteLine("Acertei!");
            return true;
        }
        Console.WriteLine("Não acertei, mas aprendi algo novo!");
        return false;
    }

    static void AprenderPrato(string tipo)
    {
        Console.WriteLine($"Que outro prato de {tipo} você estava pensando?");
        string novoPrato = Console.ReadLine().Trim();
        pratosPorTipo[tipo].Add(novoPrato);
        ultimoPratoAdicionado = novoPrato; 
        Console.WriteLine($"Adicionei {novoPrato} aos pratos do tipo {tipo}.");
    }

    static void AprenderNovoPrato()
    {
        Console.WriteLine("Qual é o prato que você estava pensando?");
        string prato = Console.ReadLine().Trim();

        Console.WriteLine("Que tipo de prato é esse? (Por exemplo: massa, doce, etc.)");
        string tipo = Console.ReadLine().Trim().ToLower();

        if (pratosPorTipo.ContainsKey(tipo))
        {
            pratosPorTipo[tipo].Add(prato);
        }
        else
        {
            pratosPorTipo.Add(tipo, new List<string> { prato });
            ultimoTipoAdicionado = tipo; 
        }
        ultimoPratoAdicionado = prato; 

        Console.WriteLine($"Aprendi um novo tipo de prato: {tipo} com {prato}!");
    }
}
