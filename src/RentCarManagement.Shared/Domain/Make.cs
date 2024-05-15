using System.ComponentModel.DataAnnotations;

namespace Shared.Domain;

public class Make : BaseDomainModel
{
    [Required]
    public string Name { get; set; }
}