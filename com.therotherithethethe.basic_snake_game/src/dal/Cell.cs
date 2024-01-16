namespace com.therotherithethethe.basic_snake_game.src.dal
{
    public class Cell
    {
        private int _x = 1;
        private int _y = 1;
        private Grid _grid;
        private String _texture = "⬛";

        public Cell(Grid grid)
        {
            _grid = grid;
        }

        public string Texture
        {
            get { return _texture; }
            set { _texture = value; }
        }

        public int X
        {
            get { return _x; }
            set 
            {               
                _x = value;
            }
        }

        public int Y
        {
            get { return _y; }
            set
            { 
                _y = value;
            }
        }
        public Grid Grid => _grid;
    }
}
