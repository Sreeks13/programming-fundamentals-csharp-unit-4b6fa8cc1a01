namespace CheckoutLog;

public static class CheckoutProcessor
{
    public static string CleanEntry(string entry)
    {
        return string.Join(
            " ",
            entry.Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(x => x.Trim())
        );
    }

    public static void SaveEntry(string entry, string filePath)
    {
        File.WriteAllText(filePath, entry);
    }

    public static string ReadEntry(string filePath)
    {
        return File.ReadAllText(filePath);
    }

    public static void AppendEntry(string entry, string filePath)
    {
        File.AppendAllText(filePath, Environment.NewLine + entry);
    }
}