﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DAL.Model
{
    public class Token
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [StringLength(100)]
        public string Tkey { get; set; }
        [Required]
        public DateTime CreatedAt { get; set; }
        public DateTime? DeletedAt { get; set; }
        [Required]
        [ForeignKey("User")]
        public string UserId { get; set; }
        public virtual User User { get; set; }

    }
}
