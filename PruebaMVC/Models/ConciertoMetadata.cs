using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PruebaMVC.Models
{
    [ModelMetadataType(typeof(ConciertoMetadata))]
    public partial class Concierto { }
    public class ConciertoMetadata
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public DateTime? Fecha { get; set; }
        [Required]
        public string? Genero { get; set; }
        //[Required(ErrorMessage = "Introduzca el Lugar del Concierto")]
        [Required]
        public string? Lugar { get; set; }
        //[Required(ErrorMessage = "Introduzca el Titulo del Concierto")]
        [Required]
        public string? Titulo { get; set; }
        //[Required(ErrorMessage = "Introduzca el Precio del Concierto")]
        [Required]
        public decimal? Precio { get; set; }
        public virtual ICollection<CancionesConcierto> CancionesConciertos { get; set; } = new List<CancionesConcierto>();
        public virtual ICollection<ConciertosGrupo> ConciertosGrupos { get; set; } = new List<ConciertosGrupo>();
    }
}
