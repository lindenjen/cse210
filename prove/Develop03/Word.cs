public class Word {
    public string Text { get; }
    public bool IsHidden { get; private set; }

    //tells whether or not the word is hidden

    public Word(string text) {
        Text = text;
        IsHidden = false;
    }

    public void Hide() {
        IsHidden = true;
    }
}