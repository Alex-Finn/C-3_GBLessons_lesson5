using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
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
            decimal N = 0;
            bool flag = false;
            Console.Write("Введите целое число N (от 1 до 27): ");
            do
            {
                flag = Decimal.TryParse(Console.ReadLine(), out N);
                if (!(N > 0))
                {
                    Console.WriteLine("N должно быть целым числом больше нуля. Попробуйте еще");
                    flag = false;
                }
            } while (!flag);

            ThreadClass threadObject = new ThreadClass(N);
            Thread threadFactorial = new Thread(new ThreadStart(threadObject.GetFactorial));
            Thread threadSum = new Thread(new ThreadStart(threadObject.GetIntSum));
            threadFactorial.Name = "Поток с факториалом";
            threadSum.Name = "Поток с суммой";

            threadFactorial.Start();
            threadSum.Start();
            Console.WriteLine("Вторичные потоки запущены. Ждём завершения\n");
            Console.ReadKey();
        }

        public class ThreadClass
        {
            //private string _message;
            private decimal _N;
            
            public ThreadClass(/*string message,*/ decimal N)
            {
                //_message = message;
                _N = N;
            }
            /*
            public void ThreadClassMethod()
            {
                //Console.WriteLine(_message);
            }
            */
            public void GetFactorial()
            {
                StringBuilder stb = new StringBuilder();
                decimal fact = 1;
                stb.Append(fact.ToString() + " * ");
                for (decimal i = _N; i > 1; i--)
                {
                    stb.Append(i.ToString() + " * ");
                    fact *= i;
                }
                Console.WriteLine(Thread.CurrentThread.Name + " запущен\n");
                Console.WriteLine("Факториал N = " + fact);
                Console.WriteLine("Ряд для факториала : " + stb);
                Console.WriteLine(Thread.CurrentThread.Name + " остановлен\n");
            }

            public void GetIntSum()
            {
                StringBuilder stb = new StringBuilder();
                decimal sum = 0;
                for (decimal i = 1; i <= _N; i++)
                {
                    stb.Append(i.ToString()+ " + ");
                    sum += i;
                }
                Console.WriteLine(Thread.CurrentThread.Name + " запущен\n");
                Console.WriteLine("Сумма целых до N = " + sum);
                Console.WriteLine("Ряд для суммирования : " + stb);
                Console.WriteLine(Thread.CurrentThread.Name + " остановлен\n");
            }
        }        
    }
}
