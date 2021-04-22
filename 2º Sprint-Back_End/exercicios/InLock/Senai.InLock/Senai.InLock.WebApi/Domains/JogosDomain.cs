using System;

namespace Senai.InLock.WebApi.Domains {
    public class JogosDomain {
        public int idJogo { get; set; }
        public string nome { get; set; }
        public string descricao { get; set; }
        public DateTime dtLancamento { get; set; }
        public decimal valor { get; set; }
        public int idEstudio { get; set; }
        public EstudiosDomain estudio { get; set; }
    }
}
