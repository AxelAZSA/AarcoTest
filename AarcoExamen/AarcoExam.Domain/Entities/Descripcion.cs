using System;
using System.Collections.Generic;

namespace AarcoExamen.Domain.Entities
{
    public partial class Descripcion
    {
        public Guid DescripcionId { get; set; }
        public string Detalle { get; set; } = null!;
        public int ModeloId { get; set; }

        public virtual Modelo Modelo { get; set; }
    }
}
