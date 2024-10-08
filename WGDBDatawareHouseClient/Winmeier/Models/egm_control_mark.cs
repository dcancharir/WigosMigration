using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace WGDBDatawareHouseClient.Winmeier.Models;

[Keyless]
[Table("egm_control_mark")]
public partial class egm_control_mark
{
    [Column(TypeName = "datetime")]
    public DateTime ecm_control_mark { get; set; }
}
