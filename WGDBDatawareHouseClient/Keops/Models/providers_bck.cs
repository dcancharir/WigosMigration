using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace WGDBDatawareHouseClient.Keops.Models;

[Keyless]
[Table("providers_bck")]
public partial class providers_bck
{
    public int pv_id { get; set; }

    [StringLength(100)]
    public string pv_name { get; set; } = null!;

    public bool pv_hide { get; set; }

    [Column(TypeName = "money")]
    public decimal pv_points_multiplier { get; set; }

    public bool pv_3gs { get; set; }

    [StringLength(100)]
    public string? pv_3gs_vendor_id { get; set; }

    [StringLength(100)]
    public string? pv_3gs_vendor_ip { get; set; }

    public bool pv_site_jackpot { get; set; }

    public bool pv_only_redeemable { get; set; }

    public int? pv_id_new { get; set; }
}
