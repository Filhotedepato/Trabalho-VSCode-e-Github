using System;
using System.Collections.Generic;

// Classe Sensor genérica
class Sensor
{
    public string Tipo { get; private set; }
    public double Valor { get; private set; }
    public string ID { get; private set; }

    private Random random;

    public Sensor(string tipo, string id)
    {
        Tipo = tipo;
        ID = id;
        random = new Random();
    }

    // Simula a leitura de valores do sensor
    public void ColetarDados()
    {
        switch (Tipo)
        {
            case "Pressao":
                Valor = 50 + random.NextDouble() * 50; // Valor entre 50 e 100
                break;
            case "Temperatura":
                Valor = 20 + random.NextDouble() * 40; // Valor entre 20 e 60
                break;
            case "Umidade":
                Valor = 30 + random.NextDouble() * 70; // Valor entre 30 e 100
                break;
            default:
                Valor = 0;
                break;
        }
    }
}

// Classe Dispositivo que possui vários sensores
class Dispositivo
{
    public string Nome { get; private set; }
    public List<Sensor> Sensores { get; private set; }

    public Dispositivo(string nome)
    {
        Nome = nome;
        Sensores = new List<Sensor>();
    }

    // Adiciona um sensor ao dispositivo
    public void AdicionarSensor(Sensor sensor)
    {
        Sensores.Add(sensor);
    }

    // Coleta dados de todos os sensores do dispositivo
    public void ColetarDados()
    {
        foreach (var sensor in Sensores)
        {
            sensor.ColetarDados();
        }
    }

    // Exibe os dados coletados dos sensores
    public void ExibirDados()
    {
        Console.WriteLine($"Dispositivo: {Nome}");
        foreach (var sensor in Sensores)
        {
            Console.WriteLine($"  Sensor: {sensor.Tipo} {sensor.ID}, Valor: {sensor.Valor:F2}");
        }
    }
}

// Classe principal do programa
class Program
{
    static void Main()
    {
        // Cria dispositivos e adiciona sensores a eles
        Dispositivo dispositivo1 = new Dispositivo("braco mecanico");
        dispositivo1.AdicionarSensor(new Sensor("Pressao", "001"));
        dispositivo1.AdicionarSensor(new Sensor("Temperatura", "002"));
        dispositivo1.AdicionarSensor(new Sensor("Umidade", "003"));

        Dispositivo dispositivo2 = new Dispositivo("Motor");
        dispositivo2.AdicionarSensor(new Sensor("Pressao", "004"));
        dispositivo2.AdicionarSensor(new Sensor("Temperatura", "005"));
        dispositivo2.AdicionarSensor(new Sensor("Umidade", "006"));

        Dispositivo dispositivo3 = new Dispositivo("Esteira");
        dispositivo3.AdicionarSensor(new Sensor("Pressao", "007"));
        dispositivo3.AdicionarSensor(new Sensor("Temperatura", "008"));
        dispositivo3.AdicionarSensor(new Sensor("Umidade", "009"));

        while (true)
        {
            Console.Clear();
            Console.WriteLine("Selecione um comando:");
            Console.WriteLine("1. Coletar e exibir dados dos dispositivos");
            Console.WriteLine("2. Sair");

            string escolha = Console.ReadLine();

            if (escolha == "1")
            {
                AtualizarDispositivos(new List<Dispositivo> { dispositivo1, dispositivo2, dispositivo3 });
            }
            else if (escolha == "2")
            {
                break;
            }
            else
            {
                Console.WriteLine("Opção inválida. Tente novamente.");
            }

            Console.WriteLine("Pressione qualquer tecla para continuar...");
            Console.ReadKey();
        }
    }

    static void AtualizarDispositivos(List<Dispositivo> dispositivos)
    {
        Console.Clear(); // Limpa a tela antes de exibir novos dados
        foreach (var dispositivo in dispositivos)
        {
            dispositivo.ColetarDados();
            dispositivo.ExibirDados();
        }
    }
}
