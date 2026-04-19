namespace ReadingCompanion;

public class ConsoleUI
{
    FileSaver libraryFile;
    List<Book> library;

    public ConsoleUI()
    {
        libraryFile = new FileSaver("library.txt");
        library = new List<Book>();
        LoadLibrary();
    }

    public void LoadLibrary()
    {
        var lines = libraryFile.ReadAllLines();
        foreach (var line in lines)
        {
            if (line.Length == 0)
            {
                continue;
            }
            var splitted = line.Split(":", StringSplitOptions.RemoveEmptyEntries);
            if (splitted.Length >= 2)
            {
                Book book = new Book(splitted[0], splitted[1]);
                book.Owned = true;
                library.Add(book);
            }
        }
    }

    public bool IsBookInLibrary(string title, string author)
    {
        foreach (var book in library)
        {
            if (book.Title == title && book.Author == author)
            {
                return true;
            }
        }
        return false;
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

        if (IsBookInLibrary(title, author))
        {
            Console.WriteLine("This book is already in your library!");
            return;
        }

        Book newBook = new Book(title, author);
        newBook.Owned = true;
        library.Add(newBook);
        libraryFile.AppendLine(title + ":" + author);
        Console.WriteLine("Book added to library successfully!");
    }
}
