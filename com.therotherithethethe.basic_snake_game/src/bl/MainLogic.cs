using com.therotherithethethe.basic_snake_game.src.dal;

namespace com.therotherithethethe.basic_snake_game.src.bl
{
    internal class MainLogic
    {
        private Grid _grid;
        private Cell[] _snakeCells = new Cell[1];

        private Cell _food;

        private ConsoleKey _currentDirection = ConsoleKey.RightArrow;
        public MainLogic(Grid grid, Cell snakeHead)
        {
            _grid = grid;
            _snakeCells[0] = snakeHead;

            _food = new Cell(_grid) { 
                Texture = "X"
            };

            InitializeGameTable();
            SpawnFood();
        }
        public void InitializeGameTable()
        {
            _grid.SetTextureToGrid(_snakeCells[0].X, _snakeCells[0].Y, _snakeCells[0].Texture);
        }
        public void SpawnFood()
        {
            Random r = new Random();
            bool isFoodXYEqualSnakeXY;
            int x, y;
            int cellCounter = _snakeCells.Length;

            if( cellCounter == _grid.XLength*_grid.YLength ) 
            {
                //do nothing
            }
            else
            {
                do
                {
                    isFoodXYEqualSnakeXY = false;
                    x = r.Next(1, _grid.XLength + 1);
                    y = r.Next(1, _grid.YLength + 1);

                    for (int i = 0; i < _snakeCells.Length; i++)
                    {
                        if (x == _snakeCells[i].X && y == _snakeCells[i].Y)
                        {
                            isFoodXYEqualSnakeXY = true;
                        }

                    }
                } while (isFoodXYEqualSnakeXY);



                _food.X = x;
                _food.Y = y;
                _grid.SetTextureToGrid(_food.X, _food.Y, _food.Texture);
            }
            
        }

        public void UpdateGameTable()
        {
            Cell[] coordinatesBuffer = new Cell[_snakeCells.Length];

            Cell lastCell = new Cell(_grid)
            {
                X = _snakeCells[_snakeCells.Length - 1].X,
                Y = _snakeCells[_snakeCells.Length - 1].Y
            };

            for (int i = 0; i < coordinatesBuffer.Length; i++)
            {
                coordinatesBuffer[i] = new Cell(_grid) 
                {
                    X = _snakeCells[i].X,
                    Y = _snakeCells[i].Y
                };
            }

            if (Console.KeyAvailable)
            {
                ConsoleKeyInfo keyChoice = Console.ReadKey(true);
                if (keyChoice.Key == ConsoleKey.UpArrow || keyChoice.Key == ConsoleKey.DownArrow ||
                    keyChoice.Key == ConsoleKey.LeftArrow || keyChoice.Key == ConsoleKey.RightArrow)
                {
                    _currentDirection = keyChoice.Key;
                }
            }


            switch(_currentDirection)
            {
                case ConsoleKey.UpArrow:

                    _snakeCells[0].Y = _snakeCells[0].Y - 1;
                    
                    break;

                case ConsoleKey.DownArrow:
                    _snakeCells[0].Y = _snakeCells[0].Y + 1;

                    break;

                case ConsoleKey.LeftArrow:
                    _snakeCells[0].X = _snakeCells[0].X - 1;

                    break;

                case ConsoleKey.RightArrow:
                    _snakeCells[0].X = _snakeCells[0].X + 1;

                    break;
                default:
                    _snakeCells[0].X = _snakeCells[0].X;
                    break;
            }

            for (int i = 1; i < coordinatesBuffer.Length; i++)
            {
                _snakeCells[i].Y = coordinatesBuffer[i - 1].Y;
                _snakeCells[i].X = coordinatesBuffer[i - 1].X;
            }


            for (int i = 0; i < _snakeCells.Length; i++)
            {
                _grid.SetTextureToGrid(_snakeCells[i].X, _snakeCells[i].Y, _snakeCells[0].Texture);
            }

            _grid.SetTextureToGrid(coordinatesBuffer[coordinatesBuffer.Length-1].X, coordinatesBuffer[coordinatesBuffer.Length - 1].Y, _grid.Texture);

            if (_snakeCells[0].X == _food.X && _snakeCells[0].Y == _food.Y)
            {

                Cell[] newSnakeCells = new Cell[_snakeCells.Length + 1];
                

                for(int i = 0;i < _snakeCells.Length;i++)
                {
                    newSnakeCells[i] = _snakeCells[i];
                }
                newSnakeCells[newSnakeCells.Length - 1] = new Cell(_grid) { 
                    X = lastCell.X, 
                    Y = lastCell.Y 
                };

                _snakeCells = newSnakeCells;
                _grid.SetTextureToGrid(lastCell.X, lastCell.Y, lastCell.Texture);
                SpawnFood();

            }


        }
        public bool IsGameOver()
        {
            for (int i = 0; i < _snakeCells.Length; i++)
            {
                for (int j = 0; j < _snakeCells.Length; j++)
                {
                    if (i == j || _snakeCells.Length == 1)
                    {
                        continue;
                    }
                    if ((_snakeCells[j].X == _snakeCells[i].X) && (_snakeCells[j].Y == _snakeCells[i].Y))
                    {
                        return true;
                    }
                }
            }
            return _snakeCells[0].X == _grid.XLength + 1 || _snakeCells[0].X < 1 || _snakeCells[0].Y == _grid.YLength + 1 || _snakeCells[0].Y < 1;

        }
        public Grid Grid => _grid;
        public Cell[] SnakeCells => _snakeCells;

    }
}
