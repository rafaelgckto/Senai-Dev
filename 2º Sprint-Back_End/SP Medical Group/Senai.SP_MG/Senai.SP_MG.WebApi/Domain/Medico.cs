using System;
using System.Collections.Generic;

#nullable disable

namespace Senai.SP_MG.WebApi.Domain {
    public partial class Medico {
        public Medico() {
            Consulta = new HashSet<Consulta>();
            Usuarios = new HashSet<Usuario>();
        }

        public int IdMedico { get; set; }
        public string Crm { get; set; }
        public int IdEspecialidade { get; set; }
        public int IdClinica { get; set; }

        public virtual Clinica IdClinicaNavigation { get; set; }
        public virtual Especialidade IdEspecialidadeNavigation { get; set; }
        public virtual ICollection<Consulta> Consulta { get; set; }
        public virtual ICollection<Usuario> Usuarios { get; set; }
    }
}
