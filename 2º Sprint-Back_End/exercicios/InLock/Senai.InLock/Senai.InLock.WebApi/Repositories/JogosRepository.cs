using Senai.InLock.WebApi.Domains;
using Senai.InLock.WebApi.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace Senai.InLock.WebApi.Repositories {
    public class JogosRepository : IJogosRepository {
        const string connectionString = "Server=CELSO-PC;Database=InLock_Games;User Id=sa;Password=7895123;";

        public void Delete(int id) {
            throw new System.NotImplementedException();
        }

        public List<JogosDomain> ListAll() {
            throw new System.NotImplementedException();
        }

        public List<JogosDomain> ListGamesStudios() {
            // MVP
            List<JogosDomain> listUsers = new List<JogosDomain>();

            using(SqlConnection con = new SqlConnection(connectionString)) {
                string querySelectAll = "SELECT * FROM Jogos AS J INNER JOIN Estudios AS E ON J.idEstudio = E.idEstudio;";

                con.Open();

                SqlDataReader sdr;

                using(SqlCommand cmd = new SqlCommand(querySelectAll, con)) {
                    sdr = cmd.ExecuteReader();

                    while(sdr.Read()) {
                        JogosDomain game = new JogosDomain() {
                            idJogo = Convert.ToInt32(sdr[0]),
                            nome = sdr[1].ToString(),
                            descricao = sdr[2].ToString(),
                            dtLancamento = Convert.ToDateTime(sdr[3]),
                            valor = decimal.Parse(sdr[4].ToString()),
                            idEstudio = Convert.ToInt32(sdr[5]),
                            estudio = new EstudiosDomain() {
                                idEstudio = Convert.ToInt32(sdr[6]),
                                nome = sdr[7].ToString()
                            }
                        };

                        listUsers.Add(game);
                    }

                    return listUsers;
                }
            }
        }

        public List<JogosDomain> ListStudiosGames() {
            throw new System.NotImplementedException();
        }

        public void Register(JogosDomain newTEntity) {
            // MVP
            using(SqlConnection con = new SqlConnection(connectionString)) {
                string queryInsert = "INSERT INTO Jogos(nome, descricao, dtLancamento, valor, idEstudio) VALUES(@nome, @descricao, @dtLancamento, @valor, @idEstudio)";

                using(SqlCommand cmd = new SqlCommand(queryInsert, con)) {
                    cmd.Parameters.AddWithValue("@nome", newTEntity.nome);
                    cmd.Parameters.AddWithValue("@descricao", newTEntity.descricao);
                    cmd.Parameters.AddWithValue("@dtLancamento", newTEntity.dtLancamento);
                    cmd.Parameters.AddWithValue("@valor", newTEntity.valor);
                    cmd.Parameters.AddWithValue("@idEstudio", newTEntity.idEstudio);

                    con.Open();

                    cmd.ExecuteNonQuery();
                }
            }
        }

        public JogosDomain SearchById(int id) {
            throw new System.NotImplementedException();
        }

        public void Update(JogosDomain newTEntity) {
            throw new System.NotImplementedException();
        }
    }
}
