public class ListingActivity : Activity
{

    public ListingActivity(string name, string description) 
    {
        this.name = name;
        this.description = description;
    }

    private string[] prompts = {
        "Who are people that you appreciate?",
        "What are personal strengths of yours?",
        "Who are people that you have helped this week?",
        "When have you felt the Holy Ghost this month?",
        "Who are some of your personal heroes?"
    };

    public override void Start()
    {
        base.Start();
        int secondsLeft = duration;
        Random random = new Random();
        string prompt = prompts[random.Next(prompts.Length)];
        Console.WriteLine(prompt);
      
        CountDown(5);
        Console.WriteLine("Begin listing...");
        int items = 0;
        while (secondsLeft > 0)
        {
            string item = Console.ReadLine();
            if (item != "")
            {
                items++;
                secondsLeft -= 5; 
            }
            else
            {
                break;
            }
        }
        Console.WriteLine($"You listed {items} items.");
    }
}
