public class Entry
{
        public string _prompt { get; private set; }
        public string _entry { get; private set; }
        private string _date;
        
        public Entry(string prompt, string entry)
        {
            _prompt = prompt;
            _entry = entry;
            _date = GenerateDate();
        }

        public string GenerateDate()
        {
            return DateTime.Now.ToShortDateString();
        }

        public void Display()
        {
            Console.WriteLine($"Date: {_date} - Prompt: {_prompt}");
            Console.WriteLine($"{_entry}\n");
        }
    

}