using System;
using System.ComponentModel.DataAnnotations;

namespace Senai.Peoples.WebApi.Domains {
    /// <summary>
    /// Classe que representa a entidade Funcionario.
    /// </summary>
    public class Funcionario {
        public int idFuncionario { get; set; }

        [Required(ErrorMessage ="O nome do funcionário é obrigatório")]
        public string nome { get; set; }

        public string sobrenome { get; set; }

        [DataType(DataType.Date)]
        public DateTime dtNasc { get; set; }
    }
}
