namespace ReadingCompanion;

public class Book
{
    public string Title { get; set; }
    public string Author { get; set; }
    public bool Owned { get; set; }

    public Book(string title, string author)
    {
        this.Title = title;
        this.Author = author;
        this.Owned = false;
    }

    public override string ToString()
    {
        return this.Title + " by " + this.Author;
    }
}