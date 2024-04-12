# AffariTuoi

This C# code defines a program that simulates a game where a player interacts with a set of "packages" (pacchi). Here's an overview of its main components:

    Global Variables:
        It defines various global variables including a list of packages (pacchi), an instance of the Random class (random), player's name (nomeGiocatore), player's package (paccoGiocatore), and other related variables.

    Main Method (Main()):
        It starts the program and enters a loop (MainMenu()) to display a menu and handle user input until the user chooses to exit the program.

    Menu Handling Method (MainMenu()):
        Displays options to the user (e.g., play or exit) and handles user input accordingly.

    Game Logic Methods:
        Giocando(): Manages the game loop where the player interacts with packages until no packages are left.
        fareTiro(): Simulates a player's move by selecting a package and revealing its contents.
        ChiamataDottore(): Triggers an event where a "doctor" makes an offer or asks for a package exchange.

    Methods for Package Management:
        ContarePacchiDisponibili(): Counts the available packages.
        statoDiGioco(): Displays the current game state including remaining shots and available packages.
        InitializePacchi(): Initializes the packages, assigning values and colors, and shuffling them.
        RandomizePacchi(): Implements the Fisher-Yates algorithm to shuffle the packages randomly.
        AddPeopleToPacchi(): Assigns names and regions to the packages.

    Player Interaction Methods:
        ChiedereDatiGiocatore(): Prompts the user to input their name.
        Play(): Starts the game, initializing data and calling necessary methods.

Overall, this program creates a simple game where the player interacts with packages, revealing their contents and making decisions based on the game events. The packages contain values and colors, and the player's goal is to make strategic choices to maximize their outcome.
