using System;
using System.Collections.Generic;

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

    public void ColetarDados()
    {
        switch (Tipo)
        {
            case "Pressao":
                Valor = 50 + random.NextDouble() * 50; 
                break;
            case "Temperatura":
                Valor = 20 + random.NextDouble() * 40; 
                break;
            case "Umidade":
                Valor = 30 + random.NextDouble() * 70; 
                break;
            default:
                Valor = 0;
                Console.WriteLine($"Tipo de sensor nao reconhecido: {Tipo}");
                break;
        }
    }
}

class Dispositivo
{
    public string Nome { get; private set; }
    public List<Sensor> Sensores { get; private set; }

    public Dispositivo(string nome)
    {
        Nome = nome;
        Sensores = new List<Sensor>();
    }

    public void AdicionarSensor(Sensor sensor)
    {
        Sensores.Add(sensor);
    }

    public void ColetarDados()
    {
        foreach (var sensor in Sensores)
        {
            sensor.ColetarDados();
        }
    }

    public void ExibirDados()
    {
        Console.WriteLine($"Dispositivo: {Nome}");
        foreach (var sensor in Sensores)
        {
            Console.WriteLine($"  Sensor: {sensor.Tipo} {sensor.ID}, Valor: {sensor.Valor:F2}");
        }
    }
}

class Program
{
    static void Main()
    {
        Console.WriteLine("Boa tarde! Bem-vindo ao sistema de monitoramento de dispositivos.");
        Console.WriteLine("Antes de iniciar, qual o seu nome?");
        string nomeUsuario = Console.ReadLine();

        Console.WriteLine($"Prazer em conhece-lo, {nomeUsuario}! Vamos configurar seus dispositivos.");

        // Cria dispositivos e adiciona sensores a eles
        Dispositivo dispositivo1 = new Dispositivo("Braco mecanico");
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
            Console.WriteLine($"Selecione um comando, {nomeUsuario}:");
            Console.WriteLine("1. Coletar e exibir dados dos dispositivos");
            Console.WriteLine("2. Sair");

            string escolha = Console.ReadLine();

            if (escolha == "1")
            {
                dispositivo1.ColetarDados();
                dispositivo1.ExibirDados();

                dispositivo2.ColetarDados();
                dispositivo2.ExibirDados();

                dispositivo3.ColetarDados();
                dispositivo3.ExibirDados();
            }
            else if (escolha == "2")
            {
                Console.WriteLine("Obrigado por usar o sistema. Ate logo!");
                break;
            }
            else
            {
                Console.WriteLine("Opcao invalida. Tente novamente.");
            }

            Console.WriteLine("Pressione qualquer tecla para continuar...");
            Console.ReadKey();
        }
    }
}
