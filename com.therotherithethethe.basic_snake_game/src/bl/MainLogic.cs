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
        }
        public void InitializeGameTable()
        {
            _grid.SetTextureToGrid()
        }
    }
}
