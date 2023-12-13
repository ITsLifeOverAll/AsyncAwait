
// Asynchronous programming with async and await
// https://learn.microsoft.com/en-us/dotnet/csharp/asynchronous-programming/

using System.Diagnostics;

namespace AsyncBreakfast;

internal class Program
{
    static void Main(string[] args)
    {
        var stopwatch = Stopwatch.StartNew();

        Coffee cup = PourCoffee();                  // 0 secs.
        Console.WriteLine("coffee is ready");
        Console.WriteLine();

        Egg eggs = FryEggs(2);                      // 6 secs
        Console.WriteLine("eggs are ready");
        Console.WriteLine();

        Toast toast = ToastBread(2);                // 3 secs.
        Console.WriteLine("toast is ready");
        Console.WriteLine();

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