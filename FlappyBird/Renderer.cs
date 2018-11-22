using System;

class Renderer
{
    public void Render(Map map)
    {
        string output = "";

        for (int x = 0; x < map.GameMap.Count; x++)
        {
            for (int y = 0; y < map.GameMap[x].Count; y++)
            {
                output += map.GameMap[x][y].PrintSymbol();
            }
            output += "\n";
        }
        Console.WriteLine(output);
    }
}

