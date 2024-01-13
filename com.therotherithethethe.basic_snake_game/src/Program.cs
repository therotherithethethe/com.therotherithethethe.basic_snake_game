using com.therotherithethethe.basic_snake_game.src.dal;
using System.Collections.Generic;

namespace com.therotherithethethe.basic_snake_game.src
{
    internal class Program
    {
        static int[,] array = { 
            { 1, 2, 3 }, 
            { 1, 1, 1 } 
        };
        static int[] array1 = { 1 };
        static void Main(string[] args)
        {
            Console.WriteLine($"{array.GetLength(0)} {array.GetLength(1)}");
            

        }
    }
}