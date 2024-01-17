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

        int cellCounter;

        public Menu(MainLogic mainLogic)
        {
            _grid = mainLogic.Grid;
            _snakeHead = mainLogic.SnakeCells[0];
            _logic = mainLogic;
            cellCounter = mainLogic.SnakeCells.Length;
        }

        public void Print()
        {
            Grid gridBuffer = new Grid(_grid.XLength, _grid.YLength);
            Cell snakeHead = new Cell(gridBuffer);
            MainLogic logicBuffer = new MainLogic(gridBuffer, snakeHead);

            Console.Clear();
            Console.WriteLine(GetCenteredText("1. play"));

            switch (Console.ReadKey().KeyChar)
            {
                case '1':
                    while(!_logic.IsGameOver() && cellCounter != _grid.YLength*_grid.XLength - 1)
                    {
                        cellCounter = _logic.SnakeCells.Length;
                        PrintCurrentGameStage();
                        Thread.Sleep(300);
                        _logic.UpdateGameTable();

                    }

                    Console.Clear();
                    if (_logic.IsGameOver())
                    {
                        Console.WriteLine(GetCenteredText("YOU ARE LOOSER"));
                    }
                    else
                    {
                        Console.WriteLine(GetCenteredText("YOU ARE WINNER"));
                    }

                    break;
                default:
                    break;
            }
            Console.ReadKey();
            _grid = gridBuffer;
            _snakeHead = snakeHead;
            _logic = logicBuffer;

            Print();
        }
        public void PrintCurrentGameStage()
        {
            Console.Clear();
            StringBuilder txt = new StringBuilder();
            for (int y = 0; y < _grid.YLength; y++)
            {
                txt.Append("\n");
                for (int x = 0; x <_grid.XLength; x++)
                {
                    txt.Append(_grid.Table[y, x]);
                }
            }
            //Console.Write(txt);
            txt.AppendLine();
            txt.AppendLine(cellCounter.ToString());

            Console.WriteLine(GetCenteredText(txt.ToString()));
        }
        static string GetCenteredText(string text)
        {
            int consoleWidth = Console.WindowWidth;
            int consoleHeight = Console.WindowHeight;

            string[] lines = text.Split('\n');
            int maxLineLength = 0;
            foreach (var line in lines)
            {
                if (line.Length > maxLineLength)
                    maxLineLength = line.Length;
            }

            int startX = (consoleWidth - maxLineLength) / 2;
            int startY = (consoleHeight - lines.Length) / 2;

            if (startX < 0) startX = 0;
            if (startY < 0) startY = 0;

            StringBuilder sb = new StringBuilder();

            for (int i = 0; i < startY; i++)
            {
                sb.AppendLine();
            }

            foreach (var line in lines)
            {
                sb.Append(' ', startX);
                sb.AppendLine(line);
            }

            return sb.ToString();
        }
    }
}
