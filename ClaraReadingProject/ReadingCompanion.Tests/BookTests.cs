namespace ReadingCompanion.Tests;

using ReadingCompanion;

public class BookTests
{
    [Fact]
    public void Test_BookConstructor()
    {
        Book book = new Book("Test Title", "Test Author");
        
        Assert.Equal("Test Title", book.Title);
        Assert.Equal("Test Author", book.Author);
        Assert.False(book.Owned);
    }

    [Fact]
    public void Test_BookToString()
    {
        Book book = new Book("Title", "Author");
        string result = book.ToString();
        
        Assert.Equal("Title by Author", result);
    }
}
