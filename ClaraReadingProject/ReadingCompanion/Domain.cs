namespace ReadingCompanion;

public class Book
{
    public string Title { get; set; }
    public string Author { get; set; }
    public bool Owned { get; set; }
    public bool Finished { get; set; }
    public int? Rating { get; set; }
    public string Notes { get; set; }
    public string DateFinished { get; set; }

    public Book(string title, string author)
    {
        this.Title = title;
        this.Author = author;
        this.Owned = false;
        this.Finished = false;
        this.Rating = null;
        this.Notes = "No notes";
        this.DateFinished = "";

    }

    public override string ToString()
    {
        return this.Title + " by " + this.Author;
    }
}