namespace com.therotherithethethe.basic_snake_game.src.dal
{
    public class Grid
    {
        private String[,] _table;
        private int _xLength;
        private int _yLength;
        private const String _texture = "⬜";
        public Grid(int xLength, int yLength)
        {
            if (xLength <= 0 || yLength <= 0)
                throw new ArgumentException("Lengths must be positive.");


            _table = new String[yLength, xLength];
            _xLength = xLength;
            _yLength = yLength;
            TableInitialize();
        }

        //to do
        private void TableInitialize() 
        {
            for (int i = 0; i < _yLength; i++)
            {
                for (int j = 0; j < _xLength; j++)
                {
                    _table[i, j] = _texture;
                }
            }
        }

        public string[,] Table => _table;

        public void SetTextureToGrid(int x, int y, string texture)
        {
            if(x <= 0 || y <= 0 || x >= _xLength + 1 || y >= _yLength + 1)
            {
                //do nothing
            }
            else
            {
                _table[y - 1, x - 1] = x >= 0 && x <= _xLength || y >= 0 && y <= _yLength ? texture :
                    throw new ArgumentException("Coordinates exception");
            }

        }

        public int XLength => _xLength;

        public int YLength => _yLength;
        public String Texture => _texture;

    }

}
