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
        p1 = new Player(20,20);
    }
    
    public void Start()
    {
        while (GameOver == false)
        {
            RemovePlayerShots();
            MovePlayerShots();
            DrawPlayerShot();
            // Game.DrawMap();
            // Game.DrawEnemy();
            DrawPlayer();
            Console.ForegroundColor = ConsoleColor.Black;
            char input = Console.ReadKey().KeyChar;
            Console.ForegroundColor = ConsoleColor.White;
            if(input == 'a' || input == 'd')
            {
                RemovePlayer();
                p1.Move(input);
            }
            else if(input == ' ')
            {
                p1.Shoot();
                DrawPlayerShot();
            }
            DrawPlayer();
            // Game.p1.Move();
            
        }
        
    }
    public void DrawPlayerShot()
    {
        int i = 0;
        while(i < p1.shotlist.Count)
        {
            Console.SetCursorPosition(p1.shotlist[i].x, p1.shotlist[i].y);
            Console.WriteLine("|");
            i++;
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
    public void MovePlayerShots()
    {
        int i = 0;
        while(i < p1.shotlist.Count)
        {
            p1.shotlist[i].y--;
            if (p1.shotlist[i].y <= -1)
            {
                p1.shotlist.RemoveAt(i);
            }
            i++;
        }
    }
    public void RemovePlayerShots()
    {
        int i = 0;
        while(i < p1.shotlist.Count)
        {
            Console.SetCursorPosition(p1.shotlist[i].x, p1.shotlist[i].y);
            Console.Write(" ");
            i++;
        }
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
    public void Shoot()
    {
        shotlist.Add(new Shot(x, y));
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