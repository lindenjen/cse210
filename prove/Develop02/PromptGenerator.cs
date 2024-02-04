using System;

public class PromptGenerator
{
    public string[] _prompts = new string[]
    {
        "Describe a moment that made you laugh out loud today.",
        "What goals did you accomplish today, and how did it make you feel?",
        "What is something new that you learnt today?",
        "Describe a moment when you felt proud of yourself today.",
        "How did you show kindness or support to someone else today?"
    };

    public string GetRandomPrompt()
    {
        Random random = new Random();
        int index = random.Next(_prompts.Length);
        return _prompts[index];
    }
}