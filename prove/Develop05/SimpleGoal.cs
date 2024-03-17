public class SimpleGoal : Goal
{
    public SimpleGoal(string name, int points, int eventCount) : base(name, points, eventCount) { }

    public override void Complete()
    {
        Console.WriteLine($"Congratulations! You have completed the goal: {Name}");
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