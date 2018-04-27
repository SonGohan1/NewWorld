using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace NewWorld10
{
    class ExitRound
    {
        public static int AvailableSettler;

        public static void CalculateRound(Player player)
        {
            SettlerCalculation(player);
            CalculateGrainmaschineProduction(player);
            CalculateOilmaschineProduction(player);
            CalculateMetalmaschineProduction(player);
            CalculateCrystalmaschineProdcution(player);
        }
        public static void SettlerCalculation(Player player)
        {
            if (player.Grain.Balance > player.Siedler) player.Grain.Balance -= player.Siedler;
            else
            {
                player.Siedler = player.Grain.Balance;
                player.Grain.Balance = 0;
            }
        }

        public static void CalculateGrainmaschineProduction(Player player)
        {
            AvailableSettler = player.Siedler;
            for (var i = 0; i < player.GrainMaschines; i++)
            {
                if (player.Oil.Balance > 0 && AvailableSettler > 0)
                {
                    player.Oil.Balance--;
                    player.Grain.Balance += 10;
                    AvailableSettler--;
                }
            }
        }
        public static void CalculateOilmaschineProduction(Player player)
        {
            for (var i = 0; i < player.OilMaschines; i++)
            {
                if (player.Oil.Balance > 0 && AvailableSettler > 0)
                {
                    player.Oil.Balance--;
                    player.Oil.Balance += 5;
                    AvailableSettler--;
                }
            }
        }
        public static void CalculateMetalmaschineProduction(Player player)
        {
            for (var i = 0; i < player.MetalMaschines; i++)
            {
                if (player.Oil.Balance > 0 && AvailableSettler > 0)
                {
                    player.Oil.Balance--;
                    player.Metal.Balance += 1;
                    AvailableSettler--;
                }
            }
        }

        public static void CalculateCrystalmaschineProdcution(Player player)
        {
            for (var i = 0; i < player.CrystalMaschines; i++)
            {
                if (player.Oil.Balance > 0 && AvailableSettler > 0)
                {
                    player.Oil.Balance--;
                    player.Crystal.Balance++;
                    AvailableSettler--;
                }
            }
        }


    }
}
