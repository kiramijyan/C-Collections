using System;

namespace Program
{
    class Program
    {
        static void Main(string[] args)
        {
            ArrayDemo1();
        }

        static void ArrayDemo1()
        {
            string[] daysOfWeek =
            {
                "Monday",
                "Tuesday",
                "Wensday",
                "Thursday",
                "Friday",
                "Saturday",
                "Sunday"
            };

            
            foreach(string day in daysOfWeek)
            {
                Console.WriteLine("Before " + day);
            }

            daysOfWeek[2] = "Wednesday";

            foreach (string day in daysOfWeek)
            {
                Console.WriteLine("After " + day);
            }

        }
    }
}
