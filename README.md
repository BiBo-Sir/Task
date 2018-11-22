参考链接：
http://www.cnblogs.com/lonelyxmas/p/9509298.html

Task前世今生：

	Task用的是线程池，线程池的线程数量的有上限的，这个可以通过ThreadPool修改，
	我们经常会用到task.run ,new task ,和task.factory.startnew方法来创建任务。
	
	Task.Factory.StartNew(action)不是直接创建线程，创建的是任务，它有一个任务队列，
	然后通过任务调度器把任务分配到线程池中的空闲线程中，任务是不能被直接执行的，
	
	只有分配给线程才能被执行，如果任务的数量比线程池中的线程多，线程池的线程数量还没有到达上限，就会创建新线程执行任务。
	如果线程池的线程已到达上限，没有分配到线程的任务需要等待有线程空闲的时候才执行


FCL ： .Net Framework Class Library
	
1、Task的优势
　　ThreadPool相比Thread来说具备了很多优势，但是ThreadPool却又存在一些使用上的不方便。比如：
　　◆ ThreadPool不支持线程的取消、完成、失败通知等交互性操作；
　　◆ ThreadPool不支持线程执行的先后次序；
　　以往，如果开发者要实现上述功能，需要完成很多额外的工作，现在，FCL中提供了一个功能更强大的概念：Task。
Task在线程池的基础上进行了优化，并提供了更多的API
	
	
	
创建Task
无返回值的方式
　　方式1:
　　var t1 = new Task(() => TaskMethod("Task 1"));
　　t1.Start();
　　Task.WaitAll(t1);//等待所有任务结束 
　　注:
　　任务的状态:
　　Start之前为:Created
　　Start之后为:WaitingToRun 

　　方式2:
　　Task.Run(() => TaskMethod("Task 2"));

　　方式3:
　　Task.Factory.StartNew(() => TaskMethod("Task 3")); 直接异步的方法 
　　或者
　　var t3=Task.Factory.StartNew(() => TaskMethod("Task 3"));
　　Task.WaitAll(t3);//等待所有任务结束
　　注:
　　任务的状态:
　　Start之前为:Running
　　Start之后为:Running
  
  带返回值的方式
　　方式4:
　　Task<int> task = CreateTask("Task 1");
　　task.Start(); 
　　int result = task.Result;
	
异步编程async await
await 运算符应用于异步方法中的任务，在方法的执行中插入挂起点，直到所等待的任务完成。 任务表示正在进行的工作。
