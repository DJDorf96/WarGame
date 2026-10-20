// UC2



class Game
{
    public Player p1;
    public void CreatePlayer()
    {
        p1 = new Player(5,5);
    }
}

class Player
{
    public List<Shot> shotlist;
    public int x;
    public int y;
    public Player(int x, int y) //Contructor
    {
        this.x = x;
        this.y = y;
        shotlist = new List<Shot>();
    }
    public void shoot()
    {
        shotlist.Add(new Shot(5, 5));
    }
}

class Enemy
{

}

class Shot
{
    public int x;
    public int y;
    public Shot(int x, int y)
    {
        this.x = x;
        this.y = y;
    }
}