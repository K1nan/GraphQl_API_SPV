using System;
using System.Collections.Generic;

namespace GPL.DBModels;

public partial class Person
{
    public int Id { get; set; }

    public string? Pn { get; set; }

    public virtual ICollection<PersonInfo> PersonInfos { get; } = new List<PersonInfo>();
}
