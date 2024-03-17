public class ChecklistGoal : Goal
{
    private int totalRequired;
    private int bonusPoints;
    

    public ChecklistGoal(string name, int points, int eventCount, int required, int bonusPoints) : base(name, points, eventCount)
    {
        totalRequired = required;
        this.bonusPoints = bonusPoints;
        
    }

    public override int getScore() 
    {
        int score = Points * EventCount;
        if (EventCount >= totalRequired) {
            score = score + bonusPoints;
        }
        return score;
    }

    public override void Complete()
    {
        
        if (EventCount >= totalRequired)
        {
            Console.WriteLine($"Congratulations! You have completed the checklist goal: {Name} and earned the bounus points!");
        } else {
            int more = totalRequired - EventCount;
            Console.WriteLine($"Congratulations! You have completed the checklist goal: {Name} - {more} to earn the bonus points!");
        }
    }

    public string getValues() 
    {
        return $"|{totalRequired}|{bonusPoints}";
    }

    public override string Status()
    {
        if (EventCount >= totalRequired) {
            return "[X] Bonus Earned!";
        } else if (EventCount > 0) {
            int more = totalRequired - EventCount;
            return $"[X] {more} to earn the bonus points!";
        } else {
            return "[ ]";
        }
    }
}
