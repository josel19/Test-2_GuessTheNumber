//Variables globales
int RandomNumber = SelectRandomNumber();
int attempts = 0;
var playerName = "";

startGame();

void startGame()
{
    Console.WriteLine("Guess the number");
    Console.WriteLine("What's your name?");
    playerName = Console.ReadLine();
  
    WannaPlay();   
}

void WannaPlay()
{
    if (attempts == 0)
    {
        Console.WriteLine($"Hi, {playerName}!, do you wanna play? Yes/No");
    }
    else {
        Console.WriteLine($"Do you wanna play again? Yes/No");
    }
    
    var wannaPlay = Console.ReadLine();
    switch (wannaPlay?.ToLower().Trim())
    {
        case "yes":
            Play();
            break;
        case "no":
            NoPlay();
            break;
        default:
            Console.WriteLine("Please write Yes or No");
            WannaPlay();
            break;
    }
}

void Play()
{
    Console.WriteLine("Pick a number between 1 and 10");
    try {
        int numberChose = int.Parse(Console.ReadLine());
        compareNumbers(numberChose);
    }
    catch(Exception e)
    {
        Console.WriteLine("Write a number");
        Play();
    }  
}

void NoPlay()
{
    Console.WriteLine("Ok!, have a good day!");
    if(attempts > 0)
    {
        Console.WriteLine("Attemps:" + attempts);
    }
}

int SelectRandomNumber()
{
    Random random = new();
    int RandomNumber = random.Next(1,10);
    return RandomNumber;
}

void compareNumbers(int numberChose)
{
    if (numberChose > RandomNumber)
    {
        Console.WriteLine("Try again!, your number is higher.");
        attempts++;
        Play();
        return;
    }
    else if(numberChose < RandomNumber)
    {
        Console.WriteLine("Try again!, your number is lower.");
        attempts++;
        Play();
        return;
    }
    Console.WriteLine($"Nice job {playerName}, You win!");
    WannaPlay();
    return;
}
