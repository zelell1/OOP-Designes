using SourceKit.Generators.Builder.Annotations;

namespace Lab5.Application.Abstractions.Queries;

[GenerateBuilder]
public sealed partial record SessionQuery(Guid[] Id);