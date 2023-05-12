using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace GPL.DBModels;

public partial class PersonInfo
{
    public int? Id { get; set; }
    public string? FirstName { get; set; }
    public string? LastName { get; set; }

    public DateTime? Fom { get; set; }
    public DateTime? Tom { get; set; }
    public string? Salary { get; set; }
    [NotMapped]
    public int? TotalDays
    {
        get
        {
            if (Tom.HasValue && Fom.HasValue)
            {
                return (Tom.Value - Fom.Value).Days;
            }
            else
            {
                return null;
            }
        }
        set { }
    }

    public virtual Person? PersonId { get; set; }

}
