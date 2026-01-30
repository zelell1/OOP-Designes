using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace Lab5.Presentation.Models;

public sealed class GetBalanceRequest
{
    [NotNull]
    [Required]
    public Guid? Id { get; set; }
}