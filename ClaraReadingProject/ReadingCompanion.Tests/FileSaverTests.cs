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

    [Fact]
    public void Test_WriteAllLines()
    {
        List<string> lines = new List<string>();
        lines.Add("Line 1");
        lines.Add("Line 2");
        lines.Add("Line 3");
        
        fileSaver.WriteAllLines(lines);
        
        var result = fileSaver.ReadAllLines();
        Assert.Equal(3, result.Length);
    }

    
    [Fact]
    public void Test_ReadEmptyFile()
    {
        var lines = fileSaver.ReadAllLines();
        Assert.Empty(lines);
    }

}
