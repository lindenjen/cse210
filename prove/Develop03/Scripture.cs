public class Scripture {
    private string reference;
    private List<Word> words;

    public Scripture(string reference, string text) {
        this.reference = reference;
        this.words = text.Split(' ').Select(w => new Word(w)).ToList();
    }

    public void Display() {
        Console.WriteLine($"Scripture: {reference}\n");
        foreach (var word in words) {
            Console.Write(word.IsHidden ? "___ " : word.Text + " ");
        }
        Console.WriteLine();
    }

    public bool AllWordsHidden() {
        return words.All(word => word.IsHidden);
    }

    //hide a random word
    public bool HideRandomWord() {
        var visibleWords = words.Where(word => !word.IsHidden).ToList();
        if (visibleWords.Count == 0) return false;

        var random = new Random();
        int index = random.Next(visibleWords.Count);
        visibleWords[index].Hide();
        return true;
    }
}