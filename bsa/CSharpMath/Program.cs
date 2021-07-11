using System;

namespace CSharpMath
{
    class Program
    {
        static void Main(string[] args)
        {

            while (true)
            {

                Console.WriteLine("Do you want to play Y or N");                
                var play = Console.ReadLine();

                if (play == "N")
                {
                    break;
                }

                Console.WriteLine("Tell me how old you are");

                int age = int.Parse(Console.ReadLine());

                


                var old = new Random().Next(30);
                old = 15;

                Console.WriteLine("the random number is " + old);
                int result = (age) - (old);

                //if the result is greater than 0 and less than 10 write one comment
                //if the result is greater than 10 and less than 20 write a different comment

                if (result > 0 && result < 10)
                {
                    Console.WriteLine($"You will die in soon");
                }

                if (result > 10 && result < 20)
                {
                    Console.WriteLine($"You will die in {result} years");
                }
                else
                {
                    Console.WriteLine($"ur mum says bruh u so fat u gonna die cause of your raging obesity {result} years");
                }

            }



        }
    }
}
