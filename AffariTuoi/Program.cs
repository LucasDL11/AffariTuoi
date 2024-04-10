using System;

class Program
{
    public static List<Pacco> pacchi = new List<Pacco>();
    static Random random = new Random(); // Instace of Random
    public static string nomeGiocatore = "";
    public static Pacco paccoGiocatore;
    public static int tiri = 0;
    public static string[] regioniItaliane = {
            "Abruzzo",
            "Basilicata",
            "Calabria",
            "Campania",
            "Emilia-Romagna",
            "Friuli-Venezia Giulia",
            "Lazio",
            "Liguria",
            "Lombardia",
            "Marche",
            "Molise",
            "Piemonte",
            "Puglia",
            "Sardegna",
            "Sicilia",
            "Toscana",
            "Trentino-Alto Adige",
            "Umbria",
            "Valle d'Aosta",
            "Veneto"
        };
    public static string[] nomiItaliani = {
            "Giuseppe",
            "Mario",
            "Luigi",
            "Giovanni",
            "Francesco",
            "Antonio",
            "Angela",
            "Maria",
            "Anna",
            "Giulia",
            "Roberto",
            "Rosa",
            "Lucia",
            "Alessandro",
            "Elena",
            "Paolo",
            "Sara",
            "Carmela",
            "Marco",
            "Giovanna"
        };
    static void Main()
    {

        bool showMenu = true;
        // Array contenente le regioni italiane


        while (showMenu)
        {
            showMenu = MainMenu();
        }
    }

    static bool MainMenu()
    {
        Console.Clear();
        Console.WriteLine("Benvenuto!");
        Console.WriteLine("1. Giocare");
        Console.WriteLine("2. Salire");
        Console.Write("\nSeleziona un'opzione: ");

        switch (Console.ReadLine())
        {
            case "1":
                Play();
                return true;
            case "2":
                return false;
            default:
                Console.WriteLine("Opzione non valida, si prega di riprovare.");
                Console.ReadLine();
                return true;
        }
    }

    static void Giocando()
    {
        tiri = random.Next(1, (int)((pacchi.Count) * 0.2));       
        statoDiGioco();
        while (tiri > 0)
        {
            fareTiro();
        }
        //Console.WriteLine("1. Se");
        //Console.WriteLine("2. Salire");
        //Console.Write("\nSeleziona un'opzione: ");

        //switch (Console.ReadLine())
        //{
        //    case "1":
        //        Play();
        //        return true;
        //    case "2":
        //        return false;
        //    default:
        //        Console.WriteLine("Opzione non valida, si prega di riprovare.");
        //        Console.ReadLine();
        //        return true;
        //}
    }

    private static void statoDiGioco()
    {
        Console.Clear();
        Console.WriteLine($"///////////Giocando " + nomeGiocatore + "///////////");
        Console.WriteLine($"///////////Tu pacco " + (pacchi.IndexOf(paccoGiocatore) + 1) + "///////////");
        Console.WriteLine($"Tiri: " + tiri);
        foreach (Pacco pacco in pacchi)
        {
            int numeroPacco = (pacchi.IndexOf(pacco) + 1);
            if (pacco.Disponibile && pacchi.IndexOf(pacco) != pacchi.IndexOf(paccoGiocatore))
            {
                Console.WriteLine("#" + numeroPacco + " " + pacco.NomeRegione);
            }
            else if (!pacco.Disponibile)
            {
                if (pacco.Colore == "rosso")
                {
                    // Set the text color to blue
                    Console.ForegroundColor = ConsoleColor.Red;
                }
                else
                {
                    // Set the text color to blue
                    Console.ForegroundColor = ConsoleColor.Red;
                }
                Console.WriteLine("#" + numeroPacco + " " + pacco.NomeRegione + " aveva " + pacco.Valore);
                Console.ResetColor();
            }
        }
    }

    static void fareTiro()
    {
        bool valido = false;
        string numeroDiPacco = "";
        while (valido == false)
        {
            Console.WriteLine("Inserire numero di pacco");
            numeroDiPacco = Console.ReadLine();
            if (int.Parse(numeroDiPacco) >= 1 && int.Parse(numeroDiPacco) <= 20) {
                {
                    valido = true;
                }
            }
        }
        string saluto = pacchi.ElementAt((int.Parse(numeroDiPacco) - 1)).Persona.SalutoPersona();
        pacchi.ElementAt((int.Parse(numeroDiPacco) - 1)).Disponibile = false;
        Console.WriteLine(saluto);
        Console.ReadLine();
        if (pacchi.ElementAt((int.Parse(numeroDiPacco) - 1)).Colore == "rosso")
        {
            // Set the text color to blue
            Console.ForegroundColor = ConsoleColor.Red;
        }
        else
        {
            // Set the text color to blue
            Console.ForegroundColor = ConsoleColor.Red;
        }
            Console.WriteLine("Il valore del pacco è " + pacchi.ElementAt((int.Parse(numeroDiPacco) - 1)).Valore);
        Console.ReadLine();
        Console.ResetColor();
        tiri--;
        statoDiGioco();

    }

