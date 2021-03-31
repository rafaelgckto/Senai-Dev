using System;

namespace Senai.Peoples.WebApi.Domains {
    /// <summary>
    /// Classe que representa a entidade Funcionario.
    /// </summary>
    public class Funcionario {
        public int idFuncionario { get; set; }
        public string nome { get; set; }
        public string sobrenome { get; set; }
        public DateTime dtNasc { get; set; }
    }
}
