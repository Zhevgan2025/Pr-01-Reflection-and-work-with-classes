using System;
using System.Reflection;


namespace Task1
{
    public class Task1
    {
        public string Cat { get; set; }
        public string Dog { get; set; }
        public string Snake { get; set; }

        public Task1() { }

        public Task1(string cat, string dog, string snake)
        {
            Cat = cat;
            Dog = dog;
            Snake = snake;
        }

        public void CatSay()
        {
            Console.WriteLine("Meow, Meow, Meow");

        }

        public void DogSay()
        {
            Console.WriteLine("Woff! Woff! Woff!");
        }

        public void SnakeSay()
        {
            Console.WriteLine("SSS! SSS! SSS.");
        }
    }

    public class Veterinarian
    {
        public void AnimalReport(string report)
        {
            Console.WriteLine($"{report}: everyone is healthy");
        }


        public void State(int healthy, int sick)
        {
            if (healthy > sick)
            {
                Console.WriteLine("Most animals are healthy");
            }
            else if (healthy < sick)
            {
                Console.WriteLine("Many animals are sick");
            }
            else
            {
                Console.WriteLine("The report was successful.");
            }


        }


    }
}





