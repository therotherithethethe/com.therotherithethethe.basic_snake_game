using com.therotherithethethe.basic_snake_game.src.dal;

namespace com.therotherithethethe.basic_snake_game.src.bl
{
    internal class MainLogic
    {
        private Grid _grid;
        private Snake _snake;

        public MainLogic(Grid grid, Snake snake)
        {
            _grid = grid;
            _snake = snake;
            InitializeGameTable();
        }
        public void InitializeGameTable()
        {
            _grid.SetTextureToGrid(_snake.X, _snake.Y, _snake.Texture);
        }
        public void UpdateGameTable()
        {
            int tempX = _snake.X;
            int tempY = _snake.Y;
            ConsoleKeyInfo choice = Console.ReadKey();

            switch(choice.Key)
            {
                case ConsoleKey.UpArrow:

                    _snake.Y = _snake.Y - 1;
                    _grid.SetTextureToGrid(_snake.X, _snake.Y, _snake.Texture);
                    _grid.SetTextureToGrid(tempX, tempY, _grid.Texture);
                    break;

                case ConsoleKey.DownArrow:
                    _snake.Y = _snake.Y + 1;
                    _grid.SetTextureToGrid(_snake.X, _snake.Y, _snake.Texture);
                    _grid.SetTextureToGrid(tempX, tempY, _grid.Texture);
                    break;

                case ConsoleKey.LeftArrow:
                    _snake.X = _snake.X - 1;
                    _grid.SetTextureToGrid(_snake.X, _snake.Y, _snake.Texture);
                    _grid.SetTextureToGrid(tempX, tempY, _grid.Texture);
                    break;

                case ConsoleKey.RightArrow:
                    _snake.X = _snake.X + 1;
                    _grid.SetTextureToGrid(_snake.X, _snake.Y, _snake.Texture);
                    _grid.SetTextureToGrid(tempX, tempY, _grid.Texture);
                    break;
            }

        }
        public Grid Grid => _grid;
        public Snake Snake => _snake;

    }
}
