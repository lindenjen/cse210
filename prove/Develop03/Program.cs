using System;

class Program {
    static void Main(string[] args) {
        //for full points I replaced the hardcoded verse with a random verse selected from an array
        //var scripture = new Scripture("John 3:16", "For God so loved the world that he gave his one and only Son, that whoever believes in him shall not perish but have eternal life.");
        Scripture scripture = VerseGenerator.GetRandomVerse();

        Console.Clear();
        scripture.Display();
        WaitForEnterOrQuit();

        //break when all words are hidden
        while (!scripture.AllWordsHidden()) {
            Console.Clear();
            bool wordHidden = scripture.HideRandomWord();
            if (!wordHidden) break; 
            scripture.Display();
            WaitForEnterOrQuit();
        }
    }

    //print enter or quit
    static void WaitForEnterOrQuit() {
        Console.WriteLine("Press Enter to continue or type 'quit' to exit.");
        if (Console.ReadLine().ToLower() == "quit") Environment.Exit(0);
    }
}