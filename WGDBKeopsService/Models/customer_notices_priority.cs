using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace WGDBKeopsService.Models;

[Keyless]
[Table("customer_notices_priority")]
public partial class customer_notices_priority
{
    public long cnp_priority_id { get; set; }

    [StringLength(100)]
    public string cnp_priority_name { get; set; } = null!;

    public int cnp_flags { get; set; }

    public bool cnp_enabled { get; set; }

    public int? cnp_priority_order { get; set; }
}
