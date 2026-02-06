using System;
using System.Linq;

namespace FunSlot
{
    class Payline
    {
        public Dictionary<string, int[]> GetFirstReelSymbol(string[][] grid)
        {
            Dictionary<string, int[]> baseSymbol = new Dictionary<string, int[]>();

            foreach (string sym in grid[0])
            {
                if (!baseSymbol.TryGetValue(sym, out int[] r))
                    baseSymbol.Add(sym, new int[grid.Length]);
            }
            return baseSymbol;
        }
        public void CountSymbolOfReel(string[][] grid, Dictionary<string, int[]> firstSymbol)
        {
            for (int i = 0; i < grid.Length; i++)
            {
                foreach (string key in firstSymbol.Keys)
                {
                    for (int j = 0; j < grid[i].Length; j++)
                    {
                        if (grid[i][j] == key)
                        {
                            firstSymbol[key][i] += 1;
                        }
                    }
                }

            }
        }
        public Dictionary<string, Dictionary<string, object>> CalculatePayout(Dictionary<string, int[]> firstSymbol)
        {
            Dictionary<string, Dictionary<string, object>> list = new Dictionary<string, Dictionary<string, object>>();
            foreach (KeyValuePair<string, int[]> entry in firstSymbol)
            {
                Dictionary<string, object> payoutAmount = new Dictionary<string, object>();
                int totalWay = 1;
                Console.WriteLine(string.Join(", ", entry.Value));
                for (int i = 0; i < entry.Value.Length; i++)
                {
                    if (entry.Value[i] != 0)
                    {
                        totalWay *= entry.Value[i];
                        payoutAmount["totalWay"] = totalWay;
                        payoutAmount["index"] = i;

                    }
                    else
                    {
                        break;
                    }
                }
                list[entry.Key] = payoutAmount;
            }

            return list;
        }

        public void PayoutCalculation(Dictionary<string, Dictionary<string, object>> List, Symbols[] symbols)
        {
            foreach (KeyValuePair<string, Dictionary<string, object>> data in List)
            {
                var item = symbols.FirstOrDefault(x => x.code == data.Key);
                var indexCode = List[item.code]["index"];
                var totalPayout = List[item.code]["totalWay"];
                var payoutAmount = item.paytable[(int)indexCode] * (int)totalPayout;
                Console.WriteLine(item.code + " " + item.paytable[(int)indexCode] + " * " + totalPayout + " = " + payoutAmount);

            }

        }

    }

}
