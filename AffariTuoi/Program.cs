using System;

class Program
{
    // Lista per contenere i pacchi
    public static List<Pacco> pacchi = new List<Pacco>();

    // Istanza della classe Random per generare numeri casuali
    static Random random = new Random(); // Istanza di Random

    // Nome del giocatore
    public static string nomeGiocatore = "";

    // Pacco del giocatore
    public static Pacco paccoGiocatore;

    // Numero del pacco del giocatore
    public static int numeroPaccoGiocatore;

    // Numero di lanci
    public static int tiri = 0;

    // Array contenente le regioni italiane
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

    // Array contenente i nomi italiani
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
        // Variabile booleana per controllare se mostrare il menu
        bool showMenu = true;

        // Ciclo per mostrare continuamente il menu finché showMenu è true
        while (showMenu)
        {
            // Chiamata alla funzione MainMenu() e aggiornamento di showMenu con il valore restituito
            showMenu = MainMenu();
        }
    }


    static bool MainMenu()
    {
        // Pulisce la console per un'interfaccia utente pulita
        Console.Clear();

        // Mostra il messaggio di benvenuto e le opzioni del menu
        Console.WriteLine("Benvenuto!");
        Console.WriteLine("1. Giocare");
        Console.WriteLine("2. Uscire");
        Console.Write("\nSeleziona un'opzione: ");

        // Legge l'input dell'utente per selezionare un'opzione
        switch (Console.ReadLine())
        {
            case "1":
                // Se l'utente sceglie di giocare, chiama la funzione Play() e ritorna true per continuare a mostrare il menu
                Play();
                return true;
            case "2":
                // Se l'utente sceglie di uscire, ritorna false per terminare il ciclo del menu
                return false;
            default:
                // Se l'input dell'utente non corrisponde a nessuna opzione valida, mostra un messaggio di errore e ritorna true per continuare a mostrare il menu
                Console.WriteLine("Opzione non valida, si prega di riprovare.");
                Console.ReadLine(); // Attende l'input dell'utente prima di proseguire
                return true;
        }
    }


    static void Giocando()
    {
        // Controlla quanti pacchi sono disponibili
        int pacchiDisponibili = ContarePacchiDisponibili();

        // Continua finché ci sono pacchi disponibili
        while (pacchiDisponibili > 0)
        {
            // Calcola il numero di tiri in base alla percentuale del 20% dei pacchi rimanenti
            tiri = random.Next(1, (int)(pacchi.Count * 0.2));

            // Mostra lo stato del gioco
            statoDiGioco();

            // Esegue i tiri finché ci sono ancora tiri disponibili
            while (tiri > 0)
            {
                fareTiro(); // Esegue un tiro
            }

            // Se non ci sono più tiri disponibili, chiama la funzione ChiamataDottore()
            if (tiri == 0)
            {
                ChiamataDottore();
            }

            // Aggiorna il numero di pacchi disponibili
            pacchiDisponibili = ContarePacchiDisponibili();
        }
    }


    private static int ContarePacchiDisponibili()
    {
        // Variabile per contare i pacchi disponibili
        int counter = 0;

        // Itera attraverso ogni pacco nella lista
        foreach (Pacco pacco in pacchi)
        {
            // Controlla se il pacco è disponibile
            if (pacco.Disponibile)
            {
                counter++; // Incrementa il contatore
            }
        }

        return counter; // Restituisce il numero totale di pacchi disponibili
    }


    private static void statoDiGioco()
    {
        // Pulisce la console per un'interfaccia utente pulita
        Console.Clear();

        // Mostra il titolo del gioco e il pacco del giocatore corrente
        Console.WriteLine($"/////////// Giocando {nomeGiocatore} ///////////");
        Console.WriteLine($"/////////// Il tuo pacco #{numeroPaccoGiocatore} ///////////");

        // Mostra il numero di tiri rimanenti
        Console.WriteLine($"Tiri rimanenti: {tiri}");

        // Itera attraverso ogni pacco nella lista
        foreach (Pacco pacco in pacchi)
        {
            // Ottiene il numero del pacco corrente nella lista
            int numeroPacco = pacchi.IndexOf(pacco) + 1;

            // Controlla se il pacco è disponibile e non appartiene al giocatore
            if (pacco.Disponibile && !pacco.AppartieneAlGiocatore)
            {
                // Mostra il numero del pacco
                Console.WriteLine($"Pacco #{numeroPacco}");
            }
            // Se il pacco non è disponibile e non appartiene al giocatore
            else if (!pacco.Disponibile && !pacco.AppartieneAlGiocatore)
            {
                // Imposta il colore del testo in base al colore del pacco
                if (pacco.Colore == "rosso")
                {
                    Console.ForegroundColor = ConsoleColor.Red; // Rosso per i pacchi rossi
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Blue; // Blu per i pacchi blu
                }

                // Mostra il valore del pacco
                Console.WriteLine($"Pacco #{numeroPacco} aveva valore {pacco.Valore}");

                // Reimposta il colore del testo al colore predefinito
                Console.ResetColor();
            }
        }
    }


    static void fareTiro()
    {
        bool isValidInput = false;
        string inputNumeroDiPacco = "";
        int numeroDiPacco = 0;

        // Continua a richiedere l'input finché non è valido
        while (!isValidInput)
        {
            // Richiede all'utente di inserire il numero del pacco
            Console.WriteLine("Inserisci il numero del pacco:");
            inputNumeroDiPacco = Console.ReadLine();

            // Verifica se l'input è un intero valido
            isValidInput = int.TryParse(inputNumeroDiPacco, out numeroDiPacco);

            // Se l'input non è valido, mostra un messaggio di errore
            if (!isValidInput || numeroDiPacco < 1 || numeroDiPacco > 20 || !pacchi.ElementAt(numeroDiPacco - 1).Disponibile)
            {
                Console.WriteLine("Input non valido. Si prega di inserire un numero valido tra 1 e 20 che corrisponda a un pacco disponibile.");
                isValidInput = false; // Imposta isValidInput su false per continuare il ciclo
            }
        }

        // Ottiene il saluto dalla persona associata al pacco selezionato
        string saluto = pacchi.ElementAt(numeroDiPacco - 1).Persona.SalutoPersona();

        // Imposta il pacco come non disponibile
        pacchi.ElementAt(numeroDiPacco - 1).Disponibile = false;

        // Mostra il saluto della persona associata al pacco
        Console.WriteLine(saluto);
        Console.ReadLine();

        // Imposta il colore del testo in base al colore del pacco
        if (pacchi.ElementAt(numeroDiPacco - 1).Colore == "rosso")
        {
            Console.ForegroundColor = ConsoleColor.Red; // Rosso per i pacchi rossi
        }
        else
        {
            Console.ForegroundColor = ConsoleColor.Blue; // Blu per i pacchi blu
        }

        // Mostra il valore del pacco
        Console.WriteLine($"Il valore del pacco è {pacchi.ElementAt(numeroDiPacco - 1).Valore}");
        Console.ReadLine();

        // Reimposta il colore del testo al colore predefinito
        Console.ResetColor();

        // Decrementa il numero di tiri rimanenti
        tiri--;

        // Aggiorna lo stato del gioco
        statoDiGioco();
    }


    static void ChiamataDottore()
    {
        int randomNumber = 2; // Simula la generazione casuale di un numero (1 o 2)

        // Se il numero casuale è 1, il dottore fa un'offerta
        if (randomNumber == 1)
        {
            DottoreFaOfferta();
        }
        // Altrimenti, il dottore chiede un cambio di pacco
        else
        {
            DottoreChiedeCambio();
        }
    }


    private static void DottoreFaOfferta()
    {
        // Calcola il totale dei valori dei pacchi disponibili
        double totalValoriPacchi = 0;
        foreach (Pacco pacco in pacchi)
        {
            if (pacco.Disponibile)
            {
                totalValoriPacchi += pacco.Valore;
            }
        }

        // Calcola l'offerta del dottore come il 0.04% del totale dei valori dei pacchi, arrotondato al migliaio più vicino
        totalValoriPacchi = Math.Round((Math.Round(totalValoriPacchi * 0.04) / 1000)) * 1000;

        // Mostra l'offerta del dottore
        Console.WriteLine("Il dottore fa un'offerta di " + totalValoriPacchi);
        Console.ReadLine();
    }

    private static void DottoreChiedeCambio()
    {
        // Richiede all'utente di accettare o rifiutare il cambio di pacco proposto dal dottore
        Console.WriteLine("Il dottore chiede un cambio di pacco!");
        Console.WriteLine("1) Accettare");
        Console.WriteLine("2) Rifiutare");

        string scelta = Console.ReadLine();

        // Gestisce la scelta dell'utente
        switch (scelta)
        {
            case "1":
                // Se l'utente accetta, esegue il cambio di pacchi
                Console.WriteLine("Hai accettato il cambio di pacco.");
                CambioPacchi();
                break;
            case "2":
                // Se l'utente rifiuta, mostra un messaggio di conferma
                Console.WriteLine("Hai rifiutato il cambio di pacco.");
                break;
            default:
                // Se l'utente inserisce un'opzione non valida, mostra un messaggio di errore
                Console.WriteLine("Selezione non valida.");
                break;
        }
    }


    private static void CambioPacchi()
    {
        bool isValidInput = false;
        string inputNumeroDiPacco = "";
        int numeroDiPacco = 0;

        // Richiede all'utente di scegliere un pacco disponibile fino a quando non viene fornito un input valido
        while (!isValidInput)
        {
            Console.WriteLine("Scegli un pacco disponibile:");
            inputNumeroDiPacco = Console.ReadLine();
            isValidInput = int.TryParse(inputNumeroDiPacco, out numeroDiPacco);

            // Verifica se l'input è valido e se il numero di pacco è compreso tra 1 e 20 e se il pacco è disponibile
            if (!isValidInput)
            {
                Console.WriteLine("Input non valido. Si prega di inserire un numero valido:");
            }
            else if (numeroDiPacco >= 1 && numeroDiPacco <= 20 && pacchi.ElementAt(numeroDiPacco - 1).Disponibile)
            {
                isValidInput = true;
                CambiarePacco(numeroDiPacco - 1);
            }
            else
            {
                Console.WriteLine("Input non valido o pacco non disponibile. Si prega di inserire un numero valido:");
                isValidInput = false;
            }
        }
    }


    private static void CambiarePacco(int paccoSelezionato)
    {
        // Ottiene l'indice del pacco del giocatore attuale
        int paccoGiocatoreIndex = numeroPaccoGiocatore - 1;

        // Salva i dati del pacco del giocatore attuale e del pacco selezionato
        Pacco paccoGiocatoreBackup = pacchi[paccoGiocatoreIndex];
        Pacco paccoSelezionatoBackup = pacchi[paccoSelezionato];

        // Salva i dati del nome e della regione del pacco selezionato
        string nomePaccoSelezionatoBackup = paccoSelezionatoBackup.Persona.NomePersona;
        string regionePaccoSelezionatoBackup = paccoSelezionatoBackup.Persona.RegionePersona;

        // Scambia i pacchi tra il giocatore attuale e il pacco selezionato
        pacchi[paccoSelezionato] = paccoGiocatoreBackup; // nuovo pacco del giocatore
        pacchi[paccoGiocatoreIndex] = paccoSelezionatoBackup;

        // Ripristina i dati del nome e della regione del pacco del giocatore attuale
        pacchi[paccoGiocatoreIndex].Persona.NomePersona = nomePaccoSelezionatoBackup;
        pacchi[paccoGiocatoreIndex].Persona.RegionePersona = regionePaccoSelezionatoBackup;
        pacchi[paccoGiocatoreIndex].AppartieneAlGiocatore = false;
        pacchi[paccoGiocatoreIndex].Disponibile = true;

        // Aggiorna i dati del pacco selezionato con il nome del giocatore e lo rende non disponibile
        pacchi[paccoSelezionato].Persona.NomePersona = nomeGiocatore;
        pacchi[paccoSelezionato].Persona.RegionePersona = "";
        pacchi[paccoSelezionato].AppartieneAlGiocatore = true;
        pacchi[paccoSelezionato].Disponibile = false;

        // Aggiorna il pacco del giocatore attuale e il numero del pacco giocatore
        paccoGiocatore = pacchi[paccoGiocatoreIndex];
        numeroPaccoGiocatore = paccoSelezionato + 1;
    }


    static void Play()
    {
        // Pulisce la console e mostra il messaggio di benvenuto al gioco
        Console.Clear();
        Console.WriteLine("Affari tuoi!");

        // Avvia il gioco
        GameStart();

        // Attende che l'utente prema un tasto prima di chiudere il gioco
        Console.ReadLine();
    }


    static void GameStart()
    {
        // Chiede all'utente di inserire il nome
        ChiedereDatiGiocatore();

        // Inizializza i pacchi per il gioco
        InitializePacchi();

        // Aggiunge le persone ai pacchi
        AddPeopleToPacchi();

        // Avvia il gioco
        Giocando();
    }

    static void ChiedereDatiGiocatore()
    {
        Console.Clear();
        Console.WriteLine("Inserisci il tuo nome:");
        string input = Console.ReadLine();

        // Continua a richiedere il nome finché non viene inserito un valore non vuoto
        while (string.IsNullOrWhiteSpace(input))
        {
            Console.WriteLine("Il nome non può essere vuoto. Inserisci nuovamente:");
            input = Console.ReadLine();
        }

        // Assegna il nome giocatore, rimuovendo eventuali spazi iniziali e finali
        nomeGiocatore = input.Trim();

        // Mostra un saluto con il nome del giocatore
        Console.WriteLine($"Ciao {nomeGiocatore}!");
    }


    private static void InitializePacchi()
    {
        // Pulisce la lista dei pacchi
        pacchi.Clear();

        // Crea e aggiunge i pacchi blu
        pacchi.Add(new Pacco("blu", 0));
        pacchi.Add(new Pacco("blu", 1));
        pacchi.Add(new Pacco("blu", 5));
        pacchi.Add(new Pacco("blu", 10));
        pacchi.Add(new Pacco("blu", 20));
        pacchi.Add(new Pacco("blu", 50));
        pacchi.Add(new Pacco("blu", 75));
        pacchi.Add(new Pacco("blu", 100));
        pacchi.Add(new Pacco("blu", 200));
        pacchi.Add(new Pacco("blu", 500));

        // Crea e aggiunge i pacchi rossi
        pacchi.Add(new Pacco("rosso", 5000));
        pacchi.Add(new Pacco("rosso", 10000));
        pacchi.Add(new Pacco("rosso", 15000));
        pacchi.Add(new Pacco("rosso", 20000));
        pacchi.Add(new Pacco("rosso", 30000));
        pacchi.Add(new Pacco("rosso", 50000));
        pacchi.Add(new Pacco("rosso", 75000));
        pacchi.Add(new Pacco("rosso", 100000));
        pacchi.Add(new Pacco("rosso", 200000));
        pacchi.Add(new Pacco("rosso", 300000));

        // Mescola i pacchi
        RandomizePacchi();
    }


    private static void RandomizePacchi()
    {
        // Algoritmo di mescolamento Fisher-Yates
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
        // Assegna un pacco al giocatore
        paccoGiocatore = pacchi[random.Next(0, pacchi.Count)];
        paccoGiocatore.Persona.NomePersona = nomeGiocatore;
        paccoGiocatore.Disponibile = false;
        paccoGiocatore.AppartieneAlGiocatore = true;
        numeroPaccoGiocatore = pacchi.IndexOf(paccoGiocatore) + 1;

        // Assegna nomi e regioni ai pacchi degli altri giocatori
        foreach (Pacco pacco in pacchi)
        {
            if (!pacco.AppartieneAlGiocatore)
            {
                pacco.Persona.NomePersona = nomiItaliani[random.Next(0, nomiItaliani.Length)];
                pacco.Persona.RegionePersona = regioniItaliane[random.Next(0, regioniItaliane.Length)];
                Console.WriteLine(pacco.ToString());
            }
        }
    }

}

