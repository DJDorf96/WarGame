// UC6 - Update
Console.CursorVisible = false;

Game g1 = new Game();
g1.Start();

class Game
{
    public int EnemyLowestX;
    public int EnemyDirection;
    public int EnemyHighestX;
    public int EnemyCount;
    public List<Enemy> EnemyList;
    public bool GameOver = false;
    public Player p1;
    public Game()
    {
        EnemyLowestX = int.MaxValue;
        EnemyCount = 40;
        EnemyDirection = 1;
        CreatePlayer();
        EnemyList = new List<Enemy>();
        CreateEnemy();
        DrawPlayer();
        DrawEnemy();
        DrawBoard();
    }
    public void CreatePlayer()
    {
        p1 = new Player(20,20);
    }
    public void CreateEnemy()
    {
        int i = 1;
        int xhen = 1;
        int yned = 0;
        while(i < EnemyCount+1)
        {
            EnemyList.Add(new Enemy(xhen+5, yned+5));
            if(i % 10 == 0)
            {
                xhen = 0;
                yned++;
            }
            i++;
            xhen++;
        }
        
    }
    
    public void Start()
    {
        while (GameOver == false)
        {
            RemovePlayerShots();
            MovePlayerShots();
            DrawPlayerShot();
            DrawPlayer();
            // Game.DrawMap();
            // Game.DrawEnemy();
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
            MoveEnemy();
            DrawEnemy();
            // Game.p1.Move();
            
        }
        
    }
    public void MoveEnemy()
    {
        int i = 0;
        if(EnemyHighestX < 39 && EnemyLowestX > 1)
        {
            while (i < EnemyList.Count)
            {
                EnemyList[i].x = EnemyList[i].x + (1 * EnemyDirection);
                i++;
            }
        }
        else
        {
            EnemyDirection = -EnemyDirection;
            EnemyHighestX = 0;
            EnemyLowestX = int.MaxValue;
            while (i < EnemyList.Count)
            {
                EnemyList[i].x = EnemyList[i].x + (1 * EnemyDirection);
                EnemyList[i].y++;
                i++;
            }
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
    public void DrawEnemy()
    {
        int i = 0;
        while (i < EnemyList.Count)
        {
            Console.SetCursorPosition(EnemyList[i].x, EnemyList[i].y);
            Console.WriteLine("O");
            if (EnemyList[i].x > EnemyHighestX) // Kan potentielt forbedres! 
            {
                EnemyHighestX = EnemyList[i].x;
            }
            if (EnemyList[i].x < EnemyLowestX)
            {
                EnemyLowestX = EnemyList[i].x;
            }                
            i++;
        }
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
    public void DrawBoard()
    {
        int i = 0;
        while(i < 20)
        {
            Console.SetCursorPosition(0, i);
            Console.Write("|");
            i++;
        }
        i = 0;
        while(i < 20)
        {
            Console.SetCursorPosition(40, i);
            Console.Write("|");
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
        if(a == 'a' && x > 1)
        {
            x--;
        }
        if (a == 'd' && x < 39)
        {
            x++;
        }
    }
}

class Enemy
{
    public bool IsDead;
    public int x;
    public int y;
    public Enemy(int x, int y)
    {
        this.x = x;
        this.y = y;
        IsDead = false;
    }
    
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