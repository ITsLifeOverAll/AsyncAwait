
var s = SynchronizationContext.Current;
Console.WriteLine($"SynchronizationContext: {s?.ToString()}");

Console.WriteLine($"Main before ExecuteAsync: Thread: {Thread.CurrentThread.ManagedThreadId}");

_ = await ExecuteAsync();

Console.WriteLine($"Main after ExecuteAsync: Thread: {Thread.CurrentThread.ManagedThreadId}");
return;

async Task<int> ExecuteAsync()
{
    Console.WriteLine($"\tExecuteAsync Thread: {Thread.CurrentThread.ManagedThreadId}");
    await Task.Delay(500);
    Console.WriteLine($"\tExecuteAsync Thread after delay: {Thread.CurrentThread.ManagedThreadId}");
    return await Execute2Async();
}

async Task<int> Execute2Async()
{
    Console.WriteLine($"\tExecute2Async Thread: {Thread.CurrentThread.ManagedThreadId}");
    return await Task.FromResult( 0 );
}
