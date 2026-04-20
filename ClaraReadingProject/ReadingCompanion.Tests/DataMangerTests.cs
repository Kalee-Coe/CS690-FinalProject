namespace ReadingCompanion.Tests;

using ReadingCompanion;

public class DataManagerTests
{
    DataManager dataManager;

    public DataManagerTests()
    {
        File.WriteAllText("library.txt", "");
        File.WriteAllText("to_read.txt", "");
        File.WriteAllText("finished.txt", "");
        dataManager = new DataManager();
    }

    [Fact]
    public void Test_AddBookToLibrary()
    {
        int initialCount = dataManager.Library.Count;
        dataManager.AddBookToLibrary("Test Book", "Test Author");
        Assert.Equal(initialCount + 1, dataManager.Library.Count);
    }

    [Fact]
    public void Test_AddDuplicateBookToLibrary()
    {
        dataManager.AddBookToLibrary("Unique Book", "Unique Author");
        int countAfterFirst = dataManager.Library.Count;
        
        dataManager.AddBookToLibrary("Unique Book", "Unique Author");
        int countAfterSecond = dataManager.Library.Count;
        
        Assert.Equal(countAfterFirst, countAfterSecond);
    }

     [Fact]
    public void Test_AddBookToToRead()
    {
        int initialCount = dataManager.ToRead.Count;
        dataManager.AddBookToToRead("Test Book", "Test Author");
        Assert.Equal(initialCount + 1, dataManager.ToRead.Count);
    }

    [Fact]
    public void Test_MarkBookAsFinished()
    {
        int initialCount = dataManager.Finished.Count;
        dataManager.MarkBookAsFinished("Finished Book", "Author", 5, "Great!", "03/15/2024");
        Assert.Equal(initialCount + 1, dataManager.Finished.Count);
    }

    [Fact]
    public void Test_IsBookInLibrary()
    {
        dataManager.AddBookToLibrary("Check Book", "Check Author");
        bool result = dataManager.IsBookInLibrary("Check Book", "Check Author");
        Assert.True(result);
    }

    [Fact]
    public void Test_RemoveBookFromToRead()
    {
        dataManager.AddBookToToRead("Remove Me", "Author");
        int countAfterAdd = dataManager.ToRead.Count;
        
        dataManager.RemoveBookFromToRead("Remove Me", "Author");
        int countAfterRemove = dataManager.ToRead.Count;
        
        Assert.Equal(countAfterAdd - 1, countAfterRemove);
    }
}