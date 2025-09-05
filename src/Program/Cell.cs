namespace Ucu.Poo.GameOfLife;

public class Cell
{
    private bool alive;

    public bool Alive
    {
        get{return alive;}
        set{alive = value;}
    }

    public Cell(bool estado)
    {
        this.Alive = estado;
    }
}