using System;
using System.Collections.Generic;

#nullable disable

namespace Senai.SP_MG.WebApi.Domain {
    public partial class TipoUsuario {
        public TipoUsuario() {
            Usuarios = new HashSet<Usuario>();
        }

        public int IdTipoUsuario { get; set; }
        public string Perfil { get; set; }

        public virtual ICollection<Usuario> Usuarios { get; set; }
    }
}
