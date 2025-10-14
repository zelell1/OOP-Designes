namespace Itmo.ObjectOrientedProgramming.Lab2.ValueObjects;

public class FilePath
{
    public string Value { get; }

    public FilePath(string value)
    {
        ArgumentException.ThrowIfNullOrEmpty(value);

        if (!Path.IsPathRooted(value))
        {
            throw new ArgumentException($"{nameof(value)} must be rooted");
        }

        if (!string.IsNullOrEmpty(Path.GetDirectoryName(value)) && !Directory.Exists(Path.GetDirectoryName(value)))
        {
            throw new ArgumentException($"{nameof(value)} must exist");
        }

        Value = value;
    }
}