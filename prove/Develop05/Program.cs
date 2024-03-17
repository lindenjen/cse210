using System;

public class Program
{
    private static List<Goal> goals = new List<Goal>();
    private static int score = 0;

    public static void Main(string[] args)
    {
        LoadGoals(); 

        while (true)
        {
            ShowScore();
            Console.WriteLine($"Your current level is: {getLevel()}");
            Console.WriteLine("1. Create new goal");
            Console.WriteLine("2. Record event");
            Console.WriteLine("3. Show goals");
            Console.WriteLine("4. Show Levels");
            Console.WriteLine("5. Quit");

            int choice = Convert.ToInt32(Console.ReadLine());

            switch (choice)
            {
                case 1:
                    AddGoal();
                    break;
                case 2:
                    RecordEvent();
                    break;
                case 3:
                    ShowGoals();
                    break;
                case 4:
                    explainLevels();
                    break;
                case 5:
                    SaveGoals();
                    return;
            }
        }
    }

    private static void AddGoal()
    {
        Console.WriteLine("Enter goal name:");
        string name = Console.ReadLine();

        Console.WriteLine("Enter goal type (1: Simple, 2: Eternal, 3: Checklist):");
        int type = Convert.ToInt32(Console.ReadLine());

        Console.WriteLine("Enter points for completing the goal:");
        int points = Convert.ToInt32(Console.ReadLine());

        Goal goal;
        switch (type)
        {
            case 1:
                goal = new SimpleGoal(name, points, 0);
                break;
            case 2:
                goal = new EternalGoal(name, points, 0);
                break;
            case 3:
                Console.WriteLine("Enter total required times to complete:");
                int required = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Enter bonus points once completed:");
                int bonusPoints = Convert.ToInt32(Console.ReadLine());
                goal = new ChecklistGoal(name, points, required, bonusPoints, 0);
                break;
            default:
                Console.WriteLine("Invalid choice.");
                return;
        }

        goals.Add(goal);
    }

    private static void RecordEvent()
    {
        Console.WriteLine("Select the goal to record event for:");
        for (int i = 0; i < goals.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {goals[i].Name}");
        }

        int choice = Convert.ToInt32(Console.ReadLine());
        if (choice <= 0 || choice > goals.Count)
        {
            Console.WriteLine("Invalid choice.");
            return;
        }

        int scoreBefore = goals[choice - 1].getScore();
        goals[choice - 1].RecordEvent();
        goals[choice - 1].Complete();
        int addPoints = goals[choice - 1].getScore() - scoreBefore;
        score += addPoints;
    }

    private static void ShowGoals()
    {
        Console.WriteLine("Goals:");
        for (int i = 0; i < goals.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {goals[i].Name} {goals[i].Status()}");
        }
    }

    private static void ShowScore()
    {
        Console.WriteLine($"Your current score is: {score}");
    }

    private static void SaveGoals()
    {
        using (StreamWriter writer = new StreamWriter("goals.txt"))
        {
            foreach (var goal in goals)
            {
                
                if (goal is ChecklistGoal checklistGoal)
                {
                    writer.WriteLine($"{goal.GetType().Name}|{goal.Name}|{goal.Points}|{goal.EventCount}" + checklistGoal.getValues());
                    //writer.WriteLine(checklistGoal.Status());
                } else {
                    writer.WriteLine($"{goal.GetType().Name}|{goal.Name}|{goal.Points}|{goal.EventCount}");
                }
            }
        }
    }

    private static void LoadGoals()
    {
        if (File.Exists("goals.txt"))
        {
            using (StreamReader reader = new StreamReader("goals.txt"))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    string[] parts = line.Split('|');
                    string name = parts[1];
                    int points = Convert.ToInt32(parts[2]);
                    int eventCount = Convert.ToInt32(parts[3]);

                    bool goalAdded = false;

                    if (parts[0] == "SimpleGoal")
                    {
                        goals.Add(new SimpleGoal(name, points, eventCount));
                        goalAdded = true;
                    }
                    else if (parts[0] == "EternalGoal")
                    {
                        goals.Add(new EternalGoal(name, points, eventCount));
                        goalAdded = true;
                    }
                    else if (parts[0] == "ChecklistGoal")
                    {
                                               
                        
                        int totalRequired = Convert.ToInt32(parts[4]);
                        int bonusPoints = Convert.ToInt32(parts[5]);
                        goals.Add(new ChecklistGoal(name, points, eventCount, totalRequired, bonusPoints) );
                        goalAdded = true;
                    }
                    
                    if (goalAdded) {
                       score = score + goals[goals.Count - 1].getScore();
                    }
                }
                
            }
        }
    }

    public static void explainLevels()
    {
        Console.WriteLine($"Your current level is: {getLevel()}");
        Console.WriteLine("<100 points = Beginner");
        Console.WriteLine("100-300 points = Squire");
        Console.WriteLine("300-700 points = Knight");
        Console.WriteLine("700-1000 points = Lord");
        Console.WriteLine("1000+ points = King!");
    }

    public static string getLevel() 
    {
        if (score < 100) {
            return "Beginner";
        } else if (score <= 300) {
            return "Squire";
        } else if (score <= 700) {
            return "Knight";
        } else if (score < 1000) {
            return "Lord";
        } else {
            return "King";
        }
            
            
        
    }
}
