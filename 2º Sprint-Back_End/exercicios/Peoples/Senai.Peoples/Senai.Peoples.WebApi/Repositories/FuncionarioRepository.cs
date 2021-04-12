using Senai.Peoples.WebApi.Domains;
using Senai.Peoples.WebApi.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace Senai.Peoples.WebApi.Repositories {
    /// <summary>
    /// Classe responsável pelo repositório dos funcionários.
    /// </summary>
    public class FuncionarioRepository : IFuncionarioRepository {
        //MSSQLSERVER é a instância padrão, portanto, apenas forneça o nome do servidor sozinho na string de conexão.
        const string stringConexao = "Server=DESKTOP-KVRRD63;Database=Peoples;User Id=sa;Password=7895123;";

        /// <summary>
        /// Lista todos os funcionários.
        /// </summary>
        /// <returns>Uma lista de funcionários.</returns>
        public List<Funcionario> Get() {
            List<Funcionario> listEmployees = new List<Funcionario>();

            using(SqlConnection con = new SqlConnection(stringConexao)) {
                string querySelectAll = "SELECT * FROM Funcionario";

                con.Open();

                SqlDataReader sdr;

                using(SqlCommand cmd = new SqlCommand(querySelectAll, con)) {
                    sdr = cmd.ExecuteReader();

                    while(sdr.Read()) {
                        Funcionario employee = new Funcionario() {
                            idFuncionario = Convert.ToInt32(sdr[0]),
                            nome = sdr[1].ToString(),
                            sobrenome = sdr[2].ToString(),
                            dtNasc = Convert.ToDateTime(sdr[3])
                        };

                        listEmployees.Add(employee);
                    }

                    return listEmployees;
                }
            }
        }

        /// <summary>
        /// Busca um funcionário através do seu id.
        /// </summary>
        /// <param name="id">O 'id' do funcionário que será buscado.</param>
        /// <returns>O funcionário buscado ou null caso não seja encontrado.</returns>
        public Funcionario GetById(int id) {
            using(SqlConnection con = new SqlConnection(stringConexao)) {
                string querySelectById = "SELECT idFuncionario, nome, sobrenome, dtNasc FROM Funcionario WHERE idFuncionario = @Id";

                con.Open();

                SqlDataReader sdr;

                using(SqlCommand cmd = new SqlCommand(querySelectById, con)) {
                    cmd.Parameters.AddWithValue("@Id", id);

                    sdr = cmd.ExecuteReader();

                    if(sdr.Read()) {
                        Funcionario soughtEmployee = new Funcionario() {
                            idFuncionario = Convert.ToInt32(sdr["idFuncionario"]),
                            nome = sdr["nome"].ToString(),
                            sobrenome = sdr["sobrenome"].ToString(),
                            dtNasc = Convert.ToDateTime(sdr["dtNasc"])
                        };

                        return soughtEmployee;
                    }

                    return null;
                }
            }
        }

        /// <summary>
        /// Busca um funcionário através do seu nome.
        /// </summary>
        /// <param name="newEmployee">O 'nameEployee' do funcionário que será buscado.</param>
        /// <returns>O funcionário buscado ou null caso não seja encontrado.</returns>
        public Funcionario GetByName(string nameEmployee) {
            using(SqlConnection con = new SqlConnection(stringConexao)) {
                string querySelectById = "SELECT idFuncionario, nome, sobrenome, dtNasc FROM Funcionario WHERE nome = @NOME";

                con.Open();

                SqlDataReader sdr;

                using(SqlCommand cmd = new SqlCommand(querySelectById, con)) {
                    cmd.Parameters.AddWithValue("@NOME", nameEmployee);

                    sdr = cmd.ExecuteReader();

                    /*DateTime dt = DateTime.ParseExact(sdr["dtNasc"].ToString(), "MM/dd/yyyy hh:mm:ss tt", CultureInfo.InvariantCulture);
                    string s = dt.ToString("dd/MM/yyyy", CultureInfo.InvariantCulture);*/

                    if(sdr.Read()) {
                        Funcionario soughtEmployee = new Funcionario() {
                            idFuncionario = Convert.ToInt32(sdr["idFuncionario"]),
                            nome = sdr["nome"].ToString(),
                            sobrenome = sdr["sobrenome"].ToString(),
                            dtNasc = Convert.ToDateTime(sdr["dtNasc"])
                        };

                        return soughtEmployee;
                    }

                    return null;
                }
            }
        }

        /// <summary>
        /// Lista todos os funcionários, exibindo o nome completo.
        /// </summary>
        /// <returns>A lista de funcionários com nome completo.</returns>
        public List<Funcionario> GetFullName() {
            List<Funcionario> listEmployees = new List<Funcionario>();

            using(SqlConnection con = new SqlConnection(stringConexao)) {
                string queryFullName = "SELECT CONCAT(nome, ' ', sobrenome) AS [Nome Completo] FROM Funcionario";

                con.Open();

                SqlDataReader sdr;

                using(SqlCommand cmd = new SqlCommand(queryFullName, con)) {
                    sdr = cmd.ExecuteReader();

                    while(sdr.Read()) {
                        /*Funcionario soughtEmployee = new Funcionario() {
                            nome = sdr["nome"].ToString(),
                            sobrenome = sdr["sobrenome"].ToString()
                        };

                        listEmployees.Add(soughtEmployee);*/
                    }

                    return listEmployees;
                }
            }
        }

        /// <summary>
        /// Lista todos os funcionários em ordem crescente ou decrescente(ASC - ascending ou DESC - descending).
        /// </summary>
        /// <param name="order">O tipo de ordem que será buscado.</param>
        /// <returns>A lista de funcionários na ordem escolhida.</returns>
        public List<Funcionario> GetOrdination(string order) {
            List<Funcionario> listEmployees = new List<Funcionario>();

            using(SqlConnection con = new SqlConnection(stringConexao)) {
                string queryOrderASC = "SELECT nome, sobrenome FROM Funcionario ORDER BY nome ASC";
                string queryOrderDESC = "SELECT nome, sobrenome FROM Funcionario ORDER BY nome DESC";

                string queryOrder = (order == "ASC") ? queryOrderASC : queryOrderDESC;

                con.Open();

                SqlDataReader sdr;

                using(SqlCommand cmd = new SqlCommand(queryOrder, con)) {
                    sdr = cmd.ExecuteReader();

                    while(sdr.Read()) {
                        Funcionario soughtEmployee = new Funcionario() {
                            nome = sdr["nome"].ToString(),
                            sobrenome = sdr["sobrenome"].ToString()
                        };

                        listEmployees.Add(soughtEmployee);
                    }

                    return listEmployees;
                }
            }
        }

        /// <summary>
        /// Efetua um cadastro de um funcionário.
        /// </summary>
        /// <param name="newEmployee">Objeto 'newEmployee' com as informações que serão cadastradas.</param>
        public void Insert(Funcionario newEmployee) {
            using(SqlConnection con = new SqlConnection(stringConexao)) {
                string queryInsert = "INSERT INTO Funcionario(nome, sobrenome, dtNasc) VALUES(@Nome, @Sobrenome, @DtNasc)";

                using(SqlCommand cmd = new SqlCommand(queryInsert, con)) {
                    cmd.Parameters.AddWithValue("@Nome", newEmployee.nome);
                    cmd.Parameters.AddWithValue("@Sobrenome", newEmployee.sobrenome);
                    cmd.Parameters.AddWithValue("@DtNasc", newEmployee.dtNasc);

                    con.Open();

                    cmd.ExecuteNonQuery();
                }
            }
        }

        /// <summary>
        /// Atualiza um funcionário passando as dados pelo corpo.
        /// </summary>
        /// <param name="employee">Objeto 'employee' com as novas informações.</param>
        public void Update(Funcionario employee) {
            using(SqlConnection con = new SqlConnection(stringConexao)) {
                string queryUpdateBody = "UPDATE Funcionario SET nome = @Nome, sobrenome = @Sobrenome, dtNasc = @DtNasc WHERE idFuncionario = @Id";

                using(SqlCommand cmd = new SqlCommand(queryUpdateBody, con)) {
                    cmd.Parameters.AddWithValue("@Id", employee.idFuncionario);
                    cmd.Parameters.AddWithValue("@Nome", employee.nome);
                    cmd.Parameters.AddWithValue("@Sobrenome", employee.sobrenome);
                    cmd.Parameters.AddWithValue("@DtNasc", employee.dtNasc);

                    con.Open();

                    cmd.ExecuteNonQuery();
                }
            }
        }

        /// <summary>
        /// Atualiza um funcionário passando o 'id' pelo recurso (URL)
        /// </summary>
        /// <param name="id">Objeto 'id' do funcionário que será atualizado.</param>
        /// <param name="employee">Objeto 'employee' com as novas informações.</param>
        public void UpdateIdUrl(int id, Funcionario employee) {
            using(SqlConnection con = new SqlConnection(stringConexao)) {
                string queryUpdateIdUrl = "UPDATE Funcionario SET nome = @Nome, sobrenome = @Sobrenome, dtNasc = @DtNasc WHERE idFuncionario = @Id";

                using(SqlCommand cmd = new SqlCommand(queryUpdateIdUrl, con)) {
                    cmd.Parameters.AddWithValue("@Id", id);
                    cmd.Parameters.AddWithValue("@Nome", employee.nome);
                    cmd.Parameters.AddWithValue("@Sobrenome", employee.sobrenome);
                    cmd.Parameters.AddWithValue("@DtNasc", employee.dtNasc);

                    con.Open();

                    cmd.ExecuteNonQuery();
                }
            }
        }

        /// <summary>
        /// Deleta um funcionário atráves do seu 'id'.
        /// </summary>
        /// <param name="id">Objeto 'id' do funcionário que será excluído.</param>
        public void Delete(int id) {
            using(SqlConnection con = new SqlConnection(stringConexao)) {
                string queryDelete = "DELETE FROM Funcionario WHERE idFuncionario = @Id";

                using(SqlCommand cmd = new SqlCommand(queryDelete, con)) {
                    cmd.Parameters.AddWithValue("@Id", id);

                    con.Open();

                    cmd.ExecuteNonQuery();
                }
            }
        }
    }
}
