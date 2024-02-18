public class Reference {
    public string Book { get; }
    public int Chapter { get; }
    public int VerseFrom { get; }
    public int? VerseTo { get; }
    
    public Reference(string book, int chapter, int verseFrom, int? verseTo = null) {
        Book = book;
        Chapter = chapter;
        VerseFrom = verseFrom;
        VerseTo = verseTo;
    }

    public override string ToString() {
        if (VerseTo.HasValue)
            return $"{Book} {Chapter}:{VerseFrom}-{VerseTo}";
        else
            return $"{Book} {Chapter}:{VerseFrom}";
    }
}