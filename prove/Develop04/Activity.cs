public class Activity
{
    public string name;
     public int duration;
     public string description;

    
    // method to display starting message and pause
    public void Welcome()
    {
        Console.WriteLine($"Welcome to the {name} activity!");
        Console.WriteLine($"{description}");
    }

    public virtual void Start() 
    {
        Console.Write("Enter duration (in seconds): ");
        duration = int.Parse(Console.ReadLine());
        Console.Clear();
        Console.WriteLine("Get ready...");
        SuperGoodSpinner(2);
    }

    // method to display ending message and pause
    public void End()
    {
        Console.WriteLine("Good job!");
        SuperGoodSpinner(2);
        Console.WriteLine($"You completed the {name} activity for {duration} seconds.");
    }


    public static void SuperGoodSpinner(int seconds) 
    {
        long start = DateTimeOffset.Now.ToUnixTimeMilliseconds();
        int x = 0;
        while ((DateTimeOffset.Now.ToUnixTimeMilliseconds() - start) < (1000 * seconds))
        {
            if (x > 0) Console.Write("\b \b"); 
            Console.Write("|");
            Thread.Sleep(250);
            Console.Write("\b \b");
            Console.Write("/");
             Thread.Sleep(250);
            Console.Write("\b \b");
            Console.Write("-");
             Thread.Sleep(250);
            Console.Write("\b \b");
            Console.Write("\\");
            Thread.Sleep(250);
            
            x++;
        }
        Console.Write("\b \b");
    }

    public void AnimateText(string text1, string text2, int seconds) 
    {
        long start = DateTimeOffset.Now.ToUnixTimeMilliseconds();
        

        while ((DateTimeOffset.Now.ToUnixTimeMilliseconds() - start) < (1000 * seconds))
        {
            Console.Write(text1);
            Thread.Sleep(160);
            Console.Write(text2);
            Thread.Sleep(160);
            Console.Write(".");
            Thread.Sleep(160);
             Console.Write(".");
            Thread.Sleep(160);
             Console.Write(".");
            Thread.Sleep(160);
            Console.Write("\b \b");
            Console.Write("\b \b");
            Console.Write("\b \b");
            for (int i = 0; i < (text1.Length + text2.Length); i++) {
                Console.Write("\b \b");
            }
            Thread.Sleep(160);
        }
    }

    public void CountDown(int seconds) 
    {
        while (seconds > 0)
        {
            Console.Write($"{seconds}");

            Thread.Sleep(1000);

            Console.Write("\b \b"); 
            seconds--;
        }
    }
}