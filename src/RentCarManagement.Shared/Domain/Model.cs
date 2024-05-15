using System.ComponentModel.DataAnnotations;

namespace Shared.Domain;

public class Model : BaseDomainModel
{
    [Required]
    public string Name { get; set; }
}