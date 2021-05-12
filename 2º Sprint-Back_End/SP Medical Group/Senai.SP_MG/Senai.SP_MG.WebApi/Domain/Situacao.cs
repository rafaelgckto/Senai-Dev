using System;
using System.Collections.Generic;

#nullable disable

namespace Senai.SP_MG.WebApi.Domain {
    public partial class Situacao {
        public Situacao() {
            Consulta = new HashSet<Consulta>();
        }

        public int IdSituacao { get; set; }
        public string Tipo { get; set; }

        public virtual ICollection<Consulta> Consulta { get; set; }
    }
}
