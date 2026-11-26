using System;

class BreathingActivity : Activity
{
    public BreathingActivity()
        : base("Breathing Activity",
            "This activity will help you relax by walking you through breathing in and out slowly. Clear your mind and focus on your breathing.")
    {
    }

    protected override void DoActivity()
    {
        DateTime endTime = DateTime.Now.AddSeconds(DurationSeconds);
        bool breatheIn = true;

        while (DateTime.Now < endTime)
        {
            if (breatheIn)
            {
                Console.WriteLine("Breathe in...");
            }
            else
            {
                Console.WriteLine("Breathe out...");
            }

            int pauseLength = GetPauseLength(endTime, 4);
            if (pauseLength > 0)
            {
                PauseWithCountdown(pauseLength);
            }

            breatheIn = !breatheIn;
        }
    }
}
