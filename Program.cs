using System;
using System.Text.Json;
using Microsoft.VisualBasic;

namespace FunSlot
{
    class Program
    {
        static void Main(string[] args)
        {
            string jsonPath = "data.json";
            string jsonContent = File.ReadAllText(jsonPath);
            var config = JsonSerializer.Deserialize<Configs>(jsonContent);
            int[] rows = { 3, 3, 3 };
            SlotMatrix slotMatrix = new SlotMatrix();
            Random random = new Random();
            string[][] grid = slotMatrix.CreateEmptyMatrix(rows.Length, rows);
            grid[0][0] = "SSS";
            BaseReel.FillBaseReel(config, rows, grid, random);
            SlotMatrix.drawScreen(grid);
        }
    }
    class BaseReel
    {
        public static string[][] FillBaseReel(Configs config, int[] rows, string[][] grid, Random random)
        {

            for (int i = 0; i < rows.Length; i++)

            {
                for (int j = 0; j < rows[i]; j++)
                {
                    int[] perConfig = config.reelConfigs[i].perConfig;
                    string[] baseReel = config.baseReel[i];
                    string symbolCode = SlotMatrix.RandomByCumWeights(baseReel, perConfig, random);
                    grid = SlotMatrix.FillSymbol(symbolCode, grid);
                }

            }
            return grid;
        }
    }

    class Payline
    {
        public Dictionary<string, List<int>> GetFirstReelSymbol(string[][] grid)
        {
            Dictionary<string, List<int>> baseSymbol = new Dictionary<string, List<int>>();

            foreach (string sym in grid[0])
            {
                baseSymbol.Add(sym, new List<int>());
            }
            return baseSymbol;
        }
        public void CountSymbolOfReel(string[][] grid, Dictionary<string, List<int>> firstSymbol)
        {

            foreach (string[] reel in grid)
            {
                foreach (string symbol in reel)
                {

                }
            }
            // firstSymbol[symvol] *= soluong 
        }
    }
}
/// 1 2 3 
/// 
/// {"a" : 0}
/// 

