using System.ComponentModel.DataAnnotations;

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
