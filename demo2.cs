
using System;
using System.Threading.Tasks;

namespace Task3
{
    class Program
    {
        async static void AsyncFunction()
        {
            await Task.Delay(1);
            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine(string.Format("异步方法:i={0}", i));
            }
        }

        public static void Main()
        {
            AsyncFunction();

            Console.WriteLine("主线程执行其他处理");
            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine(string.Format("主线程:i={0}", i));
            }
            Console.WriteLine();
            Console.ReadLine();
        }
    }
}

//分析：主线程和异步方法并行执行，for循环的值很少，所以主线程先执行完
//当 for循环值很多时，结果应该呈现主线程和异步方法交叉的顺序。


执行结果：
主线程执行其他处理
主线程:i=0
主线程:i=1
主线程:i=2
主线程:i=3
主线程:i=4
主线程:i=5
主线程:i=6
主线程:i=7
主线程:i=8
主线程:i=9

异步方法:i=0
异步方法:i=1
异步方法:i=2
异步方法:i=3
异步方法:i=4
异步方法:i=5
异步方法:i=6
异步方法:i=7
异步方法:i=8
异步方法:i=9

