public class BreathingActivity : Activity
{

    public BreathingActivity(string name, string description) 
    {
        this.name = name;
        this.description = description;
    }
      
    public override void Start()
    {
        base.Start();
        
        int secondsElapsed = 0;
        while (secondsElapsed < duration)
        {
            AnimateText("Breathe ", "in", 3);
            AnimateText("Breathe ", "out", 3);

            secondsElapsed += 6; // 2 breaths at 3 seconds each
        }
    }
}