        static void Play()
        {
            Console.Clear();
            Console.WriteLine("Affari tuoi!");
            GameStart();
            Console.ReadLine();
        }

        static void GameStart()
        {
            ChiedereDatiGiocatore();
            InitializePacchi();
            AddPeopleToPacchi();
            AddRegioneToPacchi();
            Giocando();
        }
        static void ChiedereDatiGiocatore()
        {
            Console.Clear();
            Console.WriteLine("Inserigi il tuo nome!");
            nomeGiocatore = Console.ReadLine();
            //Console.WriteLine($"Ciao " + nomeGiocatore);
        }
        private static void InitializePacchi()
        {
            pacchi.Clear();
            Pacco pacco1 = new Pacco("blu", 0);
            Pacco pacco2 = new Pacco("blu", 1);
            Pacco pacco3 = new Pacco("blu", 5);
            Pacco pacco4 = new Pacco("blu", 10);
            Pacco pacco5 = new Pacco("blu", 20);
            Pacco pacco6 = new Pacco("blu", 50);
            Pacco pacco7 = new Pacco("blu", 75);
            Pacco pacco8 = new Pacco("blu", 100);
            Pacco pacco9 = new Pacco("blu", 200);
            Pacco pacco10 = new Pacco("blu", 500);

            Pacco pacco11 = new Pacco("rosso", 5000);
            Pacco pacco12 = new Pacco("rosso", 10000);
            Pacco pacco13 = new Pacco("rosso", 15000);
            Pacco pacco14 = new Pacco("rosso", 20000);
            Pacco pacco15 = new Pacco("rosso", 30000);
            Pacco pacco16 = new Pacco("rosso", 50000);
            Pacco pacco17 = new Pacco("rosso", 75000);
            Pacco pacco18 = new Pacco("rosso", 100000);
            Pacco pacco19 = new Pacco("rosso", 200000);
            Pacco pacco20 = new Pacco("rosso", 300000);

            pacchi.Add(pacco1);
            pacchi.Add(pacco2);
            pacchi.Add(pacco3);
            pacchi.Add(pacco4);

            pacchi.Add(pacco5);
            pacchi.Add(pacco6);
            pacchi.Add(pacco7);
            pacchi.Add(pacco8);
            pacchi.Add(pacco9);
            pacchi.Add(pacco10);
            pacchi.Add(pacco11);
            pacchi.Add(pacco12);
            pacchi.Add(pacco13);
            pacchi.Add(pacco14);
            pacchi.Add(pacco15);
            pacchi.Add(pacco16);
            pacchi.Add(pacco17);
            pacchi.Add(pacco18);
            pacchi.Add(pacco19);
            pacchi.Add(pacco20);
            RandomizePacchi();
        }

    private static void RandomizePacchi()
    {
        //Fisher-Yates shuffle algorithm
            int n = pacchi.Count;
            while (n > 1)
            {
                n--;
                int k = random.Next(n + 1);
                Pacco pacco = pacchi[k];
                pacchi[k] = pacchi[n];
                pacchi[n] = pacco;
            }
    }

    private static void AddRegioneToPacchi()
    {
        List<int> numberList = new List<int>();
        foreach (Pacco pacco in pacchi)
        {
            if (pacco.NomeRegione == null)
            {
                bool unique = false;
                while (unique == false) {
                    int randomNumber = random.Next(0, regioniItaliane.Length);
                    if (!numberList.Contains(randomNumber))
                    {
                        pacco.NomeRegione = regioniItaliane[randomNumber];
                        numberList.Add(randomNumber);
                        unique = true;
                    }
                    else
                    {
                        numberList.Add(randomNumber);
                    }
                }
            }
        }
    }
    private static void AddPeopleToPacchi()
        {
            paccoGiocatore = pacchi.ElementAt(random.Next(0, pacchi.Count()));
            paccoGiocatore.Persona.NomePersona = nomeGiocatore;
            foreach (Pacco pacco in pacchi)
            {
                if (pacco.Persona != null)
                {
                    pacco.Persona.NomePersona = nomiItaliani[random.Next(0, nomiItaliani.Length)];
                    pacco.Persona.RegionePersona = regioniItaliane[random.Next(0, regioniItaliane.Length)];
                    //pacco.NomeRegione = regioniItaliane[random.Next(0, regioniItaliane.Length)];
                    Console.WriteLine(pacco.ToString());
                }
            }
        }
    }

