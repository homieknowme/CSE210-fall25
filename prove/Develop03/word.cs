public class Word
{

    public string Text;
    private bool hidden;
   
    public Word(string text)
    {
        Text = text;
        hidden = false;
    }

    public bool IsHidden()
    {
        return hidden;
    }

    public void Hide()
    {
        hidden = true;
    }

    public void Show()
    {
        hidden = false;
    }

    public string GetRenderedText()
    {
        return hidden ? new string('_', Text.Length) : Text;
    }
}
