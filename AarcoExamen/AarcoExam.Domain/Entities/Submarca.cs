using System;
using System.Collections.Generic;

namespace AarcoExamen.Domain.Entities
{
    public partial class Submarca
    {
        public Submarca()
        {
            Modelos = new HashSet<Modelo>();
        }

        public int SubmarcaId { get; set; }
        public string Nombre { get; set; } = null!;
        public int MarcaId { get; set; }

        public virtual Marca Marca { get; set; } = null!;
        public virtual ICollection<Modelo> Modelos { get; set; }
    }
}
