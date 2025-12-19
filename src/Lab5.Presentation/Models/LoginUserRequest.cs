using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace Lab5.Presentation.Models;

public sealed class LoginUserRequest
{
    [NotNull]
    [Required]
    [Range(1, int.MaxValue)]
    public int? BankNumber { get; set; }

    [NotNull]
    [Required]
    [MinLength(6)]
    public string? Password { get; set; }
}