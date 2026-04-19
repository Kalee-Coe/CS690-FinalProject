namespace ReadingCompanion;

public class ConsoleUI
{
    DataManager dataManager;

    public ConsoleUI()
    {
        dataManager = new DataManager();
    }

    public void Show()
    {
        string command;
        do
        {
            Console.WriteLine("");
            Console.WriteLine("=== Clara's Reading Companion ===");
            Console.WriteLine("1. Add a book to my library");
            Console.WriteLine("2. Exit");
            Console.Write("Select an option: ");

            command = Console.ReadLine();

            if (command == "1")
            {
                AddBookToLibrary();
            }
            else if (command == "2")
            {
                Console.WriteLine("Thank You!");
            }
            else
            {
                Console.WriteLine("Invalid option. Please try again.");
            }

        } while (command != "2");
    }

    public void AddBookToLibrary()
    {
        Console.Write("Enter book title: ");
        string title = Console.ReadLine();
        
        Console.Write("Enter book author: ");
        string author = Console.ReadLine();

        if (title.Length == 0 || author.Length == 0)
        {
            Console.WriteLine("Title and author cannot be empty!");
            return;
        }


        dataManager.AddBookToLibrary(title, author);
    }
}
