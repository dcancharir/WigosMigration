using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace WGDBWinmeierService.Models;

public partial class customer
{
    [Key]
    public long cus_customer_id { get; set; }
}
