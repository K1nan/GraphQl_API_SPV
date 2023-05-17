using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace GPL.DBModels;

public partial class PersonInfo
{
    public int Id { get; set; }
    public string? Pn { get; set; }
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    public DateTime Fom { get; set; }
    public DateTime Tom { get; set; }
    public string? Salary { get; set; }

    private int? _totalDays;
    
    public int? TotalDays
    {
        get
        {
            if (!_totalDays.HasValue)
                _totalDays = (Tom.Date - Fom.Date).Days;
            return _totalDays;
        }
        set => _totalDays = value;
    }
    public virtual Person? PersonId { get; set; }

}
