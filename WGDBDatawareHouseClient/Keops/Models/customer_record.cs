using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace WGDBDatawareHouseClient.Keops.Models;

[Keyless]
public partial class customer_record
{
    public long cur_record_id { get; set; }

    public long cur_customer_id { get; set; }

    public bool cur_deleted { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime cur_created { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? cur_expiration { get; set; }
}
