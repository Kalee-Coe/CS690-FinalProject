namespace ReadingCompanion.Tests;

using ReadingCompanion;

public class FileSaverTests
{
    FileSaver fileSaver;
    string testFileName;

    public FileSaverTests()
    {
        testFileName = "test-file.txt";
        File.Delete(testFileName);
        fileSaver = new FileSaver(testFileName);
    }

    [Fact]
    public void Test_AppendLine()
    {
        fileSaver.AppendLine("Test Line");
        var lines = File.ReadAllLines(testFileName);
        Assert.Single(lines);
        Assert.Equal("Test Line", lines[0]);
    }
}
