using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace PruebaMVC.Models

{
    [ModelMetadataType(typeof(GruposArtistaMetadata))]
    public partial class GruposArtista
    {
        public class GruposArtistaMetadata
        {
            public int Id { get; set; }
            [Display(Name = "Nombre Artista")]
            public int? ArtistasId { get; set; }
            [Display(Name = "Nombre Grupo")]
            public int? GruposId { get; set; }
            [Display(Name = "Nombre Artista")]
            public virtual Artista? Artistas { get; set; }
            [Display(Name = "Nombre Grupo")]
            public virtual Grupo? Grupos { get; set; }
        }
    }
}

