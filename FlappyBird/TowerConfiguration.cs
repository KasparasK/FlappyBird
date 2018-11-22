using System;

public enum Direction
{
    UP,
    DOWN
}

public class TowerConfiguration
{
    protected int distanceFromLastTower = 0;
    protected int distanceToNextTower = 0;
    protected int nextTowerHeight = 0;

    protected Direction lastTowerDirection = Direction.DOWN;

    public Random random;

    protected void ConfigureNextTower(int mapHeight)
    {

        distanceFromLastTower = 0;

        nextTowerHeight = GetNextTowerHeight(mapHeight);
        distanceToNextTower = GetDistanceToNextTower();
        SwapNextTowerDir();
    }

    void SwapNextTowerDir()
    {
        if (lastTowerDirection == Direction.DOWN)
            lastTowerDirection = Direction.UP;
        else
            lastTowerDirection = Direction.DOWN;
    }

    public int GetNextTowerHeight(int mapHeight)
    {
        int minHeight = mapHeight / 3;
        int maxHeight = mapHeight / 2 + 1;

        return random.Next(minHeight, maxHeight);
    }

    public int GetDistanceToNextTower()
    {
        const int minDistance = 3;
        const int maxDistance = 4;

        return random.Next(minDistance, maxDistance);
    }
}
