namespace Itmo.ObjectOrientedProgramming.Lab4.Core.ValueObject;

public readonly record struct TreeOutputParametrs
{
    public string FileIcon { get; }

    public string DirectoryIcon { get; }

    public char PaddingIcon { get; }

    public TreeOutputParametrs(string fileIcon, string directoryIcon, char paddingIcon)
    {
        FileIcon = fileIcon;
        DirectoryIcon = directoryIcon;
        PaddingIcon = paddingIcon;
    }

    public static TreeOutputParametrs Empty => new TreeOutputParametrs(string.Empty, string.Empty, '\0');
}