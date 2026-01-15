using System;
using System.Globalization;
namespace LuckySpin.Models;

public class Spin
{
    public required int Luck { get; set; } = 7;
    public required int[] Numbers { get; set; }
    public string ImageDisplay { 
        get{
            //DONE: Add logic here to return either "block" or "none" based on whether the Numbers array contains the Luck value
            foreach (int number in  Numbers)
            {
                if (number == Luck)
                {
                    return "block";
                }
            }
            return "none";
        }
    }
    Random random = new Random();
    //DONE: Adjust Constructor to generate random Numbers for the Spin
    public Spin()
    {
        Numbers = [random.Next(1,10), random.Next(1,10), random.Next(1,10)];
    }

}
