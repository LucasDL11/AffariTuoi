using System;

class Program
{
    public static List<Pacco> pacchi = new List<Pacco>();
    static Random random = new Random(); // Instace of Random
    public static string nomeGiocatore = "";
    public static Pacco paccoGiocatore;
    public static int numeroPaccoGiocatore;
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
        int pacchiDisponibile = ContarePacchiDisponibile();
        while (pacchiDisponibile > 0)
        {
            tiri = random.Next(1, (int)((pacchi.Count) * 0.2));
            statoDiGioco();
            while (tiri > 0)
            {
                fareTiro();
            }
            if (tiri == 0)
            {
                ChiamataDottore();
            }
        }
    }

    private static int ContarePacchiDisponibile()
    {
        int counter = 0;
        foreach(Pacco pacco in pacchi)
        {
            if (pacco.Disponibile)
            {
                counter++;
            }
        }
        return counter;
    }

    private static void statoDiGioco()
    {
        Console.Clear();
        Console.WriteLine($"///////////Giocando " + nomeGiocatore + "///////////");
        Console.WriteLine($"///////////Tu pacco " + numeroPaccoGiocatore + "///////////");
        Console.WriteLine($"Tiri: " + tiri);
        foreach (Pacco pacco in pacchi)
        {
            int numeroPacco = (pacchi.IndexOf(pacco) + 1);
            if (pacco.Disponibile && !pacco.AppartieneAlGiocatore)
            {
                Console.WriteLine("Pacco #" + numeroPacco + " ");
            }
            else if (!pacco.Disponibile && !pacco.AppartieneAlGiocatore)
            {
                if (pacco.Colore == "rosso")
                {
                    // Set the text color to blue
                    Console.ForegroundColor = ConsoleColor.Red;
                }
                else
                {
                    // Set the text color to blue
                    Console.ForegroundColor = ConsoleColor.Blue;
                }
                Console.WriteLine("#" + numeroPacco + " aveva " + pacco.Valore);
                Console.ResetColor();
            }
        }
    }

    static void fareTiro()
    {
        bool isValidInput = false;
        string inputNumeroDiPacco = "";
        int numeroDiPacco = 0;
        while (isValidInput == false)
        {
            Console.WriteLine("Inserire numero di pacco");
            inputNumeroDiPacco = Console.ReadLine();
            isValidInput = int.TryParse(inputNumeroDiPacco, out numeroDiPacco);
            if (!isValidInput)
            {
                Console.WriteLine("Input non valido. Si prega di inserire un numero valido:");
            }
            else if (numeroDiPacco >= 1 && numeroDiPacco <= 20 && pacchi.ElementAt((numeroDiPacco - 1)).Disponibile)
                {
                        isValidInput = true;
            }
            else
            {
                Console.WriteLine("Input non valido. Si prega di inserire un numero valido:");
                isValidInput = false;
            }
        }
        string saluto = pacchi.ElementAt((numeroDiPacco - 1)).Persona.SalutoPersona();
        pacchi.ElementAt((numeroDiPacco - 1)).Disponibile = false;
        Console.WriteLine(saluto);
        Console.ReadLine();
        if (pacchi.ElementAt((numeroDiPacco - 1)).Colore == "rosso")
        {
            // Set the text color to blue
            Console.ForegroundColor = ConsoleColor.Red;
        }
        else
        {
            // Set the text color to blue
            Console.ForegroundColor = ConsoleColor.Red;
        }
            Console.WriteLine("Il valore del pacco è " + pacchi.ElementAt((numeroDiPacco - 1)).Valore);
        Console.ReadLine();
        Console.ResetColor();
        tiri--;
        statoDiGioco();
    }

    static void ChiamataDottore()
    {
        int randomNumber = 2; //random.Next(1, 3);
        if(randomNumber == 1)
        {
            DottoreFaOfferta();
        }
        else
        {
            DottoreChiedeCambio();
        }
    }

    private static void DottoreFaOfferta()
    {
        double totalValoriPacchi = 0;
        foreach(Pacco pacco in pacchi)
        {
            if(pacco.Disponibile)
            {
                totalValoriPacchi += pacco.Valore;
            }
        }        
        totalValoriPacchi = Math.Round((Math.Round(totalValoriPacchi * 0.04) / 1000)) * 1000; //Find nearest number divisable by 1000 from the 0.04% of the sum of all available values.
        Console.WriteLine("Il dottore fa una oferta di " + totalValoriPacchi);
        Console.ReadLine();
    }
    private static void DottoreChiedeCambio()
    {
        Console.WriteLine("Il dottore chiede cambio di pacco!");
        Console.WriteLine("1) Accettare");
        Console.WriteLine("2) Rifiutare");

        string scelta = Console.ReadLine();

        switch (scelta)
        {
            case "1":
                Console.WriteLine("Hai accettato il cambio di pacco.");
                CambioPacchi();
                break;
            case "2":
                Console.WriteLine("Hai rifiutato il cambio di pacco.");
                break;
            default:
                Console.WriteLine("Selezione non valida.");
                break;
        }
    }

    private static void CambioPacchi()
    {
        bool isValidInput = false;
        string inputNumeroDiPacco = "";
        int numeroDiPacco = 0;
        while (isValidInput == false)
        {
            Console.WriteLine("Scegli un pacco disponibile!");
            inputNumeroDiPacco = Console.ReadLine();
            isValidInput = int.TryParse(inputNumeroDiPacco, out numeroDiPacco);
            if (!isValidInput)
            {
                Console.WriteLine("Input non valido. Si prega di inserire un numero valido:");
            }
            else if (numeroDiPacco >= 1 && numeroDiPacco <= 20 && pacchi.ElementAt((numeroDiPacco - 1)).Disponibile)
            {
                isValidInput = true;
                CambiarePacco((numeroDiPacco - 1));
            }
            else
            {
                Console.WriteLine("Input non valido. Si prega di inserire un numero valido:");
                isValidInput = false;
            }
        }
    }

    private static void CambiarePacco(int paccoSelezionato)
    {
        int paccoGiocatoreIndex = numeroPaccoGiocatore - 1;
        Pacco paccoGiocatoreBackup = pacchi.ElementAt(paccoGiocatoreIndex);
        Pacco paccoSelezionatoBackup = pacchi.ElementAt(paccoSelezionato);

        string nomePaccoSelezionatoBackup = paccoSelezionatoBackup.Persona.NomePersona;
        string regionePaccoSelezionatoBackup = paccoSelezionatoBackup.Persona.RegionePersona;


        pacchi[paccoSelezionato] = paccoGiocatoreBackup ; // nuovo pacco giocatore
        pacchi[paccoGiocatoreIndex] = paccoSelezionatoBackup;


        pacchi[paccoGiocatoreIndex].Persona.NomePersona = nomePaccoSelezionatoBackup;
        pacchi[paccoGiocatoreIndex].Persona.RegionePersona = regionePaccoSelezionatoBackup;
        pacchi[paccoGiocatoreIndex].AppartieneAlGiocatore = false;
        pacchi[paccoGiocatoreIndex].Disponibile = true;

        pacchi[paccoSelezionato].Persona.NomePersona = nomeGiocatore;
        pacchi[paccoSelezionato].Persona.RegionePersona = "";
        pacchi[paccoSelezionato].AppartieneAlGiocatore = true;
        pacchi[paccoSelezionato].Disponibile = false;


        paccoGiocatore = pacchi[paccoGiocatoreIndex];
       
        numeroPaccoGiocatore = paccoSelezionato + 1;
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
            //AddRegioneToPacchi();
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

    //private static void AddRegioneToPacchi()
    //{
    //    List<int> numberList = new List<int>();
    //    foreach (Pacco pacco in pacchi)
    //    {
    //        if (pacco.NomeRegione == null)
    //        {
    //            bool unique = false;
    //            while (unique == false) {
    //                int randomNumber = random.Next(0, regioniItaliane.Length);
    //                if (!numberList.Contains(randomNumber))
    //                {
    //                    pacco.NomeRegione = regioniItaliane[randomNumber];
    //                    numberList.Add(randomNumber);
    //                    unique = true;
    //                }
    //                else
    //                {
    //                    numberList.Add(randomNumber);
    //                }
    //            }
    //        }
    //    }
    //}
    private static void AddPeopleToPacchi()
        {
            paccoGiocatore = pacchi.ElementAt(random.Next(0, pacchi.Count()));
            paccoGiocatore.Persona.NomePersona = nomeGiocatore;
            paccoGiocatore.Disponibile = false;
            paccoGiocatore.AppartieneAlGiocatore = true;
            numeroPaccoGiocatore = pacchi.IndexOf(paccoGiocatore) + 1;
            foreach (Pacco pacco in pacchi)
            {
                if (!pacco.AppartieneAlGiocatore)
                {
                    pacco.Persona.NomePersona = nomiItaliani[random.Next(0, nomiItaliani.Length)];
                    pacco.Persona.RegionePersona = regioniItaliane[random.Next(0, regioniItaliane.Length)];
                    //pacco.NomeRegione = regioniItaliane[random.Next(0, regioniItaliane.Length)];
                    Console.WriteLine(pacco.ToString());
                }
            }
        }
}

