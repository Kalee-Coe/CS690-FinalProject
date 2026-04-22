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
            Console.WriteLine("2. Add a book to my to-read list");
            Console.WriteLine("3. Mark a book as finished");
            Console.WriteLine("4. View reading progress");
            Console.WriteLine("5. View notes for finished books");
            Console.WriteLine("6. Set yearly reading goal");
            Console.WriteLine("7. Exit");
            Console.Write("Select an option: ");

            command = Console.ReadLine();

            if (command == "1")
            {
                AddBookToLibrary();
            }
            else if (command == "2")
            {
                AddBookToToRead();
            }
            else if (command == "3")
            {
                MarkBookAsFinished();
            }
            else if (command == "4")
            {
                dataManager.ViewReadingProgress();
            }
            else if (command == "5")
            {
                dataManager.ViewNotesForFinishedBooks();
            }
            else if (command == "6")
            {
                SetYearlyGoal();
            }
            else if (command == "7")
            {
                Console.WriteLine("Thank You!");
            }
            else
            {
                Console.WriteLine("Invalid option. Please try again.");
            }

        } while (command != "7");
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

    public void AddBookToToRead()
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

        dataManager.AddBookToToRead(title, author);
    }

    public void MarkBookAsFinished()
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

        if (dataManager.IsBookInFinished(title, author))
        {
            Console.WriteLine("You have already finished this book!");
            return;
        }

        Console.Write("Enter your rating (1-5): ");
        string ratingInput = Console.ReadLine();
        int rating;
        if (!int.TryParse(ratingInput, out rating))
        {
            Console.WriteLine("Invalid rating. Using 0.");
            rating = 0;
        }
        
        if (rating < 1 || rating > 5)
        {
            Console.WriteLine("Rating should be between 1 and 5. Using 0.");
            rating = 0;
        }

        Console.Write("Enter your notes (press Enter for no notes): ");
        string notes = Console.ReadLine();
        
        if (notes.Length == 0)
        {
            notes = "No notes";
        }

        string dateFinished = DateTime.Now.ToString("MM/dd/yyyy");

        dataManager.MarkBookAsFinished(title, author, rating, notes, dateFinished);

        if (dataManager.IsBookInToRead(title, author))
        {
            Console.Write("This book is in your to-read list. Remove it? (yes/no): ");
            string removeFromToRead = Console.ReadLine();
            
            if (removeFromToRead.ToLower() == "yes" || removeFromToRead.ToLower() == "y")
            {
                dataManager.RemoveBookFromToRead(title, author);
                Console.WriteLine("Removed from to-read list.");
            }
        }

        if (!dataManager.IsBookInLibrary(title, author))
        {
            Console.Write("Add this book to your library? (yes/no): ");
            string addToLibrary = Console.ReadLine();
            
            if (addToLibrary.ToLower() == "yes" || addToLibrary.ToLower() == "y")
            {
                dataManager.AddBookToLibrary(title, author);
            }
        }
    }

    public void SetYearlyGoal()
    {
        Console.Write("Enter your yearly reading goal (number of books): ");
        string goalInput = Console.ReadLine();
        int goal;
        if (int.TryParse(goalInput, out goal))
        {
            if (goal > 0)
            {
                dataManager.SetYearlyGoal(goal);
            }
            else
            {
                Console.WriteLine("Goal must be greater than 0.");
            }
        }
        else
        {
            Console.WriteLine("Invalid number.");
        }
    }
}

