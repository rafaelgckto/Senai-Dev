using System;
using System.Collections.Generic;

#nullable disable

namespace Senai.SP_MG.WebApi.Domain {
    public partial class Paciente {
        public Paciente() {
            Consulta = new HashSet<Consulta>();
            Usuarios = new HashSet<Usuario>();
        }

        public int IdPaciente { get; set; }
        public string Telefone { get; set; }
        public DateTime DtNasc { get; set; }
        public string Rg { get; set; }
        public string Cpf { get; set; }
        public int IdEndereco { get; set; }

        public virtual Endereco IdEnderecoNavigation { get; set; }
        public virtual ICollection<Consulta> Consulta { get; set; }
        public virtual ICollection<Usuario> Usuarios { get; set; }
    }
}
