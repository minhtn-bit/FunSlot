using System;

namespace FunSlot
{
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
}
