public class ReflectionActivity : Activity
{
    
    public ReflectionActivity(string name, string description) 
    {
        this.name = name;
        this.description = description;
    }
    
    private string[] prompts = {
        "Think of a time when you stood up for someone else.",
        "Think of a time when you did something really difficult.",
        "Think of a time when you helped someone in need.",
        "Think of a time when you did something truly selfless."
    };

    private string[] questions = {
        "Why was this experience meaningful to you?",
        "Have you ever done anything like this before?",
        "How did you get started?",
        "How did you feel when it was complete?",
        "What made this time different than other times when you were not as successful?",
        "What is your favorite thing about this experience?",
        "What could you learn from this experience that applies to other situations?",
        "What did you learn about yourself through this experience?",
        "How can you keep this experience in mind in the future?"
    };

  
    
    

    // override start method to include reflection prompts and questions
    public override void Start()
    {
        base.Start();

        Random random = new Random();
        string prompt = prompts[random.Next(prompts.Length)];
        Console.WriteLine(prompt);
        SuperGoodSpinner(5);
        int secondsElapsed = 0;
        while (secondsElapsed < duration)
        {
            foreach (string question in questions)
            {
                Console.WriteLine(question);
                SuperGoodSpinner(10);
                secondsElapsed += 10;
                if (secondsElapsed >= duration ) return;
            }
        }
    }
}
