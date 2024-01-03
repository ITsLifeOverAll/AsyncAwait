
// Asynchronous programming with async and await
// https://learn.microsoft.com/en-us/dotnet/csharp/asynchronous-programming/

using System.Diagnostics;

namespace AsyncBreakfast;

internal class Program
{
    static async Task Main(string[] args)
    {
        var stopwatch = Stopwatch.StartNew();

        Coffee cup = PourCoffee();
        Console.WriteLine("coffee is ready");
        Console.WriteLine();

        var eggsTask = FryEggsAsync(2);
        var toastTask = ToastBreadAsync(3);

        var tasks = Task.WhenAll(eggsTask, toastTask);
        try
        {
            //Task.WaitAll(eggsTask, toastTask);

            await tasks;
        }
        catch (Exception e)
        {
            Console.WriteLine("== awaited exception ==");
                Console.WriteLine(e);
        }

        Console.WriteLine("Breakfast is ready!");
        
        Console.WriteLine($"煮早餐耗時: {stopwatch.ElapsedMilliseconds/1000:N} 秒");
    }

    private static Toast ToastBread(int slices)
    {
        for (int slice = 0; slice < slices; slice++)
        {
            Console.WriteLine("Putting a slice of bread in the toaster");
        }
        Console.WriteLine("Start toasting...");
        
        Task.Delay(3000).Wait();
        Console.WriteLine("Remove toast from toaster");

        return new Toast();
    }

    private static Task<Toast> ToastBreadAsync(int slices)
    {
        if (slices > 2)
            throw new ArgumentException(
                "slices must be less than 3",
                nameof(slices));

        return ToastBreadAsyncCore(slices);

        static async Task<Toast> ToastBreadAsyncCore(int slices)
        {
            for (int slice = 0; slice < slices; slice++)
            {
                Console.WriteLine("Putting a slice of bread in the toaster");
            }
            Console.WriteLine("Start toasting...");

            await Task.Delay(500);
            Console.WriteLine("Remove toast from toaster");

            throw new Exception("土司烤焦了 ...");

            return new Toast();
        }
    }

    private static Egg FryEggs(int howMany)
    {
        Console.WriteLine("Warming the egg pan...");
        
        Task.Delay(3000).Wait();
        Console.WriteLine($"cracking {howMany} eggs");
        Console.WriteLine("cooking the eggs ...");
        
        Task.Delay(3000).Wait();
        Console.WriteLine("Put eggs on plate");

        return new Egg();
    }
    
    private static async Task<Egg> FryEggsAsync(int howMany)
    {
        Console.WriteLine("Warming the egg pan...");

        //await Task.Delay(3000);
        Console.WriteLine($"cracking {howMany} eggs");
        Console.WriteLine("cooking the eggs ...");

        await Task.Delay(1000);
        Console.WriteLine("Put eggs on plate");

        throw new Exception("蛋掉在地上了 ...");

        return new Egg();
    }
    private static Coffee PourCoffee()
    {
        Console.WriteLine("Pouring coffee");
        return new Coffee();
    }
}


// These classes are intentionally empty for the purpose of this example. They are simply marker classes for the purpose of demonstration, contain no properties, and serve no other purpose.
internal class Bacon { }
internal class Coffee { }
internal class Egg { }
internal class Juice { }
internal class Toast { }