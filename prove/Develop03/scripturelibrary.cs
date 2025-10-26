using System;
using System.Collections.Generic;

public class ScriptureLibrary
{
    private List<(Reference, string)> scriptures;

    public ScriptureLibrary()
    {
        scriptures = new List<(Reference, string)>();
    }

    public void AddScripture(Reference reference, string scripture)
    {
        scriptures.Add((reference, scripture));
    }

    public (Reference, string) GetRandomScripture()
    {
        Random random = new Random();
        int index = random.Next(scriptures.Count); 
        return scriptures[index];
    }

    public void LoadScripturesFromFile(string filePath)
    {
        try
        {
            foreach (string line in File.ReadLines(filePath))
            {
                string[] parts = line.Split('|');
                if (parts.Length == 2)
                {
                    string referenceString = parts[0].Trim();
                    string scriptureText = parts[1].Trim();

                    Reference reference = ParseReference(referenceString);
                    scriptures.Add((reference, scriptureText));
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("An error occurred while reading the file: " + ex.Message);
        }
    }

    private Reference ParseReference(string referenceStr)
    {
        var parts = referenceStr.Split(' ');
        var book = parts[0];
        var chapterAndVerses = parts[1].Split(':');
        var chapter = int.Parse(chapterAndVerses[0]);
        var verseRange = chapterAndVerses[1].Split('-');
        int startVerse = int.Parse(verseRange[0]);
        int endVerse = verseRange.Length > 1 ? int.Parse(verseRange[1]) : startVerse;
        return new Reference(book, chapter, startVerse, endVerse);
    }
}
