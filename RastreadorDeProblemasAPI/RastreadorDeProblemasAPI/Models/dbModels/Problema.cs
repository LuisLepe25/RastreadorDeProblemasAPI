using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace RastreadorDeProblemasAPI.Models.dbModels
{
    [Table("Problema")]
    public partial class Problema
    {
        [Key]
        [Column("idProblema")]
        public int IdProblema { get; set; }
        [Required]
        [StringLength(500)]
        public string Descripcion { get; set; }
        public int IdProblemaEstatus { get; set; }
        public int IdUsuarioAsignado { get; set; }
        public long IdentificadorAlumno { get; set; }

        [JsonIgnore]
        [ForeignKey(nameof(IdProblemaEstatus))]
        [InverseProperty(nameof(ProblemaEstatus.Problemas))]
        public virtual ProblemaEstatus IdProblemaEstatusNavigation { get; set; }
        [JsonIgnore]
        [ForeignKey(nameof(IdUsuarioAsignado))]
        [InverseProperty(nameof(Usuario.Problemas))]
        public virtual Usuario IdUsuarioAsignadoNavigation { get; set; }
    }
}
