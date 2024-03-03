using System;

class Program
{

    static void Main(string[] args)
    {   
        string userChoice = "1";

        Console.Clear();
        Console.WriteLine("Welcome to the Mindfulness Program!");
        
         while (userChoice != "4")
        {

        Console.WriteLine("Please select one of the following activities to do:");
        Console.WriteLine("1. Breathing Activity");
        Console.WriteLine("2. Reflection Activity");
        Console.WriteLine("3. Listing Activity");
        Console.WriteLine("4. Quit");

        Activity activity = null;
        userChoice = Console.ReadLine();

        switch (userChoice)
        {
            case "1":
                activity = new BreathingActivity("Breathing", "This activity will help you relax by walking your through breathing in and out slowly. Clear your mind and focus on your breathing.");
                
                break;
            case "2":
                
                activity = new ReflectionActivity("Reflection", "This activity will help you reflect on times in your life when you have shown strength and resilience. This will help you recognize the power you have and how you can use it in other aspects of your life.");
                break;
            case "3":
    
                activity = new ListingActivity("Listing", "This activity will help you reflect on the good things in your life by having you list as many things as you can in a certain area.");
                break;
            case "4":
                Console.WriteLine("Goodbye!");
                Console.WriteLine("Thank you for using the Mindfulness Program!");
                break;
            default:
                    Console.WriteLine("Invalid choice! Please try again.");
                    continue;

        }

        if (activity !=  null) 
        {
            activity.Welcome();
            activity.Start();
            activity.End();
        }

        }
    }
}

