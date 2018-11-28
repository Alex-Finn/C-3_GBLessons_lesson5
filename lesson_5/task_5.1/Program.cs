using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//  1. Написать приложение, считающее в раздельных потоках:
//     a.факториал числа N, которое вводится с клавиатуру;
//     b.сумму целых чисел до N, которое также вводится с клавиатуры.

namespace task_5._1
{
    class Program
    {
        static void Main(string[] args)
        {
            int N = 0;
            bool flag = false;
            Console.Write("Введите целое число N: ");
            do
            {
                flag = Int32.TryParse(Console.ReadLine(), out N);
                if (!(N > 0)) Console.WriteLine("N должно быть целым числом больше нуля. Попробуйте еще");
            } while (!flag);
        }

        public int GetFact(int N)
        {
            int fact = 0;

            return fact;
        }

        public int GetIntSum(int N)
        {
            int sum = 0;
            for (int i = 1; i <= N; i++)
            {
                sum += i;
            }
            return sum;
        }
    }
}
