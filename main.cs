using System;

class Program 
{
    static void Main(string[] args) 
    {
        const int NumberOfTemperatures = 5;
        int[] temperatures = new int[NumberOfTemperatures];

        Console.WriteLine($"Hi User! Please enter five daily Fahrenheit temperatures (must range from -30 to 130):");

        for (int i = 0; i < NumberOfTemperatures; i++) 
        {
            while (true) 
            {
                Console.Write($"INPUT Temperature {i + 1}: ");
                if (int.TryParse(Console.ReadLine(), out int temp)) 
                {
                    if (temp >= -30 && temp <= 130) 
                    {
                        temperatures[i] = temp;
                        break; 
                    } 
                    else 
                    {
                        Console.WriteLine("EXCEPTION Temperature is invalid. Please enter a valid temperature between -30 and 130");
                    }
                } 
                else 
                {
                    Console.WriteLine("Invalid input. Please try again.");
                }
            }
        }

        bool isAscending = true;
        bool isDescending = true;
        for (int i = 1; i < NumberOfTemperatures; i++) 
        {
            if (temperatures[i] > temperatures[i - 1]) 
            {
                isDescending = false;
            }
            if (temperatures[i] < temperatures[i - 1]) 
            {
                isAscending = false;
            }
        }

        if (!isAscending && !isDescending) 
        {
            Console.WriteLine("OUTPUT It’s a mixed bag");
        } 
        else if (isAscending) 
        {
            Console.WriteLine("OUTPUT Getting warmer");
        } 
        else if (isDescending) 
        {
            Console.WriteLine("OUTPUT Getting cooler");
        } 
        else 
        {
            Console.WriteLine("Unexpected condition. Mixed bag?");
        }
        Console.Write("\nOUTPUT 5-day Temperature: [");
        for (int i = 0; i < temperatures.Length; i++) 
        {
            Console.Write(temperatures[i]);
            if (i < temperatures.Length - 1) 
            {
                Console.Write(", ");
            }
        }
        Console.WriteLine("]");

        double averageTemperature = CalculateAverage(temperatures);
        Console.WriteLine($"Average temperature is {averageTemperature:F2}");
        Console.ReadKey();
    }

    static double CalculateAverage(int[] temperatures) 
    {
        int sum = 0;
        foreach (var temp in temperatures) 
        {
            sum += temp;
        }
        return (double)sum / temperatures.Length;
    }
}
