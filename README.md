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
	
对比ThreadPool，Task的优势：
	
	ThreadPool不支持线程的取消、完成、失败通知等交互性操作；
	
	ThreadPool不支持线程执行的先后次序；
	
创建Task：

无返回值的方式
	
	方式1:
	var t1 = new Task(() => TaskMethod("Task 1"));
	t1.Start();
	Task.WaitAll(t1);//等待所有任务结束 
	注：任务的状态:
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
	
async await：

在遇到awiat关键字之前，程序是按照代码顺序自上而下以同步方式执行的。
在遇到await关键字之后，系统做了以下工作：

	1异步方法将被挂起
	
	2将控制权返回给调用者
	
	3使用线程池中的线程（而非额外创建新的线程）来计算await表达式的结果，所以await不会造成程序的阻塞
	
	4完成对await表达式的计算之后，若await表达式后面还有代码则由执行await表达式的线程（不是调用方所在的线程）继续执行这些代码
	
即：

	（1）在async标识的方法体里面，如果没有await关键字的出现，那么这种方法和调用普通的方法没什么区别。
	
	（2）在async标识的方法体里面，在await关键字出现之前，还是主线程顺序调用的，直到await关键字的出现才会出现线程阻塞
	
	（3）await关键字可以理解为等待方法执行完毕，除了可以标记有async关键字方法外，还能标记Task对象，表示等待该线程执行完毕。
	所以await关键字并不是针对于async的方法，而是针对async方法所返回给我们的Task。













	
	

