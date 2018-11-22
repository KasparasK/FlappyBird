struct MapSymbols
{
    public readonly static char player = 'W';
    public readonly static char air = ' ';
    public readonly static char brick = '|';
    public readonly static char border = '=';
    public readonly static char towerTopDown = 'v';
    public readonly static char towerTopUp = '^';
}


abstract class MapElement
{
    public abstract char PrintSymbol();
}

class Brick : MapElement
{
    public override char PrintSymbol()
    {
        return MapSymbols.brick;
    }
}

class TowerTop : MapElement
{
    public override char PrintSymbol()
    {
        return MapSymbols.towerTopUp;
    }
}

class TowerBottom : MapElement
{
    public override char PrintSymbol()
    {
        return MapSymbols.towerTopDown;
    }
}

class Border : MapElement
{
    public override char PrintSymbol()
    {
       return MapSymbols.border; 
    }
}

class Air : MapElement
{
    public override char PrintSymbol()
    {
        return MapSymbols.air;
    }
}

class Player : MapElement
{

    public override char PrintSymbol()
    {
        return MapSymbols.player;
    }
}
