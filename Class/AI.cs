using System;

namespace AI;
public class Choice
{ 
    private static Random _rand = new Random();

    public static int RandomizeChoice(int number_length = 10) 
    => _rand.Next(number_length);
}
