using System;

class Program
{
    static void Main(string[] args)
    {
        Console.Write("What is your grade percentage? ");
        string grade = Console.ReadLine();
        int number = int.Parse(grade);
        string letter = "F";
        if (number >= 90)
        {
            letter = "A";
        }
        else if (number >= 80)
        {
            letter = "B";
        }
        else if (number >= 70)
        {
            letter = "C";
        }
        else if (number >= 60)
        {
            letter = "D";
        }

        Console.WriteLine($"Your grade is: {letter}");

        if (number >= 70)
        {
           Console.WriteLine("Congratulations, you passed!"); 
        }
        else 
        {
            Console.WriteLine("Sorry, you failed. You'll do better next time!");
        }
    }
}