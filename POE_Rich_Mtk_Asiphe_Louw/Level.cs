using System;
using System.Text;

namespace POE_Rich_Mtk_Asiphe_Louw
{
    internal class Level                        //Level Class to create and display the game levels
    {
        private Tile[,] tiles;                  //2D tile class array for the level layout
        private int width;
        private int height;
        private HeroTile hero;
        private ExitTile exit;
        private Random random;
        private EnemyTile[] enemies;
        private int enemyNum;

        public Tile[,] Tiles                    //Constructor for tile array
        {
            get { return tiles; }
        }

        public HeroTile Hero
        {
            get { return hero; }
        }

        public ExitTile Exit
        {
            get { return exit; }
        }

        public Level(int width, int height, int enemyNum, HeroTile hero = null)   //Level constructor with width taking the Y variable and Height taking the X variable
        {
            this.width = width;
            this.height = height;
            tiles = new Tile[width, height];
            random = new Random();
            this.enemyNum = enemyNum;
            enemies = new EnemyTile[enemyNum];
            int i = 0;

            InitialiseTiles();                                      //Calls method to initialise the level

            Position heroPosition = GetRandomEmptyPosition();

            if (hero == null)
            {
                this.hero = (HeroTile)CreateTile(TileType.Hero, heroPosition);
            }
            else
            {
                hero.Position = heroPosition;
                tiles[heroPosition.X, heroPosition.Y] = hero;
                this.hero = hero;
            }

            Position exitPosition = GetRandomEmptyPosition();
            exit = (ExitTile)CreateTile(TileType.Exit, exitPosition);

            this.hero.UpdateVision(this);

            while (i < enemyNum)
            {
                Position enemyPosition = GetRandomEmptyPosition();
                enemies[i] = (EnemyTile)CreateTile(TileType.Enemy, enemyPosition);
                i++;
            }
        }

        private enum TileType             //Enum to dictate the tiletype, such as Empty, Wall, Hero and Exit
        {
            Empty,
            Wall,
            Hero,
            Exit,
            Enemy
        }

        private Tile CreateTile(TileType tileType, Position position)   //Method to create tiles, by figuring out which tile type to make and creating a new tile class with the given position and tiletype
        {
            Tile tile;

            switch (tileType)           //Switch that changes dependeant on the sent Enum
            {
                case TileType.Empty:
                    tile = new EmptyTile(position);
                    break;
                case TileType.Wall:
                    tile = new WallTile(position);
                    break;
                case TileType.Hero:
                    tile = new HeroTile(position);
                    break;
                case TileType.Exit:
                    tile = new ExitTile(position);
                    break;
                case TileType.Enemy:
                    tile = new GruntTile(position);
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(tileType));
            }

            tiles[position.X, position.Y] = tile;
            return tile;                //Returns created tile
        }

        private void InitialiseTiles()  //Method to initialize map with empty tiles
        {
            for (int y = 0; y < height; y++)
            {
                for (int x = 0; x < width; x++)
                {
                    bool isBoundary = x == 0 || x == width - 1 || y == 0 || y == height - 1;
                    TileType tileType = isBoundary ? TileType.Wall : TileType.Empty;
                    CreateTile(tileType, new Position(x, y));
                }
            }
        }

        private Position GetRandomEmptyPosition()
        {
            int x;
            int y;

            do
            {
                x = random.Next(0, width);
                y = random.Next(0, height);
            }
            while (!(tiles[x, y] is EmptyTile));

            return new Position(x, y);
        }

        public void SwapTiles(Tile firstTile, Tile secondTile)
        {
            Position firstPosition = firstTile.Position;
            Position secondPosition = secondTile.Position;

            tiles[firstPosition.X, firstPosition.Y] = secondTile;
            tiles[secondPosition.X, secondPosition.Y] = firstTile;

            firstTile.Position = secondPosition;
            secondTile.Position = firstPosition;
        }

        public override string ToString()
        {
            StringBuilder levelDisplay = new StringBuilder();

            for (int y = 0; y < height; y++)
            {
                for (int x = 0; x < width; x++)
                {
                    levelDisplay.Append(tiles[x, y].Display);
                }

                levelDisplay.Append('\n');
            }

            return levelDisplay.ToString();
        }

        public EnemyTile[] Enemies
        {
            get {return enemies;}
            set {enemies = value;}
        }

        public void UpdateVision(Level currentLevel)
        {
            int i = 0;
            while (i < enemyNum)
            {
                enemies[i].UpdateVision(currentLevel);
                i++;
            }
            hero.UpdateVision(currentLevel);
        }
    }
}
