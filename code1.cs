using System;
using System.Threading;
using System.Threading.Tasks;

namespace Task2
{
    class Program
    {
        static void Main(string[] args)
        {
            var t1 = new Task(() => TaskMethod(" 1"));
            var t2 = new Task(() => TaskMethod(" 2"));
            t2.Start();
            t1.Start();
            Task.WaitAll(t1, t2);
            Task.Run(() => TaskMethod(" 3"));

            Task.Factory.StartNew(() => TaskMethod(" 4"));

            //标记为长时间运行任务,则任务不会使用线程池,而在单独的线程中运行。
            Task.Factory.StartNew(() => TaskMethod(" 5"), TaskCreationOptions.LongRunning);
            Console.WriteLine();

            #region 常规的使用方式
            Console.WriteLine("主线程执行业务处理.");
            //创建任务
            Task task = new Task(() =>
            {
                Console.WriteLine("使用System.Threading.Tasks.Task执行异步操作.");
                for (int i = 0; i < 10; i++)
                {
                    Console.WriteLine(i);
                }
            });

            //启动任务,并安排到当前任务队列线程中执行任务(System.Threading.Tasks.TaskScheduler)
            task.Start();
            Console.WriteLine("主线程执行其他处理");
            task.Wait();
            #endregion

            Thread.Sleep(TimeSpan.FromSeconds(1));
            Console.ReadLine();
        }

        static void TaskMethod(string name)
        {
            Console.WriteLine("Task {0} is running, the thread id {1}. Pool thread: {2}",
                name, Thread.CurrentThread.ManagedThreadId, Thread.CurrentThread.IsThreadPoolThread);
        }
    }
}
