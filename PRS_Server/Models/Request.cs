﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace PRS_Server.Models
{
    public class Request
    {
        public int Id { get; set; }

        [StringLength(80)]
        [Required]
        public string Description { get; set; }

        [StringLength(80)]
        [Required]
        public string Justification { get; set; }

        [StringLength(80)]
        public string RejectionReason { get; set; }

        [StringLength(30)]
        [Required]
        public string DeliveryMode { get; set; }

        [StringLength(30)]
        [Required]
        public string Status { get; set; }

        [Column(TypeName = "12,2")]
        [Required]
        public decimal Total { get; set; }


        public int UserId { get; set; }

        public Request()
        {

        }
    }
}
