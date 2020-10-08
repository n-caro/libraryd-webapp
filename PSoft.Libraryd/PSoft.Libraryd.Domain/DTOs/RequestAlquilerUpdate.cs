using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace PSoft.Libraryd.Domain.DTOs
{
    public class RequestAlquilerUpdate
    {
        [Required]
        public int cliente { get; set; }
        [Required]
        public string ISBN { get; set; }
    }
}
