using System;

class BreathingActivity : Activity
{
    public BreathingActivity(string name, string description) :base(name, description)
    {
        
    }

    public void RunActivity()
    {
        StartMessage();

        DateTime startTime = DateTime.Now;
        DateTime endTime = startTime.AddSeconds(GetDuration());
        
        
        
        while (DateTime.Now < endTime)
        {
            TimeSpan remaining = endTime - DateTime.Now;
            int remainingSeconds = (int)remaining.TotalSeconds;

            if (remainingSeconds > 3)
            {
                Console.WriteLine("\nBreathe In...");
                CountDown(4);

                Console.WriteLine("Breathe Out...");
                CountDown(6);
            }

            else
                break;

        }

        EndMessage();
    }


}