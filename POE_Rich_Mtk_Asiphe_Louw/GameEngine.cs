using System;

namespace POE_Rich_Mtk_Asiphe_Louw
{
    internal class GameEngine
    {
        private const int MIN_SIZE = 10;        //Minimum size that a tile row or column can be
        private const int MAX_SIZE = 20;        //Maximun size that a tile row or column can be

        private Level currentLevel;             //Level type variable to store the currents level's data
        private int numberOfLevels;             //Variable to hold the amount of levels the game will generate
        private int currentLevelNumber;
        private int enemyNum;
        private Random random;
        private GameState gameState = GameState.InProgress;
        private int movesMade;

        public GameEngine(int numberOfLevels)
        {
            this.numberOfLevels = numberOfLevels;
            currentLevelNumber = 1;
            random = new Random();
            movesMade = 0;

            int width = random.Next(MIN_SIZE, MAX_SIZE + 1);
            int height = random.Next(MIN_SIZE, MAX_SIZE + 1);
            enemyNum = currentLevelNumber;
            currentLevel = new Level(width, height, enemyNum);
        }

        private bool MoveHero(Direction direction)
        {
            if (direction == Direction.None)
            {
                return false;
            }

            HeroTile hero = currentLevel.Hero;
            Tile targetTile = hero.Vision[(int)direction];

            if (targetTile is ExitTile)
            {
                if (currentLevelNumber == numberOfLevels)
                {
                    gameState = GameState.Complete;
                    return false;
                }

                NextLevel();
                return true;
            }

            if (!(targetTile is EmptyTile))
            {
                return false;
            }

            currentLevel.SwapTiles(hero, targetTile);
            currentLevel.UpdateVision(currentLevel);
            return true;
        }

        private void NextLevel()
        {
            currentLevelNumber++;
            HeroTile hero = currentLevel.Hero;

            int width = random.Next(MIN_SIZE, MAX_SIZE + 1);
            int height = random.Next(MIN_SIZE, MAX_SIZE + 1);
            currentLevel = new Level(width, height, enemyNum, hero);
        }

        public void TriggerMovement(Direction direction)
        {
            MoveHero(direction);
            movesMade++;

            if (movesMade % 2 == 0)
            {
                MoveEnemies();
            }
        }

        public override string ToString()
        {
            if (gameState == GameState.Complete)
            {
                return "Congratulations! You have successfully completed the game.";
            }

            return currentLevel.ToString();
        }

        private void MoveEnemies()
        {
            int i = 0;

            while (i< enemyNum)
            {
                if (currentLevel.Enemies[i].IsDead == true)
                {
                    i++;
                }
                else
                {
                    if (currentLevel.Enemies[i].GetMove(out Tile tileTo) == false)
                    {
                        i++;
                    }
                    else
                    {
                        currentLevel.SwapTiles(currentLevel.Enemies[i], tileTo);
                        currentLevel.UpdateVision(currentLevel);
                    }
                }
            }
        }
    }
}
