public class Coordonates
{

    private int ligne;

    private int col;

    private string id;

    public Coordonates(int ligne, int col, string id)
    {
        this.ligne = ligne;
        this.col = col;
        this.id = id;
    }

    public int getLigne()
    {
        return ligne;
    }

    public int getCol()
    {
        return col;
    }

    public string GetId(){
        return id;
    }

}