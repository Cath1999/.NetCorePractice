// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");
var keepPlaying = true;

while (true)
{

    Console.WriteLine("Are you ready?");

    Console.WriteLine("Let begin!!!");

    var selectedChoice = SelectChoice();
    var yourChoice = char.Parse(selectedChoice);

    Console.WriteLine($"You selected {yourChoice}");
    var opponentChoice = GetOponentChoice();

    Console.WriteLine($"I chose {opponentChoice}");

    DecidedWinner(opponentChoice, yourChoice);

    Console.WriteLine("Do you want to play again?");
    Console.WriteLine("Enter yes to play again or any other key stop....");


    var playAgain = Console.ReadLine();
    if (playAgain?.ToLower() == "yes")
        continue;
    else
        break;


}


string SelectChoice()
    {
        Console.WriteLine("Choose R,P or S: [R]ock, [P]aper or [S]cissors: ");
        var selectedChoice = Console.ReadLine();

        if (selectedChoice?.ToLower() != "r" && selectedChoice?.ToLower() != "p" && selectedChoice?.ToLower() != "s")
        {
            Console.WriteLine("Please, select only one letter: R,P or S");
            selectedChoice = SelectChoice();
        }
        return selectedChoice;
    }

    char GetOponentChoice()
    {
        char[] options = new char[] { 'R', 'P', 'S' };
        //random permite obtener cualquier numero en una serie de numeros
        Random random = new Random();

        //trabajando con el indice del array, y se elije una posicion del array para guardar el numero aleatorio
        int randomIndex = random.Next(0, options.Length);

        return options[randomIndex];
    }


void DecidedWinner(char opponentChoice, char yourChoice)
{
    if (opponentChoice == yourChoice)
    
        Console.WriteLine("Tie");


    switch(yourChoice)
    {
        case 'R':
        case 'r':

            if(opponentChoice == 'P')
            
                Console.WriteLine("Paper beats rock, I win");
                else if (opponentChoice == 'S')
                    Console.WriteLine("Rock beats Scissors, you win!");
                break;


          case 'S':
        case 's':

            if (opponentChoice == 'P')

                Console.WriteLine("Scissors beats paper, You win!");
            else if (opponentChoice == 'R')
                Console.WriteLine("Rock beats scissors, You win!");
            break;

        case 'p':
        case 'P':
            if (opponentChoice == 'S')
                Console.WriteLine("Scissors beats paper, I win!");
            else if (opponentChoice == 'R')
                Console.WriteLine("Paper beats scissors, I win!");
            break;
        default:
            break;
            }
    }



