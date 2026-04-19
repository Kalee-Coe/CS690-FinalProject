namespace ReadingCompanion.Tests;

using ReadingCompanion;

public class DataManagerTests
{
    DataManager dataManager;

    public DataManagerTests()
    {
        File.WriteAllText("library.txt", "");
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
    public void Test_IsBookInLibrary()
    {
        dataManager.AddBookToLibrary("Check Book", "Check Author");
        bool result = dataManager.IsBookInLibrary("Check Book", "Check Author");
        Assert.True(result);
    }
}