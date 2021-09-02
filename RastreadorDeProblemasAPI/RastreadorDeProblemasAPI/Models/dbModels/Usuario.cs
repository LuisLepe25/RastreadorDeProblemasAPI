using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace RastreadorDeProblemasAPI.Models.dbModels
{
    [Table("Usuario")]
    public partial class Usuario
    {
        public Usuario()
        {
            Problemas = new HashSet<Problema>();
        }

        [Key]
        public int IdUsuario { get; set; }
        [Required]
        [StringLength(50)]
        public string Nombre { get; set; }

        [JsonIgnore]
        [InverseProperty(nameof(Problema.IdUsuarioAsignadoNavigation))]
        public virtual ICollection<Problema> Problemas { get; set; }
    }
}
