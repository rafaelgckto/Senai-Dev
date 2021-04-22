using Senai.InLock.WebApi.Domains;
using Senai.InLock.WebApi.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace Senai.InLock.WebApi.Repositories {
    public class UsuarioRepository : IUsuarioRepository {
        const string connectionString = "Server=CELSO-PC;Database=InLock_Games;User Id=sa;Password=7895123;";

        public void Delete(int id) {
            using(SqlConnection con = new SqlConnection(connectionString)) {
                string queryDelete = "DELETE FROM Usuario WHERE idUsuario = @id";

                using(SqlCommand cmd = new SqlCommand(queryDelete, con)) {
                    cmd.Parameters.AddWithValue("@id", id);

                    con.Open();

                    cmd.ExecuteNonQuery();
                }
            }
        }

        public List<UsuarioDomain> ListAll() {
            List<UsuarioDomain> listUsers = new List<UsuarioDomain>();

            using(SqlConnection con = new SqlConnection(connectionString)) {
                string querySelectAll = "SELECT * FROM Usuario";

                con.Open();

                SqlDataReader sdr;

                using(SqlCommand cmd = new SqlCommand(querySelectAll, con)) {
                    sdr = cmd.ExecuteReader();

                    while(sdr.Read()) {
                        UsuarioDomain user = new UsuarioDomain() {
                            idUsuario = Convert.ToInt32(sdr[0]),
                            email = sdr[1].ToString(),
                            senha = sdr[2].ToString(),
                            idTipoUsuario = Convert.ToInt32(sdr[3])
                        };

                        listUsers.Add(user);
                    }

                    return listUsers;
                }
            }
        }

        public UsuarioDomain Login(string email, string password) {
            // MVP
            using(SqlConnection con = new SqlConnection(connectionString)) {
                string queryLogin = "SELECT idUsuario, email, senha, idTipoUsuario FROM Usuario WHERE email = @email AND senha = @senha;";

                using(SqlCommand cmd = new SqlCommand(queryLogin, con)) {
                    cmd.Parameters.AddWithValue("@email", email);
                    cmd.Parameters.AddWithValue("@senha", password);

                    con.Open();

                    SqlDataReader sdr = cmd.ExecuteReader();

                    if(sdr.Read()) {
                        UsuarioDomain searchedUser = new UsuarioDomain() {
                            idUsuario = Convert.ToInt32(sdr["idUsuario"]),
                            email = sdr["email"].ToString(),
                            senha = sdr["senha"].ToString(),
                            idTipoUsuario = Convert.ToInt32(sdr["idTipoUsuario"])
                        };

                        return searchedUser;
                    }

                    return null;
                }
            }
        }

        public void Register(UsuarioDomain newTEntity) {
            using(SqlConnection con = new SqlConnection(connectionString)) {
                string queryInsert = "INSERT INTO Usuario(email, senha, idTipoUsuario) VALUES(@email, @senha, @idTipoUsuario)";

                using(SqlCommand cmd = new SqlCommand(queryInsert, con)) {
                    cmd.Parameters.AddWithValue("@email", newTEntity.email);
                    cmd.Parameters.AddWithValue("@senha", newTEntity.senha);
                    cmd.Parameters.AddWithValue("@idTipoUsuario", newTEntity.idTipoUsuario);

                    con.Open();

                    cmd.ExecuteNonQuery();
                }
            }
        }

        public UsuarioDomain SearchById(int id) {
            using(SqlConnection con = new SqlConnection(connectionString)) {
                string querySelectById = "SELECT * FROM Usuario WHERE idUsuario = @id";

                con.Open();

                SqlDataReader sdr;

                using(SqlCommand cmd = new SqlCommand(querySelectById, con)) {
                    cmd.Parameters.AddWithValue("@id", id);

                    sdr = cmd.ExecuteReader();

                    if(sdr.Read()) {
                        UsuarioDomain soughtUser = new UsuarioDomain() {
                            idUsuario = Convert.ToInt32(sdr["idUsuario"]),
                            email = sdr["email"].ToString(),
                            senha = sdr["senha"].ToString(),
                            idTipoUsuario = Convert.ToInt32(sdr["idTipoUsuario"])
                        };

                        return soughtUser;
                    }

                    return null;
                }
            }
        }

        public void Update(UsuarioDomain newTEntity) {
            using(SqlConnection con = new SqlConnection(connectionString)) {
                string queryUpdateBody = "UPDATE Usuario SET email = @email, senha = @senha, idTipoUsuario = @idTipoUsuario WHERE idUsuario = @id";

                using(SqlCommand cmd = new SqlCommand(queryUpdateBody, con)) {
                    cmd.Parameters.AddWithValue("@id", newTEntity.idUsuario);
                    cmd.Parameters.AddWithValue("@email", newTEntity.email);
                    cmd.Parameters.AddWithValue("@senha", newTEntity.senha);
                    cmd.Parameters.AddWithValue("@idTipoUsuario", newTEntity.idTipoUsuario);

                    con.Open();

                    cmd.ExecuteNonQuery();
                }
            }
        }
    }
}
