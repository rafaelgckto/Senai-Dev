namespace Senai.InLock.WebApi.Domains {
    public class UsuarioDomain {
        public int idUsuario { get; set; }
        public string email { get; set; }
        public string senha { get; set; }
        public int idTipoUsuario { get; set; }
    }
}
