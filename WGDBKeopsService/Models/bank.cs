using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace WGDBKeopsService.Models;

[Index("bk_area_id", Name = "IX_banks_bk_area_id")]
[Index("bk_name", Name = "IX_bk_name", IsUnique = true)]
public partial class bank
{
    [Key]
    public int bk_bank_id { get; set; }

    public int bk_area_id { get; set; }

    [StringLength(50)]
    public string bk_name { get; set; } = null!;

    public byte[]? bk_timestamp { get; set; }

    public bool bk_multiposition { get; set; }

    [StringLength(4)]
    public string bk_external_id { get; set; } = null!;

    [StringLength(1)]
    [Unicode(false)]
    public string? bk_shape_code { get; set; }

    public int? bk_shape_w { get; set; }

    public int? bk_shape_h { get; set; }

    public int? bk_play_safe_distance { get; set; }
}
