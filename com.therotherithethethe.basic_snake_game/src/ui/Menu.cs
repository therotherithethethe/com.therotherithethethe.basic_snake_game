using com.therotherithethethe.basic_snake_game.src.bl;
using com.therotherithethethe.basic_snake_game.src.dal;
using System.Text;

namespace com.therotherithethethe.basic_snake_game.src.ui
{
    internal class Menu
    {
        private Cell _snakeHead;
        private Grid _grid;
        private MainLogic _logic;

        public Menu(MainLogic mainLogic)
        {
            _grid = mainLogic.Grid;
            _snakeHead = mainLogic.SnakeHead;
            _logic = mainLogic;
        }

        public void Print()
        {
            Console.WriteLine("1. play");

            switch (Console.ReadKey().KeyChar)
            {
                case '1':
                    while(true)
                    {
                        PrintCurrentGameStage();
                        _logic.UpdateGameTable();
                    }
                    break;
                default:
                    break;
            }
        }
        public void PrintCurrentGameStage()
        {
            Console.Clear();
            StringBuilder txt = new StringBuilder();
            for (int y = 0; y < _grid.YLength; y++)
            {
               // Console.WriteLine();
                txt.Append("\n");
                for (int x = 0; x <_grid.XLength; x++)
                {
                    txt.Append(_grid.Table[y, x]);
                  //  Console.Write(_grid.Table[y, x]);
                }
            }
            Console.Write(txt);
        }
    }
}
