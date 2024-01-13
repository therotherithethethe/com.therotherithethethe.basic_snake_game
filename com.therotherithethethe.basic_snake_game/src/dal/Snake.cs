namespace com.therotherithethethe.basic_snake_game.src.dal
{
    public class Snake
    {
        private int _x, _y;
        private Grid _grid;
        private const String _texture = "▣";

        public Snake(Grid grid)
        {
            _grid = grid;
            Random r = new Random();
            _x = r.Next(1, grid.XLength);
            _y = r.Next(1, grid.YLength);
        }

        public string Texture
        {
            get { return _texture; }
        }

        public int X
        {
            get { return _x; }
            set 
            {
                if (value <= 0 || value > _grid.XLength)
                {
                    throw new ArgumentException("value must be positive and smaller than grid size");
                }
                _x = value;

            }
        }

        public int Y
        {
            get { return _y; }
            set
            {
                if (value <= 0 || value > _grid.YLength)
                {
                    throw new ArgumentException("value must be positive and smaller than grid size");
                }
                _y = value;

            }
        }
    }
}
