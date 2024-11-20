using System;
using System.Collections.Generic;

namespace AarcoExamen.Domain.Entities
{
    public partial class Modelo
    {
        public int ModeloId { get; set; }
        public int Anio { get; set; }
        public int SubmarcaId { get; set; }

        public virtual Descripcion Descripcion { get; set; } = null!;
    }
}
