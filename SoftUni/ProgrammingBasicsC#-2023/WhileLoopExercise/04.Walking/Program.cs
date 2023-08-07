using System;

namespace _04.Walking
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int goal = 10000;
            bool goinghome = false;
            bool reachedGoal = false;
            int inputSteps = 0;
            int stepsum = 0;

            var steps = Console.ReadLine();
            if (steps == "Going home")
            {
                steps = Console.ReadLine();
                inputSteps = int.Parse(steps);
                stepsum += inputSteps;
                goinghome = true;
            }

            while (!goinghome)
            {
                inputSteps = int.Parse(steps);
                stepsum += inputSteps;
                if (stepsum >= 10000)
                    break;

                steps = Console.ReadLine();
                if (steps == "Going home")
                {
                    steps = Console.ReadLine();
                    inputSteps = int.Parse(steps);
                    stepsum += inputSteps;
                    break;
                }
            }

            if (stepsum >= goal)
                Console.WriteLine($"Goal reached! Good job!\n{stepsum - goal} steps over the goal!");
            if (stepsum < goal)
                Console.WriteLine($"{goal - stepsum} more steps to reach goal.");
        }
    }
}
