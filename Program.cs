using System;
using System.Reflection.Metadata;
using System.Linq;
using System.Security.Cryptography;

class Program
{
    static string[] Board = {"-", "-", "-",
                             "-", "-", "-",
                             "-", "-", "-"};

    static int[,] WinningCombos = { { 0, 1, 2 }, { 3, 4, 5 }, { 6, 7, 8 }, { 0, 3, 6 }, { 1, 4, 7 }, { 2, 5, 8 }, { 0, 4, 8 }, { 2, 3, 6 } };
    static bool GameRunning = true;
    static string CurrentPlayer = "X";
    static void Main(string[] args)
    {
        Console.WriteLine("Tic Tac Toe");
        //list options to user (eg single player)
        Console.WriteLine("1. Multiplayer Game");
        // Console.WriteLine("2. VS. CPU");
        // get an input from the user (could be an int, but remember Console.Readline returns a string u have to convert it)
        string _choice = Console.ReadLine();
        // based on what the user inputs run either StartMultiplayer or StartSinglePlayer
        int choice = Convert.ToInt32(_choice);
        if (choice == 1){
            StartMultiplayer();
            // Multiplayer
        } else if (choice == 2){
            StartSinglePlayer();
            //Singleplayer
        } else {
            Console.WriteLine("Invalid option");
        }
    }

    static void StartMultiplayer(){
        DisplayBoard();
        while (GameRunning)
        {
            WriteBoardItem();
            SwitchPlayers();
            CheckWinner();
        }
    }

    static void StartSinglePlayer(){
        DisplayBoard();
        while (GameRunning)
        {
            AIWriteBoardItem();
            SwitchPlayers();
            CheckWinner();
        }
    }
    

    static void DisplayBoard()
    {
        Console.WriteLine("Running");
        Console.WriteLine("{0} | {1} | {2}          1|2|3", Board[0], Board[1], Board[2]);
        Console.WriteLine("{0} | {1} | {2}          4|5|6", Board[3], Board[4], Board[5]);
        Console.WriteLine("{0} | {1} | {2}          7|8|9", Board[6], Board[7], Board[8]);
    }

    static void SimpleAI(){
        
    }

    static private void CheckWinner()
    {
        if (Board.Contains("-") == false)
        {
            Console.WriteLine("Draw");
            GameRunning = false;
            return;
        }
        for (int i = 0; i < WinningCombos.GetLength(0); i++)
        {
            if (Board[WinningCombos[i, 0]] != "-" && Board[WinningCombos[i, 1]] != "-" && Board[WinningCombos[i, 2]] != "-")
            {
                SwitchPlayers();
                Console.WriteLine("{0} Wins!", CurrentPlayer);
                GameRunning = false;
                return;
            }
        }
    }

    private static void SwitchPlayers()
    {
        if (CurrentPlayer == "X")
        {
            CurrentPlayer = "O";
        } else
        {
            CurrentPlayer = "X";
        }
    }

    private static void AIWriteBoardItem(){
        System.Random random = new System.Random(); 
        int position = random.Next(1,10);
        if (1 <= position && position <= 9 && Board[position] == "-")
        {
            Console.WriteLine("Invalid Selection");
            SwitchPlayers();
            AIWriteBoardItem();
        }else
        {
            Board[position] = CurrentPlayer;
            DisplayBoard();
        }

    }

    private static void WriteBoardItem()
    {
        Console.WriteLine("Enter position from 1-9");
        int position = Convert.ToInt32(Console.ReadLine()) - 1;
        Console.WriteLine(position);
        if (1 <= position && position <= 9 && Board[position] != "-")
        {
            Console.WriteLine("Invalid Selection");
            SwitchPlayers();
            WriteBoardItem();
        }
        else
        {
            Board[position] = CurrentPlayer;
            DisplayBoard();
        }
    }
}

