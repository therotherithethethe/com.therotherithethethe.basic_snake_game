using com.therotherithethethe.basic_snake_game.src.bl;
using com.therotherithethethe.basic_snake_game.src.dal;
using com.therotherithethethe.basic_snake_game.src.ui;

namespace com.therotherithethethe.basic_snake_game.src
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            Console.InputEncoding = System.Text.Encoding.UTF8;
            Grid grid = new(5, 5);

            Random r = new Random();
            Cell snakeHead = new(grid);
            MainLogic mainLogic = new(grid, snakeHead);
            Menu menu = new(mainLogic);

            menu.Print();

        }
        
    }
}