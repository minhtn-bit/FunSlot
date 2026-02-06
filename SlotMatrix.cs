using System;

public class SlotMatrix
{
    public static void drawScreen(string[][] grid)
    {
        for (int r = 0; r < grid.Length; r++)
        {
            Console.Write("|");
            for (int c = 0; c < grid[r].Length; c++)
            {
                // Căn lề 5 ký tự cho biểu tượng
                Console.Write($" {grid[r][c].PadRight(5)} |");
            }
            Console.WriteLine("");
        }
    }
    public string[][] CreateEmptyMatrix(int reel, int[] rows)
    {

        string[][] grid = new string[reel][];

        for (int i = 0; i < reel; i++)
        {
            string[] line = new string[rows[i]];
            Array.Fill(line, string.Empty);
            grid[i] = line;
        }

        return grid;


    }

    public static string[][] FillSymbol(string symbolCode, string[][] grid)
    {
        // string[][] filledGrid = grid;

        foreach (string[] reel in grid)
        {
            for (int i = 0; i < reel.Length; i++)
            {
                if (reel[i] == "")
                {
                    reel[i] = symbolCode;
                    return grid;
                }

            }
        }
        return grid;
    }

    public static string RandomByCumWeights(string[] values, int[] cumulativeWeights, Random random)
    {

        int randomWeight = random.Next(0, cumulativeWeights[^1]);

        int selectedIndex = 0;
        for (int i = 0; i < cumulativeWeights.Length; i++)
        {
            if (randomWeight < cumulativeWeights[i])
            {
                selectedIndex = i;
                break;
            }
        }

        return values[selectedIndex];
    }
}


/// {A : { }}