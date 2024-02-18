using System;

// chooses a random verse from the five verses in the array
public class VerseGenerator
{
    static readonly Scripture[] scriptureArray = new Scripture[5];
    
    static VerseGenerator() {
        
        scriptureArray[0] = new Scripture("John 3:16", "For God so loved the world that he gave his one and only Son, that whoever believes in him shall not perish but have eternal life.");
        scriptureArray[1] = new Scripture("Matthew 5:14", "Ye are the light of the world. A city that is set on an hill cannot be hid.");
        scriptureArray[2] = new Scripture("Matthew 11:28", "Come unto me, all ye that labour and are heavy laden, and I will give you rest.");
        scriptureArray[3] = new Scripture("Hebrews 11:1", "Now faith is the substance of things hoped for, the evidence of things not seen.");
        scriptureArray[4] = new Scripture("2 Nephi 2:25", "Adam fell that men might be; and men are, that they might have joy.");

    }

    public static Scripture GetRandomVerse()
    {
        Random random = new Random();
        int index = random.Next(scriptureArray.Length);
        return scriptureArray[index];
    }
}