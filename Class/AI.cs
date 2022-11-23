using System;

namespace AI;
public class Bot
{
    private string _name;

    public string Name { get => _name; }

    public Bot(string name) => _name = name;
    
        public class Choice
    { 
        private static Random _rand = new Random();

        public static int RandomNumber() => _rand.Next(2147483647);
        public static int FixedNumber(int starting_number = 0, int number_length = 10) 
        { 
            bool DesiredResults = false;
            int ReturnNumber =_rand.Next(number_length);
            while(!DesiredResults)
            {
                if(ReturnNumber < starting_number || ReturnNumber > number_length) ReturnNumber = _rand.Next(number_length);
                else DesiredResults = true;
            }
            return ReturnNumber;
        }

        public static string RandomLetter()
        {
            string ReturnLetter = "";
            string[] EnglishLetters = 
            {"A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "M", "O", "P", "Q", "R", "S", "T", "U", "V", "W", "X", "Y", "Z"};
            ReturnLetter = EnglishLetters[_rand.Next(EnglishLetters.Length)];
            return ReturnLetter;
        }
        public static string FixedLetters(params string[] chosen_letters)
        {
            string ReturnLetter = "";
            ReturnLetter = chosen_letters[_rand.Next(chosen_letters.Length)];
            return ReturnLetter;
        }
    }
}
