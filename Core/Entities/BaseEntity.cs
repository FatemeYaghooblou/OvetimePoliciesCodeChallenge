using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Core.Entities;

public class BaseEntity
{
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    [Key]
    public int Id { get; set; }
    public DateTime Created { get; set; }
    public int CreatedBy { get; set; }
    public DateTime? Modified { get; set; }
    public int? ModifiedBy { get; set; }
    public bool IsDeleted
    {
        get; set;
    }

}
