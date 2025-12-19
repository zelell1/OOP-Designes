using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace Lab5.Presentation.Models;

public sealed class OperationHistoryRequest
{
    [NotNull]
    [Required]
    public Guid? Id { get; set; }
}