using System.ComponentModel.DataAnnotations;

namespace Shared.Domain;

public class Colour : BaseDomainModel
{
    [Required] public string Name { get; set; }
}