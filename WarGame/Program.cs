// UC3


Game g1 = new Game();
g1.Start();


class Game
{
    public bool GameOver = false;
    public Player p1;
    public Game()
    {
        CreatePlayer();
    }
    public void CreatePlayer()
    {
        p1 = new Player(5,5);
    }
    
    public void Start()
    {
        while (GameOver == false)
        {

            // Game.DrawMap();
            // Game.DrawEnemy();
            DrawPlayer();
            Console.ForegroundColor = ConsoleColor.Black;
            char input = Console.ReadKey().KeyChar;
            Console.ForegroundColor = ConsoleColor.White;
            RemovePlayer();
            p1.Move(input);
            //Console.SetCursorPosition(p1.x+1, p1.y);
            //Console.Write(" ");
            DrawPlayer();
            // Game.p1.Move();
            
        }
        
    }
    public void RemovePlayer()
    {
        Console.SetCursorPosition(p1.x, p1.y);
        Console.Write(" ");
    }
    public void DrawPlayer()
    {
        Console.SetCursorPosition(p1.x, p1.y);
        Console.Write("^");
    }
    /*
    Vi skal have:
    - Game.Start();
    - Game.DrawPlayer();
    - Game.RemovePlayer();
    - Game.DrawEnemy();
    - Game.RemoveEnemy();
    - Game.DrawPlayerShots();
    - Game.RemovePlayerShots();
    - Game.DrawEnemyShots();
    - Game.RemoveEnemyShots();
    -
    
    */
     

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
    public void Move(char a)
    {
        if(a == 'a')
        {
            x--;
        }
        if (a == 'd')
        {
            x++;
        }
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