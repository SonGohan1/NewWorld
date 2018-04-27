using System;

namespace NewWorld10
{
    public class Maschines
    {
        public static void CreateMaschines(Player player, int number)
        {
            if (player.Metal.Balance > number && player.Land.FreeLand > number)
            {
                player.FreeMaschines += number;
                player.Metal.Balance -= number;
            }
            else
            {
                Console.WriteLine("Du hast nicht genügend Land oder Metall.");
            }
        }

        public static void ExemptMaschines(Player player, int assignment, int frequency)
        {
            switch (assignment)
            {
                case 1:
                    ExemptCalculation(player, player.GrainMaschines, frequency, assignment);
                    break;
                case 2:
                    ExemptCalculation(player, player.OilMaschines, frequency, assignment);
                    break;
                case 3:
                    ExemptCalculation(player, player.MetalMaschines, frequency, assignment);
                    break;
                case 4:
                    ExemptCalculation(player, player.CrystalMaschines, frequency, assignment);
                    break;
            }
        }

        private static void ExemptCalculation(Player player, int maschine, int frequency, int assignment)
        {
            if (frequency > maschine) Console.WriteLine("Du hast nicht genügend Maschinen.");
            else
                switch (assignment)
                {
                    case 1:
                        player.GrainMaschines -= frequency;
                        player.FreeMaschines += frequency;
                        break;
                    case 2:
                        player.OilMaschines -= frequency;
                        player.FreeMaschines += frequency;
                        break;
                    case 3:
                        player.MetalMaschines -= frequency;
                        player.FreeMaschines += frequency;
                        break;
                    case 4:
                        player.CrystalMaschines -= frequency;
                        player.FreeMaschines += frequency;
                        break;
                }
        }

        public static void AssignMaschines(Player player, int assignment, int frequency)
        {
            if (frequency <= player.FreeMaschines)
                switch (assignment)
                {
                    case 1:
                        player.GrainMaschines += frequency;
                        player.FreeMaschines -= frequency;
                        break;
                    case 2:
                        player.OilMaschines += frequency;
                        player.FreeMaschines -= frequency;
                        break;
                    case 3:
                        player.MetalMaschines += frequency;
                        player.FreeMaschines -= frequency;
                        break;
                    case 4:
                        player.CrystalMaschines += frequency;
                        player.FreeMaschines -= frequency;
                        break;
                }
            else Console.WriteLine("Du hast nicht genügend freie Maschinen.");
        }
    }
}