using System;

public struct IntVector2
{
    public int x, y;
    public IntVector2(int _x, int _y)
    {
        x = _x;
        y = _y;
    }
}

class Movement
{

    IntVector2 newPos = new IntVector2(8, 1);
    IntVector2 oldPos = new IntVector2(8, 1);

    const int deltaMove = 1;

    public bool WaitForKeyPress()
    {
        if (Console.ReadKey(true).Key == ConsoleKey.W)
        {
            newPos.x -= deltaMove;
            return true;
        }
        else if (Console.ReadKey(true).Key == ConsoleKey.S)
        {
            newPos.x += deltaMove;
            return true;
        }
        else
        {
            return false;
        }
    }

    public void MovePlayer(Map map)
    {
        map.ChangePlayerPos(oldPos, newPos);
        oldPos = newPos;
    }

    public bool CheckForColision(Map map)
    {
        if (map.GameMap[newPos.x][newPos.y] is Brick)
        {
            return true;
        }
        else
            return false;
    }
}

