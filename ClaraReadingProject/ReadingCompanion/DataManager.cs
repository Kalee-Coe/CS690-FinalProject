namespace ReadingCompanion;

public class DataManager
{
    FileSaver libraryFile;
    FileSaver toReadFile;
    FileSaver finishedFile;

    public List<Book> Library { get; }
    public List<Book> ToRead { get; }
    public List<Book> Finished { get; }

    public DataManager()
    {
        libraryFile = new FileSaver("library.txt");
        toReadFile = new FileSaver("toread.txt");
        finishedFile = new FileSaver("finished.txt");

        Library = new List<Book>();
        ToRead = new List<Book>();
        Finished = new List<Book>();

        LoadLibrary();
        LoadToRead();
        LoadFinished();
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

     public void LoadToRead()
    {
        var lines = toReadFile.ReadAllLines();
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
                ToRead.Add(book);
            }
        }
    }

    public void LoadFinished()
    {
        var lines = finishedFile.ReadAllLines();
        foreach (var line in lines)
        {
            if (line.Length == 0)
            {
                continue;
            }
            var splitted = line.Split(":", StringSplitOptions.RemoveEmptyEntries);
            if (splitted.Length >= 6)
            {
                Book book = new Book(splitted[0], splitted[1]);
                book.Finished = true;
                
                int rating;
                if (int.TryParse(splitted[2], out rating))
                {
                    book.Rating = rating;
                }
                
                book.Notes = splitted[3];
                book.DateFinished = splitted[4];
                
                Finished.Add(book);
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

     public void SynchronizeToRead()
    {
        List<string> lines = new List<string>();
        foreach (var book in ToRead)
        {
            lines.Add(book.Title + ":" + book.Author);
        }
        toReadFile.WriteAllLines(lines);
    }

    public void SynchronizeFinished()
    {
        List<string> lines = new List<string>();
        foreach (var book in Finished)
        {
            string ratingString = "";
            if (book.Rating.HasValue)
            {
                ratingString = book.Rating.Value.ToString();
            }
            else
            {
                ratingString = "0";
            }
            
            lines.Add(book.Title + ":" + book.Author + ":" + ratingString + ":" + book.Notes + ":" + book.DateFinished + ":finished");
        }
        finishedFile.WriteAllLines(lines);
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

     public bool IsBookInToRead(string title, string author)
    {
        foreach (var book in ToRead)
        {
            if (book.Title == title && book.Author == author)
            {
                return true;
            }
        }
        return false;
    }

    public bool IsBookInFinished(string title, string author)
    {
        foreach (var book in Finished)
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

     public void AddBookToToRead(string title, string author)
    {
        if (IsBookInToRead(title, author))
        {
            Console.WriteLine("This book is already in your to-read list!");
            return;
        }
        
        Book newBook = new Book(title, author);
        ToRead.Add(newBook);
        SynchronizeToRead();
        Console.WriteLine("Book added to to-read list successfully!");
    }

    public Book FindBookInToRead(string title, string author)
    {
        foreach (var book in ToRead)
        {
            if (book.Title == title && book.Author == author)
            {
                return book;
            }
        }
        return null;
    }

    public void RemoveBookFromToRead(string title, string author)
    {
        Book bookToRemove = FindBookInToRead(title, author);
        if (bookToRemove != null)
        {
            ToRead.Remove(bookToRemove);
            SynchronizeToRead();
        }
    }

    public void MarkBookAsFinished(string title, string author, int rating, string notes, string date)
    {
        if (IsBookInFinished(title, author))
        {
            Console.WriteLine("You have already finished this book!");
            return;
        }

        Book finishedBook = new Book(title, author);
        finishedBook.Finished = true;
        finishedBook.Rating = rating;
        
        if (notes.Length == 0)
        {
            finishedBook.Notes = "No notes";
        }
        else
        {
            finishedBook.Notes = notes;
        }
        
        finishedBook.DateFinished = date;
        Finished.Add(finishedBook);
        SynchronizeFinished();
        
        Console.WriteLine("Book marked as finished!");
    }

    public void ViewNotesForFinishedBooks()
    {
        if (Finished.Count == 0)
        {
            Console.WriteLine("No finished books to display.");
            return;
        }

        foreach (var book in Finished)
        {
            Console.WriteLine("Title: " + book.Title);
            Console.WriteLine("Author: " + book.Author);
            
            if (book.Rating.HasValue)
            {
                Console.WriteLine("Rating: " + book.Rating.Value + "/5");
            }
            else
            {
                Console.WriteLine("Rating: Not rated");
            }
            
            Console.WriteLine("Date Finished: " + book.DateFinished);
            Console.WriteLine("Notes: " + book.Notes);
            Console.WriteLine("Notes Added!");
        }
    }
}