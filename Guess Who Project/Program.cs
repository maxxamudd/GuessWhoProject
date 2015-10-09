// Name: Guess Who
// Purpose: Play the game Guess Who
// Programmer: Maxx Mudd on 9/10/2015
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Guess_Who_Project
{
    class Program
    {
        static void Main(string[] args)
        {
            // create and populate list populate list
            List<Person> people = new List<Person>();
            people = createList();

            // randomly select a mystery person
            int pick = 0;
            pick = pickPerson(people);
            Person mysteryPerson = new Person(people[pick].Name, people[pick].IsMale, 
                people[pick].IsFemale, people[pick].HairColor, people[pick].EyeColor);

            // greet user, display rules
            displayGreeting();

            int guesses = 0;
            bool win = false;
            while (win == false)
            {
                // get user choice
               win = getQuestion(ref people, mysteryPerson, ref guesses);
            }
        }
        public static void setConsoleSize()
        {
            // get screen height
            var screenHeight = SystemInformation.VirtualScreen.Height;

            if (screenHeight >= 900)
            {
                // console size for resolutions > 900
                System.Console.SetWindowSize(83, 65);
            }
            else if (screenHeight == 720)
            {
                // console size for 720 resolution
                System.Console.SetWindowSize(83, 54);
            }
            else
            {
                // do not set console size for lower resolutions
            }
        }
        public static List<Person> createList()
        {
            // people objects
            Person Jenny = new Person("Jenny", false, true, "Brown", "Brown");
            Person David = new Person("David", true, false, "Brown", "Brown");
            Person Wendy = new Person("Wendy", false, true, "Blonde", "Brown");
            Person Chris = new Person("Chris", true, false, "Blonde", "Brown");
            Person April = new Person("April", false, true, "Black", "Brown");
            Person Brian = new Person("Brian", true, false, "Black", "Brown");
            Person Susan = new Person("Susan", false, true, "Brown", "Green");
            Person Grant = new Person("Grant", true, false, "Brown", "Green");
            Person Katie = new Person("Katie", false, true, "Blonde", "Green");
            Person James = new Person("James", true, false, "Blonde", "Green");
            Person Karen = new Person("Karen", false, true, "Black", "Green");
            Person Kevin = new Person("Kevin", true, false, "Black", "Green");
            Person Maria = new Person("Maria", false, true, "Brown", "Blue");
            Person Eddie = new Person("Eddie", true, false, "Brown", "Blue");
            Person Betty = new Person("Betty", false, true, "Blonde", "Blue");
            Person Scott = new Person("Scott", true, false, "Blonde", "Blue");
            Person Sarah = new Person("Sarah", false, true, "Black", "Blue");
            Person Jason = new Person("Jason", true, false, "Black", "Blue");

            // create and populate list of objects
            List<Person> people = new List<Person>();
            people.Add(Jenny);
            people.Add(David);
            people.Add(Wendy);
            people.Add(Chris);
            people.Add(April);
            people.Add(Brian);
            people.Add(Susan);
            people.Add(Grant);
            people.Add(Katie);
            people.Add(James);
            people.Add(Karen);
            people.Add(Kevin);
            people.Add(Maria);
            people.Add(Eddie);
            people.Add(Betty);
            people.Add(Scott);
            people.Add(Sarah);
            people.Add(Jason);

            return people;
        }
        public static int pickPerson(List<Person> people)
        {
            // shuffle people list
            Random rand = new Random();
            for (int i = people.Count; i > 1; i--)
            {
                int j = rand.Next(i);
                Person temp = people[j];
                people[j] = people[i - 1];
                people[i - 1] = temp;
            }

            // pick person
            int pick = rand.Next(0, 17);

            return pick;
        }
        public static void displayGreeting()
        {
            // create asterisks for left side of title
            for (int i = 0; i < 30; ++i)
            {
                Console.Write("*");
            }

            Console.Write(" Welcome to Guess Who! ");

            // create asterisks for right side of title
            for (int i = 0; i < 30; ++i)
            {
                Console.Write("*");
            }

            Console.WriteLine("\nI have chosen a mystery person, and you have to figure out who it is!");
            Console.WriteLine("You can ask me questions about this person's hair color, eye color, and gender.");
            Console.WriteLine("Once you have enough information, make a guess!\n");

            // create line of 40 dashes
            for (int i = 0; i < 83; ++i)
            {
                Console.Write("-");
            }
            Console.WriteLine();
        }
        public static void displayPeople(ref List<Person> people)
        {
            // display people and their traits
            Console.WriteLine("People:\n");

            foreach (var p in people)
            {
                for (int j = 0; j < 20; ++j)
                {
                    Console.Write("-");
                }
                Console.Write("{0}", p.Name);
                for (int j = 0; j < 20; ++j)
                {
                    Console.Write("-");
                }
                Console.WriteLine();
                if (p.IsMale == true)
                {
                    Console.Write("Gender: Male    ");
                }
                else
                {
                    Console.Write("Gender: Female  ");
                }
                Console.Write("Hair: {0}  ", p.HairColor);
                Console.WriteLine("Eyes: {0}\n", p.EyeColor);
            }
        }
        public static bool getQuestion(ref List<Person> people, Person mysteryPerson, ref int guesses)
        {
            bool win = false;
            string input;
            int choice;

            // get choice
            Console.WriteLine();
            Console.WriteLine("What would you like to know about my mystery person?\n");
            Console.Write("[1] Gender? [2] Hair color? [3] Eye color? [4] People [5] Guess >> ");
            input = Console.ReadLine();

            // input validation
            int.TryParse(input, out choice);
            if (!int.TryParse(input, out choice) || choice > 5 || choice < 1)
            {
                choice = -1;
                while (choice == -1)
                {
                    Console.WriteLine("\nPlease enter a valid choice.\n");
                    Console.WriteLine("What would you like to know about my mystery person?\n");
                    Console.Write("[1] Gender? [2] Hair color? [3] Eye color? [4] People [5] Guess >> ");
                    input = Console.ReadLine();
                    int.TryParse(input, out choice);
                    if (!int.TryParse(input, out choice) || choice > 5 || choice < 1)
                    {
                        choice = -1;
                    }
                }
            }
            // if player wants to ask about gender
            if (choice == 1)
            {
                checkGender(ref people, mysteryPerson, ref guesses);
            }
            // if player wants to ask about hair color
            else if (choice == 2)
            {
                checkHairColor(ref people, mysteryPerson, ref guesses);
            }
            // if wants to ask about eye color
            else if (choice == 3)
            {
                checkEyeColor(ref people, mysteryPerson, ref guesses);
            }
            // if player wants to see the list of people
            else if (choice == 4)
            {
                Console.WriteLine();
                displayPeople(ref people);
            }
            // if player wants to guess who the mystery person is
            else
            {
                win = guess(ref people, mysteryPerson, ref guesses);
            }
            return win;
        }
        public static void checkGender(ref List<Person> people, Person mysteryPerson, ref int guesses)
        {
            string input;
            int choice;
            Console.WriteLine("\nWhat would would you like to know?");
            Console.Write("[1] Is your person a male? [2] Is your person a female? >> ");
            input = Console.ReadLine();

            // input validation
            int.TryParse(input, out choice);
            if (!int.TryParse(input, out choice) || choice > 2 || choice < 1)
            {
                choice = -1;
                while (choice == -1)
                {
                    Console.WriteLine("\nPlease enter a valid choice.\n");
                    Console.WriteLine("What would would you like to know?");
                    Console.Write("[1] Is your person a male? [2] Is your person a female? >> ");
                    input = Console.ReadLine();
                    int.TryParse(input, out choice);
                    if (!int.TryParse(input, out choice) || choice > 2 || choice < 1)
                    {
                        choice = -1;
                    }
                }
            }

            Console.WriteLine();

            // if player asks if mystery person is male
            if (choice == 1)
            {
                if (mysteryPerson.IsMale == true)
                {
                    Console.WriteLine("Yes, my person is a male.");

                    // remove all females from people list, increment guess counter
                    people.RemoveAll(p => p.IsFemale == true);
                    ++guesses;
                }
                else
                {
                    Console.WriteLine("No, my person is not a male.");

                    // remove all males from people list, increment guess counter
                    people.RemoveAll(p => p.IsMale == true);
                    ++guesses;
                }
            }
            // if player asks if the mystery person is female
            else
            {
                if (mysteryPerson.IsFemale == true)
                {
                    Console.WriteLine("Yes, my person is a female.");

                    // remove all males from people list, increment guess counter
                    people.RemoveAll(p => p.IsMale == true);
                    ++guesses;
                }
                else
                {
                    Console.WriteLine("No, my person not a female.");
                    
                    // remove all females from people list, increment guess counter
                    people.RemoveAll(p => p.IsFemale == true);
                    ++guesses;
                }
            }
        }
        public static void checkHairColor(ref List<Person> people, Person mysteryPerson, ref int guesses)
        {
            string input;
            int choice;
            Console.WriteLine("\nWhat would you like to know?");
            Console.Write("[1] Does your person have brown hair? [2] Does your person have blonde hair?\n[3] Does your person have black hair? >> ");
            input = Console.ReadLine();

            // input validation
            int.TryParse(input, out choice);
            if (!int.TryParse(input, out choice) || choice > 3 || choice < 1)
            {
                choice = -1;
                while (choice == -1)
                {
                    Console.WriteLine("\nPlease enter a valid choice.\n");
                    Console.WriteLine("\nWhat would you like to know?");
                    Console.Write("[1] Does your person have brown hair? [2] Does your person have blonde hair?\n[3] Does your person have black hair? >> ");
                    input = Console.ReadLine();
                    int.TryParse(input, out choice);
                    if (!int.TryParse(input, out choice) || choice > 3 || choice < 1)
                    {
                        choice = -1;
                    }
                }
            }

            Console.WriteLine();

            // if player asks if the mystery perosn has brown hair
            if (choice == 1)
            {
                if (mysteryPerson.HairColor == "Brown")
                {
                    Console.WriteLine("Yes, my person has brown hair.");
                    
                    // remove all people with black or blonde hair from people list, increment guess counter
                    people.RemoveAll(p => p.HairColor == "Black");
                    people.RemoveAll(p => p.HairColor == "Blonde");
                    ++guesses;
                }
                else
                {
                    Console.WriteLine("No, my person does not have brown hair.");
                    
                    // remove all people with brown hair from people list, increment guess counter
                    people.RemoveAll(p => p.HairColor == "Brown");
                    ++guesses;
                }
            }
            // if player asks if the mystery person has blonde hair
            else if (choice == 2)
            {
                if (mysteryPerson.HairColor == "Blonde")
                {
                    Console.WriteLine("Yes, my person has blonde hair.");
                    
                    // remove all people with brown or black hair from people list, increment guess counter
                    people.RemoveAll(p => p.HairColor == "Brown");
                    people.RemoveAll(p => p.HairColor == "Black");
                    ++guesses;
                }
                else
                {
                    Console.WriteLine("No, my person does not have blonde hair.");
                    
                    // remove all people with blonde hair from people list, increment guess counter
                    people.RemoveAll(p => p.HairColor == "Blonde");
                    ++guesses;
                }
            }
            // if player asks if the mystery person has black hair
            else
            {
                if (mysteryPerson.HairColor == "Black")
                {
                    Console.WriteLine("Yes, my person has black hair.");
                    
                    // remove all people with brown or blonde hair from people list, increment guess counter
                    people.RemoveAll(p => p.HairColor == "Brown");
                    people.RemoveAll(p => p.HairColor == "Blonde");
                    ++guesses;
                }
                else
                {
                    Console.WriteLine("No, my person does not have black hair.");
                    
                    // remove all people with black hair from people list, increment guess counter
                    people.RemoveAll(p => p.HairColor == "Black");
                    ++guesses;
                }
            }
        }
        public static void checkEyeColor(ref List<Person> people, Person mysteryPerson, ref int guesses)
        {
            string input;
            int choice;
            Console.WriteLine("\nWhat would you like to know?\n");
            Console.Write("[1] Does your person have brown eyes? [2] Does your person have green eyes?\n[3] Does your person have blue eyes? >> ");
            input = Console.ReadLine();

            // input validation
            int.TryParse(input, out choice);
            if (!int.TryParse(input, out choice) || choice > 3 || choice < 1)
            {
                choice = -1;
                while (choice == -1)
                {
                    Console.WriteLine("\nPlease enter a valid choice.");
                    Console.WriteLine("\nWhat would you like to know?\n");
                    Console.Write("[1] Does your person have brown eyes? [2] Does your person have green eyes?\n[3] Does your person have blue eyes? >> ");
                    input = Console.ReadLine();
                    int.TryParse(input, out choice);
                    if (!int.TryParse(input, out choice) || choice > 3 || choice < 1)
                    {
                        choice = -1;
                    }
                }
            }

            Console.WriteLine();

            // if player asks if the mystery person has brown eyes
            if (choice == 1)
            {
                if (mysteryPerson.EyeColor == "Brown")
                {
                    Console.WriteLine("Yes, my person has brown eyes.");
                    
                    // remove all people with green or blue eyes from people list, increment guess counter
                    people.RemoveAll(p => p.EyeColor == "Green");
                    people.RemoveAll(p => p.EyeColor == "Blue");
                    ++guesses;
                }
                else
                {
                    Console.WriteLine("No, my person does not have brown eyes.");

                    // remove all people with brown eyes from people list, increment guess counter
                    people.RemoveAll(p => p.EyeColor == "Brown");
                    ++guesses;
                }
            }
            // if player asks if the mystery person has green eyes
            else if (choice == 2)
            {
                if (mysteryPerson.EyeColor == "Green")
                {
                    Console.WriteLine("Yes, my person has green eyes.");
                    
                    // remove all people with brown or blue eyes from people list, increment guess counter
                    people.RemoveAll(p => p.EyeColor == "Brown");
                    people.RemoveAll(p => p.EyeColor == "Blue");
                    ++guesses;
                }
                else
                {
                    Console.WriteLine("No, my person does not have green eyes.");

                    // remove all people with green eyes from people list, increment guess counter
                    people.RemoveAll(p => p.EyeColor == "Green");
                    ++guesses;
                }
            }
            // if player asks if the mystery person has blue eyes
            else
            {
                if (mysteryPerson.EyeColor == "Blue")
                {
                    Console.WriteLine("Yes, my person has blue eyes.");
                    
                    // remove all people with brown or green eyes from people list, increment guess counter
                    people.RemoveAll(p => p.EyeColor == "Brown");
                    people.RemoveAll(p => p.EyeColor == "Green");
                    ++guesses;
                }
                else
                {
                    Console.WriteLine("No, my person does not have blue eyes.");
                    
                    // remove all people with blue eyes from people list, increment guess counter
                    people.RemoveAll(p => p.EyeColor == "Blue");
                    ++guesses;
                }
            }
        }
        public static bool guess(ref List<Person> people, Person mysteryPerson, ref int guesses)
        {
            string input;
            string compareString;
            bool win = false;
            compareString = mysteryPerson.Name;
            Console.Write("\nOk! Who do you think the mystery person is? Enter their name >> ");
            input = Console.ReadLine();

            if (input.ToLower() == compareString.ToLower())
            {
                // show that player has won, increment guess counter
                Console.WriteLine();
                win = true;
                ++guesses;
                for (int i = 0; i < 38; ++i)
                {
                    Console.Write("*");
                }
                Console.Write("WINNER!");
                for (int i = 0; i < 38; ++i)
                {
                    Console.Write("*");
                }
                if(guesses == 1)
                {
                    Console.WriteLine("\nYou figured out that " + mysteryPerson.Name + " is the mystery person in 1 guess!");
                    Console.WriteLine("\nThanks for playing!");
                }
                else
                {
                    Console.WriteLine("\nYou figured out that " + mysteryPerson.Name + " is the mystery person in " + guesses + " guesses!");
                    Console.WriteLine("\nThanks for playing!");
                }
                
            }
            else
            {
                // show that player is incorrect, increment guess counter
                Console.WriteLine("\nI'm sorry, that isn't my mystery person.");
                ++guesses;
            }
            return win;
        }
    }
    class Person
    {
        // set and get for traits
        public string Name { get; set; }
        public bool IsMale { get; set; }
        public bool IsFemale { get; set; }
        public string HairColor { get; set; }
        public string EyeColor { get; set; }

        // constructor
        public Person(string name, bool isMale, bool isFemale, string hairColor, string eyeColor)
        {
            Name = name;
            IsMale = isMale;
            IsFemale = isFemale;
            HairColor = hairColor;
            EyeColor = eyeColor;
        }
    }
}
