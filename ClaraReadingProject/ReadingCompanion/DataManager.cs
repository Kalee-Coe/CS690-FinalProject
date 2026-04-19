namespace ReadingCompanion;

public class DataManager
{
    FileSaver libraryFile;

    public List<Book> Library { get; }

    public DataManager()
    {
        libraryFile = new FileSaver("library.txt");
        Library = new List<Book>();
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
                Library.Add(book);
            }
        }
    }

    public void SynchronizeLibrary()
    {
        List<string> lines = new List<string>();
        foreach (var book in Library)
        {
            lines.Add(book.Title + ":" + book.Author);
        }
        libraryFile.WriteAllLines(lines);
    }

    public bool IsBookInLibrary(string title, string author)
    {
        foreach (var book in Library)
        {
            if (book.Title == title && book.Author == author)
            {
                return true;
            }
        }
        return false;
    }

    public void AddBookToLibrary(string title, string author)
    {
        if (IsBookInLibrary(title, author))
        {
            Console.WriteLine("This book is already in your library!");
            return;
        }
        
        Book newBook = new Book(title, author);
        newBook.Owned = true;
        Library.Add(newBook);
        SynchronizeLibrary();
        Console.WriteLine("Book added to library successfully!");
    }
}