using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace WGDBDatawareHouseClient.Winmeier.Models;

[Index("wscq_queue_id", Name = "IX_wcp_services_to_cj_queues_wscq_queue_id")]
public partial class wcp_services_to_cj_queue
{
    [Key]
    public long wscq_service_id { get; set; }

    public long wscq_queue_id { get; set; }
}
