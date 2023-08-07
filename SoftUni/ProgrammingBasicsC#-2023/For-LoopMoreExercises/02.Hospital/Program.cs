using System;

namespace _02.Hospital
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int period = int.Parse(Console.ReadLine());

            int treatedPatients = 0;
            int untriedtedPatients = 0;
            int doctor = 7;

            for (int i = 1; i <= period; i++)
            {
                int patient = int.Parse(Console.ReadLine());

                if (i % 3 == 0 && untriedtedPatients > treatedPatients)
                    doctor++;

                if (patient <= doctor)
                    treatedPatients += patient;
                if (patient > 7)
                {
                    treatedPatients += doctor;
                    untriedtedPatients += (patient - doctor);
                }

            }

            Console.WriteLine($"Treated patients: {treatedPatients}.");
            Console.WriteLine($"Untreated patients: {untriedtedPatients}.");
        }
    }
}
