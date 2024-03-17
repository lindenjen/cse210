public abstract class Goal
{
    public string Name { get; protected set; }
    public int Points { get; protected set; }
    public int EventCount { get; protected set; }

    public Goal(string name, int points, int eventCount)
    {
        Name = name;
        Points = points;
        EventCount = eventCount;
    }

     public void RecordEvent()
    {
       EventCount++; 
    }

    public virtual int getScore()
    {
        return EventCount * Points;
    }
    public abstract void Complete();
    public abstract string Status();
}

