using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace RastreadorDeProblemasAPI.Models.dbModels
{
    [Table("ProblemaEstatus")]
    public partial class ProblemaEstatus
    {
        public ProblemaEstatus()
        {
            Problemas = new HashSet<Problema>();
        }

        [Key]
        public int IdProblemaEstatus { get; set; }
        [Required]
        [StringLength(50)]
        public string Descripcion { get; set; }

        [JsonIgnore]
        [InverseProperty(nameof(Problema.IdProblemaEstatusNavigation))]
        public virtual ICollection<Problema> Problemas { get; set; }
    }
}
