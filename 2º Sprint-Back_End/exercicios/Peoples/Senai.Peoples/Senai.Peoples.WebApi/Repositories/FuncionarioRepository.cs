using Senai.Peoples.WebApi.Domains;
using Senai.Peoples.WebApi.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace Senai.Peoples.WebApi.Repositories {
    public class FuncionarioRepository : IFuncionarioRepository {
        //MSSQLSERVER é a instância padrão, portanto, apenas forneça o nome do servidor sozinho na string de conexão.
        const string stringConexao = "Server=DESKTOP-KVRRD63;Database=Peoples;User Id=sa;Password=7895123;";

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
                            sobrenome = sdr[2].ToString()
                        };

                        listEmployees.Add(employee);
                    }
                }
            }

            return listEmployees;
        }

        public Funcionario GetById(int id) {
            using(SqlConnection con = new SqlConnection(stringConexao)) {
                string querySelectById = "SELECT idFuncionario, nome, sobrenome FROM Funcionario WHERE idFuncionario = @Id";

                con.Open();

                SqlDataReader sdr;

                using(SqlCommand cmd = new SqlCommand(querySelectById, con)) {
                    cmd.Parameters.AddWithValue("@Id", id);

                    sdr = cmd.ExecuteReader();

                    if(sdr.Read()) {
                        Funcionario soughtEmployee = new Funcionario() {
                            idFuncionario = Convert.ToInt32(sdr["idFuncionario"]),
                            nome = sdr["nome"].ToString(),
                            sobrenome = sdr["sobrenome"].ToString()
                        };

                        return soughtEmployee;
                    }
                    
                    return null;
                }
            }
        }

        public void Insert(Funcionario newEmployee) {
            using(SqlConnection con = new SqlConnection(stringConexao)) {
                string queryInsert = "INSERT INTO Funcionario(nome, sobrenome) VALUES(@Nome, @Sobrenome)";

                using(SqlCommand cmd = new SqlCommand(queryInsert, con)) {
                    cmd.Parameters.AddWithValue("@Nome", newEmployee.nome);
                    cmd.Parameters.AddWithValue("@Sobrenome", newEmployee.sobrenome);

                    con.Open();

                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void Update(Funcionario employee) {
            using(SqlConnection con = new SqlConnection(stringConexao)) {
                string queryUpdateBody = "UPDATE Funcionario SET nome = @Nome, sobrenome = @Sobrenome WHERE idFuncionario = @Id";

                using(SqlCommand cmd = new SqlCommand(queryUpdateBody, con)) {
                    cmd.Parameters.AddWithValue("@Id", employee.idFuncionario);
                    cmd.Parameters.AddWithValue("@Nome", employee.nome);
                    cmd.Parameters.AddWithValue("@Sobrenome", employee.sobrenome);

                    con.Open();

                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void UpdateIdUrl(int id, Funcionario employee) {
            using(SqlConnection con = new SqlConnection(stringConexao)) {
                string queryUpdateIdUrl = "UPDATE Funcionario SET nome = @Nome, sobrenome = @Sobrenome WHERE idFuncionario = @Id";

                using(SqlCommand cmd = new SqlCommand(queryUpdateIdUrl, con)) {
                    cmd.Parameters.AddWithValue("@Id", id);
                    cmd.Parameters.AddWithValue("@Nome", employee.nome);
                    cmd.Parameters.AddWithValue("@Sobrenome", employee.sobrenome);

                    con.Open();

                    cmd.ExecuteNonQuery();
                }
            }
        }

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
