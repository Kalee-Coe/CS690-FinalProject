namespace ReadingCompanion;

public class ConsoleUI
{
    FileSaver fileSaver;

    public ConsoleUI()
    {
        fileSaver = new FileSaver("library.txt");
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
                Console.WriteLine("Goodbye, Clara!");
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

        fileSaver.AppendLine(title + ":" + author);
        Console.WriteLine("Book added to library successfully!");
    }
}
