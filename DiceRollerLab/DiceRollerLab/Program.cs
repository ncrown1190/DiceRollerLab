// See https://aka.ms/new-console-template for more information
//Console.WriteLine("Hello, World!");

Console.WriteLine("Welcome to The Grand Circus Dice Roller Casino");

// Calling main methods here 
do
{
    DiceRolled();

} while (GetPlayAgainAnswer() == true);

// Main Method
static void DiceRolled()
{
    Console.Write("Enter a whole number: ");
    string userInput = Console.ReadLine();

    int userNumber = 0;

    bool isRealNumber = int.TryParse(userInput, out userNumber );

    while( isRealNumber == false )
    {
        Console.Write("You must enter a whole number. tryAgain ");
        userInput = Console.ReadLine();
        isRealNumber = int.TryParse(userInput,out userNumber );

    }
    Console.Write("Press any key to roll the dice....");
    Console.ReadKey();  //waits for user to press a key to continue;
    Console.WriteLine();
    //int diceRollOne = 6;
    //int diceRollTwo = 5;
    int diceRollOne = GenerateRandomNumber(userNumber);
    Console.WriteLine($"You first roll is a {diceRollOne} ");
    int diceRollTwo = GenerateRandomNumber(userNumber);
    Console.WriteLine($"You second roll is a {diceRollTwo} ");

    int total = diceRollOne + diceRollTwo;
    Console.WriteLine($"The sum of both dice rolled come out to: {total} \n");

    Console.WriteLine(HandleSixSidedDice(diceRollOne, diceRollTwo));
    Console.WriteLine(HandleSixSideDiceTotal(diceRollOne, diceRollTwo));
}




/* 01. Create a static method to generate the random numbers.
    - Proper method header: 2 points
    - Program generates random numbers validly within the user-specified range: 1 point
   - Method returns meaningful value of proper type: 1 point
 * */

static int GenerateRandomNumber(int numberOfSides)
{
    Random random = new Random();
    int number = random.Next(1, numberOfSides);
    return number;
}

/*  02 Create a static method for six-sided dice that takes two dice values as parameters, 
 *  and returns a string for one of the valid combinations (e.g. Snake Eyes, etc.) or
 *  an empty string if the dice don’t match one of the combinations.
        - Snake Eyes: Two 1s
        - Ace Deuce: A 1 and 2
        - Box Cars: Two 6s
        - Or empty string if no matching combos 
 * */

static string HandleSixSidedDice(int diceOne, int diceTwo)
{
    int sum = diceOne + diceTwo;

    switch (sum)
    {
        case 2:
            return "\"Snake Eyes\"";
            case 3:
            return "\"Ace Deuce\"";
        case 12:
            return "\"Box cars\"";
        default:
            return "";
    }
    
}

/* 03 Create a static method for six-sided dice that takes two dice values as parameters, and 
 * returns a string for one of the valid totals (e.g. Win, etc.) or 
 * an empty string if the dice don’t match one of the totals.
        - Win: A total of 7 or 11
        - Craps: A total of 2, 3, or 12
        - Or empty string if no matching combos* 
* */

static string HandleSixSideDiceTotal(int diceOne, int diceTwo)
{
    int total = diceOne + diceTwo;

    switch (total)
    {
        case 7:
            case 11:
            return " \"Win\"";
        case 2:
            case 3:
        case 12:
            return "\"Craps\"";
        default:
            return ""; 
    }

//if(total == 7 || total == 11 )
//    {
//        return "Win";
//    }
//    if (total == 2 || total == 3 || total == 12) 
//    {
//        return "Craps";
//    }
   // return "";
}

static bool GetPlayAgainAnswer()
{

    Console.Write("\n Would you like play again. Anything but 'yes' will end the game. ");
    string? userAnswer = Console.ReadLine();
    if (userAnswer?.ToLower() != "y")
    {
        return false;
    }
    else
    {
        Console.WriteLine("YEAH LETS PLAY");
        //continue;
        return true;
    }
}