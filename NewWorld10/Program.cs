using System;
using System.Collections.Generic;

namespace NewWorld10
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            var menue = new Menue();
            List<Player> players = new List<Player>();
            Console.WriteLine("Wilkommen in der Neuen Welt");
            Console.WriteLine("============================");
            Console.Write("Wieviele Spieler? ");
            int playerNumber = Convert.ToInt32(Console.ReadLine());
            for (int i = 1; i <= playerNumber; i++)
            {
                Console.Write("Name für Spieler "+i+"?");
                var name = Console.ReadLine();
                Console.WriteLine("Name des Gebiets für Spieler " +name+"?");
                var area = Console.ReadLine();
                var player = new Player(name, area);
                players.Add(player);
            }

            while (true)
            {
                for (int a = 0; a < players.Count; a++)
                {
                    var currentPlayer = players[a];
                    Menue.ServeInteractivmenues(currentPlayer);
                }
            }
        }
    }
}