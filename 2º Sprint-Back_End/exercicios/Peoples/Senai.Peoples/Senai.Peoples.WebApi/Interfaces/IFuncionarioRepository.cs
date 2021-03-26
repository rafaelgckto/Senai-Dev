using Senai.Peoples.WebApi.Domains;
using System.Collections.Generic;

namespace Senai.Peoples.WebApi.Interfaces {
    /// <summary>
    /// Interface responsável pelo repositório 'FuncionarioRepository'.
    /// </summary>
    interface IFuncionarioRepository {
        List<Funcionario> Get();
        Funcionario GetById(int id);
        void Insert(Funcionario newEmployee);
        void Update(Funcionario employee);
        void UpdateIdUrl(int id, Funcionario employee);
        void Delete(int id);
    }
}
