using System;
using System.Collections.Generic;

namespace NewWorld10
{
    public class Menue
    {
        public static void ServeInteractivmenues(Player player)
        {
            while (true)
            {
                PrintResources(player);
                Print("1. Landverwalten\r\n2. Maschinen verwalten\r\n3. Markt besuchen\r\n4. Runde beenden\r\n");
                var input = ReadInput();
                switch (input)
                {
                    case 1:
                        LandManage(player);
                        break;
                    case 2:
                        MaschineManage(player);
                        break;
                    case 3:
                        Marketmanage(player);
                        break;
                    case 4:
                        ExitRound.CalculateRound(player);
                        return;
                }
            }
        }

        public static void Marketmanage(Player player)
        {
            while (true)
            {
                PrintResources(player);
                Print("1. Vorrat kaufen\r\n2. Vorrat verkaufen\r\n3. zurück\r\n");
                var number = ReadInput();
                switch (number)
                {
                    case 1:
                        PrintResources(player);
                        Print(
                            "Welche  Vorräte sollen gekauft werden?\r\n1. Getreide\r\n2. Öl\r\n3. Metall\r\n4.Kristall\r\n5. Abbrechen\r\n");
                        number = ReadInput();
                        BuyResources(player, number);
                        break;
                    case 2:
                        PrintResources(player);
                        Print(
                            "Welche Vorräte sollen verkauft werden?\r\n1. Getreide\r\n2. Öl\r\n3. Metall\r\n4.Kristall\r\n5. Abbrechen\r\n");
                        number = ReadInput();
                        SellResources(player, number);
                        break;
                    case 3:
                        return;
                }
            }
        }

        public static void SellResources(Player player, int input)
        {
            var resources = new List<string> {"Getreide", "Öl", "Metall", "Kristall"};
            Print("Wieviel " + resources[input - 1] + " soll verkauft werden?");
            var frequency = ReadInput();
            Calculations.SellResources(player, input, frequency);
        }

        public static void BuyResources(Player player, int input)
        {
            var resources = new List<string> {"Getreide", "Öl", "Metall", "Kristall"};
            Print("Wieviel " + resources[input - 1] + " soll gekauft werden?");
            var frequency = ReadInput();
            Calculations.BuyResources(player, input, frequency);
        }

        public static void MaschineManage(Player player)
        {
            while (true)
            {
                PrintResources(player);
                Print("1. Maschine(n) herstellen\r\n2. Maschine(n) zuordnen\r\n3. Machine(n) freistellen\r\n4. zurück\r\n");
                var input = ReadInput();
                switch (input)
                {
                    case 1:
                        PrintResources(player);
                        Print("Wieviele Maschinen sollen hergestellt werden?");
                        var number = ReadInput();
                        Maschines.CreateMaschines(player, number);
                        break;
                    case 2:
                        PrintResources(player);
                        Print(
                            "Wo sollen Maschinen zugeordnet werden?\r\n1. Getreide\r\n2. Öl\r\n3. Metall\r\n4. Kristall\r\n5. Abbrechen\r\n");
                        var assignment = ReadInput();
                        AssignMaschine(player, assignment);
                        break;
                    case 3:
                        PrintResources(player);
                        Print(
                            "Von wo sollen Maschinen freigegeben werden?\r\n1. Getreide\r\n2. Öl\r\n3. Metall\r\n4. Kristall\r\n5. Abbrechen\r\n");
                        input = ReadInput();
                        assignment = Convert.ToInt32(input);
                        ExemptMaschines(player, assignment);
                        break;
                    case 4:
                        return;
                }
            }
           
        }

        public static void ExemptMaschines(Player player, int assignment)
        {
            var resources = new List<string> {"Getreide", "Öl", "Metall", "Kristall"};
            PrintResources(player);
            Print("Wieviele Maschinen sollen von " + resources[assignment - 1] + " freigegeben werden?");
            var number = Convert.ToInt32(ReadInput());
            Maschines.ExemptMaschines(player, assignment, number);
        }

        public static void AssignMaschine(Player player, int assignment)
        {
            var resources = new List<string> {"Getreide", "Öl", "Metall", "Kristall"};
            Console.Write("Wieviele Maschinen sollen zu " + resources[assignment - 1] + " zugewiesen werden?");
            var frequency = Convert.ToInt32(Console.ReadLine());
            Maschines.AssignMaschines(player, assignment, frequency);
        }

        public static void LandManage(Player player)
        {
            while (true)
            {
                PrintResources(player);
                Print("1. Land kaufen\r\n2. Land verkaufen\r\n3. zurück\r\n");
                var input = ReadInput();
                switch (input)
                {
                    case 1:
                        Print("Wieviel Land soll gekauft werden?");
                        var number = ReadInput();
                        Calculations.BuyLand(player, number);
                        break;
                    case 2:
                        Print("Wieviel Land soll verkauft werden?");
                        number = ReadInput();
                        Calculations.SaleLand(player, number);
                        break;
                    case 3:
                        return;
                }
            }
            
        }

        public static void Print(string question)
        {
            Console.Write(question);
        }

        public static int ReadInput()
        {
            return Convert.ToInt32(Console.ReadLine());
        }

        public static void PrintResources(Player player)
        {
            Console.WriteLine("Siedler: " + player.Siedler + " | Geld: " + player.Geld + " | Land: " +
                              player.Land.Balance + " (Verfügbar: " + Calculations.LandLimit + ", Preis: " +
                              player.Land.BuyValue + "/" +
                              player.Land.SaleValue + ")\r\n");
            Console.WriteLine("Maschinen     Anzahl   Vorrat   Preis");
            var grain = $"Getreide   {player.GrainMaschines,9}    {player.Grain.Balance,5}   {player.Grain.BuyValue,2}/{player.Grain.SaleValue,2}";
            var oil = $"Öl      {player.OilMaschines,12}    {player.Oil.Balance,5}   {player.Oil.BuyValue,2}/{player.Oil.SaleValue,2}";
            var metal = $"Metall     {player.MetalMaschines,9}    {player.Metal.Balance,5}   {player.Metal.BuyValue,2}/{player.Metal.SaleValue,2}";
            var crystal = $"Kristall    {player.CrystalMaschines,8}    {player.Crystal.Balance,5}   {player.Crystal.BuyValue,2}/{player.Crystal.SaleValue}";
            var freemaschine = $"Frei    {player.FreeMaschines,12}";
            Console.WriteLine(grain);
            Console.WriteLine(oil);
            Console.WriteLine(metal);
            Console.WriteLine(crystal);
            Console.WriteLine(freemaschine);
            Console.WriteLine("---\r\n");
        }
    }
}