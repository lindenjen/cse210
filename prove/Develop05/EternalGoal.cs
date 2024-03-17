public class EternalGoal : Goal
{
    public EternalGoal(string name, int points, int eventCount) : base(name, points, eventCount) { }

    public override void Complete()
    {
        Console.WriteLine($"You've recorded the eternal goal: {Name}");
    }

    public override string Status()
    {
        if (EventCount > 0) {
            return "[X]";
        } else {
            return "[ ]";
        }
    }
}