using System;

namespace NewWorld10
{
    internal class Calculations
    {
        public static int LandLimit = 100;

        public static void BuyLand(Player player, int number)
        {
            if (player.Geld > number * 50 && LandLimit >= number)
            {
                player.Land.Balance += number;
                player.Geld -= number * 50;
                LandLimit -= number;
            }
            else
            {
                Console.WriteLine("Du hast nicht genug Geld!");
            }
        }

        public static void SaleLand(Player player, int number)
        {
            if (player.Land.Balance <= number) return;
            player.Land.Balance -= number;
            player.Geld += (int) (player.Land.BuyValue * 0.9);
        }

        public static void SellResources(Player player, int assignment, int frequency)
        {
            switch (assignment)
            {
                case 1:
                    if (player.Grain.Balance < frequency) return;
                    player.Grain.Balance -= frequency;
                    player.Geld += player.Grain.SaleValue;
                    break;
                case 2:
                    if (player.Oil.Balance < frequency) return;
                    player.Oil.Balance -= frequency;
                    player.Geld += player.Oil.SaleValue;
                    break;
                case 3:
                    if (player.Metal.Balance < frequency) return;
                    player.Metal.Balance -= frequency;
                    player.Geld += player.Metal.SaleValue;
                    break;
                case 4:
                    if (player.Crystal.Balance < frequency) return;
                    player.Crystal.Balance -= frequency;
                    player.Geld += player.Crystal.SaleValue;
                    break;
            }
        }

        public static void BuyResources(Player player, int assignment, int frequency)
        {
            switch (assignment)
            {
                case 1:
                    if (player.Geld < player.Grain.BuyValue * frequency) return;
                    player.Geld -= player.Grain.BuyValue * frequency;
                    player.Grain.Balance += frequency;
                    break;
                case 2:
                    if (player.Geld < player.Oil.BuyValue * frequency) return;
                    player.Geld -= player.Oil.BuyValue * frequency;
                    player.Oil.Balance += frequency;
                    break;
                case 3:
                    if (player.Geld < player.Metal.BuyValue * frequency) return;
                    player.Geld -= player.Metal.BuyValue * frequency;
                    player.Metal.Balance += frequency;
                    break;
                case 4:
                    if (player.Geld < player.Crystal.BuyValue * frequency) return;
                    player.Geld -= player.Crystal.BuyValue * frequency;
                    player.Crystal.Balance += frequency;
                    break;
            }
        }
    }
}