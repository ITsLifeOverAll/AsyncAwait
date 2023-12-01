
int threadCount = ThreadPool.ThreadCount;
Console.WriteLine($"Thread Pool thread count: {threadCount}");

var thread = Thread.CurrentThread;
Console.WriteLine($"Main thread Id: {thread.ManagedThreadId}");

_ = await ExecuteAsync(1);

threadCount = ThreadPool.ThreadCount;
Console.WriteLine($"Thread Pool thread count: {threadCount}");
return;

// end of program

async Task<int> ExecuteAsync(int num)
{
    // await Task.Delay(500);
    var result = await Task.FromResult(num);
    var currentThread = Thread.CurrentThread;
    Console.WriteLine($"{num,3} Thread Id: {currentThread.ManagedThreadId}");
    return result;
}
