using System;
using System.Collections.Generic;

class Map : TowerConfiguration
{

    private const int height = 16;
    private const int length = 16;

    private List<List<MapElement>> map;
    public List<List<MapElement>> GameMap
    {
        get
        {
            return map;
        }
    }

    public Map()
    {
        random = new Random();
        map =new List<List<MapElement>>();

        for (int rows = 0; rows < height; rows++)
        {
            map.Add(new List<MapElement>());
        }
        ConfigureNextTower(height);
        GenerateStartingMap();
    }

    public void ChangePlayerPos(IntVector2 oldPos, IntVector2 newPos)
    {
        map[oldPos.x][oldPos.y] = new Air();
        map[newPos.x][newPos.y] = new Player();
    }

    public void MoveMap()
    {
        RemoveMapSegment();
        AddMapSegment();
    }

    void GenerateStartingMap()
    {
        for (int i = 0; i < length; i++)
        {
            AddMapSegment();
        }
    }

    void RemoveMapSegment()
    {
        for (int row = 0; row < height; row++)
        {
            map[row].RemoveAt(0);
        }
    }

    void AddMapSegment()
    {
        distanceFromLastTower++;

        bool towerWasBuild = false;

        for (int row = 0; row < height; row++)
        {
            map[row].Add(CreateMapElement(row, ref towerWasBuild));
        }
        if (towerWasBuild == true)
        {
            ConfigureNextTower(height);
        }
    }

    MapElement CreateMapElement(int row, ref bool towerWasBuilt)
    {
        if (row == 0 || row == height - 1)
        {
            return new Border();
        }
        else if (distanceFromLastTower == distanceToNextTower)
        {
            towerWasBuilt = true;

            if (lastTowerDirection == Direction.DOWN) 
            {
                return ElementFromTheTop(row);
            }
            else
            {
                return ElementFromTheBottom(row);
            }
        }
        else
        {
            return new Air();
        }
    }

    MapElement ElementFromTheTop(int row)
    {
        if (row < nextTowerHeight)
        {
            return new Brick();
        }
        else if (row == nextTowerHeight)
        {
            return new TowerBottom();
        }
        else
        {
            return new Air();
        }
    }

    MapElement ElementFromTheBottom(int row)
    {
        if (row + nextTowerHeight > height)
        {
            return new Brick();
        }
        else if (row + nextTowerHeight == height)
        {
            return new TowerTop();
        }
        else
        {
            return new Air();
        }
    }
}