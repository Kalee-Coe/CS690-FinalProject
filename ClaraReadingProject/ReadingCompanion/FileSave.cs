namespace ReadingCompanion;

using System.IO;

public class FileSaver
{
    string fileName;

    public FileSaver(string fileName)
    {
        this.fileName = fileName;
        if (!File.Exists(this.fileName))
        {
            File.Create(this.fileName).Close();
        }
    }


    public void AppendLine(string line)
    {
        File.AppendAllText(this.fileName, line + Environment.NewLine);
    }

     public void WriteAllLines(List<string> lines)
    {
        File.WriteAllLines(this.fileName, lines);
    }

    public string[] ReadAllLines()
    {
        if (File.Exists(this.fileName))
        {
            return File.ReadAllLines(this.fileName);
        }
        return new string[0];
    }

}
