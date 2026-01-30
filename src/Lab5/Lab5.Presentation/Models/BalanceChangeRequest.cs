using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace Lab5.Presentation.Models;

public sealed class BalanceChangeRequest
{
    [NotNull]
    [Required]
    public Guid? Id { get; set; }

    [NotNull]
    [Required]
    [Range(0, int.MaxValue)]
    public decimal? Amount { get; set; }
}