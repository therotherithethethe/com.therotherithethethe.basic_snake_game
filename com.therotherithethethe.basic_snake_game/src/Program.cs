using com.therotherithethethe.basic_snake_game.src.bl;
using com.therotherithethethe.basic_snake_game.src.dal;
using com.therotherithethethe.basic_snake_game.src.ui;
using System.Collections.Generic;

namespace com.therotherithethethe.basic_snake_game.src
{
    internal class Program
    {
        /*static int[,] array = { 
            { 1, 2, 3 }, 
            { 1, 1, 1 } 
        };
        static int[] array1 = { 1 };*/
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            Grid grid = new(20, 10);
            Snake snake = new(grid);
            MainLogic mainLogic = new(grid, snake);
            Menu menu = new(mainLogic);

            menu.Print();

            Console.ReadKey();
        }
    }
}