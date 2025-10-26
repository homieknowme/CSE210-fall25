using System;
using System.Collections.Generic;

public class Scripture
{
    public Reference ScriptureReference;
    private List<Word> words;

    public Scripture(Reference reference, string text)
    {
        ScriptureReference = reference;
        words = new List<Word>();
        foreach (var wordText in text.Split(' '))
        {
            words.Add(new Word(wordText));
        }
    }

    public void HideMultipleWords(int count)
    {
        Random rand = new Random();
        int hiddenCount = 0;
        while (hiddenCount < count)
        {
            int randomIndex = rand.Next(words.Count);
            if (!words[randomIndex].IsHidden()) 
            {
                words[randomIndex].Hide();
                hiddenCount++;
            }
        }
    }

    public string Display()
    {
        List<string> displayedText = new List<string>();
        foreach (var word in words)
        {
            displayedText.Add(word.GetRenderedText());
        }
        return string.Join(" ", displayedText);
    }

    public bool IsCompletelyHidden()
    {
        foreach (var word in words)
        {
            if (!word.IsHidden()) return false;
        }
        return true;
    }

    public void HideAllWords()
    {
        foreach (var word in words)
        {
            word.Hide();
        }
    }

    public int CountVisibleWords()
{
    int visibleCount = 0;
    foreach (var word in words)
    {
        if (!word.IsHidden())
        {
            visibleCount++;
        }
    }
    return visibleCount;
}
}
