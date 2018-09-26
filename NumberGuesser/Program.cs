using System;
using System.Speech.Synthesis;

// Cntl + F5 to run build and run 
namespace NumberGuesser // container for classes and methods
{
    class Program
    {
        static void Main(string[] args) // function inside a class (method)
        {
            // Initialize a new instance of the SpeechSynthesizer.  
            SpeechSynthesizer synth = new SpeechSynthesizer();

            GetAppInfo(synth);

            GreetUser(synth);

            while(true)
            {

            // create a new random object
            Random random = new Random();

            // set correct numer
            int correctNumber = random.Next(1, 10);

            // initial guess
            int guess = 0;

            // Ask user to guess a number
            Console.WriteLine("Guess a number between 1 and 10");
            synth.Speak("Guess a number between 1 and 10");

            // while guess is not correct
            while(guess != correctNumber)
            {
                    // get user guess
                    string userAnswer = Console.ReadLine();

                // make sure its a number
                if(!int.TryParse(userAnswer, out guess))
                    {
                        PrintColorMessage(ConsoleColor.Red, "Please enter an actual number", synth);

                        // keep going
                        continue;
                    }

                    // cast to int then assign to guess
                    guess = Int32.Parse(userAnswer);

                // match parse to correct numer
                if (guess != correctNumber) {
                        PrintColorMessage(ConsoleColor.Red, "wrong number, please try again...", synth);
                        if(guess > correctNumber)
                        {
                            PrintColorMessage(ConsoleColor.Blue, "Try a lower number", synth);
                        }
                        else if (guess < correctNumber)
                        {
                            PrintColorMessage(ConsoleColor.Blue, "Try a higher number", synth);
                        }
                        else
                        {
                            continue;
                        }
                    }
                }

                // output success message
                PrintColorMessage(ConsoleColor.Yellow, "you are CORRECT!!!", synth);

                // ask to play again
                Console.WriteLine("Do you want to play again? [Y or N]");
                synth.Speak("Do you want to play again?");

                // get the answer
                string yesOrNo = Console.ReadLine().ToUpper();

                if(yesOrNo == "Y")
                {
                    continue;
                }
                else if(yesOrNo == "N")
                {
                    Console.WriteLine("Bye!");
                    synth.Speak("Bye!");
                    return;
                }
                else
                {
                    return;
                }
            }
        }

        static void GetAppInfo(SpeechSynthesizer synth)
        {
            // set app properties or variables
            string appName = "Number Guesser";
            string appVersion = "1.0.0";
            string appAuthor = "Maher Alkendi inspired by Brad Traversty";

            // Configure the audio output.   
            synth.SetOutputToDefaultAudioDevice();

            // Choose text color
            Console.ForegroundColor = ConsoleColor.Green;

            // write app info
            Console.WriteLine("{0}: Version {1} by {2}", appName, appVersion, appAuthor);
            synth.Speak(appName + ": Version " + appVersion + " by " + appAuthor);

            // reset text color
            Console.ResetColor();
        }

        static void GreetUser(SpeechSynthesizer synth)
        {
            // Ask User's Name
            Console.WriteLine("What is your name?");
            synth.Speak("What is your name?");

            // Get user name
            string userName = Console.ReadLine();

            // Answer User
            Console.WriteLine("Hello {0}, lets play a game!", userName);
            synth.Speak("Hello " + userName + ", lets play a game!");
        }

        static void PrintColorMessage(ConsoleColor color, string message, SpeechSynthesizer synth) {
            // Choose text color
            Console.ForegroundColor = color;

            // tell user ist not a number
            Console.WriteLine(message);
            synth.Speak(message);

            // reset text color
            Console.ResetColor();
        }
    }
}
