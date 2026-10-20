// UC1



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
    public int x;
    public int y;
    public Player(int x, int y) //Contructor
    {
        this.x = x;
        this.y = y;
    }
}

class Enemy
{

}

class Skud
{

}