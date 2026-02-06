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
            int[] rows = { 3, 3, 3, 3, 3 };
            SlotMatrix slotMatrix = new SlotMatrix();
            Random random = new Random();
            string[][] grid = slotMatrix.CreateEmptyMatrix(rows.Length, rows);
            BaseReel.FillBaseReel(config, rows, grid, random);
            SlotMatrix.drawScreen(grid);
            Payline payline = new Payline();
            Dictionary<string, int[]> listSymbol = payline.GetFirstReelSymbol(grid);
            payline.CountSymbolOfReel(grid, listSymbol);
            Dictionary<string, Dictionary<string, object>> listPayout = payline.CalculatePayout(listSymbol);
            foreach (KeyValuePair<string, Dictionary<string, object>> data in listPayout)
            {
                Console.WriteLine(data.Key);
                foreach (KeyValuePair<string, object> entry in data.Value)
                {
                    Console.WriteLine(entry.Key + " : " + entry.Value);
                }
            }
        }
    }

}

// [
//   a:  {
//         "b":c,
//         "b":c,
//     },

//    b: {
//         "b":c,
//         "b":c,
//     }
// ]