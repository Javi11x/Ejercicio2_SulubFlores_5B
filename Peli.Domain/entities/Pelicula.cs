using System;
using System.Collections.Generic;

#nullable disable

namespace Peli.Domain.entities
{
    public partial class Pelicula
    {
        public int IdPeli { get; set; }
        public string TituloPeli { get; set; }
        public string DirectorPeli { get; set; }
        public string GeneroPeli { get; set; }
        public int? PuntuacionPeli { get; set; }
        public int? RatingPeli { get; set; }
        public string AñopPeli { get; set; }
    }
}
