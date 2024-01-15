using com.therotherithethethe.basic_snake_game.src.dal;

namespace com.therotherithethethe.basic_snake_game.src.bl
{
    internal class MainLogic
    {
        private Grid _grid;
        private Cell[] _snakeCells = new Cell[1];

        private Cell _food;

        public MainLogic(Grid grid, Cell snakeHead)
        {
            _grid = grid;
            _snakeCells[0] = snakeHead;
            _food = new Cell(_grid) { Texture = "X"};
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
            int x, y;

            do
            {
                x = r.Next(1, _grid.XLength + 1);
                y = r.Next(1, _grid.YLength + 1);
            } while (x == _snakeCells[0].X && y == _snakeCells[0].Y);

            _food.X = x;
            _food.Y = y;
            _grid.SetTextureToGrid(_food.X, _food.Y, _food.Texture);
        }

        public void UpdateGameTable()
        {

            //int tempX = _snakeCells[0].X;
            //int tempY = _snakeCells[0].Y;
            Cell[] coordinatesBuffer = new Cell[_snakeCells.Length];

            for(int i = 0; i < coordinatesBuffer.Length; i++)
            {
                coordinatesBuffer[i] = new Cell(_grid) 
                {
                    X = _snakeCells[i].X,
                    Y = _snakeCells[i].Y,
                };
            }

            ConsoleKeyInfo choice = Console.ReadKey();

            switch(choice.Key)
            {
                case ConsoleKey.UpArrow:

                    _snakeCells[0].Y = _snakeCells[0].Y - 1;

                    for(int i = 1; i < coordinatesBuffer.Length; i++)
                    {
                        _snakeCells[i].Y = coordinatesBuffer[i - 1].Y;
                        _snakeCells[i].X = coordinatesBuffer[i - 1].X;
                    }
                    break;

                case ConsoleKey.DownArrow:
                    _snakeCells[0].Y = _snakeCells[0].Y + 1;

                    for (int i = 1; i < coordinatesBuffer.Length; i++)
                    {
                        _snakeCells[i].Y = coordinatesBuffer[i - 1].Y;
                        _snakeCells[i].X = coordinatesBuffer[i - 1].X;
                    }
                    break;

                case ConsoleKey.LeftArrow:
                    _snakeCells[0].X = _snakeCells[0].X - 1;

                    for (int i = 1; i < coordinatesBuffer.Length; i++)
                    {
                        _snakeCells[i].Y = coordinatesBuffer[i - 1].Y;
                        _snakeCells[i].X = coordinatesBuffer[i - 1].X;
                    }
                    break;

                case ConsoleKey.RightArrow:
                    _snakeCells[0].X = _snakeCells[0].X + 1;

                    for (int i = 1; i < coordinatesBuffer.Length; i++)
                    {
                        _snakeCells[i].Y = coordinatesBuffer[i - 1].Y;
                        _snakeCells[i].X = coordinatesBuffer[i - 1].X;
                    }
                    break;
                default:
                    _snakeCells[0].X = _snakeCells[0].X;
                    break;
            }
            //_grid.SetTextureToGrid(_snakeCells[0].X, _snakeCells[0].Y, _snakeCells[0].Texture);

            for (int i = 0; i < _snakeCells.Length; i++)
            {
                _grid.SetTextureToGrid(_snakeCells[i].X, _snakeCells[i].Y, _snakeCells[0].Texture);
            }

            _grid.SetTextureToGrid(coordinatesBuffer[coordinatesBuffer.Length-1].X, coordinatesBuffer[coordinatesBuffer.Length - 1].Y, _grid.Texture);

            if (_snakeCells[0].X == _food.X && _snakeCells[0].Y == _food.Y)
            {
                SpawnFood();
                int lastCell = _snakeCells.Length;
                Cell[] newSnakeCells = new Cell[lastCell + 1];


                for (int i = 0; i < _snakeCells.Length; i++)
                {
                    newSnakeCells[i] = _snakeCells[i];
                }

                if (lastCell == 0)
                {
                    newSnakeCells[0] = new Cell(_grid);
                }

                /*switch (choice.Key)
                {
                    case ConsoleKey.UpArrow:
                        newSnakeCells[lastCell].Y = _snakeCells[0].Y + 1;
                        newSnakeCells[lastCell].X = _snakeCells[0].X;
                        _grid.SetTextureToGrid(newSnakeCells[lastCell].X, newSnakeCells[lastCell].Y, _snakeCells[0].Texture);
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

                }*/
            }


        }
        private void ApplySnakeToGrid(Cell[] cells)
        {
            for(int i = 0; i < _snakeCells.Length; i++)
            {
                _grid.SetTextureToGrid(cells[i].X, cells[i].Y, _snakeCells[0].Texture);
            }
        }
        public Grid Grid => _grid;
        public Cell SnakeHead => _snakeCells[0];

    }
}
