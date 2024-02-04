using System;
using System.IO;
using Newtonsoft.Json;

class Program
{

    static void Main(string[] args)
    {   
        Journal journal = new Journal();
        string userChoice = "1";

         while (userChoice != "5")
        {
        Console.WriteLine("Welcome to the Journal Program!");
        Console.WriteLine("Please select one of the following choices:");
        Console.WriteLine("1. Write");
        Console.WriteLine("2. Display");
        Console.WriteLine("3. Load");
        Console.WriteLine("4. Save");
        Console.WriteLine("5. Quit");

        userChoice = Console.ReadLine();

        switch (userChoice)
        {
            case "1":
                PromptGenerator promptGenerator = new PromptGenerator();
                string prompt = promptGenerator.GetRandomPrompt();
                Console.WriteLine(prompt);
                string response = Console.ReadLine();

                // Entry
                Entry entry = new Entry();
                entry._prompt = prompt;
                entry._response = response;
                entry._entryDate = DateTime.Now;
               
                // Journal
                journal._entries.Add(entry);
                break;
            case "2":
                foreach (Entry singleEntry in journal._entries)
                {
                    Console.WriteLine($"{singleEntry._entryDate} {singleEntry._prompt} {singleEntry._response}");
                }
                break;
            case "3":
                Console.WriteLine("Please enter the file name to load your journal:");
                Console.WriteLine("Press Enter to use 'journal.json'");
                string loadFilePath = Console.ReadLine();
                if (string.IsNullOrEmpty(loadFilePath)) loadFilePath = "journal.json";
                if (FileExists(loadFilePath)) {
                    journal = LoadObjectFromJsonFile<Journal>(loadFilePath);
                    Console.WriteLine("Your journal has been loaded with " + journal._entries.Count + " entries!");
                }
                break;
            case "4":
                Console.WriteLine("Please enter the file name to save your journal:");
                Console.WriteLine("Press Enter to use 'journal.json'");
                string saveFilePath = Console.ReadLine();
                if (string.IsNullOrEmpty(saveFilePath)) saveFilePath = "journal.json";
                if (FileExists(saveFilePath)) {
                    SaveObjectToJsonFile(journal, saveFilePath);
                    Console.WriteLine("Your journal has been saved!");
                }
                break;
            case "5":
                Console.WriteLine("Goodbye!");
                break;
            default:
                Console.WriteLine("Please enter a number between 1 and 5");
                break;
            }
        }
    }
static void SaveObjectToJsonFile(object obj, string filePath)
    {
        string json = JsonConvert.SerializeObject(obj, Formatting.Indented);
        File.WriteAllText(filePath, json);
    }

static T LoadObjectFromJsonFile<T>(string filePath)
    {
        try
        {
            string json = File.ReadAllText(filePath);
            T loadedObject = JsonConvert.DeserializeObject<T>(json);

            return loadedObject;
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error loading object from file: {ex.Message}");
            return default;
        }
    }

    static bool FileExists(string filePath) {
        if (!File.Exists(filePath)) {
            Console.WriteLine("File does not exist."); 
            return false;
        }
        return true;
    }
}


