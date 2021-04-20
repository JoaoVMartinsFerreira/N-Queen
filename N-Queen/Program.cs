using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace N_Queen
{
    class Program
    {
        public const int N = 8;
        private static void PrintSolution(int[,] board)
        {
            for (int i = 0; i < N; ++i)
            {
                for (int j = 0; j < N; ++j)
                {
                    Console.Write(" {0} ", board[i, j]);
                }
                Console.WriteLine();
            }
        }
        private static bool isSafe(int[,]board, int row, int col)
        {
            int i, j;

            for (i = 0; i < col; ++i)
                if (Convert.ToBoolean(board[row, i]))
                    return false;
            for (i = row, j = col; i >= 0 && j >= 0; --i, --j)
                if (Convert.ToBoolean(board[i, j]))
                    return false;
            for (i = row, j = col; j >= 0 && i < N; ++i, --j)
                if (Convert.ToBoolean(board[i, j]))
                    return false;

            return true;
        }

        private static bool SolveNQ(int [,] board, int col)
        {
            if (col >= N)
                return true;
            for (int i = 0; i < N; ++i)
            {
                if(isSafe(board, i, col)){
                    board[i, col] = 1;

                    if (SolveNQ(board, col + 1))
                        return true;

                    board[i, col] = 0;
                }
            }
            return false;
        }

        public static bool Solve()
        {
            int[,] board =
            {
                { 0, 0, 0, 0, 0, 0, 0, 0 },
                { 0, 0, 0, 0, 0, 0, 0, 0 },
                { 0, 0, 0, 0, 0, 0, 0, 0 },
                { 0, 0, 0, 0, 0, 0, 0, 0 },
                { 0, 0, 0, 0, 0, 0, 0, 0 },
                { 0, 0, 0, 0, 0, 0, 0, 0 },
                { 0, 0, 0, 0, 0, 0, 0, 0 },
                { 0, 0, 0, 0, 0, 0, 0, 0 },
            };
            if (SolveNQ(board, 0) == false)
                return false;

            PrintSolution(board);
            return true;
        }
        static void Main(string[] args)
        {
            bool isSolved = Solve();
            Console.Read();
        }
    }
}
