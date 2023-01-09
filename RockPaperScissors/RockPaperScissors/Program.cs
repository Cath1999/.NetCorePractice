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

}


string SelectChoice()
    {
        Console.WriteLine("Choose R,P or S: [R]ock, [P]aper or [S]cissors: ");
        var selectedChoice = Console.ReadLine();

        if (selectedChoice?.ToUpper() != "r" && selectedChoice?.ToLower() != "p" && selectedChoice?.ToLower() != "s")
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



